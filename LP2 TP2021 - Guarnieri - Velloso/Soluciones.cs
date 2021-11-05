using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            ListaSoluciones = ListaSoluciones_;
            Llamado = _Llamado;
            ListaFiltrada = Fatales(ListaSoluciones); //filtramos las soluciones obtenidas
            Plantilla = new Tablero(0);

            //visibilidad de los botones
            btn_next.Visible = true;
            btn_back.Visible = false;

            btn_fatales.Visible = false;
            btn_next_fatal.Visible = false;
            btn_back_fatal.Visible = false;

            //TODO:Habría que encontrar la forma de ver como settear el upper bound

            ImprimirSiguiente(ListaSoluciones); //se imprime la primera solución
        }

        #endregion

        private void myDataGridView_SelectionChanged(Object sender, EventArgs e)
        {
            Dtg.ClearSelection();
        }

        #region IMPRIMIR DTG

        private void ImprimirSiguiente(List<Solucion> Lista)
        {
            if (Barra.Value < Lista.Count) // Barra.Value esta funcionando como iterador
            {
                btn_next.Visible = true;

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


                List<Ficha> Piezas = ListaSoluciones[Barra.Value].Posiciones_;
                foreach (Ficha Fichita in Piezas)
                {
                    DataGridViewImageCell iCell = new DataGridViewImageCell();
                    iCell.Value = (Bitmap)Fichita.Imagen;

                    Dtg[Fichita.Fila, Fichita.Columna] = iCell;

                    if (Plantilla.Matriz[Fichita.Fila, Fichita.Columna].Colour == eColor.NEGRO) //Si la casilla deberia ser negra
                        Dtg.Rows[Fichita.Columna].Cells[Fichita.Fila].Style.BackColor = Color.Gray; //Le cambio el color al Dtg usando "Style.BackColor"
                }

                Barra.Increment(1);

                if (Barra.Value > 0) //si me movi para adelante
                    btn_back.Visible = true; //habilito el botón de back

                if (Barra.Value == Lista.Count) //si ya se imprimieron todas las soluciones
                {
                    btn_next.Visible = false;
                    btn_fatales.Visible = true;
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

            List<Ficha> Piezas = ListaSoluciones[Barra.Value].Posiciones_;
            foreach (Ficha Fichita in Piezas)
            {
                DataGridViewImageCell iCell = new DataGridViewImageCell();
                iCell.Value = (Bitmap)Fichita.Imagen;
                Dtg[Fichita.Fila, Fichita.Columna] = iCell;

                if (Plantilla.Matriz[Fichita.Fila, Fichita.Columna].Colour == eColor.NEGRO) //Si la casilla deberia ser negra
                    Dtg.Rows[Fichita.Columna].Cells[Fichita.Fila].Style.BackColor = Color.Gray; //Le cambio el color al Dtg usando "Style.BackColor"
            }

            Barra.Increment(1);
            return;
        }

        #endregion
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Barra.Value > 0) //si me movi para adelante
                btn_back.Visible = true; //habilito el botón de back
            ImprimirSiguiente(ListaSoluciones);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Llamado.Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (Barra.Value == 2) //si soy la primera solucion
                btn_back.Visible = false; //no puedo ir para atrás

            if (Barra.Value < ListaSoluciones.Count + 1) //si no llegue al final
            {
                btn_fatales.Visible = false; //no muestro el botón de fatales
                btn_next.Visible = true;
            }

            ImprimirAnterior();
        }

        private void btn_fatales_Click(object sender, EventArgs e)
        {
            if (btn_fatales.Visible)
            {
                Barra.Value = 0;

                Dtg.Rows.Clear();
                Dtg.Refresh();
                btn_fatales.Visible = false;
                btn_back.Visible = false;

                btn_next_fatal.Visible = true;
                btn_back_fatal.Visible = false;

                if (ListaFiltrada.Count == 0)
                {
                    if (MessageBox.Show("No se encontró ningun tablero fatal", "Exit mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        this.Close();
                        Llamado.Close();
                    }
                }

                else
                    ImprimirSiguiente(ListaFiltrada);
            }
        }

        //Va con el boton de filtrar
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
        private void btn_next_fatal_Click(object sender, EventArgs e)
        {
            if (Barra.Value > 0)
                btn_back_fatal.Visible = true;

            ImprimirSiguiente(ListaFiltrada);
        }

        private void btn_back_fatal_Click(object sender, EventArgs e)
        {
            if (Barra.Value == 2)
                btn_back_fatal.Visible = false;

            if (Barra.Value < ListaFiltrada.Count + 1)
                btn_next_fatal.Visible = true;

            ImprimirAnterior();
        }
    }
}

