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

public class Casilla
{
    #region ATRIBUTOS

    //PUBLICOS:
    /// <summary>
    /// <see cref="Color"/> de la <see cref="Casilla"/>.
    /// </summary>
    public Color Colour; //TODO: inicializar! txt!! ToolBox
    /// <summary>
    /// <see cref="Ficha"/> que tiene la <see cref="Casilla"/>.
    /// </summary>
    public Ficha Fichita;

    //PRIVADOS:
    /// <summary>
    /// Columna de la <see cref="Casilla"/>.
    /// </summary>
    private uint Columna;
    /// <summary>
    /// Fila de la <see cref="Casilla"/>
    /// </summary>
    private uint Fila;

    private bool Ocupada;
    private bool Atacada;

    #endregion

    #region CONSTRUCTOR & DESTRUCTOR

    /// <summary>
    /// Constructor de la clase <see cref="Casilla"/>.
    /// </summary>
    /// <param name="_Columna"></param>
    /// <param name="_Fila"></param>
    public Casilla(uint _Columna, uint _Fila/*, Color _Color*/)
    {
        Columna = _Columna;
        Fila = _Fila;
        Ocupada = false;
        Atacada = false;
        Fichita = null;
        //Colour = _Color;
    }

    /// <summary>
    /// Destructor de la clase <see cref="Casilla"/>.
    /// </summary>
    ~Casilla()
    {

    }

    #endregion

    #region GETTERS

    public bool GetOcupada() { return Ocupada; }

    public bool GetAtacada() { return Atacada; }

    public uint GetColumna() { return Columna; }

    public uint GetFila() { return Fila; }

    public Color GetColor() { return Colour; }

    #endregion

    #region SETTERS

    public void SetColumna(uint newColumna) { Columna = newColumna; }

    public void SetFila(uint newFila) { Fila = newFila; }

    public void SetAtacada(bool newAtacada) { Atacada = newAtacada; }

    public void SetOcupada(bool newOcupada) { Ocupada = newOcupada; }

    public void SetFicha(Ficha newFichita) { Fichita = newFichita; }

    #endregion

} //end Casilla