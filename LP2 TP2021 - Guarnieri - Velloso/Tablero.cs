﻿///////////////////////////////////////////////////////////
//  Tablero.cs
//  Implementation of the Class Tablero
//  Generated by Enterprise Architect
//  Created on:      06-oct.-2021 08:09:08
//  Original author: vguar
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
//using System.Text;
//using System.IO;
using System.Diagnostics;
//using System.Drawing.Drawing2D;

/// <summary>
/// Enum para definir el Color de las Casillas.
/// </summary>
public enum eColor : int
{
    BLANCO = 0,
    NEGRO

} //end eColor

public enum TipoSolucion : int
{
    NO_SOLUCION = 0,
    LEVE,
    FATAL

} //end TipoSolucion

public class Tablero
{
    #region ATRIBUTOS

    /// <summary>
    /// Matriz de Casillas del <see cref="Tablero"/>.
    /// </summary>
    public Casilla[,] Matriz = new Casilla[Global.N_, Global.N_]; //Acceso publico, para que las fichas se puedan posicionar y atacar

    /// <summary>
    /// Lista de Fichas (se llena a medida que se posicionan las Ficha) del <see cref="Tablero"/>.
    /// </summary>
    private List<Ficha> ListaPosicionadas = new List<Ficha>(Global.N_);

    /// <summary>
    /// ID de <see cref="Tablero"/>
    /// </summary>
    private int ID;
    private TipoSolucion type;

    #endregion

    #region CONSTRUCTORES & DESTRUCTORES

    /// <summary>
    /// Constructor de la clase <see cref="Tablero"/>.: inicializa la Matriz de Casillas.
    /// </summary>
    public Tablero(int _ID)
    {
        //Creamos la matriz de Casillas (tiempo n^2, fors anidados)
        for (uint i = 0; i < Global.N_; ++i)
        {
            for (uint j = 0; j < Global.N_; ++j)
            {
                Matriz[i, j] = new Casilla(i, j);
            }
        }

        ID = _ID;
        Type = TipoSolucion.NO_SOLUCION;
        LeerArchivo(); //Inicializamos los colores del Tablero
    }

    /// <summary>
    /// Constructor por copia de la clase <see cref="Tablero"/>..
    /// </summary>
    /// <param name="newTablero"></param>
    public Tablero(Tablero newTablero, int _ID)
    {
        //Matriz = newTablero.Matriz; //TODO: preguntar si esto es válido
        for (int i = 0; i < Global.N_; ++i)
        {
            for (int j = 0; j < Global.N_; ++j)
            {
                Matriz[i, j] = newTablero.Matriz[i, j];
                Matriz[i, j].Colour = newTablero.Matriz[i, j].Colour;
                Matriz[i, j].Fichita = newTablero.Matriz[i, j].Fichita;
                Matriz[i, j].SetAtacada(newTablero.Matriz[i, j].GetAtacada());
                Matriz[i, j].SetColumna(newTablero.Matriz[i, j].GetColumna());
                Matriz[i, j].SetFila(newTablero.Matriz[i, j].GetFila());
                Matriz[i, j].SetOcupada(newTablero.Matriz[i, j].GetOcupada());
            }
        }

        Ficha[] Aux = newTablero.ListaPosicionadas.ToArray();

        //for (int i = 7; i >= 0; --i)
        //{
        //    ListaPosicionadas.Push(Aux[i]);
        //}

       // ListaPosicionadas = new Stack<Ficha>(newTablero.ListaPosicionadas); //TODO: si falla algo es ACA TAMBIEN

        ID = _ID;
    }

    /// <summary>
    /// Destructor de la clase <see cref="Tablero"/>..
    /// </summary>
    ~Tablero()
    {

    }

    #endregion

    #region LEER TXT

    /// <summary>
    /// Leemos el archivo con 1's y 0's para determinar el color de las Casillas del Tablero this.
    /// </summary>
    private void LeerArchivo()
    {
        string[] lines = System.IO.File.ReadAllLines("ColoresTablero.txt"); //Leo el archivo de colores
        int j = 0;

        foreach (string line in lines) //para cada linea
        {
            for (int i = 0; i < line.Length; i++)//recorro los caracteres de cada linea
                Matriz[j, i].Colour = line[i] == '0' ? eColor.BLANCO : eColor.NEGRO; //le asigno el color a cada casilla

            j++;
        }
    }

