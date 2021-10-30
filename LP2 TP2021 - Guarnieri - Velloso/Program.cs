using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

/* ���ATENCI�N!!!
 * Para ver los Tableros que son soluci�n, abrir la ventanda de Output.
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
            Application.Run(new Car�tula());

            int ID = 0;
            Tablero Juego = new Tablero(ID);
            Random rnd = new Random(); //Es un random que usamos para luego elegir qu� cuadrado darle a la Torre2

            #region FICHAS

            //Creamos Fichas
            Ficha Reina = new Reina("Reina");
            Ficha Rey = new Rey("Rey");
            Ficha Torre1 = new Torre("Torre1");
            Ficha Torre2 = new Torre("Torre2");
            Ficha Alfil1 = new Alfil("Alfil1");
            Ficha Alfil2 = new Alfil("Alfil2");
            Ficha Caballo1 = new Caballo("Caballo1");
            Ficha Caballo2 = new Caballo("Caballo2");

            #endregion

            List<Casilla> Cuadrado1 = new List<Casilla>(4); //5e, 5d, 4e, 4d ROJO
            List<Casilla> Cuadrado2 = new List<Casilla>(12); //6c, 3c, 3f, 6f VIOLETA
            List<Casilla> Cuadrado3 = new List<Casilla>(20); //7b, 2b, 7g, 2g AZUL
            List<Casilla> Cuadrado4 = new List<Casilla>(28); //8a, 1a, 8h, 1a VERDE

            //ROJO, VIOLETA, AZUL, VERDE -> seg�n las regiones del tablero que marcamos en nuestro pseudoc�digo

            List<Tablero> ListaSoluciones = new List<Tablero>();
            List<Tablero> ListaFatales = new List<Tablero>();

            while (ListaSoluciones.Count < 11)
            {
                #region LISTAS

                for (uint i = 3; i <= 4; i++)
                {
                    for (uint j = 3; j <= 4; j++)
                        Cuadrado1.Add(new Casilla(i, j));
                }

                 //FILA FIJA
                for (uint i = 2; i <= 5; i++)
                {
                    Cuadrado2.Add(new Casilla(2, i));
                    Cuadrado2.Add(new Casilla(5, i));
                }

                //COLUMNA FIJA
                for (uint i = 3; i < 5; i++)
                {
                    Cuadrado2.Add(new Casilla(i, 2));
                    Cuadrado2.Add(new Casilla(i, 5));
                }

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

                                                                 //FILA FIJA
                for (uint i = 0; i < Global.N_; i++)
                {
                    Cuadrado4.Add(new Casilla(0, i));
                    Cuadrado4.Add(new Casilla(7, i));
                }

                //COLUMNA FIJA
                for (uint i = 1; i < 7; i++)
                {
                    Cuadrado4.Add(new Casilla(i, 0));
                    Cuadrado4.Add(new Casilla(i, 7));
                }

                #endregion

                #region POSICIONAMIENTO DE LAS FICHAS

                Juego.Posicionar(Reina, Cuadrado1);
                Juego.Posicionar(Alfil1, Cuadrado1);
                Juego.Posicionar(Alfil2, Cuadrado2);
                Juego.Posicionar(Caballo1, Cuadrado2);
                Juego.Posicionar(Rey, Cuadrado3);
                Juego.Posicionar(Torre1, Cuadrado4);

                switch (Convert.ToInt32(rnd.Next(1, 4)))
                {
                    case 1:
                        Juego.Posicionar(Torre2, Cuadrado2); break;
                    case 2:
                        Juego.Posicionar(Torre2, Cuadrado3); break;
                    case 3:
                        Juego.Posicionar(Torre2, Cuadrado4); break;
                }

                Juego.Posicionar(Caballo2, Cuadrado2);

                #endregion

                #region GENERACI�N DE SOLUCIONES

                if (Juego.VerificarSolucion())
                {
                    ListaSoluciones.Add(Juego); //#1
                    ++ID;
                    Juego.ImprimirOutput(); //Vemos si funciona nuestro c�digo, mirandolo en nuestro Debug

                    #region ROTADO DE ORIGINAL

                    //TABLERO ROTADO 1 (90�)
                    Tablero Rotado1 = new Tablero(Juego,++ID); //#2
                    Rotado1.Rotar90();
                    ListaSoluciones.Add(Rotado1);
                    Rotado1.ImprimirOutput();

                    //TABLERO ROTADO 2 (180�)
                    Tablero Rotado2 = new Tablero(Rotado1, ++ID); //#3
                    Rotado2.Rotar90();
                    ListaSoluciones.Add(Rotado2);
                    Rotado2.ImprimirOutput();

                    //TABLERO ROTADO 3 (270�)
                    Tablero Rotado3 = new Tablero(Rotado2,++ID); //#4
                    Rotado3.Rotar90();
                    ListaSoluciones.Add(Rotado3);
                    Rotado3.ImprimirOutput();

                    #endregion

                    #region ESPEJADO ORIGINAL
                    //ESPEJADO 1
                    Tablero Espejado = new Tablero(++ID); //#5
                    Juego.Espejar(Espejado);
                    ListaSoluciones.Add(Espejado);
                    Espejado.ImprimirOutput();

                    //ESPEJADO ROTADO 1 (90)
                    Tablero EspejadoRotado1 = new Tablero(Espejado, ++ID); //#6
                    ++ID;
                    EspejadoRotado1.Rotar90();
                    ListaSoluciones.Add(EspejadoRotado1);
                    EspejadoRotado1.ImprimirOutput();

                    //ESPEJADO ROTADO 2 (180)
                    Tablero EspejadoRotado2 = new Tablero(EspejadoRotado1, ++ID); //#7
                    EspejadoRotado2.Rotar90();
                    ListaSoluciones.Add(EspejadoRotado2);
                    EspejadoRotado2.ImprimirOutput();

                    //ESPEJADO ROTADO 3 (270)
                    Tablero EspejadoRotado3 = new Tablero(EspejadoRotado2, ++ID); //#8
                    EspejadoRotado3.Rotar90();
                    ListaSoluciones.Add(EspejadoRotado3);
                    EspejadoRotado3.ImprimirOutput();

                    #endregion

                    #region INTERCAMBIO TORRES
                    //INTERCAMBIO
                    Tablero Intercambiado = new Tablero(Juego,++ID);  //#9
                    Intercambiado.IntercambiarTorres();
                    ListaSoluciones.Add(Intercambiado);
                    Intercambiado.ImprimirOutput();

                    //INTERCAMBIO ROTADO 1 (90)
                    Tablero IntercambioRotado1 = new Tablero(Intercambiado,++ID); //#10
                    IntercambioRotado1.Rotar90();
                    ListaSoluciones.Add(IntercambioRotado1);
                    IntercambioRotado1.ImprimirOutput();

                    //INTERCAMBIO ROTADO (180)
                    Tablero IntercambioRotado2 = new Tablero(IntercambioRotado1,++ID); //#11
                    IntercambioRotado2.Rotar90();
                    ListaSoluciones.Add(IntercambioRotado2);
                    IntercambioRotado2.ImprimirOutput();


                    //INTERCAMBIO ROTADO (270)
                    Tablero IntercambioRotado3 = new Tablero(IntercambioRotado2,++ID); //#12
                    IntercambioRotado3.Rotar90();
                    ListaSoluciones.Add(IntercambioRotado3);
                    IntercambioRotado3.ImprimirOutput();

                    #endregion

                    #endregion

                    #region VERIFICAR SOLUCIONES DISTINTAS 

                    for (int j = 0; j < ListaSoluciones.Count; ++j)
                    {
                        Tablero Solucion = ListaSoluciones[j];

                        for (int i = 0; i < ListaSoluciones.Count; ++i)
                        {
                            if (!Solucion.VerificarSolucionesDistintas(ListaSoluciones[i]))
                            {
                                //Pensar esto esta mal, porque la soluci�n SI va a estar en la lista de soluciones
                                ListaSoluciones.Remove(Solucion);
                            }
                        }
                    }

                    #endregion

                    #region FILTRAR FATALES

                    foreach (Tablero Solucion in ListaSoluciones)
                        if (Solucion.Type == TipoSolucion.FATAL)
                            ListaFatales.Add(Solucion);
                    #endregion
                }

                #region LIMPIAMOS LOS TABLEROS

                Juego.Limpiar();

                #endregion

                #region VACIAMOS CUADRADOS

                Cuadrado1.Clear();
                Cuadrado2.Clear();
                Cuadrado3.Clear();
                Cuadrado4.Clear();

                #endregion
            }
        }
    }
}

