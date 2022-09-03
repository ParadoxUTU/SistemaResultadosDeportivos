using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Equipo
    {
        public int idEquipo { get; set; }
        public String nombrePais { get; set; }
        public String nombreEquipo { get; set; }
        public int idDeporte { get; set; }

        public Equipo(int idE, String nP, String nE, int idD)
        {
            idEquipo = idE;
            nombrePais = nP;
            nombreEquipo = nE;
            idDeporte = idD;
        }
    }
}
