
namespace LP2_TP2021___Guarnieri___Velloso
{
    partial class Soluciones
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dta_tablero = new System.Windows.Forms.DataGridView();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dta_tablero)).BeginInit();
            this.SuspendLayout();
            // 
            // dta_tablero
            // 
            this.dta_tablero.AllowUserToAddRows = false;
            this.dta_tablero.AllowUserToDeleteRows = false;
            this.dta_tablero.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dta_tablero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dta_tablero.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dta_tablero.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dta_tablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dta_tablero.Cursor = System.Windows.Forms.Cursors.No;
            this.dta_tablero.EnableHeadersVisualStyles = false;
            this.dta_tablero.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dta_tablero.Location = new System.Drawing.Point(189, 12);
            this.dta_tablero.MultiSelect = false;
            this.dta_tablero.Name = "dta_tablero";
            this.dta_tablero.ReadOnly = true;
            this.dta_tablero.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dta_tablero.RowHeadersVisible = false;
            this.dta_tablero.RowTemplate.Height = 25;
            this.dta_tablero.ShowCellErrors = false;
            this.dta_tablero.ShowCellToolTips = false;
            this.dta_tablero.ShowEditingIcon = false;
            this.dta_tablero.ShowRowErrors = false;
            this.dta_tablero.Size = new System.Drawing.Size(425, 426);
            this.dta_tablero.TabIndex = 0;
            // 
            // btn_next
            // 
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Location = new System.Drawing.Point(667, 216);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 1;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // btn_back
            // 
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Location = new System.Drawing.Point(52, 216);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // Soluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.dta_tablero);
            this.Name = "Soluciones";
            this.Text = "Soluciones";
            ((System.ComponentModel.ISupportInitialize)(this.dta_tablero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dta_tablero;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_back;
    }
}

