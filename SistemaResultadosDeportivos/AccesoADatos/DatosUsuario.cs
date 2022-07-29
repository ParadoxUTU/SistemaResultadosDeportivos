using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Modelos;
using ADODB;

namespace SistemaResultadosDeportivos.AccesoADatos
{
    internal class DatosUsuario
    {
        public Usuario getPorId(String correo)
        {
            //Devuelve un usuario mapeado al modelo, dado su correo
            try
            {
                Usuario usuario;
                ADODB.Connection cn = Conexion.Crear();
                String sql = "SELECT * FROM Usuarios WHERE dirCorreo = '" + correo + "';";
                ADODB.Recordset rs = cn.Execute(sql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    String c = rs.Fields[0].Value.ToString();
                    String n = rs.Fields[1].Value.ToString();
                    int r;
                    int.TryParse(rs.Fields[2].Value.ToString(), out r);
                    usuario = new Usuario(c, n, r);
                }
                else
                {
                    usuario = null;
                }
                rs.Close();
                cn.Close();
                return usuario;
            }
            catch
            {
                return null;
            }
        }

        public List<Usuario> getUsuarios()
        {
            //Mapea los usuarios existentes a los modelos, y los devuelve en una lista
            string correo;
            string nombre;
            int rol;
            List<Usuario> lista = new List<Usuario>();
            String stringSql = "SELECT * FROM Usuarios;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        correo = (string)rs.Fields[0].Value;
                        if (correo != Conexion.usuario)
                        {
                            nombre = (string)rs.Fields[1].Value;
                            rol = (int)rs.Fields[2].Value;
                            Usuario usuario = new Usuario(correo, nombre, rol);
                            lista.Add(usuario);
                        }
                        rs.MoveNext();
                    }
                    cn.Close();
                }
                else
                {
                    cn.Close();
                    return null;
                }
            }
            catch{}
            return lista;
        }

        public bool agregarUsuario(String correo, String nombre, String contrasena, int rol)
        {
            //Intenta agregar una usuario a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "CREATE USER '" + correo + "'@'localhost' IDENTIFIED BY '" + contrasena + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                stringSql = "INSERT INTO Usuarios VALUES('" + correo + "', '" + nombre + "', '" + rol + "');";
                cn.Execute(stringSql, out cantFilas, -1);
                if (rol == 0)
                {
                    stringSql = "GRANT SELECT ON Usuarios TO '" + correo + "'@'localhost';";
                    cn.Execute(stringSql, out cantFilas, -1);
                    stringSql = "GRANT SELECT ON Publicidad TO '" + correo + "'@'localhost';";
                    cn.Execute(stringSql, out cantFilas, -1);
                }
                if (rol == 1)
                {
                    stringSql = "GRANT ALL ON Usuarios TO '" + correo + "'@'localhost';";
                    cn.Execute(stringSql, out cantFilas, -1);
                    stringSql = "GRANT ALL ON Publicidad TO '" + correo + "'@'localhost';";
                    cn.Execute(stringSql, out cantFilas, -1);
                    stringSql = "GRANT CREATE USER ON *.* TO '" + correo + "'@'localhost' WITH GRANT OPTION;";
                    cn.Execute(stringSql, out cantFilas, -1);
                    stringSql = "GRANT ALL PRIVILEGES ON "+ Conexion.nombreBD + ".* TO '" + correo + "'@'localhost';";
                    cn.Execute(stringSql, out cantFilas, -1);
                }  
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarUsuario(String correo)
        {
            //Intenta eliminar un usuario de la BD, dado su correo
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Usuarios WHERE dirCorreo = '" + correo + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                stringSql = "DROP USER '" + correo + "'@'localhost';";
                cn.Execute(stringSql, out cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarUsuario(String correo, String nombre, int rol)
        {
            //Intenta modificar un usuario existente en la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "UPDATE Usuarios SET username = '" + nombre + "', rol = '" + rol + "' WHERE dirCorreo = '" + correo + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool testConexion(String correo, String contrasena)
        {
            //Devuelve true si se logra establecer la conexion a la BD con los datos dados, false si no
            bool resultado;
            ADODB.Connection cn = Conexion.Crear(correo, contrasena);
            if (cn != null)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        public void actualizarConexion(String usuario, String contrasena)
        {
            //Cambia las credenciales de conexion por defecto a las dadas
            Conexion.usuario = usuario;
            Conexion.contrasena = contrasena;
        }

        public void volverAutenticador()
        {
            //Cambia las credenciales de conexion por defecto a las del usuario autenticador
            Conexion.volverAutenticador();
        }
    }
}
