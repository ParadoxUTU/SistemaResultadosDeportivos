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
    internal class DatosJugador
    {
        public List<Jugador> getJugadores()
        {
            //Mapea los jugadores existentes a los modelos, y los devuelve en una lista
            int idJugador;
            String nombreJugador;
            int edad;
            int peso;
            int estatura;
            String pais;
            int idDeporte;
            List<Jugador> lista = new List<Jugador>();
            String stringSql = "SELECT * FROM Jugadores;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idJugador = (int)rs.Fields[0].Value;
                        nombreJugador = (string)rs.Fields[1].Value;
                        edad = (int)rs.Fields[2].Value;
                        peso = (int)rs.Fields[3].Value;
                        estatura = (int)rs.Fields[4].Value;
                        pais = (string)rs.Fields[5].Value;
                        idDeporte = (int)rs.Fields[6].Value;
                        Jugador jugador = new Jugador(idJugador, nombreJugador, edad, peso, estatura, pais, idDeporte);
                        lista.Add(jugador);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public Jugador getJugadorByID(int id)
        {
            //Devuelve un jugador dependiendo de su ID
            int idJugador;
            String nombreJugador;
            int edad;
            int peso;
            int estatura;
            String pais;
            int idDeporte;
            Jugador jugador = null;
            String stringSql = "SELECT * FROM Jugadores WHERE IdJugador = '" + id + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                idJugador = (int)rs.Fields[0].Value;
                nombreJugador = (string)rs.Fields[1].Value;
                edad = (int)rs.Fields[2].Value;
                peso = (int)rs.Fields[3].Value;
                estatura = (int)rs.Fields[4].Value;
                pais = (string)rs.Fields[5].Value;
                idDeporte = (int)rs.Fields[6].Value;
                jugador = new Jugador(idJugador, nombreJugador, edad, peso, estatura, pais, idDeporte);
                cn.Close();
            }
            catch { }
            return jugador;
        }

        public List<Jugador> getJugadoresByDeporte(int idDeporte)
        {
            //Mapea los jugadores pertenecientes a un deporte existentes a los modelos, y los devuelve en una lista
            int idJugador;
            String nombreJugador;
            int edad;
            int peso;
            int estatura;
            String pais;
            List<Jugador> lista = new List<Jugador>();
            String stringSql = "SELECT * FROM Jugadores WHERE IdDeporte = '" + idDeporte + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idJugador = (int)rs.Fields[0].Value;
                        nombreJugador = (string)rs.Fields[1].Value;
                        edad = (int)rs.Fields[2].Value;
                        peso = (int)rs.Fields[3].Value;
                        estatura = (int)rs.Fields[4].Value;
                        pais = (string)rs.Fields[5].Value;
                        Jugador jugador = new Jugador(idJugador, nombreJugador, edad, peso, estatura, pais, idDeporte);
                        lista.Add(jugador);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public List<Jugador> getJugadoresByTorneo(int idTorneo)
        {
            //Mapea los jugadores pertenecientes a un torneo existentes a los modelos, y los devuelve en una lista
            int idJugador;
            String nombreJugador;
            int edad;
            int peso;
            int estatura;
            String pais;
            int idDeporte;
            List<Jugador> lista = new List<Jugador>();
            String stringSql = "SELECT * FROM Jugadores_Torneos INNER JOIN Jugadores ON Jugadores_Torneos.IdJugador=Jugadores.IdJugador WHERE IdTorneo = '" + idTorneo + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idJugador = (int)rs.Fields[0].Value;
                        nombreJugador = (string)rs.Fields[4].Value;
                        edad = (int)rs.Fields[5].Value;
                        peso = (int)rs.Fields[6].Value;
                        estatura = (int)rs.Fields[7].Value;
                        pais = (string)rs.Fields[8].Value;
                        idDeporte = (int)rs.Fields[9].Value;
                        Jugador jugador = new Jugador(idJugador, nombreJugador, edad, peso, estatura, pais, idDeporte);
                        lista.Add(jugador);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public List<Jugador> getJugadoresByEncuentro(int idEncuentro)
        {
            //Mapea los jugadores pertenecientes a un torneo existentes a los modelos, y los devuelve en una lista
            int idJugador;
            String nombreJugador;
            int edad;
            int peso;
            int estatura;
            String pais;
            int idDeporte;
            List<Jugador> lista = new List<Jugador>();
            String stringSql = "SELECT * FROM encuentros_jugadores INNER JOIN Jugadores ON encuentros_jugadores.IdJugador=Jugadores.IdJugador WHERE IdEncuentro = '" + idEncuentro + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idJugador = (int)rs.Fields[4].Value;
                        nombreJugador = (string)rs.Fields[5].Value;
                        edad = (int)rs.Fields[6].Value;
                        peso = (int)rs.Fields[7].Value;
                        estatura = (int)rs.Fields[8].Value;
                        pais = (string)rs.Fields[9].Value;
                        idDeporte = (int)rs.Fields[10].Value;
                        Jugador jugador = new Jugador(idJugador, nombreJugador, edad, peso, estatura, pais, idDeporte);
                        lista.Add(jugador);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public List<Jugador> getJugadoresByEquipo(int idEquipo)
        {
            //Mapea los jugadores pertenecientes a un plantel existentes a los modelos, y los devuelve en una lista
            int idJugador;
            String nombreJugador;
            int edad;
            int peso;
            int estatura;
            String pais;
            int idDeporte;
            List<Jugador> lista = new List<Jugador>();
            String stringSql = "SELECT * FROM Plantel INNER JOIN Jugadores ON plantel.IdJugador=jugadores.IdJugador WHERE IdEquipo = '" + idEquipo + "';";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idJugador = (int)rs.Fields[2].Value;
                        nombreJugador = (string)rs.Fields[3].Value;
                        edad = (int)rs.Fields[4].Value;
                        peso = (int)rs.Fields[5].Value;
                        estatura = (int)rs.Fields[6].Value;
                        pais = (string)rs.Fields[7].Value;
                        idDeporte = (int)rs.Fields[8].Value;
                        Jugador jugador = new Jugador(idJugador, nombreJugador, edad, peso, estatura, pais, idDeporte);
                        lista.Add(jugador);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch { }
            return lista;
        }

        public bool agregarJugador(String nombreJugador, int edad, int peso, int estatura, String pais, int idDeporte)
        {
            //Intenta agregar un jugador a la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Jugadores (NombreJugador, Edad, Peso, Estatura, Pais, IdDeporte) VALUES('" + nombreJugador + "', '" + edad + "', '" + peso + "', '" + estatura + "', '" + pais + "', '"+ idDeporte + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarJugadorAPlantel(int idJugador, int idEquipo)
        {
            //Intenta agregar un jugador a un plantel de la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Plantel (IdJugador, IdEquipo) VALUES('" + idJugador + "', '" + idEquipo + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool agregarJugadorAAlineacion(int idJugador, int idEquipo, int idEncuentro, int numero)
        {
            //Intenta agregar un jugador a una alineacion de la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Alineaciones (IdJugador, IdEquipo, IdEncuentro, Numero) VALUES('" + idJugador + "', '" + idEquipo + "', '" + idEncuentro + "', '" + numero + "');";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarJugador(int id)
        {
            //Intenta eliminar un jugador de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Jugadores WHERE IdJugador = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarJugador(int id, String nombreJugador, int edad, int peso, int estatura, String pais, int idDeporte)
        {
            //Intenta modificar un torneo existente en la BD con los datos dados
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "UPDATE Jugadores SET NombreJugador = '" + nombreJugador + "', Edad = '" + edad + "', peso = '" + peso + "', Estatura = '" + estatura + "', Pais = '" + pais + "' WHERE IdJugador = '" + id + "';";
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
            String stringSql = "SELECT LAST_INSERT_ID() FROM Jugadores;";
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
