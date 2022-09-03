using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADODB;
using SistemaResultadosDeportivos.Modelos;

namespace SistemaResultadosDeportivos.AccesoADatos
{
    public class DatosPublicidad
    {

        public List<Publicidad> getPublicidades()
        {
            //Mapea las publicidades existentes a los modelos, y las devuelve en una lista
            int idPublicidad;
            string marca;
            string pathBanner;
            string urlSitio;
            List<Publicidad> lista = new List<Publicidad>();
            String stringSql = "SELECT * FROM Publicidad;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idPublicidad = (int)rs.Fields[0].Value;
                        marca = (string)rs.Fields[1].Value;
                        urlSitio = (string)rs.Fields[2].Value;
                        pathBanner = (string)rs.Fields[3].Value;
                        Publicidad publicidad = new Publicidad(idPublicidad, marca, pathBanner, urlSitio);
                        lista.Add(publicidad);
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

        public bool agregarPublicidad(String marca, String pathBanner, String urlSitio)
        {
            //Intenta agregar una publicidad a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Publicidad (Marca, PathBanner,  URLSitio) VALUES('" + marca + "', '" + pathBanner + "', '" + urlSitio + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarPublicidad(String id)
        {
            //Intenta eliminar una publicidad de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Publicidad WHERE idPublicidad = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarPublicidad(int id, String marca, String pathBanner, String urlSitio)
        {
            //Intenta modificar una publicidad existente en la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "UPDATE Publicidad SET marca = '" + marca + "', PathBanner = '" + pathBanner + "', URLSitio = '" + urlSitio + "' WHERE IdPublicidad = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
