///////////////////////////////////////////////////////////
//  Caballo.cs
//  Implementation of the Class Caballo
//  Generated by Enterprise Architect
//  Created on:      06-oct.-2021 08:09:07
//  Original author: vguar
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Caballo : Ficha
{
    #region CONSTRUCTOR & DESTRUCTOR

    /// <summary>
    /// Constructor de la clase <see cref="Caballo"/>.
    /// </summary>
    /// <param name="_Nombre"></param>
    public Caballo(string _Nombre) : base(_Nombre)
    {

    }

    /// <summary>
    /// Destructor de la clase <see cref="Caballo"/>.
    /// </summary>
    ~Caballo()
    {

    }

    #endregion

    #region ATAQUE 

    /// <summary>
    /// Ataque de <see cref="Caballo"/>.
    /// </summary>
    /// <param name="Ataque"></param>
    /// <param name="Pos"></param>
    /// <param name="Fatal"></param>
    public override void Atacar(Tablero Ataque, Casilla Pos, bool Fatal)
    {
        uint j = Pos.GetColumna();
        uint i = Pos.GetFila();

        if (i - 2 >= 0)
        {
            if (j + 1 < 8)
                Ataque.Matriz[i - 2, j + 1].SetAtacada(true);

            if (j - 1 >= 0)
                Ataque.Matriz[i - 2, j - 1].SetAtacada(true);
        }

        if (i + 2 < 8)
        {
            if (j - 1 >= 0)
                Ataque.Matriz[i + 2, j - 1].SetAtacada(true);
            if (j + 1 < 8)
                Ataque.Matriz[i + 2, j + 1].SetAtacada(true);
        }

        if (i + 1 < 8)
        {
            if (j + 2 < 8)
                Ataque.Matriz[i + 1, j + 2].SetAtacada(true);
            if (j - 2 >= 0)
                Ataque.Matriz[i + 1, j - 2].SetAtacada(true);
        }

        if (i - 1 >= 0)
        {
            if (j - 2 >= 0)
                Ataque.Matriz[i - 1, j - 2].SetAtacada(true);
            if (j + 2 < 8)
                Ataque.Matriz[i - 1, j + 2].SetAtacada(true);
        }
    }

    #endregion

} //end Caballo