    #endregion

    #region METODOS DE TABLERO

    /// <summary>
    /// Retorna true si el Tablero this es una solución al problema de la cobertura total del Tablero de Ajedrez, con las Fichas atacando de forma fatal.
    /// </summary>
    /// <returns></returns>
    //public bool FiltrarFatales(Tablero Filtrado) 
    //{
    //    foreach (Ficha Fichita in ListaPosicionadas)
    //    {
    //        Fichita.Atacar(Filtrado, Buscar(Fichita));
    //    }

    //    return (Filtrado.VerificarSolucion()) ? true : false; //si es una solución fatal, devulve true y sino devuelve false
    //}

    /// <summary>
    /// Limpia el Tablero this: Las Casillas no están atacadas, ni ocupadas, y las Fichas son null.
    /// </summary>
    public void Limpiar()
    {
        for (uint i = 0; i < Global.N_; i++)
        {
            for (uint j = 0; j < Global.N_; j++)
            {
                Matriz[i, j].SetAtacada(false);
                Matriz[i, j].SetFicha(null);
                Matriz[i, j].SetOcupada(false);
            }
        }
        ListaPosicionadas.Clear();
        //Boton: clear
    }

    /// <summary>
    /// Ubica a la Ficha que le llega por parámetro en una Casilla de la SubLista que le llega por parámetro.
    /// Segun el parámetro booleano "Remove", quita de la SubLista la Casilla donde se ubico la Ficha. //TODO: ACA PUNTERO O COPIA!!
    /// Llama a la función Ataque de Ficha, con el Tablero Ataque.
    /// </summary>
    /// <param name="Fichita"></param>
    /// <param name="Ataque"></param>
    /// <param name="SubLista"></param>
    /// <param name="Remove"></param>
    public void Posicionar(Ficha Fichita, List<Casilla> SubLista, bool Remove = true) //Se administra desde el main
    {
        //Variable
        Random r = new Random();
        int index = r.Next(SubLista.Count); //Elegimos un índice random de la SubLista 

        uint i = SubLista[index].GetFila(); //guardamos la fila correspondiente a la casilla
        uint j = SubLista[index].GetColumna(); //guardamos la columna correspondiente a la casilla

        if (Fichita.GetName() == "Alfil2") //si estamos posicionando el segundo alfil
        {
            Ficha FichaAux = ListaPosicionadas[1]; //el ultimo (antes de posicionar el alfil 2) simpre es Alfil1
            try
            {
                while (Matriz[i, j].GetColor() == Matriz[FichaAux.Fila, FichaAux.Columna].GetColor()) //Mientras los dos alfiles sean del mismo color
                {
                    index = r.Next(SubLista.Count); //Elegimos un índice random de la SubLista 

                    i = SubLista[index].GetFila(); //nos guardamos nuevamente la fila
                    j = SubLista[index].GetColumna(); //nos guardamos nuevamente la columna
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Ocupamos la casilla con la fichita
        if (Remove)
        {
            Matriz[i, j].SetFicha(Fichita);
            Matriz[i, j].SetOcupada(true);
        }
        else if (Fichita is Caballo)
            Matriz[i, j].SetSuperpuesta(Fichita); //La unica que se puede superponer es Caballo2
        

        //Le ponemos a la ficha la columna y fila correspondiente
        Fichita.Fila = ((int)i);
        Fichita.Columna = ((int)j);

        Fichita.Atacar(this, Matriz[i, j]); //Es la funcion que "pinta" --> OJO porque no es la filtrada

        ListaPosicionadas.Add(Fichita); //agrego a la lista la ficha que posicioné

        if (Remove)
            SubLista.RemoveAt(index); //Sacamos de la lista al elemento ocupado, para que otros no lo puedan ocupar.
        
    }

    /// <summary>
    /// Imprime en el output las fichas del <see cref="Tablero"/>
    /// </summary>
    public void ImprimirOutput()
    {
        for (uint i = 0; i < Global.N_; ++i)
        {
            Debug.Write("|");
            for (uint j = 0; j < Global.N_; ++j)
            {
                if (Matriz[i, j].Fichita == null)
                {
                    Debug.Write(" # |");
                }
                else
                {
                    if (Matriz[i, j].Fichita.GetName() == "Reina")
                        Debug.Write(" Q |");
                    else if (Matriz[i, j].Fichita.GetName() == "Rey")
                        Debug.Write(" K |");
                    else if (Matriz[i, j].Fichita.GetName() == "Torre1" || Matriz[i, j].Fichita.GetName() == "Torre2")
                        Debug.Write(" T |");
                    else if (Matriz[i, j].Fichita.GetName() == "Caballo1" || Matriz[i, j].Fichita.GetName() == "Caballo2")
                        Debug.Write(" C |");
                    else
                        Debug.Write(" A |");
                }

            }
            Debug.Write("\n");
        }
        Debug.Write("\n\n");

    }

    #endregion

    #region MULTIPLICADORES DE SOLUCIONES

    /// <summary>
    /// Retorna un nuevo Tablero, que es igual al Tablero this pero rotado 90°.
    /// </summary>
    /// <returns></returns>
    public void Rotar90()
    {
        int N = Global.N_ - 1;

        for (int i = 0; i < Global.N_ / 2; i++)
        {
            for (int j = i; j < Global.N_ - i - 1; j++)
            {
                Casilla aux = Matriz[i, j]; //Variable auxiliar        

                Matriz[i, j] = Matriz[j, N - i]; // Movemos Casillas de derecha a arriba

                Matriz[j, N - i] = Matriz[N - i, N - j]; // Movemos Casillas de abajo a la derecha

                Matriz[N - i, N - j] = Matriz[N - j, i]; // Movemos Casillas de izquierda a abajo

                Matriz[N - j, i] = aux;

            }
        }

        for (int i = 0; i < Global.N_; ++i)
        {
            for (int k = 0; k < Global.N_; ++k)
            {
                Matriz[i, k].SetFila((uint)i);
                Matriz[i, k].SetColumna((uint)k);

                if (Matriz[i, k].Fichita != null)
                {
                    Matriz[i, k].Fichita.Fila = i;
                    Matriz[i, k].Fichita.Columna = k;

                    ListaPosicionadas.Add(Matriz[i, k].Fichita);
                }
            }
        }
    }

    /// <summary>
    /// Retorna un nuevo Tablero, que es igual al Tablero this pero espejado.
    /// </summary>
    /// <returns></returns>
    public Tablero Espejar(Tablero Espejar)
    {
        Ficha aux;

        for (int i = 0; i < Global.N_; ++i) //recorro fila
        {
            for (int j = 0; j < Global.N_; ++j) //recorro columna
            {
                if (Matriz[i, j].Fichita != null) //si hay una ficha en la casilla i,j
                {
                    aux = Matriz[i, j].Fichita; //ficha auxiliar

                    if (Matriz[i, 7 - j].Fichita != null) //si en la casilla "espejo" hay una ficha
                    {
                        Espejar.Matriz[i, j].SetFicha(Matriz[i, 7 - j].Fichita); //realizo el intercambio
                        Espejar.Matriz[i, j].Fichita.Fila = i;
                        Espejar.Matriz[i, j].Fichita.Columna = 7 - j;


                    }

                    Espejar.Matriz[i, 7 - j].SetFicha(aux);
                    //Espejar.Matriz[i, 7 - j].Fichita.Fila = i;
                    //Espejar.Matriz[i, 7 - j].Fichita.Columna = j;
                }
            }
        }

        SetLista(Espejar);

        return Espejar;
    }

    /// <summary>
    /// Retorna un nuevo Tablero, que es igual al Tablero this pero con las Torres con las columnas intercambiadas, 
    /// siempre que se ubiquen en Casillas con distinta Columna o Fila. 
    /// </summary>
    /// <returns></returns>
    public void IntercambiarTorres()
    {
        Casilla T1, T2;

        try
        {
            T1 = BuscarXNombre("Torre1");
            T2 = BuscarXNombre("Torre2");
        }
        catch (Exception ex)
        {
            throw ex; //MessageBox
        }

        if (T1.GetColumna() != T2.GetColumna() || T1.GetFila() != T2.GetFila())
        {
            uint x1 = T1.GetFila();
            uint y1 = T1.GetColumna();
            uint x2 = T2.GetFila();
            uint y2 = T2.GetColumna();

            Ficha Torre1 = Matriz[x1, y1].Fichita;
            Ficha Torre2 = Matriz[x2, y2].Fichita;

            if (Matriz[x1, y2].Fichita == null)
            {
                Matriz[x1, y1].SetFicha(null);

                Matriz[x1, y2].SetFicha(Torre1);
                Matriz[x1, y2].Fichita.Columna = (int)y2;
                Matriz[x1, y2].Fichita.Fila = (int)x1;
            }


            if (Matriz[x2, y1].Fichita == null)
            {
                Matriz[x2, y2].SetFicha(null);

                Matriz[x2, y1].SetFicha(Torre2);
                Matriz[x2, y1].Fichita.Columna = (int)y1;
                Matriz[x2, y1].Fichita.Fila = (int)x2;
            }

            return;

        }

        throw new Exception("\n Error en IntercambiarTorres: Torre1 y Torre2 están en la misma fila/ columna ");
    }

    #endregion

    #region VERIFICACIONES

    /// <summary>
    /// Retorna si es una solución  al problema de la cobertura total del Tablero de Ajedrez y si lo es, retorna el tipo (falta o leve).
    /// </summary>
    /// <returns></returns>
    public bool VerificarSolucion()
    {
        TipoSolucion Type_ = TipoSolucion.FATAL;

        for (int i = 0; i < Global.N_; i++)
        {
            for (int j = 0; j < Global.N_; j++)
            {
                if (!Matriz[i, j].GetAtacadaFatalmente())
                    Type_ = TipoSolucion.LEVE;
                if (!Matriz[i, j].GetAtacada())
                {
                    Type = TipoSolucion.NO_SOLUCION;
                    return false;
                }
            }
        }
        Type = Type_;
        return true;
    }

    /// <summary>
    /// Retorna true si el Tablero que le llega por parámetro es distinto a this, en otro caso retorna false
    /// </summary>
    /// <param name="T"></param>
    /// <returns></returns>
    public bool VerificarSolucionesDistintas(Tablero T)
    {
        if (ID != T.ID)
        { //Para no compararme conmigo mismo

            #region IDEA

            //Ficha Caballo2 = ListaPosicionadas.Pop();
            //Ficha Torre2 = ListaPosicionadas.Pop();
            //Ficha Torre1 = ListaPosicionadas.Pop();
            //Ficha Rey = ListaPosicionadas.Pop();
            //Ficha Caballo1 = ListaPosicionadas.Pop();
            //Ficha Alfil2 = ListaPosicionadas.Pop();
            //Ficha Alfil1 = ListaPosicionadas.Pop();
            //Ficha Reina = ListaPosicionadas.Pop();

            //Ficha Caballo2_T = T.ListaPosicionadas.Pop();
            //Ficha Torre2_T = T.ListaPosicionadas.Pop();
            //Ficha Torre1_T = T.ListaPosicionadas.Pop();
            //Ficha Rey_T = T.ListaPosicionadas.Pop();
            //Ficha Caballo1_T = T.ListaPosicionadas.Pop();
            //Ficha Alfil2_T = T.ListaPosicionadas.Pop();
            //Ficha Alfil1_T = T.ListaPosicionadas.Pop();
            //Ficha Reina_T = T.ListaPosicionadas.Pop();

            ////foreach(Ficha Fichita in ListaPosicionadas)
            ////{
            ////    if(Fichita is Torre || Fichita is Alfil || Fichita is Caballo)
            ////        if (!((Fichita.Columna == T.ListaPosicionadas.Pop().Columna) && (Fichita.Fila == T.ListaPosicionadas.Pop().Fila)))
            ////            if (!((Fichita.Columna == Torre2_T.Columna) && (Torre1.Columna == Torre2_T.Columna)))
            ////                return true;
            ////}

            //if (!((Reina.Columna == Reina_T.Columna) && (Reina.Fila == Reina_T.Fila)))
            //    return true;

            //if (!((Rey.Columna == Rey_T.Columna) && (Rey.Fila == Rey_T.Fila)))
            //    return true;

            //if (!((Torre1.Columna == Torre1_T.Columna) && (Torre1.Fila == Torre1_T.Fila)))
            //    if (!((Torre1.Columna == Torre2_T.Columna) && (Torre1.Columna == Torre2_T.Columna)))
            //        return true;

            //if (!((Torre2.Columna == Torre2_T.Columna) && (Torre2.Fila == Torre2_T.Fila)))
            //    if (!((Torre2.Columna == Torre1_T.Columna) && (Torre2.Columna == Torre1_T.Columna)))
            //        return true;

            //if (!((Caballo1.Columna == Caballo1_T.Columna) && (Caballo1.Fila == Caballo1_T.Fila)))
            //    if (!((Caballo1.Columna == Caballo2_T.Columna) && (Caballo1.Fila == Caballo2_T.Fila)))
            //        return true;

            //if (!((Caballo2.Columna == Caballo2_T.Columna) && (Caballo2.Fila == Caballo2_T.Fila)))
            //    if (!((Caballo2.Columna == Caballo1_T.Columna) && (Caballo2.Fila == Caballo1_T.Fila)))
            //        return true;

            //if (!((Alfil1.Columna == Alfil1_T.Columna) && (Alfil1.Fila == Alfil1_T.Fila)))
            //    if (!((Alfil1.Columna == Alfil2_T.Columna) && (Alfil1.Columna == Alfil2_T.Columna)))
            //        return true;

            //if (!((Alfil2.Columna == Alfil2_T.Columna) && (Alfil2.Fila == Alfil2_T.Fila)))
            //    if (!((Alfil2.Columna == Alfil1_T.Columna) && (Alfil2.Columna == Alfil1_T.Columna)))
            //        return true;

            //return false;
            #endregion

            #region LO VIEJO
            //for (int i = 0; i < Global.N_; ++i)
            //{
            //    for (int j = 0; j < Global.N_; ++j)
            //    {

            //        if (Matriz[i, j].Fichita != null) //Me fijo si en esa casilla hay ficha //ACA DICE QUE POS ES NULL!
            //        {
            //            if (T.Matriz[i, j].Fichita != null) //Si en la otra matriz hay también una ficha
            //            {
            //                if (T.Matriz[i, j].Fichita.GetType() != Matriz[i, j].Fichita.GetType()) //Me fijo si son de distinto tipo
            //                    return true;
            //            }
            //            else //Sino, ya sé que son distintas
            //                return true;
            //        }
            //    }
            //}
            #endregion

            #region LO NUEVO

            //Creo dos arrays con la ListaPosicionadas de ambos tableros:
            Ficha[] _THIS = this.ListaPosicionadas.ToArray();
            Ficha[] _T = T.ListaPosicionadas.ToArray();

            for (int i = 0; i < Global.N_; ++i) //TODO: si falla algo es de aca
            {
                if (_THIS[i].Columna != _T[i].Columna || _THIS[i].Fila != _T[i].Fila)
                    return true;
            }

            #endregion
        }

        return false; //Si no entra a ningun return previo, quiere decir que son iguales
    }
    #endregion

    #region BUSCAR

    /// <summary>
    /// Retorna la casilla donde está la Ficha que le llega por parámetro.
    /// </summary>
    /// <param name="Fichita"></param>
    /// <returns></returns>
    //public Casilla Buscar(Ficha Fichita)
    //{
    //    for (int i = 0; i < Global.N_; ++i)
    //        for (int j = 0; j < Global.N_; ++j)
    //            if (Matriz[i, j].Fichita == Fichita)
    //                return Matriz[i, j];
    //    throw new Exception("\n----- Error en buscar: " + Fichita.GetName() + " no está en el Tablero ----- ");
    //} //TODO: VER CUAL ALGORITMO DE BUSQUEDA USAR

    /// <summary>
    /// Retorna la casilla donde está la Ficha con el nombre que le llega por parámetro.
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public Casilla BuscarXNombre(string Name)
    {
        for (int i = 0; i < Global.N_; ++i)
            for (int j = 0; j < Global.N_; ++j)
            {
                if (Matriz[i, j].Fichita != null)
                    if (Matriz[i, j].Fichita.GetName() == Name)
                        return Matriz[i, j];
            }

        throw new Exception("\n----- Error en BuscarXNombre: " + Name + "no está en el Tablero ----- ");
    } //TODO: VER CUAL ALGORITMO DE BUSQUEDA USAR

    #endregion

    #region SETTERS & GETTES
    public TipoSolucion Type { get => type; set => type = value; }

    private void SetLista(Tablero T)
    {
        for (int i = 0; i < Global.N_; ++i)
            for (int k = 0; k < Global.N_; ++k)
                if (Matriz[i, k].Fichita != null)
                    T.ListaPosicionadas.Add(Matriz[i, k].Fichita);
    }
    #endregion

} //end Tablero