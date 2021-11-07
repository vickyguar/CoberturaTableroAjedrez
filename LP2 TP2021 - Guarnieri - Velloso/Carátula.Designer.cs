
namespace LP2_TP2021___Guarnieri___Velloso
{
    partial class Carátula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Carátula));
            this.btn_generar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.num_cant = new System.Windows.Forms.NumericUpDown();
            this.lbl_soluciones = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cant)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_generar
            // 
            this.btn_generar.BackColor = System.Drawing.Color.Black;
            this.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_generar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_generar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_generar.Location = new System.Drawing.Point(275, 489);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(230, 33);
            this.btn_generar.TabIndex = 6;
            this.btn_generar.Text = "Generar";
            this.btn_generar.UseVisualStyleBackColor = false;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::LP2_TP2021___Guarnieri___Velloso.Properties.Resources.Caratula;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 541);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // num_cant
            // 
            this.num_cant.Location = new System.Drawing.Point(414, 460);
            this.num_cant.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_cant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_cant.Name = "num_cant";
            this.num_cant.Size = new System.Drawing.Size(91, 23);
            this.num_cant.TabIndex = 16;
            this.num_cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_cant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_soluciones
            // 
            this.lbl_soluciones.AutoSize = true;
            this.lbl_soluciones.BackColor = System.Drawing.Color.Transparent;
            this.lbl_soluciones.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_soluciones.Location = new System.Drawing.Point(276, 464);
            this.lbl_soluciones.Name = "lbl_soluciones";
            this.lbl_soluciones.Size = new System.Drawing.Size(132, 15);
            this.lbl_soluciones.TabIndex = 17;
            this.lbl_soluciones.Text = "Cantidad de soluciones:";
            // 
            // Carátula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.lbl_soluciones);
            this.Controls.Add(this.num_cant);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Carátula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carátula";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown num_cant;
        private System.Windows.Forms.Label lbl_soluciones;
    }
}