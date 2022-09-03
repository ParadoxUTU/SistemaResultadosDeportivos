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
    public partial class ABMPublicidad : Form
    {
        public LogicaPublicidad lgp;
        int var = 0;

        public ABMPublicidad()
        {
            InitializeComponent();
            lgp = new LogicaPublicidad();
            this.Dock = DockStyle.Fill;
            listarPublicidad();
        }

        private void listarPublicidad()
        {
            flpPublicidad.Controls.Clear();
            List<Publicidad> lista = lgp.devolverPublicidades();
            if (lista != null)
            {
                int i =  0;
                int tamano = flpPublicidad.Width - 5;

                foreach (Publicidad pb in lista)
                {
                    String tamanoSt = "Sitio web: " + pb.urlSitio;
                    String tamanoSt2 = "Banner: " + pb.pathBanner;
                    String tamanoSt3 = "Marca: " + pb.marca;
                    if (tamanoSt.Length > tamano)
                    {
                        tamano = tamanoSt.Length;
                    }
                    else if (tamanoSt2.Length > tamano)
                    {
                        tamano = tamanoSt2.Length;
                    }
                    else if (tamanoSt3.Length > tamano)
                    {
                        tamano = tamanoSt3.Length;
                    }
                }

                foreach (Publicidad pb in lista)
                {
                    Label lblBoton = new Label();
                    Label lblBoton2 = new Label();
                    Label lblBoton3 = new Label();
                    Panel pnlPublicidad = new Panel();
                    Button btnPublicidad = new Button();
                    String textMarca = "Marca: " + pb.marca;
                    String textBanner = "Banner: " + pb.pathBanner;
                    String textSitio = "Sitio web: " + pb.urlSitio;
                    propiedadesBoton(btnPublicidad, i, tamano);
                    propiedadesLabel(lblBoton, textMarca, btnPublicidad, 8);
                    propiedadesLabel(lblBoton2, textBanner, btnPublicidad, 39);
                    propiedadesLabel(lblBoton3, textSitio, btnPublicidad, 70);
                    propiedadesPanel(pnlPublicidad, pb.pathBanner);
                    btnPublicidad.Controls.Add(pnlPublicidad);
                    btnPublicidad.Controls.Add(lblBoton);
                    btnPublicidad.Controls.Add(lblBoton2);
                    btnPublicidad.Controls.Add(lblBoton3);
                    flpPublicidad.Controls.Add(btnPublicidad);
                    btnPublicidad.Click += new EventHandler(btnPublicidad_Click);
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
            if (t == (flpPublicidad.Width - 5))
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

        private void propiedadesPanel(Panel pnl, String path)
        {
            pnl.Width = 92;
            pnl.Height = 91;
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Img\\" + path))
            {
                Image imagenBanner = Image.FromFile(Directory.GetCurrentDirectory() + "\\Img\\" + path);
                Bitmap bitmapBanner = new Bitmap(imagenBanner, pnl.Width, pnl.Height);
                pnl.BackgroundImage = bitmapBanner;
            }
            else
            {
                Image imagenBanner = Properties.Resources.error;
                Bitmap bitmapBanner = new Bitmap(imagenBanner, pnl.Width, pnl.Height);
                pnl.BackgroundImage = bitmapBanner;
            }
        }

        private void btnPublicidad_Click(object sender, EventArgs e)
        {
            Button btnUsuario = sender as Button;
            int i = (Int32)btnUsuario.Tag;
            var = i;
            new SubFrmModificarPublicidad(this).Visible = true;
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
            restablecerTextos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String banner = txtBuscar.Text;
            int id = 0;
            String m = "";
            String p = "";
            String u = "";
            int i = 0;
            List<Publicidad> lista = lgp.devolverPublicidades();
            Publicidad publicidad = new Publicidad(id, m, p, u);
            bool bandera = true;
            if (lista != null)
            {
                foreach (Publicidad pb in lista)
                {
                    if (pb.pathBanner == banner)
                    {
                        i = 1;
                        id = lista.IndexOf(pb);
                        publicidad = pb;
                    }
                    else if (banner == "")
                    {
                        i = 1;
                        bandera = false;
                    }
                }
                if (bandera && i == 1)
                {
                    flpPublicidad.Controls.Clear();
                    int tamano = flpPublicidad.Width - 5;
                    Label lblBoton = new Label();
                    Label lblBoton2 = new Label();
                    Label lblBoton3 = new Label();
                    Panel pnlPublicidad = new Panel();
                    Button btnPublicidad = new Button();
                    String textMarca = "Marca: " + publicidad.marca;
                    String textBanner = "Banner: " + publicidad.pathBanner;
                    String textSitio = "Sitio web: " + publicidad.urlSitio;
                    if (textSitio.Length > tamano)
                    {
                        tamano = textSitio.Length;
                    }
                    else if (textBanner.Length > tamano)
                    {
                        tamano = textBanner.Length;
                    }
                    else if (textMarca.Length > tamano)
                    {
                        tamano = textMarca.Length;
                    }
                    propiedadesBoton(btnPublicidad, id, tamano);
                    propiedadesLabel(lblBoton, textMarca, btnPublicidad, 8);
                    propiedadesLabel(lblBoton2, textBanner, btnPublicidad, 39);
                    propiedadesLabel(lblBoton3, textSitio, btnPublicidad, 70);
                    propiedadesPanel(pnlPublicidad, publicidad.pathBanner);
                    btnPublicidad.Controls.Add(pnlPublicidad);
                    btnPublicidad.Controls.Add(lblBoton);
                    btnPublicidad.Controls.Add(lblBoton2);
                    btnPublicidad.Controls.Add(lblBoton3);
                    flpPublicidad.Controls.Add(btnPublicidad);
                    btnPublicidad.Click += new EventHandler(btnPublicidad_Click);
                }
                else if (bandera == false && i == 1)
                {
                    listarPublicidad();
                }
                else
                {
                    MessageBox.Show("No se encontraron coincidencias");
                    listarPublicidad();
                }
                restablecerTextos();
            }
        }

        public void eliminarPublicidad()
        {
            List<Publicidad> lista = lgp.devolverPublicidades();
            Publicidad publicidad = lista[var];
            String id = (publicidad.idPublicidad).ToString();
            lgp.eliminarPublicidad(id);
            listarPublicidad();
        } 

        public bool confirmarModificacion(String marca, String pathBanner, String urlSitio)
        {
            /*Confirma la modificacion de la publicidad seleccionada, con los datos ingresados
            desde el subframe de modificacion*/
            int idPublicidad;
            List<Publicidad> lista = lgp.devolverPublicidades();
            Publicidad publicidad = lista[var];
            String id = (publicidad.idPublicidad).ToString();
            bool exito = int.TryParse(id, out idPublicidad);
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

        public String obtenerMarca()
        {
            List<Publicidad> lista = lgp.devolverPublicidades();
            Publicidad publicidad = lista[var];
            String marca = publicidad.marca;
            return marca;
        }
        public String obtenerBanner()
        {
            List<Publicidad> lista = lgp.devolverPublicidades();
            Publicidad publicidad = lista[var];
            String banner = publicidad.pathBanner;
            return banner;
        }

        public String obtenerSitio()
        {
            List<Publicidad> lista = lgp.devolverPublicidades();
            Publicidad publicidad = lista[var];
            String sitio = publicidad.urlSitio;
            return sitio;
        }

        private void restablecerTextos()
        {
            txtMarca.Text = null;
            txtPathBanner.Text = null;
            txtUrlSitio.Text = null;
            txtBuscar.Text = "Escriba el nombre del banner de la publicidad que desea consultar";
        }

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscar.Text = null;
        }

        private void ABMPublicidad_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            pnlBuscar.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlLupa.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            flpPublicidad.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            this.WindowState = FormWindowState.Maximized;
        }
    }
}

