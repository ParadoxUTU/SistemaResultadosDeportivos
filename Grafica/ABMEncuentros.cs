using SistemaResultadosDeportivos.Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Logica;
using System.Drawing;


namespace SistemaResultadosDeportivos
{
    public partial class ABMEncuentros : Form
    {
        public LogicaEncuentros lge;
        private LogicaDeportes lgd;
        public LogicaTorneos lgt;
        public LogicaEquipos lgeq;
        FrmInicioEncuentros frmencuentros;

        public ABMEncuentros(FrmInicioEncuentros e)
        {
            InitializeComponent();
            lge = new LogicaEncuentros();
            lgd = new LogicaDeportes();
            lgt = new LogicaTorneos();
            lgeq = new LogicaEquipos();
            listarDeportes();
            this.Dock = DockStyle.Fill;
            timeHora.ShowUpDown = true;
            frmencuentros = e;
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

        private void listarTorneos(int idDeporte)
        {
            cbxTorneos.Items.Clear();
            List<Torneo> lista = lgt.devolverTorneosPorDeporte(idDeporte);
            if (lista.Count != 0)
            {
                foreach (Torneo t in lista)
                {
                    cbxTorneos.Items.Add(t.nombreTorneo);
                }
            }
        }

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscar.Text = null;
        }

        private void ABMEncuentros_Load(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlBuscar.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            pnlLupa.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
            flpEncuentros.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime fechaEncuentro = dateFecha.Value;
            String strFecha = fechaEncuentro.Year.ToString() + "-" + fechaEncuentro.Month.ToString() + "-" + fechaEncuentro.Day.ToString();
            DateTime horaEncuentro = timeHora.Value;
            String strHora = horaEncuentro.Hour.ToString() + ":" + horaEncuentro.Minute.ToString();
            bool pausado = (cbxEstado.SelectedIndex == 1);
            int minActual = (int)numMinActual.Value;
            bool comenzo = (cbxEstado.SelectedIndex == 0);
            bool finalizo = (cbxEstado.SelectedIndex == 2);
            String nombreEncuentro = txtNombre.Text;
            try
            {
                if (cbxDeportes.SelectedItem != null)
                {
                    Deporte deporte = lgd.devolverDeportes()[cbxDeportes.SelectedIndex];
                    Encuentro encuentro = new Encuentro(0, fechaEncuentro, horaEncuentro, pausado, minActual, comenzo, finalizo, nombreEncuentro, deporte.idDeporte); //Se crea un objeto de tipo Encuentro con una id = 0 para pasarlo por parametro y obtener sus demas atributos
                    if (confirmarAgregacion(strFecha, strHora, pausado, minActual, comenzo, finalizo, nombreEncuentro, deporte.idDeporte))
                    {
                        int idEncuentro = lge.devolverUltimaID();
                        if (deporte.porEquipos)
                        {
                            lge.agregarEncCol(idEncuentro, 0);
                            if (cbxTorneos.SelectedItem == null)
                            {
                                //new SubFrmEncCol(this, deporte, encuentro).Visible = true;
                            }
                            else
                            {
                                Torneo torneo = lgt.devolverTorneosPorDeporte(deporte.idDeporte)[cbxTorneos.SelectedIndex];
                                lge.agregarEncuentroTorneo(idEncuentro, torneo.idTorneo, "G");
                                //new SubFrmEncCol(this, torneo, encuentro).Visible = true;
                            }
                        }
                        else
                        {
                            lge.agregarEncInd(idEncuentro);
                            if (cbxTorneos.SelectedItem == null)
                            {
                                //new SubFrmEncInd(this, deporte, encuentro).Visible = true;
                            }
                            else
                            {
                                Torneo torneo = lgt.devolverTorneosPorDeporte(deporte.idDeporte)[cbxTorneos.SelectedIndex];
                                lge.agregarEncuentroTorneo(idEncuentro, torneo.idTorneo, "G");
                                //new SubFrmEncInd(this, torneo, deporte, encuentro).Visible = true;
                            }
                        }
                    }
                    frmencuentros.listarEncuentros();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Datos mal colocados.");
                }
            }
            catch { }
        }

        public bool confirmarAgregacion(String fecha, String hora, bool pausado, int minActual, bool comenzo, bool finalizo, String nombreEncuentro, int idDeporte)
        {
            /*Confirma la agregación del encuentro con los datos ingresados
            desde el subframe de agregación*/
            bool exito = false;
            if(lge.agregarEncuentro(fecha, hora, pausado, minActual, comenzo, finalizo, nombreEncuentro, idDeporte))
            {
                exito = true;
            }
            return exito;
        }

        private void cbxDeportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deporte deporte = lgd.devolverDeportes()[cbxDeportes.SelectedIndex];
            int idDeporte = deporte.idDeporte;
            listarTorneos(idDeporte);
        }
    }
}
