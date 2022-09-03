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
    internal class DatosSet
    {
        public List<Set> getSets()
        {
            //Mapea los sets existentes a los modelos, y los devuelve en una lista
            int idSet;
            int numeroSet;
            int puntuacionSet;
            List<Set> lista = new List<Set>();
            String stringSql = "SELECT * FROM Sets;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idSet = (int)rs.Fields[0].Value;
                        numeroSet = (int)rs.Fields[1].Value;
                        puntuacionSet = (int)rs.Fields[2].Value;
                        Set set = new Set(idSet, numeroSet, puntuacionSet);
                        lista.Add(set);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public List<Set> getSetsEquipoEncuentro(int idEquipo, int idEncuentro)
        {
            //Mapea los sets pertenecientes a equipo en un encuentro determinado a los modelos, y los devuelve en una lista
            int idSet;
            int numeroSet;
            int puntuacionSet;
            List<Set> lista = new List<Set>();
            String stringSql = "SELECT * FROM Enc_eq_sets INNER JOIN sets ON enc_eq_sets.IdSet=sets.IdSet WHERE IdEquipo = '" + idEquipo + "' AND '" + idEncuentro + "' ;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idSet = (int)rs.Fields[3].Value;
                        numeroSet = (int)rs.Fields[4].Value;
                        puntuacionSet = (int)rs.Fields[5].Value;
                        Set set = new Set(idSet, numeroSet, puntuacionSet);
                        lista.Add(set);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public List<Set> getSetsJugadorEncuentro(int idJugador, int idEncuentro)
        {
            //Mapea los sets pertenecientes a jugador en un encuentro determinado a los modelos, y los devuelve en una lista
            int idSet;
            int numeroSet;
            int puntuacionSet;
            List<Set> lista = new List<Set>();
            String stringSql = "SELECT * FROM Enc_jug_sets INNER JOIN sets ON enc_jug_sets.IdSet=sets.IdSet WHERE IdEquipo = '" + idJugador + "' AND '" + idEncuentro + "' ;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idSet = (int)rs.Fields[3].Value;
                        numeroSet = (int)rs.Fields[4].Value;
                        puntuacionSet = (int)rs.Fields[5].Value;
                        Set set = new Set(idSet, numeroSet, puntuacionSet);
                        lista.Add(set);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public Set getSetByID(int id)
        {
            //Devuelve un set dependiendo de su ID
            int numeroSet;
            int puntuacionSet;
            Set set = null;
            String stringSql = "SELECT * FROM Sets WHERE IdSet = '" + id + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                numeroSet = (int)rs.Fields[1].Value;
                puntuacionSet = (int)rs.Fields[2].Value;
                set = new Set(id, numeroSet, puntuacionSet);
                cn.Close();
            }
            catch { }
            return set;
        }

        public bool agregarSet(int numeroSet, int puntuacionSet)
        {
            //Intenta agregar un set a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Sets (NumeroSet, PuntuacionSet) VALUES('" + numeroSet + "', '" + puntuacionSet + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarSetEquipo(int idSet, int idEquipo, int idEncuentro)
        {
            //Intenta agregar un set de un equipo a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Enc_eq_sets (IdSet, IdEquipo, IdEncuentro) VALUES('" + idSet + "', '" + idEquipo + "', '" + idEncuentro + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarSetJugador(int idSet, int idJugador, int idEncuentro)
        {
            //Intenta agregar un set de un jugador a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Enc_jug_sets (IdSet, IdJugador, IdEncuentro) VALUES('" + idSet + "', '" + idJugador + "', '" + idEncuentro + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarSet(int id)
        {
            //Intenta eliminar un set dada una ID en la BD
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Sets WHERE idSet = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarSetsEncuentroEquipo(int idEncuentro)
        {
            //Intenta eliminar todos los sets de un encuentro de equipos dada una ID en la BD
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Enc_eq_sets WHERE idEncuentro = '" + idEncuentro + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarSetsEncuentroIndividual(int idEncuentro)
        {
            //Intenta eliminar todos los sets de un encuentro de equipos dada una ID en la BD
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Enc_jug_sets WHERE idEncuentro = '" + idEncuentro + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarSetDeEquipo(int idSet)
        {
            //Intenta eliminar un set en específico de un encuentro de equipos dada una ID en la BD
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Enc_eq_sets WHERE idSet = '" + idSet + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool eliminarSetDeJugador(int idSet)
        {
            //Intenta eliminar un set en específico de un encuentro de equipos dada una ID en la BD
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Enc_jug_sets WHERE idSet = '" + idSet + "';";
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
            //Devuelve el ID generado tras el último insert en Sets.
            int id = 0;
            String stringSql = "SELECT LAST_INSERT_ID() FROM Sets;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                id = (int)rs.Fields[0].Value;
                cn.Close();
                return id;
            }
            catch{}
            return id;
        }
    }
}
