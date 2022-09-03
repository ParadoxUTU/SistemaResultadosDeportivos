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
    internal class DatosTorneo
    {
        public List<Torneo> getTorneos()
        {
            //Mapea los torneos existentes a los modelos, y los devuelve en una lista
            int idTorneo;
            String fechaComienzo;
            String fechaFin;
            String nombrePais;
            String nombreTorneo;
            int idDeporte;
            List<Torneo> lista = new List<Torneo>();
            String stringSql = "SELECT * FROM Torneos;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idTorneo = (int)rs.Fields[0].Value;
                        fechaComienzo = Convert.ToString(rs.Fields[1].Value);
                        fechaFin = Convert.ToString(rs.Fields[2].Value);
                        nombrePais = (string)rs.Fields[3].Value;
                        nombreTorneo = (string)rs.Fields[4].Value;
                        idDeporte = (int)rs.Fields[5].Value;
                        Torneo torneo = new Torneo(idTorneo, fechaComienzo, fechaFin, nombrePais, nombreTorneo, idDeporte);
                        lista.Add(torneo);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch {}
            return lista;
        }

        public List<Torneo> getTorneosByDeporte(int idDeporte)
        {
            //Mapea los torneos existentes pertenecientes a un deporte a los modelos, y los devuelve en una lista
            int idTorneo;
            String fechaComienzo;
            String fechaFin;
            String nombrePais;
            String nombreTorneo;
            List<Torneo> lista = new List<Torneo>();
            String stringSql = "SELECT * FROM Torneos WHERE IdDeporte = '" + idDeporte + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idTorneo = (int)rs.Fields[0].Value;
                        fechaComienzo = Convert.ToString(rs.Fields[1].Value);
                        fechaFin = Convert.ToString(rs.Fields[2].Value);
                        nombrePais = (string)rs.Fields[3].Value;
                        nombreTorneo = (string)rs.Fields[4].Value;
                        Torneo torneo = new Torneo(idTorneo, fechaComienzo, fechaFin, nombrePais, nombreTorneo, idDeporte);
                        lista.Add(torneo);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch{}
            return lista;
        }

        public Torneo getTorneoByID(int id)
        {
            //Devuelve un torneo dependiendo de su ID
            String fechaComienzo;
            String fechaFin;
            String nombrePais;
            String nombreTorneo;
            int idDeporte;
            Torneo torneo = null;
            String stringSql = "SELECT * FROM Torneos WHERE IdTorneo = '" + id + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                fechaComienzo = Convert.ToString(rs.Fields[1].Value);
                fechaFin = Convert.ToString(rs.Fields[2].Value);
                nombrePais = (string)(rs.Fields[3].Value);
                nombreTorneo = (string)rs.Fields[4].Value;
                idDeporte = (int)rs.Fields[5].Value;
                torneo = new Torneo(id, fechaComienzo, fechaFin, nombrePais, nombreTorneo, idDeporte);
                cn.Close();
            }
            catch { }
            return torneo;
        }

        public Torneo getTorneoByEncuentro(int idEncuentro)
        {
            //Devuelve un torneo dependiendo de su encuentro
            int idTorneo;
            String fechaComienzo;
            String fechaFin;
            String nombrePais;
            String nombreTorneo;
            int idDeporte;
            Torneo torneo = null;
            String stringSql = "SELECT * FROM Encuentros_Torneos INNER JOIN Torneos ON encuentros_torneos.IdTorneo=Torneos.IdTorneo WHERE IdEncuentro = '" + idEncuentro + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                idTorneo = (int)rs.Fields[3].Value;
                fechaComienzo = Convert.ToString(rs.Fields[4].Value);
                fechaFin = Convert.ToString(rs.Fields[5].Value);
                nombrePais = (string)(rs.Fields[6].Value);
                nombreTorneo = (string)rs.Fields[7].Value;
                idDeporte = (int)rs.Fields[8].Value;
                torneo = new Torneo(idTorneo, fechaComienzo, fechaFin, nombrePais, nombreTorneo, idDeporte);
                cn.Close();
            }
            catch { }
            return torneo;
        }

        public bool agregarTorneo(String fechaComienzo, String fechaFin, string nombrePais, string nombreTorneo, int idDeporte)
        {
            //Intenta agregar un torneo a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Torneos (FechaComienzo, FechaFin, NombrePais, NombreTorneo, IdDeporte) VALUES('" + fechaComienzo + "', '" + fechaFin + "', '" + nombrePais + "', '" + nombreTorneo + "', '" + idDeporte + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarTorneo(int id)
        {
            //Intenta eliminar un torneo de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Torneos WHERE IdTorneo = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarTorneo(int id, String fechaComienzo, String fechaFin, string nombrePais, string nombreTorneo, int idDeporte)
        {
            //Intenta modificar un torneo existente en la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "UPDATE Torneos SET FechaComienzo = '" + fechaComienzo + "', FechaFin = '" + fechaFin + "', NombrePais = '" + nombrePais + "', NombreTorneo = '" + nombreTorneo + "' WHERE IdTorneo = '" + id + "';";
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
            String stringSql = "SELECT LAST_INSERT_ID() FROM Torneos;";
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
