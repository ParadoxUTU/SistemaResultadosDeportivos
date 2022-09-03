namespace SistemaResultadosDeportivos
{
    partial class FrmVerEncuentroApp
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
            this.flpIncidencias = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMinuto = new System.Windows.Forms.Label();
            this.lblPuntaje2 = new System.Windows.Forms.Label();
            this.lblPuntaje1 = new System.Windows.Forms.Label();
            this.lblEquipo2 = new System.Windows.Forms.Label();
            this.lblEquipo1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpIncidencias
            // 
            this.flpIncidencias.AutoScroll = true;
            this.flpIncidencias.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpIncidencias.Location = new System.Drawing.Point(23, 99);
            this.flpIncidencias.Name = "flpIncidencias";
            this.flpIncidencias.Size = new System.Drawing.Size(964, 408);
            this.flpIncidencias.TabIndex = 6;
            // 
            // lblMinuto
            // 
            this.lblMinuto.AutoSize = true;
            this.lblMinuto.BackColor = System.Drawing.Color.Transparent;
            this.lblMinuto.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinuto.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblMinuto.Location = new System.Drawing.Point(487, 37);
            this.lblMinuto.Name = "lblMinuto";
            this.lblMinuto.Size = new System.Drawing.Size(29, 32);
            this.lblMinuto.TabIndex = 32;
            this.lblMinuto.Text = "0";
            // 
            // lblPuntaje2
            // 
            this.lblPuntaje2.AutoSize = true;
            this.lblPuntaje2.BackColor = System.Drawing.Color.Transparent;
            this.lblPuntaje2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntaje2.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblPuntaje2.Location = new System.Drawing.Point(759, 37);
            this.lblPuntaje2.Name = "lblPuntaje2";
            this.lblPuntaje2.Size = new System.Drawing.Size(29, 32);
            this.lblPuntaje2.TabIndex = 31;
            this.lblPuntaje2.Text = "0";
            // 
            // lblPuntaje1
            // 
            this.lblPuntaje1.AutoSize = true;
            this.lblPuntaje1.BackColor = System.Drawing.Color.Transparent;
            this.lblPuntaje1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntaje1.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblPuntaje1.Location = new System.Drawing.Point(213, 37);
            this.lblPuntaje1.Name = "lblPuntaje1";
            this.lblPuntaje1.Size = new System.Drawing.Size(29, 32);
            this.lblPuntaje1.TabIndex = 30;
            this.lblPuntaje1.Text = "0";
            // 
            // lblEquipo2
            // 
            this.lblEquipo2.AutoSize = true;
            this.lblEquipo2.BackColor = System.Drawing.Color.Transparent;
            this.lblEquipo2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipo2.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblEquipo2.Location = new System.Drawing.Point(856, 37);
            this.lblEquipo2.Name = "lblEquipo2";
            this.lblEquipo2.Size = new System.Drawing.Size(131, 32);
            this.lblEquipo2.TabIndex = 29;
            this.lblEquipo2.Text = "Equipo 2";
            // 
            // lblEquipo1
            // 
            this.lblEquipo1.AutoSize = true;
            this.lblEquipo1.BackColor = System.Drawing.Color.Transparent;
            this.lblEquipo1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipo1.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblEquipo1.Location = new System.Drawing.Point(17, 37);
            this.lblEquipo1.Name = "lblEquipo1";
            this.lblEquipo1.Size = new System.Drawing.Size(131, 32);
            this.lblEquipo1.TabIndex = 28;
            this.lblEquipo1.Text = "Equipo 1";
            // 
            // FrmVerEncuentroApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SistemaResultadosDeportivos.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(1007, 532);
            this.Controls.Add(this.lblMinuto);
            this.Controls.Add(this.lblPuntaje2);
            this.Controls.Add(this.lblPuntaje1);
            this.Controls.Add(this.lblEquipo2);
            this.Controls.Add(this.lblEquipo1);
            this.Controls.Add(this.flpIncidencias);
            this.Name = "FrmVerEncuentroApp";
            this.Text = "FrmVerEncuentroApp";
            this.Load += new System.EventHandler(this.FrmVerEncuentroApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpIncidencias;
        public System.Windows.Forms.Label lblMinuto;
        public System.Windows.Forms.Label lblPuntaje2;
        public System.Windows.Forms.Label lblPuntaje1;
        private System.Windows.Forms.Label lblEquipo2;
        private System.Windows.Forms.Label lblEquipo1;
    }
}