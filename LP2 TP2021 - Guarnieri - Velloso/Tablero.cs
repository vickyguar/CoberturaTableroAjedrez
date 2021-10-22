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
public enum Color : int
{
    BLANCO = 0,
    NEGRO

} //end Color

public class Tablero
{
    #region ATRIBUTOS

    /// <summary>
    /// Matriz de Casillas del <see cref="Tablero"/>.
    /// </summary>
    public Casilla[,] Matriz = new Casilla[8, 8]; //Acceso publico, para que las fichas se puedan posicionar y atacar

    /// <summary>
    /// Pila de Fichas (se llena a medida que se posicionan las Ficha) del <see cref="Tablero"/>.
    /// </summary>
    private Stack<Ficha> PilaPosicionadas = new Stack<Ficha>(8);

    #endregion

    #region CONSTRUCTORES & DESTRUCTORES

    /// <summary>
    /// Constructor de la clase <see cref="Tablero"/>.: inicializa la Matriz de Casillas.
    /// </summary>
    public Tablero()
    {
        //Creamos la matriz de Casillas (tiempo n^2, fors anidados)
        for (uint i = 0; i < 8; ++i)
        {
            for (uint j = 0; j < 8; ++j)
            {
                Matriz[i, j] = new Casilla(i, j);
            }
        }
        LeerArchivo();
    }

