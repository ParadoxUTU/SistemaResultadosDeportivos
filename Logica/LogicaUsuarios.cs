using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaResultadosDeportivos.Modelos;
using SistemaResultadosDeportivos.AccesoADatos;
using SistemaResultadosDeportivos.APIs;


namespace SistemaResultadosDeportivos.Logica
{
    internal class LogicaUsuarios
    {
        private DatosUsuario dt;

        public LogicaUsuarios()
        {
            dt = new DatosUsuario();
        }
        public RespuestaAutenticacion autenticar(String correo, String contrasena)
        {
            /*Autentica las credenciales dadas en la BD, y devuelve una respuesta
            con el rol del usuario, y si fue exitosa la autenticacion*/
            Usuario usuario = dt.getPorId(correo);
            RespuestaAutenticacion res;
            if (usuario != null && dt.testConexion(correo, contrasena))
            {
                dt.actualizarConexion(correo, contrasena);
                res = new RespuestaAutenticacion(true, usuario.rol);
            }
            else
            {
                res = new RespuestaAutenticacion(false, -1);
            }
            return res;
        }

        public List<Usuario> devolverUsuarios()
        {
            //Devuelve una lista con los usuarios en la BD
            return dt.getUsuarios();
        }

        public bool esMiembro(string correo)
        {
            //Devuelve true si es miembro, false si no lo es
            return dt.esMiembro(correo);
        }

        public bool agregarMiembro(string correo)
        {
            //Agrega un miembro a la BD
            return dt.agregarMiembro(correo);
        }

        public bool eliminarMiembro(string correo)
        {
            //Agrega un miembro a la BD
            return dt.eliminarMiembro(correo);
        }

        public bool registrarUsuario(String correo, String nombre, String contrasena, int rol)
        {
            //Intenta agregar un usuario a la BD, con los datos dados
            return dt.agregarUsuario(correo, nombre, contrasena, rol);
        }
        public bool bajaUsuario(String correo)
        {
            //Intenta eliminar un usuario de la BD con el correo dado
            return dt.eliminarUsuario(correo);
        }
        
        public bool modificarUsuario(String correo, String nombre, int rol)
        {
            //Intenta modificar un usuario en la BD, con los datos dados
            return dt.modificarUsuario(correo, nombre, rol);
        }

        public void volverAutenticador()
        {
            //El usuario por defecto vuelve a ser el autenticador
            dt.volverAutenticador();
        }
    }
}
