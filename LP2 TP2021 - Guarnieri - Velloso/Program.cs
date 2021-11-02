using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

/* ¡¡¡ATENCIÓN!!!
 * Para ver los Tableros que son solución, abrir la ventanda de Output.
 */

namespace LP2_TP2021___Guarnieri___Velloso
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Carátula());

            

           // Application.Run(new Soluciones(ListaSoluciones));

        }
    }
}