    /// <summary>
    /// Constructor por copia de la clase <see cref="Tablero"/>..
    /// </summary>
    /// <param name="newTablero"></param>
    public Tablero(Tablero newTablero)
    {
        //Matriz = newTablero.Matriz; //TODO: preguntar si esto es válido
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
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
        PilaPosicionadas = newTablero.PilaPosicionadas;
        PilaPosicionadas = newTablero.PilaPosicionadas;
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
                Matriz[j, i].Colour = line[i] == '0' ? Color.BLANCO : Color.NEGRO; //le asigno el color a cada casilla

            j++;
        }
    }

    #endregion

    #region METODOS DE TABLERO

    /// <summary>
    /// Retorna true si el Tablero this es una solución al problema de la cobertura total del Tablero de Ajedrez, con las Fichas atacando de forma fatal.
    /// </summary>
    /// <returns></returns>
    public bool FiltrarFatales(Tablero Filtrado)
    {
        foreach (Ficha Fichita in PilaPosicionadas)
        {
            Fichita.Atacar(Filtrado, Buscar(Fichita), true);
        }

        return (Filtrado.VerificarSolucion()) ? true : false; //si es una solución fatal, devulve true y sino devuelve false
    }

    /// <summary>
    /// Imprime en Form
    /// </summary>
    public void Imprimir()
    {

        //Boton: print
    }

    /// <summary>
    /// Limpia el Tablero this: Las Casillas no están atacadas, ni ocupadas, y las Fichas son null.
    /// </summary>
    public void Limpiar()
    {
        for (uint i = 0; i < 8; i++)
        {
            for (uint j = 0; j < 8; j++)
            {
                Matriz[i, j].SetAtacada(false);
                Matriz[i, j].SetFicha(null);
                Matriz[i, j].SetOcupada(false);
            }
        }
        PilaPosicionadas.Clear();
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
    public void Posicionar(Ficha Fichita, Tablero Ataque, List<Casilla> SubLista, bool Remove = true) //Se administra desde el main
    {
        //Variable
        Random r = new Random();
        int index = r.Next(SubLista.Count); //Elegimos un índice random de la SubLista 

        uint i = SubLista[index].GetFila();
        uint j = SubLista[index].GetColumna();

        if (Fichita.GetName() == "Alfil2")
        {
            Ficha FichaAux = PilaPosicionadas.Peek(); //el ultimo simpre es Alfil1
            try
            {
                while (Matriz[i,j].GetColor() == Buscar(FichaAux).GetColor()) //Mientras los dos alfiles sean del mismo color
                {
                    index = r.Next(SubLista.Count); //Elegimos un índice random de la SubLista 

                    i = SubLista[index].GetFila();
                    j = SubLista[index].GetColumna();
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        //Ocupamos la casilla con la fichita
        Matriz[i, j].SetFicha(Fichita);
        Matriz[i, j].SetOcupada(true);

        Fichita.Atacar(Ataque, Matriz[i,j]); //Es la funcion que "pinta" --> OJO porque no es la filtrada

        PilaPosicionadas.Push(Fichita);
        if (Remove)
            SubLista.RemoveAt(index); //Sacamos de la lista al elemento ocupado, para que otros no lo puedan ocupar.

    }

    /// <summary>
    /// Imprime en Consola las fichas del Tablero
    /// </summary>
    public void ImprimirOutput()
    {
        for (uint i =0; i < 8; ++i)
        {
            for(uint j =0; j < 8; ++j)
            {
                if(Matriz[i,j].Fichita == null)
                {
                    Debug.Write("  ##   ");
                }
                else
                {
                    if (Matriz[i, j].Fichita.GetName() == "Reina")
                        Debug.Write(" Reina  ");
                    else if (Matriz[i, j].Fichita.GetName() == "Rey")
                        Debug.Write("  Rey   ");
                    else if (Matriz[i, j].Fichita.GetName() == "Torre1" || Matriz[i, j].Fichita.GetName() == "Torre2")
                        Debug.Write(" Torre  ");
                    else if (Matriz[i, j].Fichita.GetName() == "Caballo1" || Matriz[i, j].Fichita.GetName() == "Caballo2")
                        Debug.Write(" Caballo ");
                    else
                        //(Matriz[i, j].Fichita.GetName() == "Alfil1" || Matriz[i, j].Fichita.GetName() == "Alfil2")
                        Debug.Write(" Alfil ");
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
        int N = 8 - 1;

        for (int i = 0; i < 8 / 2; i++)
        { 
            for (int j = i; j < 8 - i - 1; j++)
            {
                Casilla aux = Matriz[i, j]; //Variable auxiliar

                Matriz[i, j] = Matriz[j, N - i]; // Movemos Casillas de derecha a arriba

                Matriz[j, N - i] = Matriz[N - i, N - j]; // Movemos Casillas de abajo a la derecha
                
                Matriz[N - i, N - j] = Matriz[N - j, i]; // Movemos Casillas de izquierda a abajo

                Matriz[N - j, i] = aux; 
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

        for (int i = 0; i < 8; ++i) //recorro fila
        {
            for (int j = 0; j < 8; ++j) //recorro columna
            {
                if (Matriz[i, j].Fichita != null) //si hay una ficha en la casilla i,j
                {
                    aux = Matriz[i, j].Fichita; //ficha auxiliar
                    
                    if (Matriz[i, 7 - j].Fichita != null) //si en la casilla "espejo" hay una ficha
                        Espejar.Matriz[i, j].SetFicha(Matriz[i, 7 - j].Fichita); //realizo el intercambio
                    
                    Espejar.Matriz[i, 7 - j].SetFicha(aux);
                }
            }
        }
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
            }


            if (Matriz[x2, y1].Fichita == null)
            {
                Matriz[x2, y2].SetFicha(null);
                Matriz[x2, y1].SetFicha(Torre2);
            }

            return;
        }

        throw new Exception("\n Error en IntercambiarTorres: Torre1 y Torre2 están en la misma fila/ columna ");
    }

    #endregion

    #region VERIFICACIONES

    /// <summary>
    /// Retorna true si el Tablero this es una solución al problema de la cobertura total del Tablero de Ajedrez.
    /// </summary>
    /// <returns></returns>
    public bool VerificarSolucion()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (!Matriz[i, j].GetAtacada())
                    return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Retorna true si el Tablero que le llega por parámetro es distinto a this, en otro caso retorna false
    /// </summary>
    /// <param name="T"></param>
    /// <returns></returns>
    public bool VerificarSolucionesDistintas(Tablero T)
    {
        foreach (Casilla Pos in Matriz) //Para cada Casilla de la Matriz
        {
            if (Pos.Fichita != null) //Me fijo si en esa casilla hay ficha
            {
                if (T.Matriz[Pos.GetFila(), Pos.GetColumna()].Fichita != null) //Si en la otra matriz hay también una ficha
                {
                    if (T.Matriz[Pos.GetFila(), Pos.GetColumna()].Fichita.GetType() != Pos.Fichita.GetType()) //Me fijo si son de distinto tipo
                        return true;
                }
                else //Sino, ya sé que son distintas
                    return true;
            }
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
    public Casilla Buscar(Ficha Fichita)
    {
        for (int i = 0; i < 8; ++i)
            for (int j = 0; j < 8; ++j)
                if (Matriz[i, j].Fichita == Fichita)
                    return Matriz[i, j];
        throw new Exception("\n----- Error en buscar: " + Fichita.GetName() + " no está en el Tablero ----- ");
    } //TODO: VER CUAL ALGORITMO DE BUSQUEDA USAR

    /// <summary>
    /// Retorna la casilla donde está la Ficha con el nombre que le llega por parámetro.
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public Casilla BuscarXNombre(string Name)
    {
        for (int i = 0; i < 8; ++i)
            for (int j = 0; j < 8; ++j)
            {
                if(Matriz[i,j].Fichita!=null)
                    if (Matriz[i, j].Fichita.GetName() == Name)
                        return Matriz[i, j];
            }
                
        throw new Exception("\n----- Error en BuscarXNombre: " + Name + "no está en el Tablero ----- ");
    } //TODO: VER CUAL ALGORITMO DE BUSQUEDA USAR

    #endregion

} //end Tablero