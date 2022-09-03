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
    public class DatosEquipo
    {
        public List<Equipo> getEquipos()
        {
            //Mapea los equipos existentes a los modelos, y los devuelve en una lista
            int idEquipo;
            String nombrePais;
            String nombreEquipo;
            int idDeporte;
            List<Equipo> lista = new List<Equipo>();
            String stringSql = "SELECT * FROM Equipos;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idEquipo = (int)rs.Fields[0].Value;
                        nombrePais = (string)rs.Fields[1].Value;
                        nombreEquipo = (string)rs.Fields[2].Value;
                        idDeporte = (int)rs.Fields[3].Value;
                        Equipo equipo = new Equipo(idEquipo, nombrePais, nombreEquipo, idDeporte);
                        lista.Add(equipo);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch {}
            return lista;
        }

        public Equipo getEquipoByID(int id)
        {
            //Devuelve un equipo dependiendo de su ID
            String nombrePais;
            String nombreEquipo;
            int idDeporte;
            Equipo equipo = null;
            String stringSql = "SELECT * FROM Equipos WHERE IdEquipo = '" + id + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                nombrePais = (string)rs.Fields[1].Value;
                nombreEquipo = (string)rs.Fields[2].Value;
                idDeporte = (int)rs.Fields[3].Value;
                equipo = new Equipo(id, nombrePais, nombreEquipo, idDeporte);
                cn.Close();
            }
            catch { }
            return equipo;
        }

        public List<Equipo> getEquiposByDeporte(int idDeporte)
        {
            //Mapea los equipos existentes pertenecientes a un deporte existentes a los modelos, y los devuelve en una lista
            int idEquipo;
            String nombrePais;
            String nombreEquipo;
            List<Equipo> lista = new List<Equipo>();
            String stringSql = "SELECT * FROM Equipos WHERE IdDeporte = '" + idDeporte + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idEquipo = (int)rs.Fields[0].Value;
                        nombrePais = (string)rs.Fields[1].Value;
                        nombreEquipo = (string)rs.Fields[2].Value;
                        Equipo equipo = new Equipo(idEquipo, nombrePais, nombreEquipo, idDeporte);
                        lista.Add(equipo);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch {}
            return lista;
        }

        public List<Equipo> getEquiposByTorneo(int idTorneo)
        {
            //Mapea los equipos existentes pertenecientes a un torneo existentes a los modelos, y los devuelve en una lista
            int idEquipo;
            String nombrePais;
            String nombreEquipo;
            int idDeporte;
            List<Equipo> lista = new List<Equipo>();
            String stringSql = "SELECT * FROM Equipos_Torneos INNER JOIN Equipos ON Equipos_Torneos.IdEquipo=Equipos.IdEquipo WHERE IdTorneo = '" + idTorneo + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idEquipo = (int)rs.Fields[0].Value;
                        nombrePais = (string)rs.Fields[3].Value;
                        nombreEquipo = (string)rs.Fields[4].Value;
                        idDeporte = (int)rs.Fields[5].Value;
                        Equipo equipo = new Equipo(idEquipo, nombrePais, nombreEquipo, idDeporte);
                        lista.Add(equipo);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch{}
            return lista;

        }

        public List<Equipo> getEquiposByEncuentro(int idEncuentro)
        {
            //Mapea los equipos pertenecientes a un torneo existentes a los modelos, y los devuelve en una lista
            int idEquipo;
            String pais;
            String nombreEquipo;
            int idDeporte;
            List<Equipo> lista = new List<Equipo>();
            String stringSql = "SELECT * FROM encuentros_equipos INNER JOIN Equipos ON encuentros_equipos.IdEquipo=Equipos.IdEquipo WHERE IdEncuentro = '" + idEncuentro + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idEquipo = (int)rs.Fields[4].Value;
                        pais = (string)rs.Fields[5].Value;
                        nombreEquipo = (string)rs.Fields[6].Value;
                        idDeporte = (int)rs.Fields[7].Value;
                        Equipo equipo = new Equipo(idEquipo, pais, nombreEquipo, idDeporte);
                        lista.Add(equipo);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch {}
            return lista;
        }

        public bool agregarEquipo(String nombrePais, String nombreEquipo, int idDeporte)
        {
            //Intenta agregar un equipo a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Equipos (NombrePais, NombreEquipo,  IdDeporte) VALUES('" + nombrePais + "', '" + nombreEquipo + "', '" + idDeporte + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarEquipo(int id)
        {
            //Intenta eliminar un equipo de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Equipos WHERE IdEquipo = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarEquipo(int id, String nombrePais, String nombreEquipo, int idDeporte)
        {
            //Intenta modificar un equipo existente en la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "UPDATE Equipos SET NombrePais = '" + nombrePais + "', NombreEquipo = '" + nombreEquipo + "', idDeporte = '" + idDeporte + "' WHERE IdEquipo = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int getLastID()
        {
            //Devuelve el ID generado tras el último insert.
            int id = 0;
            String stringSql = "SELECT LAST_INSERT_ID() FROM Equipos;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                id = (int)rs.Fields[0].Value;
                cn.Close();
                return id;
            }
            catch { }
            return id;
        }
    }
}
