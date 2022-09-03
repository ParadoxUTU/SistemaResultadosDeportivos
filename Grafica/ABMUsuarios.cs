using SistemaResultadosDeportivos.Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Logica;
using System.Drawing;

namespace SistemaResultadosDeportivos
{
    public partial class ABMUsuarios : Form
    {
        private LogicaUsuarios lgu;
        int var = 0;

        public ABMUsuarios()
        {
            InitializeComponent();
            lgu = new LogicaUsuarios();
            this.Dock = DockStyle.Fill;
            listarUsers();
        }

        private void listarUsers()
        {
            flpUsuarios.Controls.Clear();
            List<Usuario> lista = lgu.devolverUsuarios();
            if (lista != null)
            {
                int i = 0;
                int tamano = flpUsuarios.Width - 5;

                foreach (Usuario us in lista)
                {
                    String tamanoSt = "Mail: " + us.correo;
                    String tamanoSt2 = "Username: " + us.nombre;
                    if (tamanoSt.Length > tamano)
                    {
                        tamano = tamanoSt.Length;
                    }
                    else if (tamanoSt2.Length > tamano) 
                    {
                        tamano = tamanoSt2.Length;
                    }
                }

                foreach (Usuario us in lista)
                {
                    Label lblBoton = new Label();
                    Label lblBoton2 = new Label();
                    Label lblBoton3 = new Label();
                    Panel pnlPerfil = new Panel();
                    Button btnUsuario = new Button();
                    String textMail = "Mail: " + us.correo;
                    String textUser = "Username: " + us.nombre;
                    String textRol = "";
                    if (us.rol == 0)
                    {
                        textRol = "Rol: User";
                    }
                    else
                    {
                        textRol = "Rol: Admin";
                    }
                    propiedadesBoton(btnUsuario, i, tamano);
                    propiedadesLabel(lblBoton, textMail, btnUsuario, 8);
                    propiedadesLabel(lblBoton2, textUser, btnUsuario, 39);
                    propiedadesLabel(lblBoton3, textRol, btnUsuario, 70);
                    propiedadesPanel(pnlPerfil);
                    btnUsuario.Controls.Add(pnlPerfil);
                    btnUsuario.Controls.Add(lblBoton);
                    btnUsuario.Controls.Add(lblBoton2);
                    btnUsuario.Controls.Add(lblBoton3);
                    flpUsuarios.Controls.Add(btnUsuario);
                    btnUsuario.Click += new EventHandler(btnUsuario_Click);
                    i++;
                }
            }
        }

        private void propiedadesBoton(Button btn, int i, int t)
        {
            btn.Height = 92;
            btn.Tag = i;
            btn.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            btn.FlatStyle = FlatStyle.Flat;
            if (t == (flpUsuarios.Width - 5))
            {
                btn.Width = t;
            }
            else
            {
                btn.Width = t * 10;
            }
        }

        private void propiedadesLabel(Label lbl, String s, Button btn, int l)
        {
            lbl.Text = s;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.White;
            lbl.Width = s.Length*10;
            lbl.Location = new System.Drawing.Point(110, l);
        }

        private void propiedadesPanel(Panel pnl)
        {
            pnl.Width = 92;
            pnl.Height = 91;
            Image imagenPerfil = Properties.Resources.perfil;
            Bitmap bitmapPerfil = new Bitmap(imagenPerfil, pnl.Width, pnl.Height - 1);
            pnl.BackgroundImage = bitmapPerfil;
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Button btnUsuario = sender as Button;
            int i = (Int32)btnUsuario.Tag;
            var = i;
            new SubFrmModificarUsuario(this).Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String correo = txtBuscar.Text;
            String c = ""; 
            String n = ""; 
            int r = 0;
            int i = 0;
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = new Usuario(c, n, r);
            bool bandera = true;
            if (lista != null)
            {
                foreach (Usuario us in lista) 
                { 
                    if (us.correo == correo) 
                    {
                        r = 1;
                        i = lista.IndexOf(us);
                        user = us;
                    }
                    else if (correo == "")
                    {
                        r = 1;
                        bandera = false;    
                    }
                }
                if (bandera && r == 1)
                {
                    flpUsuarios.Controls.Clear();
                    int tamano = flpUsuarios.Width - 5;
                    Label lblBoton = new Label();
                    Label lblBoton2 = new Label();
                    Label lblBoton3 = new Label();
                    Panel pnlPerfil = new Panel();
                    Button btnUsuario = new Button();
                    String textMail = "Mail: " + user.correo;
                    String textUser = "Username: " + user.nombre;
                    String textRol = "";
                    if (textMail.Length > tamano)
                    {
                        tamano = textMail.Length;
                    }
                    else if (textUser.Length > tamano)
                    {
                        tamano = textUser.Length;
                    }
                    if (user.rol == 0)
                    {
                        textRol = "Rol: User";
                    }
                    else
                    {
                        textRol = "Rol: Admin";
                    }
                    propiedadesPanel(pnlPerfil);
                    propiedadesBoton(btnUsuario, i, tamano);
                    propiedadesLabel(lblBoton, textMail, btnUsuario, 8);
                    propiedadesLabel(lblBoton2, textUser, btnUsuario, 39);
                    propiedadesLabel(lblBoton3, textRol, btnUsuario, 70);
                    btnUsuario.Controls.Add(pnlPerfil);
                    btnUsuario.Controls.Add(lblBoton);
                    btnUsuario.Controls.Add(lblBoton2);
                    btnUsuario.Controls.Add(lblBoton3);
                    flpUsuarios.Controls.Add(btnUsuario);
                    btnUsuario.Click += new EventHandler(btnUsuario_Click);
                }
                else if (bandera == false && r == 1)
                {
                    listarUsers();
                }
                else if (bandera && r == 0)
                {
                    MessageBox.Show("No se encontraron coincidencias");
                    listarUsers();
                }
                restablecerTextos();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
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
                        listarUsers();
                        restablecerTextos();
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
            restablecerTextos();
        }

        public void eliminarUsuario()
        {
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = lista[var];
            String correo = user.correo;
            lgu.bajaUsuario(correo);
            listarUsers();
        }

        public bool confirmarModificacion(String nombre, int rol)
        {
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = lista[var];
            String correo = user.correo;
            bool exito;
            if (lgu.modificarUsuario(correo, nombre, rol))
            {
                listarUsers();
                exito = true;
            }
            else
            {
                exito = false;
            }
            return exito;
        }

        public String obtenerUsuario()
        {
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = lista[var];
            String username = user.nombre;
            return username;
        }

        public int obtenerRol()
        {
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = lista[var];
            int rol = user.rol;
            return rol;
        }

        public bool esMiembro()
        {
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = lista[var];
            bool esMiembro = lgu.esMiembro(user.correo);
            return esMiembro;
        }

        public void agregarMiembro()
        {
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = lista[var];
            lgu.agregarMiembro(user.correo);
        }

        public void eliminarMiembro()
        {
            List<Usuario> lista = lgu.devolverUsuarios();
            Usuario user = lista[var];
            lgu.eliminarMiembro(user.correo);
        }

        private void restablecerTextos()
        {
            txtCorreo.Text = null;
            txtContrasena.Text = null;
            cbxRol.SelectedItem = null;
            txtNombre.Text = null;
            txtBuscar.Text = "Escriba el correo electronico del usuario que desea consultar";
        }

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscar.Text = null;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlBuscar.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlLupa.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            flpUsuarios.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
