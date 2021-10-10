using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new Form1());


            //Listas globales
            List<Casilla> Cuadrado1 = new List<Casilla>(4); //5e, 5d, 4e, 4d ROJO

            for(uint i = 3; i<=4; i++)
            {
                for (uint j = 3; j <= 4; j++)
                    Cuadrado1.Add(new Casilla(i, j));
            }

            List<Casilla> Cuadrado2 = new List<Casilla>(12); //6c, 3c, 3f, 6f VIOLETA
            //FILA FIJA
            for (uint i = 2; i <= 5; i++)
            { 
                Cuadrado2.Add(new Casilla(2,i));
                Cuadrado2.Add(new Casilla(5, i));
            }

            //COLUMNA FIJA
            for (uint i = 3; i < 5; i++)
            {
                Cuadrado2.Add(new Casilla(i, 2));
                Cuadrado2.Add(new Casilla(i, 5));
            }

            List<Casilla> Cuadrado3 = new List<Casilla>(20); //7b, 2b, 7g, 2g AZUL
            //FILA FIJA
            for (uint i = 1; i <= 6; i++)
            {
                Cuadrado3.Add(new Casilla(1, i));
                Cuadrado3.Add(new Casilla(6, i));
            }

            //COLUMNA FIJA
            for (uint i = 2; i < 6; i++)
            {
                Cuadrado3.Add(new Casilla(i, 1));
                Cuadrado3.Add(new Casilla(i, 6));
            }

            List<Casilla> Cuadrado4 = new List<Casilla>(28); //8a, 1a, 8h, 1a VERDE
             //FILA FIJA
            for (uint i = 0; i <= 7; i++)
            {
                Cuadrado3.Add(new Casilla(0, i));
                Cuadrado3.Add(new Casilla(7, i));
            }

            //COLUMNA FIJA
            for (uint i = 1; i < 7; i++)
            {
                Cuadrado3.Add(new Casilla(i, 0));
                Cuadrado3.Add(new Casilla(i, 7));
            }

            /*
              A  B  C  D  E  F  G  H
            8 00 01 02 03 04 05 06 07
            7 10 11 12 13 14 15 16 17
            6 20 21 22 23 24 25 26 27
            5 30 31 32 33 34 35 36 37
            4 40 41 42 43 44 45 46 47
            3 50 51 52 53 54 55 56 57
            2 60 61 62 63 64 65 66 67
            1 70 71 72 73 74 75 76 77
            */

            /*
              A  B  C  D  E  F  G  H
            8 00 01 02 03 04 05 06 07
            7 10                   17
            6 20                   27
            5 30                   37
            4 40                   47
            3 50                   57
            2 60                   67
            1 70 71 72 73 74 75 76 77
            */
        }
    }
}
