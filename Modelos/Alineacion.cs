using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Alineacion
    {
        public int idEquipo { get; set; }
        public int idEncuentro { get; set; }
        public int idJugador { get; set; }
        public int numero { get; set; }

        public Alineacion(int idEq, int idEn, int idJ, int n)
        {
            idEquipo = idEq;
            idEncuentro = idEn;
            idJugador = idJ;
            numero = n;
        }
    }
}
