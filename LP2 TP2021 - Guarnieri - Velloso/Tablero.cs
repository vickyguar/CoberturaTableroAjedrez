﻿///////////////////////////////////////////////////////////
//  Tablero.cs
//  Implementation of the Class Tablero
//  Generated by Enterprise Architect
//  Created on:      06-oct.-2021 08:09:08
//  Original author: vguar
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public enum Color : int
{
    BLANCO = 0,
    NEGRO

}//end ColorAlfil

public class Tablero
{

    //private static uint ContSoluciones = 0; //Inicializamos en cero el contador static
    //private ushort ID;
    public Casilla[,] Matriz = new Casilla[8, 8]; //Acceso publico, para que las fichas se puedan posicionar y atacar
    private Stack<Ficha> PilaPosicionadas = new Stack<Ficha>(8);

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

    }

    public Tablero(Tablero newTablero)
    {
        Matriz = newTablero.Matriz;
        PilaPosicionadas = newTablero.PilaPosicionadas;
    }

    public Tablero Espejar()
    {
        Tablero Espejado = new Tablero(this); //copia del tablero original
        Casilla aux;
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                aux = Matriz[i, j];
                Matriz[i, j] = Matriz[7 - i, j];
                Matriz[7 - i, j] = aux; //TODO: verificar que cuando cambiamos las casillas, se llevan con ellas las fichas
            }
        }

        return Espejado;
    }



    ~Tablero()
    {

    }

    #region GENERADORES SOLUCIONES


    public Tablero Rotar90()
    {
        Tablero Rotado = new Tablero(this); //TODO: si esto no nos hace una copia -> sobrecargar el operador =
        int t;
        for (int i = 0; i < 8; i++)
        {
            t = 0;
            for (int j = 7; j >= 0; j--)
            {
                Rotado.Matriz[i, t] = Matriz[j, i];
                t++;
            }
        }

        return Rotado;
    }
    #endregion

    public bool FiltrarFatales() //Si devuelve true, en el main lo agrego a la lista de fatales.
    {
        //La idea es ir sacando las fichas y ver en donde estan
        /* TableroFisico.FiltrarFatales()  -> Este tablero fisico no esta "pintado", el que está pintado es el de Ataque
         * Podríamos hacer una copia de este tablero físico, y llamarlo Tablero filtrado, y pintar a tablero filtrado
         */
        Tablero Filtrado = new Tablero(this); //es una copia del tablero fisico

        for (uint i = 0; i < 8; ++i) //recorremos la pila de fichas en el tablero de copia
        {
            Ficha aux = Filtrado.PilaPosicionadas.Pop();
            Casilla pos = Buscar(aux);
            aux.Atacar(Filtrado, pos, true);//"pintar casilleros" de forma fatal (true)
        }
        return (Filtrado.VerificarSolucion()) ? true : false; //si es una solución fatal, devulve true y sino devuelve false
    }

    public void Imprimir()
    {
        //Boton: print
    }

    public void Limpiar()
    {
        //Boton: clear
    }

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
    /// 
    /// </summary>
    /// <param name="Fichita"></param>
    /// <param name="Ataque"></param>
    /// <param name="SubLista"></param>
    /// <param name="Remove"></param>
    public void Posicionar(Ficha Fichita, Tablero Ataque, List<Casilla> SubLista, bool Remove = true) //Se administra desde el main
    {
        //Variable
        Random r = new Random();
        int index = 0;

        index = Convert.ToInt32(r.Next(SubLista.Count)); //Elegimos un índice random de la SubLista 

        if (Fichita.GetName() == "Alfil2")
        {
            Ficha FichaAux = PilaPosicionadas.Peek(); //el ultimo simpre es Alfil1
            try
            {
                while (SubLista[index].GetColor() == Buscar(FichaAux).GetColor()) //Mientras los dos alfiles sean del mismo color
                    Posicionar(Fichita, Ataque, SubLista);
            }catch(Exception ex)
            {
                throw ex;
            }
         
        }

        //Ocupamos la casilla con la fichita
        SubLista[index].SetFicha(Fichita);
        SubLista[index].SetOcupada(true);

        Fichita.Atacar(Ataque, SubLista[index]); //Es la funcion que "pinta" --> OJO porque no es la filtrada

        PilaPosicionadas.Push(Fichita);
        if (Remove)
            SubLista.RemoveAt(index); //Sacamos de la lista al elemento ocupado, para que otros no lo puedan ocupar.

    }

    /// 
    /// <param name="Fichita"></param>
    public Casilla Buscar(Ficha Fichita)
    {
        for (int i = 0; i < 8; ++i)
            for (int j = 0; j < 8; ++j)
                if (Matriz[i, j].Fichita == Fichita)
                    return Matriz[i, j];
        throw new Exception("\n----- Error en buscar: " + Fichita.GetName() + "no está en el Tablero ----- ");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public Casilla BuscarXNombre(string Name)
    {
        for (int i = 0; i < 8; ++i)
            for (int j = 0; j < 8; ++j)
                if (Matriz[i, j].Fichita.GetName() == Name)
                    return Matriz[i, j];
        throw new Exception("\n----- Error en BuscarXNombre: " + Name + "no está en el Tablero ----- ");
    }
    //TODO: VER CUAL ALGORITMO DE BUSQUEDA USAR

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Tablero IntercambiarTorres()
    {
        Tablero Intercambiado = new Tablero(this);
        Casilla T1;
        Casilla T2;

        try
        {
            T1 = Intercambiado.BuscarXNombre("Torre1");
            T2 = Intercambiado.BuscarXNombre("Torre2");
        } catch(Exception ex)
        {
            throw ex; //MessageBox
        }

        if (T1.GetColumna() != T2.GetColumna() || T1.GetFila() != T2.GetFila())
        {
            uint ColAux = T1.GetColumna();
            T1.SetColumna(T2.GetColumna());
            T2.SetColumna(ColAux);
            return Intercambiado;
        }
        throw new Exception("\n----- Error en IntercambiarTorres: Torre1 y Torre2 están en la misma fila/ columna ----- ");
    }

    //Funcion Caballo

}
//end Tablero