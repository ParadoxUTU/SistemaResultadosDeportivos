using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaResultadosDeportivos.AccesoADatos
{
    public class Conexion
    {
        private static String origenDatos = "miodbc";
        public static String nombreBD = "bd_paradox";
        public static String usuario = "auth";
        public static String contrasena = "1";

        public static ADODB.Connection Crear()
        {
            //Se crea una conexion con el usuario y contrasena por defecto
            ADODB.Connection cn = new ADODB.Connection();
            try
            {
                cn.Open(origenDatos, usuario, contrasena);
                cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
                return cn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public static ADODB.Connection Crear(String us, String con)
        {
            //Se crea una conexion con el usuario y la contrasena dados
            ADODB.Connection cn = new ADODB.Connection();
            try
            {
                if (!con.Equals(""))
                {
                    cn.Open(origenDatos, us, con);
                    cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
                }
                else
                {
                    cn = null;
                }
                return cn;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public static void volverAutenticador()
        {
            //El usuario por defecto vuelve a ser el autenticador
            usuario = "auth";
            contrasena = "1";
        }
    }
}
