using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.APIs
{
    public class RespuestaPublicidad
    {
        public String pathBanner { get; set; }
        public String urlSitio { get; set; }

        public RespuestaPublicidad(string p, string u)
        {
            this.pathBanner = p;
            this.urlSitio = u;
        }
    }
}
