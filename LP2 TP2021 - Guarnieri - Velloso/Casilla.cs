///////////////////////////////////////////////////////////
//  Casilla.cs
//  Implementation of the Class Casilla
//  Generated by Enterprise Architect
//  Created on:      06-oct.-2021 08:09:07
//  Original author: vguar
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Casilla {

	private bool Atacada;
	//private uint Columna;
	//private uint Fila;
	private bool Ocupada;
	private string ID;
	public Ficha Fichita;

	public Casilla(string _ID){
		ID = _ID;
		Ocupada = false;
		Fichita = null;
		Atacada = false;
	}

	~Casilla(){

	}

    public bool Ocupar()
    {
        if (!Ocupada && !(Fichita is Torre)) //el dynamic_cast en C#
            return false; //si estoy ocupada, no se puede posicionar una ficha
		
        Ocupada = true; //la casilla estaba desocupada, entonces la ocupo
        return true; //la pude ocupar
    }

	public void SetAtacada(bool newAtacada)
    {
		Atacada = newAtacada;
    }

	public bool GetAtacada()
	{
		return Atacada;
	}
	//public uint GetColumna()
	//   {
	//	return Columna;
	//   }
	//public uint GetFila()
	//{
	//	return Fila;
	//}

	//public void SetColumna(ushort col)
	//   {
	//	Columna = col;
	//   }

	//public void SetFila(ushort fila)
	//{
	//	Fila = fila;
	//}

}//end Casilla