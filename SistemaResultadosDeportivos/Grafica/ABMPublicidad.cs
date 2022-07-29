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

namespace SistemaResultadosDeportivos
{
    public partial class ABMPublicidad : Form
    {
        public LogicaPublicidad lgp;

        public ABMPublicidad()
        {
            InitializeComponent();
            lgp = new LogicaPublicidad();
            this.Dock = DockStyle.Fill;
            listarPublicidad();
        }
        private void listarPublicidad()
        {
            //Despliega todas las publicidades como entradas en el listview
            lviewPublicidad.Items.Clear();
            List<Publicidad> lista = lgp.devolverPublicidades();
            if (lista != null)
            {
                foreach (Publicidad pb in lista)
                {
                    ListViewItem item = new ListViewItem(pb.idPublicidad.ToString());
                    item.SubItems.Add(pb.marca);
                    item.SubItems.Add(pb.pathBanner);
                    item.SubItems.Add(pb.urlSitio);
                    lviewPublicidad.Items.Add(item);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*Agrega una publicidad a la BD con los datos ingresados en los textboxes, luego
            lo muestra en el listview*/
            string marca = txtMarca.Text;
            string pathBanner = txtPathBanner.Text;
            string urlSitio = txtUrlSitio.Text;
            if (!marca.Equals("") && !pathBanner.Equals("") && !urlSitio.Equals(""))
            {
                if (lgp.agregarPublicidad(marca, pathBanner, urlSitio))
                {
                    listarPublicidad();
                }
            }
            else
            {
                MessageBox.Show("No se ha podido agregar la publicidad");
            }
            limpiarTextos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Elimina una publicidad si esta está seleccionada en el listview
            if (lviewPublicidad.SelectedItems.Count > 0)
            {
                string id = lviewPublicidad.SelectedItems[0].Text;
                if (lgp.eliminarPublicidad(id))
                {
                    listarPublicidad();
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar la publicidad.");
                }
            }
            else
            {
                MessageBox.Show("No se ha publicidad seleccionada.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modifica marca, path, y url de una publicidad seleccionada en el listview
            try
            {
                if (lviewPublicidad.SelectedItems.Count > 0)
                {
                    new SubFrmModificarPublicidad(this).Visible = true;
                }
                else
                {
                    MessageBox.Show("No hay publicidad seleccionada.");
                }
            }
            catch { }
        }

        public bool confirmarModificacion(String marca, String pathBanner, String urlSitio)
        {
            /*Confirma la modificacion de la publicidad seleccionada, con los datos ingresados
            desde el subframe de modificacion*/
            int idPublicidad;
            bool exito = int.TryParse(lviewPublicidad.SelectedItems[0].Text, out idPublicidad);
            if (exito && lgp.modificarPublicidad(idPublicidad, marca, pathBanner, urlSitio))
            {
                listarPublicidad();
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
            txtMarca.Text = null;
            txtPathBanner.Text = null;
            txtUrlSitio.Text = null;
        }

        private void ABMPublicidad_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            this.WindowState = FormWindowState.Maximized;
        }
    }
}

