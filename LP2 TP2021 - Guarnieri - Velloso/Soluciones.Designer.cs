
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Dtg = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_next = new System.Windows.Forms.Button();
            this.Barra = new System.Windows.Forms.ProgressBar();
            this.btn_fatales = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_back_fatal = new System.Windows.Forms.Button();
            this.btn_next_fatal = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg
            // 
            this.Dtg.AllowUserToAddRows = false;
            this.Dtg.AllowUserToDeleteRows = false;
            this.Dtg.AllowUserToResizeColumns = false;
            this.Dtg.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Dtg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dtg.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.Dtg.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.Dtg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg.ColumnHeadersVisible = false;
            this.Dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.Dtg.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Dtg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dtg.Enabled = false;
            this.Dtg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Dtg.Location = new System.Drawing.Point(187, 119);
            this.Dtg.MultiSelect = false;
            this.Dtg.Name = "Dtg";
            this.Dtg.ReadOnly = true;
            this.Dtg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Dtg.RowHeadersVisible = false;
            this.Dtg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dtg.RowTemplate.Height = 50;
            this.Dtg.RowTemplate.ReadOnly = true;
            this.Dtg.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dtg.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.Dtg.ShowCellErrors = false;
            this.Dtg.ShowCellToolTips = false;
            this.Dtg.ShowEditingIcon = false;
            this.Dtg.ShowRowErrors = false;
            this.Dtg.Size = new System.Drawing.Size(400, 400);
            this.Dtg.TabIndex = 0;
            this.Dtg.TabStop = false;
            this.Dtg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 50F;
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 50F;
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 50F;
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 50;
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Location = new System.Drawing.Point(649, 496);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 1;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // Barra
            // 
            this.Barra.BackColor = System.Drawing.Color.DimGray;
            this.Barra.ForeColor = System.Drawing.Color.White;
            this.Barra.Location = new System.Drawing.Point(187, 62);
            this.Barra.Maximum = 10;
            this.Barra.Name = "Barra";
            this.Barra.Size = new System.Drawing.Size(400, 23);
            this.Barra.Step = 1;
            this.Barra.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Barra.TabIndex = 1;
            // 
            // btn_fatales
            // 
            this.btn_fatales.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_fatales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fatales.Location = new System.Drawing.Point(649, 409);
            this.btn_fatales.Name = "btn_fatales";
            this.btn_fatales.Size = new System.Drawing.Size(75, 23);
            this.btn_fatales.TabIndex = 2;
            this.btn_fatales.Text = "Filtrar";
            this.btn_fatales.UseVisualStyleBackColor = false;
            this.btn_fatales.Visible = false;
            this.btn_fatales.Click += new System.EventHandler(this.btn_fatales_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Location = new System.Drawing.Point(53, 496);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 3;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click_1);
            // 
            // btn_back_fatal
            // 
            this.btn_back_fatal.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_back_fatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back_fatal.Location = new System.Drawing.Point(53, 467);
            this.btn_back_fatal.Name = "btn_back_fatal";
            this.btn_back_fatal.Size = new System.Drawing.Size(75, 23);
            this.btn_back_fatal.TabIndex = 4;
            this.btn_back_fatal.Text = "Back";
            this.btn_back_fatal.UseVisualStyleBackColor = false;
            this.btn_back_fatal.Click += new System.EventHandler(this.btn_back_fatal_Click_1);
            // 
            // btn_next_fatal
            // 
            this.btn_next_fatal.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_next_fatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next_fatal.Location = new System.Drawing.Point(649, 467);
            this.btn_next_fatal.Name = "btn_next_fatal";
            this.btn_next_fatal.Size = new System.Drawing.Size(75, 23);
            this.btn_next_fatal.TabIndex = 5;
            this.btn_next_fatal.Text = "Next";
            this.btn_next_fatal.UseVisualStyleBackColor = false;
            this.btn_next_fatal.Click += new System.EventHandler(this.btn_next_fatal_Click_1);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Location = new System.Drawing.Point(649, 438);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Visible = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click_1);
            // 
            // Soluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_next_fatal);
            this.Controls.Add(this.btn_back_fatal);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_fatales);
            this.Controls.Add(this.Barra);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.Dtg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Soluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soluciones";
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dtg;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ProgressBar Barra;
        private System.Windows.Forms.Button btn_fatales;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_back_fatal;
        private System.Windows.Forms.Button btn_next_fatal;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.DataGridViewImageColumn Column7;
        private System.Windows.Forms.DataGridViewImageColumn Column8;
    }
}

