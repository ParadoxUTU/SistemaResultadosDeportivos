using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Logica;

namespace SistemaResultadosDeportivos
{
    public partial class FrmBackoffice : Form
    {
        private LogicaUsuarios lgu;

        public FrmBackoffice()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.lgu = new LogicaUsuarios();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cambia la ventana a la de administracion de usuarios
            if (this.MdiChildren.Count() > 0)
            {
                this.MdiChildren[0].Dispose();
            }
            ABMUsuarios usuarios = new ABMUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }

        private void publicidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cambia la ventana a la de administracion de publicidades
            if (this.MdiChildren.Count() > 0)
            {
                this.MdiChildren[0].Dispose();
            }
            ABMPublicidad publicidad = new ABMPublicidad();
            publicidad.MdiParent = this;
            publicidad.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Logout
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estás seguro?", "Confirmar deslogueo", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                this.Dispose();
                lgu.volverAutenticador();
                new FrmLogin().Visible = true;
            }
        }

        private void FrmBackoffice_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void FrmBackoffice_Load(object sender, EventArgs e)
        {
            ABMUsuarios usuarios = new ABMUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }
    }
}
