using SistemaResultadosDeportivos.Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Logica;
using System.Drawing;


namespace SistemaResultadosDeportivos
{
    public partial class ABMEquipos : Form
    {
        LogicaDeportes lgd;
        LogicaEquipos lgeq;

        public ABMEquipos()
        {
            InitializeComponent();
            lgd = new LogicaDeportes();
            lgeq = new LogicaEquipos();
            listarDeportes();
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

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscar.Text = null;
        }

        private void ABMEquipos_Load(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlBuscar.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlLupa.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            flpEquipos.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*Agrega un equipo a la BD con los datos ingresados en los textboxes, luego
            lo muestra en el listview*/
            try
            {
                if(txtNombre.Text != null && txtPais.Text != null && cbxDeportes.SelectedItem != null)
                {
                    string nombre = txtNombre.Text;
                    string pais = txtPais.Text;
                    Deporte deporte = lgd.devolverDeportes()[cbxDeportes.SelectedIndex];
                    int idDeporte = deporte.idDeporte;
                    if (lgeq.agregarEquipo(pais, nombre, idDeporte))
                    {
                        MessageBox.Show("Equipo agregado");
                        //listarEquipos();
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
