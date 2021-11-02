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
        List<Tablero> ListaSoluciones;
        Carátula Llamado;
        public Soluciones(List<Tablero> ListaSoluciones_, Carátula _Llamado)
        {
            InitializeComponent();
            ListaSoluciones = ListaSoluciones_;
            Llamado = _Llamado;

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Barra.Value < ListaSoluciones.Count)
            {
                btn_next.Visible = true;
                btn_fatales.Visible = false;

                //Limpiar tablero
                Dtg.Rows.Clear();
                Dtg.Refresh();

                Dtg.ColumnCount = Global.N_;
                Dtg.RowCount = Global.N_;
                for (int i = 0; i < Global.N_; ++i)
                {
                    for (int j = 0; j < Global.N_; ++j)
                    {
                        DataGridViewImageCell iCell = new DataGridViewImageCell();

                        if (ListaSoluciones[Barra.Value].Matriz[i, j].Fichita != null) // Barra.Value esta funcionando como iterador
                            iCell.Value = (Bitmap)ListaSoluciones[Barra.Value].Matriz[i, j].Fichita.Imagen;
                        else
                            iCell.Value = (Bitmap)Image.FromFile("Transparente.png");//iCell.Value = (Bitmap)ListaSoluciones[Barra.Value].Matriz[i, j].Img;

                        Dtg[i, j] = iCell;

                        if (ListaSoluciones[Barra.Value].Matriz[i, j].Colour == eColor.NEGRO) //Si la casilla deberia ser negra
                            Dtg.Rows[j].Cells[i].Style.BackColor = Color.Black; //Le cambio el color al Dtg usando "Style.BackColor"
                    }
                }

                Barra.Increment(1); //Incrementamos nuestra Progress Bar (iterador)

                if (Barra.Value == 10)
                {
                    MessageBox.Show("Ya se imprimieron 10 tableros distintos");
                    btn_next.Visible = false;
                    btn_fatales.Visible = true;
                }
            }
           

        }

        //Va con el boton de filtrar
        static List<Tablero> Fatales(List<Tablero> ListaSoluciones)
        {
            List<Tablero> ListaFatales = new List<Tablero>();

            #region FILTRAR FATALES

            foreach (Tablero Solucion in ListaSoluciones)
                if (Solucion.Type == TipoSolucion.FATAL)
                    ListaFatales.Add(Solucion);
            #endregion

            return ListaFatales;
        }

        private void btn_fatales_Click(object sender, EventArgs e)
        {
            List<Tablero> ListaFatales = Fatales(ListaSoluciones);

        }
    }
}
