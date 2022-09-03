using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    public class Set
    {
        public int idSet { get; set; }
        public int numeroSet { get; set; }
        public int puntuacionSet { get; set; }

        public Set(int idS, int nS, int pS)
        {
            idSet = idS;
            numeroSet = nS;
            puntuacionSet = pS;
        }
    }
}
