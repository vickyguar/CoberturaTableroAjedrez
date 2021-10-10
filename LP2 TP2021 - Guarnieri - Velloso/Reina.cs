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



public class Reina : Ficha {

	public Reina(string _Nombre): base(_Nombre)
	{

	}

	~Reina(){

	}

	public override void Atacar(Tablero Ataque, bool Fatal)
	{
		Diagonal1(Ataque, Fatal);
		Diagonal2(Ataque, Fatal);
		Diagonal3(Ataque, Fatal);
		Diagonal4(Ataque, Fatal);
		Horizontal1(Ataque, Fatal);
		Horizontal2(Ataque, Fatal);
		Vertical1(Ataque, Fatal);
		Vertical2(Ataque, Fatal);
	}

}//end Reina