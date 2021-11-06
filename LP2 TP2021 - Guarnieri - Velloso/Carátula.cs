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

        public SortedList<uint, Ficha> Posiciones_ { get => Posiciones; set => Posiciones = value; }
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
            List<Solucion> ListaSoluciones = Programa();
            Soluciones FormSoluciones = new Soluciones(ListaSoluciones, this);

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
                //----------------------------------------------------
                for (int i = 3; i <= 4; i++)
                {
                    for (int j = 3; j <= 4; j++)
                        Cuadrado1.Add(new Casilla(i, j));
                }

                for(int k=0; k < Cuadrado1.Count; ++k)
                {
                    if (Cuadrado1[k].GetFila() - Cuadrado1[k].GetColumna() % 2 == 0)
                        Cuadrado1[k].Colour = eColor.NEGRO;
                }

                //----------------------------------------------------
                for (int j = 2; j <= 5; j++)
                {
                    Cuadrado2.Add(new Casilla(2, j));
                    Cuadrado2.Add(new Casilla(5, j));
                }


                for (int i = 3; i < 5; i++)
                {
                    Cuadrado2.Add(new Casilla(i, 2));
                    Cuadrado2.Add(new Casilla(i, 5));
                }

                for (int k = 0; k < Cuadrado2.Count; ++k)
                {
                    if (Cuadrado2[k].GetFila() - Cuadrado2[k].GetColumna() % 2 == 0)
                        Cuadrado2[k].Colour = eColor.NEGRO;
                }
                //----------------------------------------------------
                for (int i = 1; i <= 6; i++)
                {
                    Cuadrado3.Add(new Casilla(1, i));
                    Cuadrado3.Add(new Casilla(6, i));
                }

                for (int i = 2; i < 6; i++)
                {
                    Cuadrado3.Add(new Casilla(i, 1));
                    Cuadrado3.Add(new Casilla(i, 6));
                }

                for (int k = 0; k < Cuadrado3.Count; ++k)
                {
                    if (Cuadrado3[k].GetFila() - Cuadrado3[k].GetColumna() % 2 == 0)
                        Cuadrado3[k].Colour = eColor.NEGRO;
                }
                //----------------------------------------------------
                for (int i = 0; i < Global.N_; i++)
                {
                    Cuadrado4.Add(new Casilla(0, i));
                    Cuadrado4.Add(new Casilla(7, i));
                }

                for (int i = 1; i < 7; i++)
                {
                    Cuadrado4.Add(new Casilla(i, 0));
                    Cuadrado4.Add(new Casilla(i, 7));
                }

                for (int k = 0; k < Cuadrado4.Count; ++k)
                {
                    if (Cuadrado4[k].GetFila() - Cuadrado4[k].GetColumna() % 2 == 0)
                        Cuadrado4[k].Colour = eColor.NEGRO;
                }
                //----------------------------------------------------

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
                    Juego.ImprimirOutput();

                   // Juego.ListaPosicionadas_[0].Atacar(Juego, Juego.Matriz[1, 4]); //No me deja hacer esto :( 
                   //Quería probar porque quiero ver cuándo es que se pone todo fatal.


                    Juego.VerificarSolucion();

                    #region ROTADO DE ORIGINAL

                    //TABLERO ROTADO 1 (90°) 
                    Tablero Rotado1 = new Tablero(Juego, ++ID); //#2
                    Rotado1.Rotar90();
                    Solucion SolRotado1 = new Solucion(Rotado1.CopiaLista(Rotado1.ListaPosicionadas_), Rotado1.Type);
                    if (!Solutions.Contains(SolRotado1))
                        Solutions.Add(SolRotado1);
                    Rotado1.ImprimirOutput();

                    //TABLERO ROTADO 2 (180°)
                    Tablero Rotado2 = new Tablero(Rotado1, ++ID); //#3
                    Rotado2.Rotar90();
                    Solucion SolRotado2 = new Solucion(Rotado2.CopiaLista(Rotado2.ListaPosicionadas_), Rotado2.Type);
                    if (!Solutions.Contains(SolRotado2))
                        Solutions.Add(SolRotado2);

                    //TABLERO ROTADO 3 (270°)
                    Tablero Rotado3 = new Tablero(Rotado2, ++ID); //#4
                    Rotado3.Rotar90();
                    Solucion SolRotado3 = new Solucion(Rotado3.CopiaLista(Rotado3.ListaPosicionadas_), Rotado3.Type);
                    if (!Solutions.Contains(SolRotado3))
                        Solutions.Add(SolRotado3);

                    #endregion

                    #region ESPEJADO ORIGINAL
                    //ESPEJADO 1
                    Tablero Espejado = new Tablero(++ID); //#5
                    Juego.Espejar(Espejado);
                    Solucion SolEspejado = new Solucion(Espejado.CopiaLista(Espejado.ListaPosicionadas_), Espejado.Type);
                    if (!Solutions.Contains(SolEspejado))
                        Solutions.Add(SolEspejado);

                    //ESPEJADO ROTADO 1 (90)
                    Tablero EspejadoRotado1 = new Tablero(Espejado, ++ID); //#6
                    EspejadoRotado1.Rotar90();
                    Solucion SolEspejadoRotado1 = new Solucion(EspejadoRotado1.CopiaLista(EspejadoRotado1.ListaPosicionadas_), EspejadoRotado1.Type);
                    if (!Solutions.Contains(SolEspejadoRotado1))
                        Solutions.Add(SolEspejadoRotado1);

                    //ESPEJADO ROTADO 2 (180)
                    Tablero EspejadoRotado2 = new Tablero(EspejadoRotado1, ++ID); //#7
                    EspejadoRotado2.Rotar90();
                    Solucion SolEspejadoRotado2 = new Solucion(EspejadoRotado2.CopiaLista(EspejadoRotado2.ListaPosicionadas_), EspejadoRotado2.Type);
                    if (!Solutions.Contains(SolEspejadoRotado2))
                        Solutions.Add(SolEspejadoRotado2);

                    //ESPEJADO ROTADO 3 (270)
                    Tablero EspejadoRotado3 = new Tablero(EspejadoRotado2, ++ID); //#8
                    EspejadoRotado3.Rotar90();
                    Solucion SolEspejadoRotado3 = new Solucion(EspejadoRotado3.CopiaLista(EspejadoRotado3.ListaPosicionadas_), EspejadoRotado3.Type);
                    if (!Solutions.Contains(SolEspejadoRotado3))
                        Solutions.Add(SolEspejadoRotado3);

                    #endregion

                    #region INTERCAMBIO TORRES
                    ////INTERCAMBIO
                    Tablero Intercambiado = new Tablero(++ID);  //#9
                    Juego.IntercambiarTorres(Intercambiado);
                    //Intercambiado.IntercambiarTorres();
                    Solucion SolIntercambiado = new Solucion(Intercambiado.CopiaLista(Intercambiado.ListaPosicionadas_), Intercambiado.Type);
                    if (!Solutions.Contains(SolIntercambiado))
                        Solutions.Add(SolIntercambiado);

                    #endregion

                }
                #endregion

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
            return Solutions;
        }
    }
}
#endregion