using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Modelos;
using SistemaResultadosDeportivos.Logica;
using ADODB;
using System.IO;


namespace SistemaResultadosDeportivos
{
    public partial class ABMDeportes : Form
    {
        LogicaDeportes lgd;
        int var = 0;

        public ABMDeportes()
        {
            InitializeComponent();
            lgd = new LogicaDeportes();
            listarDeportes();
        }

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscar.Text = null;
        }

        private void ABMDeportes_Load(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlBuscar.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlLupa.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            flpDeportes.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
        }

        public void listarDeportes()
        {
            flpDeportes.Controls.Clear();
            List<Deporte> lista = lgd.devolverDeportes();
            if (lista != null)
            {
                int i = 0;
                int tamano = flpDeportes.Width - 5;

                foreach (Deporte dep in lista)
                {
                    String tamanoSt = dep.nombreDeporte;
                    String tamanoSt2;
                    if (dep.porEquipos)
                        tamanoSt2 = "Modalidad: colectivo";
                    else
                        tamanoSt2 = "Modalidad: individual";
                    if (tamanoSt.Length > tamano)
                    {
                        tamano = tamanoSt.Length;
                    }
                    else if (tamanoSt2.Length > tamano)
                    {
                        tamano = tamanoSt2.Length;
                    }
                }

                foreach (Deporte dep in lista)
                {
                    Label lblBoton = new Label();
                    Label lblBoton2 = new Label();
                    Label lblBoton3 = new Label();
                    Button btnDeporte = new Button();
                    String textNombre = dep.nombreDeporte;
                    String textModalidad;
                    if (dep.porEquipos)
                        textModalidad = "Modalidad: colectivo";
                    else
                        textModalidad = "Modalidad: individual";                    
                    propiedadesBoton(btnDeporte, i, tamano);
                    propiedadesLabel(lblBoton, textNombre, btnDeporte, 8);
                    propiedadesLabel(lblBoton2, textModalidad, btnDeporte, 39);
                    btnDeporte.Controls.Add(lblBoton);
                    btnDeporte.Controls.Add(lblBoton2);
                    btnDeporte.Controls.Add(lblBoton3);
                    flpDeportes.Controls.Add(btnDeporte);
                    btnDeporte.Click += new EventHandler(btnDeporte_Click);
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
            if (t == (flpDeportes.Width - 5))
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

        private void btnDeporte_Click(object sender, EventArgs e)
        {
            Button btnDeporte = sender as Button;
            int i = (Int32)btnDeporte.Tag;
            var = i;
            //new SubFrmModificarEncuentro(this).Visible = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*Agrega un deporte a la BD con los datos ingresados en los textboxes, luego
            lo muestra en el listview*/
            try
            {
                if (cbxModalidad.SelectedItem != null && cbxPuntuacion.SelectedItem != null && txtNombre.Text != "")
                {
                    string nombre = txtNombre.Text;
                    string modalidad;
                    bool porEquipos;
                    string puntuacion;
                    bool anotaciones;
                    bool sets;
                    int participantes = (int)numParticipantes.Value;
                    int alineacion = (int)numAlineacion.Value;
                    modalidad = cbxModalidad.SelectedItem.ToString();
                    puntuacion = cbxPuntuacion.SelectedItem.ToString();
                    porEquipos = (modalidad == "Por equipos");
                    anotaciones = (puntuacion == "Anotaciones");
                    sets = (puntuacion == "Sets");
                    if (lgd.agregarDeporte(porEquipos, anotaciones, sets, participantes, nombre, alineacion))
                    {
                        listarDeportes();
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
