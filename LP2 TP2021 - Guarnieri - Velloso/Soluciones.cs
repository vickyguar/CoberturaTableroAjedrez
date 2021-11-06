using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LP2_TP2021___Guarnieri___Velloso
{
    public partial class Soluciones : Form
    {
        
        List<Solucion> ListaSoluciones;
        List<Solucion> ListaFiltrada;

        Tablero Plantilla;
        Carátula Llamado;

        #region CONSTRUCTOR

        public Soluciones(List<Solucion> ListaSoluciones_, Carátula _Llamado)
        {
            InitializeComponent();
            this.Icon = new Icon("Icono.ico");

            Global.timeMeasure.Stop();

            ListaSoluciones = ListaSoluciones_;
            Llamado = _Llamado;
            ListaFiltrada = Fatales(ListaSoluciones); //filtramos las soluciones obtenidas
            Plantilla = new Tablero(0);

            //visibilidad de los botones
            btn_next.Visible = true;
            btn_back.Visible = false;
            btn_exit.Visible = true;
            btn_time.Visible = true;
                
            rbtn_fatales.Checked = false;
            rbtn_leves.Checked = true;
            Barra.Maximum = ListaSoluciones.Count;
            Dtg.ClearSelection();

            ImprimirSiguiente(ListaSoluciones); //se imprime la primera solución
        }

        #endregion

       

        #region BOTONES
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Barra.Value > 0) //si me movi para adelante
                btn_back.Visible = true; //habilito el botón de back

            if(!rbtn_fatales.Checked)
            {
                rbtn_fatales.Checked = false;
                rbtn_leves.Checked = true;
                ImprimirSiguiente(ListaSoluciones);
            }
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            if (Barra.Value == 2) //si soy la primera solucion
                btn_back.Visible = false; //no puedo ir para atrás

            if (Barra.Value < ListaSoluciones.Count + 1) //si no llegue al final
            {
                //btn_fatales.Visible = false; //no muestro el botón de fatales
                btn_next.Visible = true;
            }

            ImprimirAnterior();
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Llamado.Close();
        }
        #endregion

        #region IMPRIMIR DTG

        private void ImprimirSiguiente(List<Solucion> Lista)
        {
            if (Barra.Value < Lista.Count) // Barra.Value esta funcionando como iterador
            {
                btn_next.Visible = true;

                if (Barra.Value == 0)
                    btn_back.Visible = false;

                //Limpiar tablero
                if (Barra.Value != 0)
                {
                    Dtg.Rows.Clear();
                    Dtg.Refresh();
                }

                //Asigno la cantidad 
                Dtg.ColumnCount = Global.N_;
                Dtg.RowCount = Global.N_;

                for (int i = 0; i < Global.N_; ++i)
                {
                    for (int j = 0; j < Global.N_; ++j)
                    {
                        DataGridViewImageCell iCell = new DataGridViewImageCell();
                        iCell.Value = (Bitmap)Image.FromFile("Transparente.png");

                        Dtg[i, j] = iCell;

                        if (Plantilla.Matriz[i, j].Colour == eColor.NEGRO) //Si la casilla deberia ser negra
                            Dtg.Rows[j].Cells[i].Style.BackColor = Color.Gray; //Le cambio el color al Dtg usando "Style.BackColor"
                    }
                }


                SortedList<uint,Ficha> Piezas = ListaSoluciones[Barra.Value].Posiciones_;
                for(uint i = 0; i<Piezas.Count; i++)
                {
                    DataGridViewImageCell iCell = new DataGridViewImageCell();
                    iCell.Value = (Bitmap)Piezas[i].Imagen;

                    Dtg[Piezas[i].Fila, Piezas[i].Columna] = iCell;

                    if (Plantilla.Matriz[Piezas[i].Fila, Piezas[i].Columna].Colour == eColor.NEGRO) //Si la casilla deberia ser negra
                        Dtg.Rows[Piezas[i].Columna].Cells[Piezas[i].Fila].Style.BackColor = Color.Gray; //Le cambio el color al Dtg usando "Style.BackColor"
                }

                Barra.Increment(1);

                if (Barra.Value > 1) //si me movi para adelante
                    btn_back.Visible = true; //habilito el botón de back

                if (Barra.Value == Lista.Count) //si ya se imprimieron todas las soluciones
                {
                    btn_next.Visible = false;
                }
            }
            return;
        }

        private void ImprimirAnterior()
        {
            if (Barra.Value > 1)
            {
                Barra.Value = Barra.Value - 2;
                //Limpiar tablero
                Dtg.Rows.Clear();
                Dtg.Refresh();

                Dtg.ColumnCount = 8;
                Dtg.RowCount = 8;


                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 8; ++j)
                    {
                        DataGridViewImageCell iCell = new DataGridViewImageCell();
                        iCell.Value = (Bitmap)Image.FromFile("Transparente.png");

                        Dtg[i, j] = iCell;

                        if (Plantilla.Matriz[i, j].Colour == eColor.NEGRO) //Si la casilla deberia ser negra
                            Dtg.Rows[j].Cells[i].Style.BackColor = Color.Gray; //Le cambio el color al Dtg usando "Style.BackColor"
                    }
                }

            }

            SortedList<uint, Ficha> Piezas = ListaSoluciones[Barra.Value].Posiciones_;
            for (uint i = 0; i < Piezas.Count; i++)
            {
                DataGridViewImageCell iCell = new DataGridViewImageCell();
                iCell.Value = (Bitmap)Piezas[i].Imagen;

                Dtg[Piezas[i].Fila, Piezas[i].Columna] = iCell;

                if (Plantilla.Matriz[Piezas[i].Fila, Piezas[i].Columna].Colour == eColor.NEGRO) //Si la casilla deberia ser negra
                    Dtg.Rows[Piezas[i].Columna].Cells[Piezas[i].Fila].Style.BackColor = Color.Gray; //Le cambio el color al Dtg usando "Style.BackColor"
            }

            Barra.Increment(1);
            return;
        }

        #endregion

        static List<Solucion> Fatales(List<Solucion> ListaSoluciones)
        {
            List<Solucion> ListaFatales = new List<Solucion>();

            #region FILTRAR FATALES

            foreach (Solucion Solution in ListaSoluciones)
                if (Solution.Tipo_ == TipoSolucion.FATAL)
                    ListaFatales.Add(Solution);
            #endregion

            return ListaFatales;
        }

        private void rbtn_fatales_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn_fatales.Checked)
            {
                Dtg.Rows.Clear();
                Dtg.Refresh();

                Barra.Value = 0;

                if (ListaFiltrada.Count == 0)
                {
                    if (MessageBox.Show("No se encontró ningun tablero fatal", "Exit mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        rbtn_fatales.Checked = false;
                        rbtn_leves.Checked = true;
                        ImprimirSiguiente(ListaSoluciones);
                    }
                }
                else
                {
                    ImprimirSiguiente(ListaFiltrada);
                }
            }
        }

        private void btn_time_Click(object sender, EventArgs e)
        {


            string output_omega = "\nDescripción cuantitativa Ω(n):\n" + "\nΩ(n) = n\n" + "\nEl tiempo de ejecución del algoritmo depende tanto del tamaño de la entrada (la cantidad de tebleros solicitados por el usuario) " +
                "como de algunas caracteristicas de la entrada, como por ejemplo si el tablero queda completamente atacado. Esto se debe a que el posicionamiento de las fichas en el tablero" +
                "se hace de forma aleatoria en, con lo cual dependemos de esta aleatoriedad para definir si es solución o no. Al mismo tiempo, con un tablero que encuentre, visto que lo espejamos, " +
                "lo rotamos e intercambiamos las torres, obtenemos 9 soluciones distintas. Con lo cual, si se quieren generar 18 soluciones, el algorimo solo tendra que encontrar 2 soluciones y luego aplicarle las trasnformaciones." +
                "Es por esto que la cota inferior de nuestro algoritmo es Ω(n) = n, dejando de lado las constantes a (gradiente) y b (ordenada al origen) si n toma valores muy grandes";


            string output = "\nDescripción cualitativa O(n):\n" +
                "• Resulta dificil determinar la cota superior del tiempo de ejecución de nuestro programa, ya que tiene muchas instancias donde se juega con la aleatoriedad.\n" +
                "• Se le ha dado mucha libertad a la computadora, con lo cual, en un muy mal caso, puede llegar a ser imposible que encuentre una solución.\n" +
                "• Sin embargo, hemos calculado un promedio de 30 realizaciones, para encontrar 10 tableros de 62 ± 19 segundos\n";

            MessageBox.Show("TIEMPO: " + Global.timeMeasure.Elapsed.Minutes.ToString() + ":" 
                + Global.timeMeasure.Elapsed.Seconds.ToString() + ":" 
                + Global.timeMeasure.Elapsed.Milliseconds.ToString() + output_omega + output, 
                "Tiempo de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

