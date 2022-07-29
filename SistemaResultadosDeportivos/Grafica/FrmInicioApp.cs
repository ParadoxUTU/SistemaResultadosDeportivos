using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaResultadosDeportivos.APIs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;

namespace SistemaResultadosDeportivos
{
    public partial class FrmInicioApp : Form
    {
        APIpublicidad publicidad;
        Image imagenBanner;
        String urlSitio;

        public FrmInicioApp()
        {
            InitializeComponent();
            publicidad = new APIpublicidad();
            RespuestaPublicidad res = JsonConvert.DeserializeObject<RespuestaPublicidad>(publicidad.publicidadToJSON());
            setImageBanner(res.pathBanner);
            urlSitio = res.urlSitio;
        }

        private void setImageBanner(string path)
        {
            //Establece la imagen del banner, dado la ruta respectiva
            try
            {
                imagenBanner = Image.FromFile(Directory.GetCurrentDirectory() + "\\Img\\" + path);
                Bitmap bitmapBanner = new Bitmap(imagenBanner, banner.Width, banner.Height);
                banner.Image = bitmapBanner;
            }
            catch { }
        }
        private void banner_Click(object sender, EventArgs e)
        {
            //Al clickear sobre el banner, te lleva al sitio web respectivo
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = urlSitio,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("No se puede abrir el link.");
            }
        }

        private void FrmInicioApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
