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
        public Soluciones()
        {
            InitializeComponent();
        }

        private void btn_next_Click(object sender, EventArgs e)
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

                    if (Table.Matriz[i, j].Fichita != null)
                        iCell.Value = (Bitmap)Table.Matriz[i, j].Fichita.Img;
                    else
                        iCell.Value = (Bitmap)Table.Matriz[i, j].Img_blanco;

                    Dtg[i, j] = iCell;

                    if (Table.Matriz[i, j].Colour == eColor.NEGRO)
                        Dtg.Rows[j].Cells[i].Style.BackColor = Color.Black;
                }
            }

            Barra.Increment(1);

            if (Barra.Value == 10)
                MessageBox.Show("Ya se imprimieron 10 tableros distintos");
        }
    }
}
