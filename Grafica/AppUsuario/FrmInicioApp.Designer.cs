
namespace SistemaResultadosDeportivos
{
    partial class FrmInicioApp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.banner = new System.Windows.Forms.PictureBox();
            this.flpEncuentros = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
            this.SuspendLayout();
            // 
            // banner
            // 
            this.banner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.banner.Location = new System.Drawing.Point(103, 497);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(776, 139);
            this.banner.TabIndex = 1;
            this.banner.TabStop = false;
            this.banner.Click += new System.EventHandler(this.banner_Click);
            // 
            // flpEncuentros
            // 
            this.flpEncuentros.AutoScroll = true;
            this.flpEncuentros.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpEncuentros.Location = new System.Drawing.Point(52, 21);
            this.flpEncuentros.Name = "flpEncuentros";
            this.flpEncuentros.Size = new System.Drawing.Size(884, 441);
            this.flpEncuentros.TabIndex = 17;
            this.flpEncuentros.WrapContents = false;
            // 
            // FrmInicioApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SistemaResultadosDeportivos.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(979, 648);
            this.Controls.Add(this.flpEncuentros);
            this.Controls.Add(this.banner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInicioApp";
            this.Text = "App";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInicioApp_FormClosed);
            this.Load += new System.EventHandler(this.FrmInicioApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.banner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox banner;
        private System.Windows.Forms.FlowLayoutPanel flpEncuentros;
    }
}

