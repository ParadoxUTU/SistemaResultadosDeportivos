using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaResultadosDeportivos.Modelos
{
    internal class Usuario
    {
        public String correo { get; set; }
        public String nombre { get; set; }
        public int rol { get; set; }

        public Usuario(String c, String n, int r)
        {
            correo = c;
            nombre = n;
            rol = r;
        }
    }
}