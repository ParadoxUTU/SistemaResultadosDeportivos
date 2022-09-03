using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Jugador
    {
        public int idJugador { get; set; }
        public String nombreJugador { get; set; }
        public int edad { get; set; }
        public int peso { get; set; }
        public int estatura { get; set; }
        public String pais { get; set; }
        public int idDeporte { get; set; }

        public Jugador(int idJ, String nJ, int e, int pe, int es, String p, int idD)
        {
            idJugador = idJ;
            nombreJugador = nJ;
            edad = e;
            peso = pe;
            estatura = es;
            pais = p;
            idDeporte = idD;
        }
    }
}
