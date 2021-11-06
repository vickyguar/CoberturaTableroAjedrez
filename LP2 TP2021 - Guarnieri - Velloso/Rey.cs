///////////////////////////////////////////////////////////
//  Rey.cs
//  Implementation of the Class Rey
//  Generated by Enterprise Architect
//  Created on:      06-oct.-2021 08:09:07
//  Original author: vguar
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

public class Rey : Ficha
{
    #region CONSTRUCTOR & DESTRUCTOR

    /// <summary>
    /// Constructor de la clase <see cref="Rey"/>.
    /// </summary>
    /// <param name="_Nombre"></param>
    public Rey(string _Nombre) : base(_Nombre, Image.FromFile("Rey.png"))
    {

    }

    public Rey(Rey newFichita) : base(newFichita)
    {
    }

    /// <summary>
    /// Destructor de la clase <see cref="Rey"/>.
    /// </summary>
    ~Rey()
    {

    }

    #endregion

    #region ATAQUE 

    /// <summary>
    /// Ataque de <see cref="Rey"/>.
    /// </summary>
    /// <param name="Ataque"></param>
    /// <param name="Pos"></param>
    /// <param name="Fatal"></param>
    public override void Atacar(Tablero Ataque, Casilla Pos)
    {
        int i = Pos.GetFila();
        int j = Pos.GetColumna();

        //No verificamos si lo que pinta est� fuera del Tablero, porque nosostras le restringimos al Rey a posicionarse en el Cuadrado3 (ver Main)
        //El Rey siempre ataca de forma fatal.

        Ataque.Matriz[i + 1, j].SetAtacada(true);
        Ataque.Matriz[i + 1, j].SetAtacadaFatalmente(true);

        Ataque.Matriz[i - 1, j].SetAtacada(true);
        Ataque.Matriz[i - 1, j].SetAtacadaFatalmente(true);

        Ataque.Matriz[i, j + 1].SetAtacada(true);
        Ataque.Matriz[i, j + 1].SetAtacadaFatalmente(true);

        Ataque.Matriz[i, j - 1].SetAtacada(true);
        Ataque.Matriz[i, j - 1].SetAtacadaFatalmente(true);

        Ataque.Matriz[i + 1, j + 1].SetAtacada(true);
        Ataque.Matriz[i + 1, j + 1].SetAtacadaFatalmente(true);

        Ataque.Matriz[i + 1, j - 1].SetAtacada(true);
        Ataque.Matriz[i + 1, j - 1].SetAtacadaFatalmente(true);

        Ataque.Matriz[i - 1, j + 1].SetAtacada(true);
        Ataque.Matriz[i - 1, j + 1].SetAtacadaFatalmente(true);

        Ataque.Matriz[i - 1, j - 1].SetAtacada(true);
        Ataque.Matriz[i - 1, j - 1].SetAtacadaFatalmente(true);

    }

    #endregion

} //end Rey