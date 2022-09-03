using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.APIs
{
    internal class RespuestaAutenticacion
    {
        public bool exito { get; set; }
        public int rol { get; set; }

        public RespuestaAutenticacion(bool ex, int r)
        {
            exito = ex;
            rol = r;
        }
    }
}
