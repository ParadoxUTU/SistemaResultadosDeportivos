using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Encuentro
    {
        public int idEncuentro { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set; }
        public bool pausado { get; set; }
        public int minActual { get; set; }
        public bool comenzo { get; set; }
        public bool finalizo { get; set; }
        public String nombreEncuentro { get; set; }
        public int idDeporte { get; set; }

        public Encuentro(int idE, DateTime f, DateTime h, bool p, int m, bool c, bool fi, String nE, int idD)
        {
            idEncuentro = idE;
            fecha = f;
            hora = h;
            pausado = p;
            minActual = m;
            comenzo = c;
            finalizo = fi;
            nombreEncuentro = nE;
            idDeporte = idD;
        }
    }
}
