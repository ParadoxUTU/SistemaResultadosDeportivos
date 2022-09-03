using SistemaResultadosDeportivos.Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Logica;
using System.Drawing;

namespace SistemaResultadosDeportivos
{
    public partial class ABMJugadores : Form
    {
        LogicaDeportes lgd;
        LogicaJugadores lgj;
        int var = 0;

        public ABMJugadores()
        {
            InitializeComponent();
            lgd = new LogicaDeportes();
            lgj = new LogicaJugadores();
            listarDeportes();
            listarJugadores();
        }

        private void listarDeportes()
        {
            cbxDeportes.Items.Clear();
            List<Deporte> lista = lgd.devolverDeportes();
            if (lista.Count != 0)
            {
                foreach (Deporte d in lista)
                {
                    cbxDeportes.Items.Add(d.nombreDeporte);
                }
            }
        }

        public void listarJugadores()
        {
            flpJugadores.Controls.Clear();
            int i = 0;
            int tamano = flpJugadores.Width - 5;
            List<Jugador> lista = lgj.devolverJugadores();
            foreach (Jugador j in lista)
            {
                String tamanoSt = "Nombre: " + j.nombreJugador;
                String tamanoSt2 = "Pais: " + j.edad;
                if (tamanoSt.Length > tamano)
                {
                    tamano = tamanoSt.Length;
                }
                else if (tamanoSt2.Length > tamano)
                {
                    tamano = tamanoSt2.Length;
                }
            }

            foreach (Jugador j in lista)
            {
                String textNombre = "Nombre: " + j.nombreJugador;
                String textPais = "Pais: " + j.pais;
                String textEdad = "Edad: " + j.edad;
                asignarComponentes(textNombre, textPais, textEdad, i, tamano);
                i++;
            }
        }

        public void eliminarJugador()
        {
            List<Jugador> lista = lgj.devolverJugadores();
            Jugador jugador = lista[var];
            int idJugador = jugador.idJugador;
            lgj.eliminarJugador(idJugador);
            listarJugadores();
        }

        public void asignarComponentes(String n, String p, String e, int i, int tamano)
        {
            Label lblBoton = new Label();
            Label lblBoton2 = new Label();
            Label lblBoton3 = new Label();
            Panel pnlPerfil = new Panel();
            Button btnJugador = new Button();
            String textNombre = n;
            String textPais = p;
            propiedadesBoton(btnJugador, i, tamano);
            propiedadesLabel(lblBoton, textNombre, btnJugador, 8);
            propiedadesLabel(lblBoton2, textPais, btnJugador, 39);
            propiedadesPanel(pnlPerfil);
            btnJugador.Controls.Add(pnlPerfil);
            btnJugador.Controls.Add(lblBoton);
            btnJugador.Controls.Add(lblBoton2);
            btnJugador.Controls.Add(lblBoton3);
            flpJugadores.Controls.Add(btnJugador);
            btnJugador.Click += new EventHandler(btnJugadores_Click);
        }

        public Jugador obtenerJugador()
        {
            List<Jugador> lista = lgj.devolverJugadores();
            Jugador jugador = lista[var];
            return jugador;
        }

        public bool confirmarModificacion(String nombre, String pais, int edad, int estatura, int peso)
        {
            List<Jugador> lista = lgj.devolverJugadores();
            Jugador jugador = lista[var];
            int idJugador = jugador.idJugador;
            int idDeporte = jugador.idDeporte;
            bool exito;
            if (lgj.modificarJugador(idJugador, nombre, edad, peso, estatura, pais, idDeporte))
            {
                listarJugadores();
                exito = true;
            }
            else
            {
                exito = false;
            }
            return exito;
        }

        private void propiedadesBoton(Button btn, int i, int t)
        {
            btn.Height = 92;
            btn.Tag = i;
            btn.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            btn.FlatStyle = FlatStyle.Flat;
            if (t == (flpJugadores.Width - 5))
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
            lbl.Width = s.Length * 10;
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

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            Button btnJugador = sender as Button;
            int i = (Int32)btnJugador.Tag;
            var = i;
            new SubFrmModificarJugador(this).Visible = true;
        }

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscar.Text = null;
        }

        private void ABMJugadores_Load(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlBuscar.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlLupa.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            flpJugadores.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNombre.Text != "" && cbxDeportes.SelectedItem != null)
                {
                    string nombre = txtNombre.Text;
                    int edad = (int)numEdad.Value;
                    int peso = (int)numPeso.Value;
                    int estatura = (int)numEstatura.Value;
                    string pais = txtPais.Text;
                    Deporte deporte = lgd.devolverDeportes()[cbxDeportes.SelectedIndex];
                    int idDeporte = deporte.idDeporte;
                    if (lgj.agregarJugador(nombre, edad, peso, estatura, pais, idDeporte))
                    {
                        listarJugadores();
                    }
                    else
                    {
                        MessageBox.Show("Datos mal colocados.");
                    }
                }
            }
            catch { }
        }
    }
}
