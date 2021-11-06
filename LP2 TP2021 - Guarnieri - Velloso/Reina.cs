///////////////////////////////////////////////////////////
//  Reina.cs
//  Implementation of the Class Reina
//  Generated by Enterprise Architect
//  Created on:      06-oct.-2021 08:09:07
//  Original author: vguar
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

public class Reina : Ficha
{

    #region CONSTRUCTOR & DESTRUCTOR

    /// <summary>
    /// Constructor de la clase <see cref="Reina"/>.
    /// </summary>
    /// <param name="_Nombre"></param>
    public Reina(string _Nombre) : base(_Nombre, Image.FromFile("Reina.png"))
    {

    }

    /// <summary>
    /// Constructor por copia de la clase <see cref="Reina"/>.
    /// </summary>
    /// <param name="newFichita"></param>
    public Reina(Reina newFichita) : base(newFichita)
    {
    }

    /// <summary>
    /// Destructor de la clase <see cref="Reina"/>.
    /// </summary>
    ~Reina()
    {

    }

    #endregion

    #region ATAQUE

    /// <summary>
    /// Ataque de <see cref="Reina"/>.
    /// </summary>
    /// <param name="Ataque"></param>
    /// <param name="Pos"></param>
    /// <param name="Fatal"></param>
    public override void Atacar(Tablero Ataque, Casilla Pos)
    {
        Diagonal1(Ataque, Pos);
        Diagonal2(Ataque, Pos);
        Diagonal3(Ataque, Pos);
        Diagonal4(Ataque, Pos);
        Horizontal1(Ataque, Pos);
        Horizontal2(Ataque, Pos);
        Vertical1(Ataque, Pos);
        Vertical2(Ataque, Pos);
    }

    #endregion

} //end Reina