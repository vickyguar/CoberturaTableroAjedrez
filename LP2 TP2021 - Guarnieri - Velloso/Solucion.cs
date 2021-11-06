using System;
using System.Collections.Generic;
using System.Text;

namespace LP2_TP2021___Guarnieri___Velloso
{
    public class Solucion
    {
        #region ATRIBUTOS

        /// <summary>
        /// Lista de Fichas posicionadas.
        /// </summary>
        SortedList<uint, Ficha> Posiciones;

        /// <summary>
        /// Tipo de solucion: NO_SOLUCION, LEVE, FATAL.
        /// </summary>
        TipoSolucion Tipo;

        #endregion

        #region CONSTRUCTOR & DESTRUCTOR
        /// <summary>
        /// Constructor de la clase Solucion
        /// </summary>
        /// <param name="Lista"></param>
        /// <param name="type_"></param>
        public Solucion(SortedList<uint, Ficha> Lista, TipoSolucion type_)
        {
            Posiciones = Lista;
            Tipo = type_;
        }

        /// <summary>
        /// Destructor de la clase Solucion
        /// </summary>
        ~Solucion()
        {

        }

        #endregion

        #region GETTERS & SETTERS

        public SortedList<uint, Ficha> Posiciones_ { get => Posiciones; set => Posiciones = value; }
        public TipoSolucion Tipo_ { get => Tipo; set => Tipo = value; }

        #endregion
    }
}
