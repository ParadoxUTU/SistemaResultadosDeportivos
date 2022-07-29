using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaResultadosDeportivos
{
    public partial class SubFrmModificarUsuario : Form
    {
        ABMUsuarios usuarios;

        public SubFrmModificarUsuario(ABMUsuarios u)
        {
            InitializeComponent();
            usuarios = u;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Recoge los datos de modificacion, y los envía al frame original para su confirmacion
            String nombre = txtUsername.Text;
            int rol;
            if(cbxRol.SelectedItem != null)
            {
                if (cbxRol.SelectedItem.ToString().Equals("User"))
                {
                    rol = 0;
                }
                else
                {
                    rol = 1;
                }
            }
            else
            {
                rol = -1;
            }
            
            if (!nombre.Equals("") && rol != -1)
            {
                this.Dispose();
                if (!usuarios.confirmarModificacion(nombre, rol))
                {
                    new SubFrmModificarUsuario(usuarios).Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Datos invalidos.");
            }
        }

        private void SubFrmModificarUsuario_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
