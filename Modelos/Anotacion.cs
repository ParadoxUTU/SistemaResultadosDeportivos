using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Anotacion
    {
        public int idAnotacion { get; set; }
        public int idJugador { get; set; }
        public int minuto { get; set; }
        public int idEncuentro { get; set; }

        public Anotacion(int idA, int idJ, int m, int idE)
        {
            idAnotacion = idA;
            idJugador = idJ;
            minuto = m;
            idEncuentro = idE;
        }
    }
}
