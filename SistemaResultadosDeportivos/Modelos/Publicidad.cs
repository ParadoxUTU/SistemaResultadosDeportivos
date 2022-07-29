using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADODB;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Publicidad
    {
        public int idPublicidad;
        public String marca;
        public String pathBanner;
        public String urlSitio;

        public Publicidad(int id, string m, string p, string u)
        {
            this.idPublicidad = id;
            this.marca = m;
            this.pathBanner = p;
            this.urlSitio = u;
        }
    }
}
