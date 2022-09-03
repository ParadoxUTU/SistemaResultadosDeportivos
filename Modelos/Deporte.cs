using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Deporte
    {
        public int idDeporte { get; set; }
        public bool porEquipos { get; set; }
        public bool anotaciones { get; set; }
        public bool sets { get; set; }
        public int cantParticipantes { get; set; }
        public String nombreDeporte { get; set; }
        public int tamAlineacion { get; set; }

        public Deporte(int idD, bool pE, bool a, bool s, int cP, String nD, int tA)
        {
            idDeporte = idD;
            porEquipos = pE;
            anotaciones = a;
            sets = s;
            cantParticipantes = cP;
            nombreDeporte = nD;
            tamAlineacion = tA;
        }
    }
}
