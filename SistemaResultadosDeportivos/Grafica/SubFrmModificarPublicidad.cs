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
    public partial class SubFrmModificarPublicidad : Form
    {
        ABMPublicidad publicidad;

        public SubFrmModificarPublicidad(ABMPublicidad p)
        {
            InitializeComponent();
            publicidad = p;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Recoge los datos de modificacion, y los envía al frame original para su confirmacion
            String marca = txtMarca.Text;
            String pathBanner = txtUrlBanner.Text;
            String urlSitio = txtUrlSitio.Text;
            if (!marca.Equals("") && !pathBanner.Equals("") && !urlSitio.Equals(""))
            {
                this.Dispose();
                if (!publicidad.confirmarModificacion(marca, pathBanner, urlSitio))
                {
                    new SubFrmModificarPublicidad(publicidad).Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Datos invalidos.");
            }
        }

        private void SubFrmModificarPublicidad_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}






