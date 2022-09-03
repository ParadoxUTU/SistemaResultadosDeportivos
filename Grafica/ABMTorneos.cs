using SistemaResultadosDeportivos.Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Logica;
using System.Drawing;


namespace SistemaResultadosDeportivos
{
    public partial class ABMTorneos : Form
    {
        LogicaDeportes lgd;
        LogicaTorneos lgt;
        int var = 0;

        public ABMTorneos()
        {
            InitializeComponent();
            lgd = new LogicaDeportes();
            lgt = new LogicaTorneos();
            listarDeportes();
            listarTorneos();
        }

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscar.Text = null;
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

        public void listarTorneos()
        {
            flpTorneos.Controls.Clear();
            List<Torneo> lista = lgt.devolverTorneos();
            if (lista != null)
            {
                int i = 0;
                int tamano = flpTorneos.Width - 5;

                foreach (Torneo tor in lista)
                {
                    String tamanoSt = tor.nombreTorneo;
                    String tamanoSt2 = "Pais: " + tor.nombrePais;
                    if (tamanoSt.Length > tamano)
                    {
                        tamano = tamanoSt.Length;
                    }
                    else if (tamanoSt2.Length > tamano)
                    {
                        tamano = tamanoSt2.Length;
                    }
                }

                foreach (Torneo tor in lista)
                {
                    Label lblBoton = new Label();
                    Label lblBoton2 = new Label();
                    Label lblBoton3 = new Label();
                    Button btnTorneo = new Button();
                    String textNombre = tor.nombreTorneo;
                    String textFecha = "Pais: " + tor.nombrePais;
                    String textHora = "Fecha: " + tor.fechaComienzo;
                    propiedadesBoton(btnTorneo, i, tamano);
                    propiedadesLabel(lblBoton, textNombre, btnTorneo, 8);
                    propiedadesLabel(lblBoton2, textFecha, btnTorneo, 39);
                    propiedadesLabel(lblBoton3, textHora, btnTorneo, 70);
                    btnTorneo.Controls.Add(lblBoton);
                    btnTorneo.Controls.Add(lblBoton2);
                    btnTorneo.Controls.Add(lblBoton3);
                    flpTorneos.Controls.Add(btnTorneo);
                    btnTorneo.Click += new EventHandler(btnTorneo_Click);
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
            if (t == (flpTorneos.Width - 5))
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

        private void btnTorneo_Click(object sender, EventArgs e)
        {
            Button btnTorneo = sender as Button;
            int i = (Int32)btnTorneo.Tag;
            var = i;
            //new SubFrmModificarEncuentro(this).Visible = true;
        }

        private void ABMTorneos_Load(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlBuscar.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlLupa.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            flpTorneos.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*Agrega un torneo a la BD con los datos ingresados en los textboxes, luego
            lo muestra en el listview*/
            try
            {
                if (txtNombre.Text != "" && cbxDeportes.SelectedItem != null)
                {
                    DateTime fechaInicio = dateFechaInicio.Value;
                    String strFechaInicio = fechaInicio.Year.ToString() + "-" + fechaInicio.Month.ToString() + "-" + fechaInicio.Day.ToString();
                    DateTime fechaFin = dateFechaFin.Value;
                    String strFechaFin = fechaFin.Year.ToString() + "-" + fechaFin.Month.ToString() + "-" + fechaFin.Day.ToString();
                    string nombre = txtNombre.Text;
                    string pais = txtPais.Text;
                    Deporte deporte = lgd.devolverDeportes()[cbxDeportes.SelectedIndex];
                    int idDeporte = deporte.idDeporte;
                    if (lgt.agregarTorneo(strFechaInicio, strFechaFin, pais, nombre, idDeporte))
                    {
                        listarTorneos();
                    }
                }
                else
                {
                    MessageBox.Show("Datos mal colocados.");
                }
            }
            catch { }
            
        }
    }
}
