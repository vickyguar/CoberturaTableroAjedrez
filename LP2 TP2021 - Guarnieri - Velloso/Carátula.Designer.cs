
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
            this.Titulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_generar = new System.Windows.Forms.Button();
            this.btn_instru = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Titulo.ForeColor = System.Drawing.Color.Black;
            this.Titulo.Location = new System.Drawing.Point(179, 20);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(447, 39);
            this.Titulo.TabIndex = 2;
            this.Titulo.Text = "Cobertura del tablero de Ajedrez";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.BurlyWood;
            this.panel3.Controls.Add(this.Titulo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 76);
            this.panel3.TabIndex = 5;
            // 
            // btn_generar
            // 
            this.btn_generar.BackColor = System.Drawing.Color.Black;
            this.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_generar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_generar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_generar.Location = new System.Drawing.Point(558, 219);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(136, 27);
            this.btn_generar.TabIndex = 6;
            this.btn_generar.Text = "Generar";
            this.btn_generar.UseVisualStyleBackColor = false;
            // 
            // btn_instru
            // 
            this.btn_instru.BackColor = System.Drawing.Color.DimGray;
            this.btn_instru.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_instru.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_instru.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_instru.Location = new System.Drawing.Point(558, 262);
            this.btn_instru.Name = "btn_instru";
            this.btn_instru.Size = new System.Drawing.Size(136, 27);
            this.btn_instru.TabIndex = 7;
            this.btn_instru.Text = "Instrucciones";
            this.btn_instru.UseVisualStyleBackColor = false;
            // 
            // Carátula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_instru);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.panel3);
            this.Name = "Carátula";
            this.Text = "Carátula";
            this.Load += new System.EventHandler(this.Carátula_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Button btn_instru;
    }
}