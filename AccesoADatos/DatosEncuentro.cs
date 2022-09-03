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
    internal class DatosEncuentro
    {
        public List<Encuentro> getEncuentros()
        {
            //Mapea los encuentros existentes a los modelos, y los devuelve en una lista
            int idEncuentro;
            DateTime fecha;
            DateTime hora;
            bool pausado = false;
            int minActual;
            bool comenzo = false;
            bool finalizo = false;
            String nombreEncuentro;
            int idDeporte;
            List<Encuentro> lista = new List<Encuentro>();
            String stringSql = "SELECT * FROM Encuentros;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idEncuentro = (int)rs.Fields[0].Value;
                        fecha = rs.Fields[1].Value;
                        hora = rs.Fields[2].Value;
                        pausado = Convert.ToBoolean(rs.Fields[3].Value);
                        minActual = (int)rs.Fields[4].Value;
                        comenzo = Convert.ToBoolean(rs.Fields[5].Value);
                        finalizo = Convert.ToBoolean(rs.Fields[6].Value);
                        nombreEncuentro = (String)rs.Fields[7].Value;
                        idDeporte = (int)rs.Fields[8].Value;
                        Encuentro encuentro = new Encuentro(idEncuentro, fecha, hora, pausado, minActual, comenzo, finalizo, nombreEncuentro, idDeporte);
                        lista.Add(encuentro);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            return lista;
        }

        public List<Encuentro> getEncuentrosByTorneo(int idTorneo)
        {
            //Mapea los encuentros existentes a los modelos, y los devuelve en una lista
            int idEncuentro;
            DateTime fecha;
            DateTime hora;
            bool pausado;
            int minActual;
            bool comenzo;
            bool finalizo;
            String nombreEncuentro;
            int idDeporte;
            List<Encuentro> lista = new List<Encuentro>();
            String stringSql = "SELECT * FROM Encuentros_Torneos INNER JOIN Encuentros ON encuentros_torneos.IdEncuentro=Encuentros.IdEncuentro WHERE IdTorneo = '" + idTorneo + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idEncuentro = (int)rs.Fields[3].Value;
                        fecha = rs.Fields[4].Value;
                        hora = rs.Fields[5].Value;
                        pausado = Convert.ToBoolean(rs.Fields[6].Value);
                        minActual = (int)rs.Fields[7].Value;
                        comenzo = Convert.ToBoolean(rs.Fields[8].Value);
                        finalizo = Convert.ToBoolean(rs.Fields[9].Value);
                        nombreEncuentro = (String)rs.Fields[10].Value;
                        idDeporte = (int)rs.Fields[11].Value;
                        Encuentro encuentro = new Encuentro(idEncuentro, fecha, hora, pausado, minActual, comenzo, finalizo, nombreEncuentro, idDeporte);
                        lista.Add(encuentro);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return lista;
        }

        public int getCountEncuentrosEquipos(int idEncuentro)
        {
            //Devuelve la cantidad de equipos que hay seleccionados en un encuentro
            int cantidadEquipos = 0;
            String stringSql = "SELECT * FROM encuentros_equipos WHERE IdEncuentro = '" + idEncuentro + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                cantidadEquipos = rs.RecordCount;
            }
            catch
            {
                cantidadEquipos = 0;
            }
            return cantidadEquipos;
        }

        public int getCountEncuentrosJugadores(int idEncuentro)
        {
            //Devuelve la cantidad de equipos que hay seleccionados en un encuentro
            int cantidadJugadores = 0;
            String stringSql = "SELECT * FROM encuentros_jugadores WHERE IdEncuentro = '" + idEncuentro + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                cantidadJugadores = rs.RecordCount;
            }
            catch
            {
                cantidadJugadores = 0;
            }
            return cantidadJugadores;
        }

        public List<Alineacion> getAlineacion(int idEquipo, int idEncuentro)
        {
            //Devuelve la alineacion de un equipo en un encuentro dado
            int idJugador;
            int numero;
            List<Alineacion> lista = new List<Alineacion>();
            String stringSql = "SELECT * FROM Alineaciones WHERE IdEquipo = '" + idEquipo + "' AND IdEncuentro = '" + idEncuentro + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idJugador = (int)rs.Fields[2].Value;
                        numero = (int)rs.Fields[3].Value;
                        Alineacion alineacion = new Alineacion(idEquipo, idEncuentro, idJugador, numero);
                        lista.Add(alineacion);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return lista;
        }

        public bool agregarEncuentro(String fecha, String hora, bool pausado, int minActual, bool comenzo, bool finalizo, String nombreEncuentro, int idDeporte)
        {
            //Intenta agregar un encuentro a la BD con los datos dados
            sbyte p = Convert.ToSByte(pausado);
            sbyte c = Convert.ToSByte(comenzo);
            sbyte f = Convert.ToSByte(finalizo);
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Encuentros (Fecha, Hora, Pausado, MinActual, Comenzo, Finalizo, NombreEncuentro, IdDeporte) VALUES('" + fecha + "', '" + hora + "', '" + p + "', '" + minActual + "', '" + c + "', '" + f + "', '" + nombreEncuentro + "', '" + idDeporte + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarEncInd(int idEncuentro)
        {
            //Intenta agregar un encuentro individual a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Enc_ind (IdEncuentro) VALUES('" + idEncuentro + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarEncCol(int idEncuentro, int cantCambios)
        {
            //Intenta agregar un encuentro colectivo a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Enc_col (IdEncuentro, CantCambios) VALUES('" + idEncuentro + "', '" + cantCambios +"');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool agregarEncuentroTorneo(int idEncuentro, int idTorneo, String etapa)
        {
            //Intenta agregar un encuentro de torneo a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Encuentros_Torneos (IdEncuentro, IdTorneo, Etapa) VALUES('" + idEncuentro + "', '" + idTorneo + "', '" + etapa + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarEncuentroJugador(int idEncuentro, int idJugador, int puesto, int puntuacion)
        {
            //Intenta agregar un encuentro de jugador a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Encuentros_Jugadores (IdEncuentro, IdJugador, Puesto, Puntuacion) VALUES('" + idEncuentro + "', '" + idJugador + "', '" + puesto + "', '" + puntuacion + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool eliminarEncuentroJugadorPorEncuentro(int idEncuentro)
        {
            //Intenta eliminar un encuentro de jugador de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Encuentros_Jugadores WHERE IdEncuentro = '" + idEncuentro + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarEncuentroEquipo(int idEncuentro, int idEquipo, int ganador, int puntuacion)
        {
            //Intenta agregar un encuentro de jugador a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO encuentros_equipos(IdEncuentro, IdEquipo, Ganador, Puntuacion) VALUES('" + idEncuentro + "', '" + idEquipo + "', '" + ganador + "', '" + puntuacion + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool eliminarEncuentroEquipoPorEncuentro(int idEncuentro)
        {
            //Intenta eliminar un encuentro de equipo de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Encuentros_Equipos WHERE IdEncuentro = '" + idEncuentro + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarEncuentro(int id)
        {
            //Intenta eliminar un encuentro de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Encuentros WHERE IdEncuentro = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarEncInd(int id)
        {
            //Intenta eliminar un encuentro individual de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM enc_ind WHERE IdEncuentro = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarEncCol(int id)
        {
            //Intenta eliminar un encuentro colectivo de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM enc_col WHERE IdEncuentro = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarEncuentroTorneo(int id)
        {
            //Intenta eliminar un encuentro de torneo de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM encuentros_torneos WHERE IdEncuentro = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarAlineacionesDeEncuentro(int idEncuentro)
        {
            //Intenta eliminar las alineaciones de un encuentro en la BD
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Alineaciones WHERE IdEncuentro = '" + idEncuentro + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarEncuentro(int id, String fecha, String hora, bool pausado, int minActual, bool comenzo, bool finalizo, String nombreEncuentro, int idDeporte)
        {
            //Intenta modificar un encuentro existente en la BD con los datos dados
            sbyte p = Convert.ToSByte(pausado);
            sbyte c = Convert.ToSByte(comenzo);
            sbyte f = Convert.ToSByte(finalizo);
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "UPDATE Encuentros SET Fecha = '" + fecha + "', Hora = '" + hora + "', pausado = '" + p + "', MinActual = '" + minActual + "', Comenzo = '" + c + "', Finalizo = '" + f + "', NombreEncuentro = '" + nombreEncuentro + "', IdDeporte = '" + idDeporte + "' WHERE IdEncuentro = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public int getLastID()
        {
            //Devuelve el ID generado tras el último insert.
            int id = 0;
            String stringSql = "SELECT LAST_INSERT_ID() FROM Encuentros;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                id = (int)rs.Fields[0].Value;
                cn.Close();                
                return id;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            return id;
        }
    }
}
