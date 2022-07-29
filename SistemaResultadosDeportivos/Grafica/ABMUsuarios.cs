using SistemaResultadosDeportivos.Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Logica;

namespace SistemaResultadosDeportivos
{
    public partial class ABMUsuarios : Form
    {
        private LogicaUsuarios lgu;

        public ABMUsuarios()
        {
            InitializeComponent();
            lgu = new LogicaUsuarios();
            this.Dock = DockStyle.Fill;
            listarUsuarios();
        }

        private void listarUsuarios()
        {
            //Despliega todos los usuarios como entradas en el listview
            lviewUsuarios.Items.Clear();
            List<Usuario> lista = lgu.devolverUsuarios();
            if (lista != null)
            {
                foreach (Usuario us in lista)
                {
                    ListViewItem item = new ListViewItem(us.correo);
                    item.SubItems.Add(us.nombre);
                    if(us.rol == 0)
                    {
                        item.SubItems.Add("User");
                    }
                    else
                    {
                        item.SubItems.Add("Admin");
                    }
                    lviewUsuarios.Items.Add(item);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*Agrega un usuario a la BD con los datos ingresados en los textboxes, luego
            lo muestra en el listview*/
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;
            int rol;
            string nombre = txtNombre.Text;
            try
            {
                if (cbxRol.SelectedItem != null)
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
                
                if (!correo.Equals("") && !contrasena.Equals("") && !nombre.Equals("") && rol != -1)
                {
                    if (lgu.registrarUsuario(correo, nombre, contrasena, rol))
                    {
                        listarUsuarios();
                        limpiarTextos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido agregar el usuario");
                    }
                }
                else
                {
                    MessageBox.Show("No se ha podido agregar el usuario");
                }
            }
            catch
            {
                MessageBox.Show("No se ha podido agregar el usuario");
            }
            limpiarTextos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Elimina un usuario si este está seleccionado en el listview
            if (lviewUsuarios.SelectedItems.Count > 0)
            {
                string correo = lviewUsuarios.SelectedItems[0].Text;
                if (lgu.bajaUsuario(correo))
                {
                    listarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar el usuario");
                }
            }
            else
            {
                MessageBox.Show("No hay usuario seleccionado.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modifica nombre y rol de un usuario seleccionado en el listview
            try
            {
                if (lviewUsuarios.SelectedItems.Count > 0)
                {
                    new SubFrmModificarUsuario(this).Visible = true;
                }
                else
                {
                    MessageBox.Show("No hay usuario seleccionado.");
                }
            }
            catch { }
        }

        public bool confirmarModificacion(String nombre, int rol)
        {
            /*Confirma la modificacion del usuario seleccionado, con los datos ingresados
            desde el subframe de modificacion*/
            String correo = lviewUsuarios.SelectedItems[0].Text;
            bool exito;
            if (lgu.modificarUsuario(correo, nombre, rol))
            {
                listarUsuarios();
                exito = true;
            }
            else
            {
                exito = false;
            }
            return exito;
        }

        private void limpiarTextos()
        {
            //Limpia todas las casillas de texto
            txtCorreo.Text = null;
            txtContrasena.Text = null;
            cbxRol.SelectedItem = null;
            txtNombre.Text = null;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
