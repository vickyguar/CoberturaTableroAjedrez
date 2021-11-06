using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

static class Global
{
    #region ATRIBUTOS

    /// <summary>
    /// Constante útil para definir límites.
    /// </summary>
    private static int N = 8;

    /// <summary>
    /// Objeto del tipo Stopwatch para medir el tiempo.
    /// </summary>
    public static Stopwatch timeMeasure = new Stopwatch();

    #endregion

    #region GETTER & SETTER

    public static int N_
    {
        get { return N; }
        set { N = value; }
    }

    #endregion
}
