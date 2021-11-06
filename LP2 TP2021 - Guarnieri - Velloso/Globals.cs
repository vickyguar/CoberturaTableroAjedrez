using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

static class Global
{
    private static int N = 8;

    public static int N_
    {
        get { return N; }
        set { N = value; }
    }

    public static Stopwatch timeMeasure = new Stopwatch();

}
