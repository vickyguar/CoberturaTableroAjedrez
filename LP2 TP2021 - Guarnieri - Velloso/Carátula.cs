using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LP2_TP2021___Guarnieri___Velloso
{
    public class Solucion
    {
        SortedList<uint, Ficha> Posiciones;
        TipoSolucion Tipo;
      //  int ID;

        public SortedList<uint,Ficha> Posiciones_ { get => Posiciones; set => Posiciones = value; }
        public TipoSolucion Tipo_ { get => Tipo; set => Tipo = value; }

        //public int ID_ { get => ID; set => ID = value; }

        public Solucion(SortedList<uint, Ficha> Lista, TipoSolucion type_ /*int ID_*/)
        {
            Posiciones = Lista;
            Tipo = type_;
           // ID = ID_;
        }
    }

    public partial class Carátula : Form
    {
        Soluciones FormSoluciones;
        public Carátula()
        {
            InitializeComponent();
            this.Show();
            List<Solucion> ListaSoluciones = Programa();
            FormSoluciones = new Soluciones(ListaSoluciones, this);

        }

        private void Carátula_Load(object sender, EventArgs e)
        {

        }

        #region BOTON

        /// <summary>
        /// Evento click en el botón GENERAR de <see cref="Carátula"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_Click(object sender, EventArgs e)
        {
            FormSoluciones.Show(); //Abrimos el form de soluciones
            this.Hide(); //Cerramos el Form de Carátula
        }

        #endregion

        #region PROGRAMA

        /// <summary>
        /// Algoritmo
        /// </summary>
        /// <returns></returns>
        static List<Solucion> Programa()
        {
            int ID = -1;
            Tablero Juego = new Tablero(ID);
            Random rnd = new Random(); //Es un random que usamos para luego elegir qué cuadrado darle a la Torre2
            List<Solucion> Solutions = new List<Solucion>();

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

            //ROJO, VIOLETA, AZUL, VERDE -> según las regiones del tablero que marcamos en nuestro pseudocódigo

            while (Solutions.Count < 11)
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

                switch (Convert.ToInt32(rnd.Next(1, 4))) //A la torre 2 le paso eliminar
                {
                    case 1:
                        Juego.Posicionar(Torre2, Cuadrado2, false); break;
                    case 2:
                        Juego.Posicionar(Torre2, Cuadrado3, false); break;
                    case 3:
                        Juego.Posicionar(Torre2, Cuadrado4, false); break;
                }

                Juego.Posicionar(Caballo2, Cuadrado2, false);

                #endregion

                #region GENERACIÓN DE SOLUCIONES

                if (Juego.VerificarSolucion())
                {
                    //ListaSoluciones.Add(CopiaLista(Juego.ListaPosicionadas_)); //#1 -> me copia (con objetos nuevos) la lista que tiene las fichas de la solución
                    Solucion Table = new Solucion(Juego.CopiaLista(Juego.ListaPosicionadas_), Juego.Type);

                    if (!Solutions.Contains(Table))
                        Solutions.Add(Table);
                    #region ROTADO DE ORIGINAL

                    //TABLERO ROTADO 1 (90°) 
                    Tablero Rotado1 = new Tablero(Juego, ++ID); //#2
                    Rotado1.Rotar90();
                    Solucion SolRotado1 = new Solucion(Rotado1.CopiaLista(Rotado1.ListaPosicionadas_), Rotado1.Type);
                    if (!Solutions.Contains(SolRotado1))
                        Solutions.Add(SolRotado1);

                    //ListaSoluciones.Add());

                    //TABLERO ROTADO 2 (180°)
                    Tablero Rotado2 = new Tablero(Rotado1, ++ID); //#3
                    Rotado2.Rotar90();
                    Solucion SolRotado2 = new Solucion(Rotado2.CopiaLista(Rotado2.ListaPosicionadas_), Rotado2.Type);
                    if (!Solutions.Contains(SolRotado2))
                        Solutions.Add(SolRotado2);

                    //ListaSoluciones.Add(CopiaLista(Rotado2.ListaPosicionadas_));


                    //TABLERO ROTADO 3 (270°)
                    Tablero Rotado3 = new Tablero(Rotado2, ++ID); //#4
                    Rotado3.Rotar90();
                    Solucion SolRotado3 = new Solucion(Rotado3.CopiaLista(Rotado3.ListaPosicionadas_), Rotado3.Type);
                    if (!Solutions.Contains(SolRotado3))
                        Solutions.Add(SolRotado3);



                    //ListaSoluciones.Add(CopiaLista(Rotado3.ListaPosicionadas_));
                    #endregion

                    #region ESPEJADO ORIGINAL
                    //ESPEJADO 1
                    Tablero Espejado = new Tablero(++ID); //#5
                    Juego.Espejar(Espejado);
                    Solucion SolEspejado = new Solucion(Espejado.CopiaLista(Espejado.ListaPosicionadas_), Espejado.Type);
                    if (!Solutions.Contains(SolEspejado))
                        Solutions.Add(SolEspejado);
                    //ListaSoluciones.Add(CopiaLista(Espejado.ListaPosicionadas_));

                    //ESPEJADO ROTADO 1 (90)
                    Tablero EspejadoRotado1 = new Tablero(Espejado, ++ID); //#6
                    EspejadoRotado1.Rotar90();
                    Solucion SolEspejadoRotado1 = new Solucion(EspejadoRotado1.CopiaLista(EspejadoRotado1.ListaPosicionadas_), EspejadoRotado1.Type);
                    if (!Solutions.Contains(SolEspejadoRotado1))
                        Solutions.Add(SolEspejadoRotado1);

                    //ListaSoluciones.Add(CopiaLista(EspejadoRotado1.ListaPosicionadas_));

                    //ESPEJADO ROTADO 2 (180)
                    Tablero EspejadoRotado2 = new Tablero(EspejadoRotado1, ++ID); //#7
                    EspejadoRotado2.Rotar90();
                    Solucion SolEspejadoRotado2 = new Solucion(EspejadoRotado2.CopiaLista(EspejadoRotado2.ListaPosicionadas_), EspejadoRotado2.Type);
                    if (!Solutions.Contains(SolEspejadoRotado2))
                        Solutions.Add(SolEspejadoRotado2);

                    //ListaSoluciones.Add(CopiaLista(EspejadoRotado2.ListaPosicionadas_));

                    //ESPEJADO ROTADO 3 (270)
                    Tablero EspejadoRotado3 = new Tablero(EspejadoRotado2, ++ID); //#8
                    EspejadoRotado3.Rotar90();
                    Solucion SolEspejadoRotado3 = new Solucion(EspejadoRotado3.CopiaLista(EspejadoRotado3.ListaPosicionadas_), EspejadoRotado3.Type);
                    if (!Solutions.Contains(SolEspejadoRotado3))
                        Solutions.Add(SolEspejadoRotado3);

                    //ListaSoluciones.Add(CopiaLista(EspejadoRotado3.ListaPosicionadas_));

                    #endregion

                    #region INTERCAMBIO TORRES
                    ////INTERCAMBIO
                    //Tablero Intercambiado = new Tablero(++ID);  //#9
                    //Juego.IntercambiarTorres(Intercambiado);
                    ////Intercambiado.IntercambiarTorres();
                    //Solucion SolIntercambiado = new Solucion(Intercambiado.CopiaLista(Intercambiado.ListaPosicionadas_), Intercambiado.Type);
                    //if (!Solutions.Contains(SolIntercambiado))
                    //    Solutions.Add(SolIntercambiado);

                    ////ListaSoluciones.Add(CopiaLista(Intercambiado.ListaPosicionadas_));
                    //#region ROTADO TORRE
                    ////INTERCAMBIO ROTADO 1 (90)
                    //Tablero IntercambioRotado1 = new Tablero(Intercambiado, ++ID); //#10
                    //IntercambioRotado1.Rotar90();
                    //Solucion SolIntercambiadoRotado1 = new Solucion(IntercambioRotado1.CopiaLista(IntercambioRotado1.ListaPosicionadas_), IntercambioRotado1.Type);
                    //if (!Solutions.Contains(SolIntercambiadoRotado1))
                    //    Solutions.Add(SolIntercambiadoRotado1);

                    ////ListaSoluciones.Add(CopiaLista(IntercambioRotado1.ListaPosicionadas_));

                    ////INTERCAMBIO ROTADO (180)
                    //Tablero IntercambioRotado2 = new Tablero(IntercambioRotado1, ++ID); //#11
                    //IntercambioRotado2.Rotar90();
                    //Solucion SolIntercambiadoRotado2 = new Solucion(IntercambioRotado2.CopiaLista(IntercambioRotado2.ListaPosicionadas_), IntercambioRotado2.Type);
                    //if (!Solutions.Contains(SolIntercambiadoRotado2))
                    //    Solutions.Add(SolIntercambiadoRotado2);

                    ////ListaSoluciones.Add(CopiaLista(IntercambioRotado2.ListaPosicionadas_));

                    ////INTERCAMBIO ROTADO (270)
                    //Tablero IntercambioRotado3 = new Tablero(IntercambioRotado2, ++ID); //#12
                    //IntercambioRotado3.Rotar90();
                    //Solucion SolIntercambiadoRotado3 = new Solucion(IntercambioRotado3.CopiaLista(IntercambioRotado3.ListaPosicionadas_), IntercambioRotado3.Type);
                    //if (!Solutions.Contains(SolIntercambiadoRotado3))
                    //    Solutions.Add(SolIntercambiadoRotado3);
                    #endregion

                    #endregion

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

            //for (int i = 0; i < ListaSoluciones.Count; ++i)
            //{
            //    ListaSoluciones[i].ImprimirOutput();
            //}

            return Solutions;

        }

        /*
         * Steps para el Form:
         * Main() -> Cartula
         * Cuando se precione le boton generar, hay que correr el programa
         * Se tiene que abrir un form con un boton de next con las soluciones
         */

      

    }
}