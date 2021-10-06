///////////////////////////////////////////////////////////
//  Ficha.cs
//  Implementation of the Class Ficha
//  Generated by Enterprise Architect
//  Created on:      06-oct.-2021 08:09:07
//  Original author: vguar
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public abstract class Ficha {

	protected string Nombre;
	protected Casilla Posicion;
	public Tablero m_Tablero;

    public Ficha()
    {

    }

    ~Ficha()
    {

    }

    public Casilla GetPosicion() //TODO: como la hago const?
    {
        return Posicion;
    }

    public void SetPosicion(Casilla newPos)
    {
        this.Posicion = newPos;
    }

	public abstract void Atacar(Tablero Ataque);

}//end Ficha