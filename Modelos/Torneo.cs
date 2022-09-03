using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Torneo
    {
        public int idTorneo { get; set; }
        public String fechaComienzo { get; set; }
        public String fechaFin { get; set; }
        public String nombrePais { get; set; }
        public String nombreTorneo { get; set; }
        public int idDeporte { get; set; }

        public Torneo(int idT, String fC, String fF, string nP, string nT, int idD)
        {
            idTorneo = idT;
            fechaComienzo = fC;
            fechaFin = fF;
            nombrePais = nP;
            nombreTorneo = nT;
            idDeporte = idD;
        }
    }
}
