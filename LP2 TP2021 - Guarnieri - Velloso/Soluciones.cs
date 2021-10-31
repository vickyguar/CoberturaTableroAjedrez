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
        public Soluciones(List<Tablero> ListaSoluciones_)
        {
            InitializeComponent();
            ListaSoluciones = ListaSoluciones_;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Barra.Value < ListaSoluciones.Count)
            {

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

                        if (ListaSoluciones[Barra.Value].Matriz[i, j].Fichita != null)
                            iCell.Value = (Bitmap)ListaSoluciones[Barra.Value].Matriz[i, j].Fichita.Imagen;
                        else
                            iCell.Value = (Bitmap)ListaSoluciones[Barra.Value].Matriz[i, j].Img;

                        Dtg[i, j] = iCell;

                        if (ListaSoluciones[Barra.Value].Matriz[i, j].Colour == eColor.NEGRO)
                            Dtg.Rows[j].Cells[i].Style.BackColor = Color.Black;
                    }
                }

                Barra.Increment(1);

                if (Barra.Value == 10)
                    MessageBox.Show("Ya se imprimieron 10 tableros distintos");
            }
            else
                MessageBox.Show("Se imprimieron todos los tableros");
        }
    }
}
