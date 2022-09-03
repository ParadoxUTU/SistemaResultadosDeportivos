using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.APIs
{
    public class RespuestaAnotaciones
    {
        public int puntaje { get; set; }

        public RespuestaAnotaciones(int p)
        {
            puntaje = p;
        }
    }
}
