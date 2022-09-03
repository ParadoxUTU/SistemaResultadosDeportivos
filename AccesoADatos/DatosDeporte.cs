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
    internal class DatosDeporte
    {
        public List<Deporte> getDeportes()
        {
            //Mapea los deportes existentes a los modelos, y los devuelve en una lista
            int idDeporte;
            bool porEquipos;
            bool anotaciones;
            bool sets;
            int cantParticipantes;
            String nombreDeporte;
            int tamAlineacion = 0;
            List<Deporte> lista = new List<Deporte>();
            String stringSql = "SELECT * FROM Deportes;";
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                if (rs.RecordCount > 0)
                {
                    for (int i = 0; i < (int)cantFilas; i++)
                    {
                        idDeporte = (int)rs.Fields[0].Value;
                        porEquipos = Convert.ToBoolean(rs.Fields[1].Value);
                        anotaciones = Convert.ToBoolean(rs.Fields[2].Value);
                        sets = Convert.ToBoolean(rs.Fields[3].Value);
                        cantParticipantes = (int)rs.Fields[4].Value;
                        nombreDeporte = (String)rs.Fields[5].Value;
                        try
                        {
                            tamAlineacion = (int)rs.Fields[6].Value;
                        }
                        catch {}
                        Deporte deporte = new Deporte(idDeporte, porEquipos, anotaciones, sets, cantParticipantes, nombreDeporte, tamAlineacion);
                        lista.Add(deporte);
                        rs.MoveNext();
                    }
                }
                cn.Close();
            }
            catch {}
            return lista;
        }

        public Deporte getDeporteByID(int id)
        {
            //Devuelve un deporte dependiendo de su ID
            bool porEquipos;
            bool anotaciones;
            bool sets;
            int cantParticipantes;
            String nombreDeporte;
            int tamAlineacion = 0;
            Deporte deporte = null;
            String stringSql = "SELECT * FROM Deportes WHERE IdDeporte = '" + id + "';"; 
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                ADODB.Recordset rs = cn.Execute(stringSql, out object cantFilas, -1);
                porEquipos = Convert.ToBoolean(rs.Fields[1].Value); 
                anotaciones = Convert.ToBoolean(rs.Fields[2].Value);
                sets = Convert.ToBoolean(rs.Fields[3].Value);
                cantParticipantes = (int)rs.Fields[4].Value;
                nombreDeporte = (String)rs.Fields[5].Value;
                try
                {
                    tamAlineacion = (int)rs.Fields[6].Value;
                }
                catch { }
                deporte = new Deporte(id, porEquipos, anotaciones, sets, cantParticipantes, nombreDeporte, tamAlineacion);
                cn.Close();
            }
            catch { }
            return deporte;
        }

        public bool agregarDeporte(bool porEquipos, bool anotaciones, bool sets, int cantParticipantes, String nombreDeporte, int tamAlineacion)
        {
            //Intenta agregar un deporte a la BD con los datos dados
            sbyte pE = Convert.ToSByte(porEquipos);
            sbyte a = Convert.ToSByte(anotaciones);
            sbyte s = Convert.ToSByte(sets);
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "INSERT INTO Deportes (PorEquipos, Anotaciones, Sets, CantParticipantes, NombreDeporte, TamAlineacion) VALUES('" + pE + "', '" + a + "', '" + s + "', '" + cantParticipantes + "', '" + nombreDeporte + "', '" + tamAlineacion + "');";
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

        public bool eliminarDeporte(int id)
        {
            //Intenta eliminar un deporte de la BD, dada una id
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "DELETE FROM Deportes WHERE IdDeporte = '" + id + "';";
                cn.Execute(stringSql, out object cantFilas, -1);
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarDeporte(int id, bool porEquipos, bool anotaciones, bool sets, int cantParticipantes, String nombreDeporte, int tamAlineacion)
        {
            //Intenta modificar un deporte existente en la BD con los datos dados
            sbyte pE = Convert.ToSByte(porEquipos);
            sbyte a = Convert.ToSByte(anotaciones);
            sbyte s = Convert.ToSByte(sets);
            try
            {
                ADODB.Connection cn = Conexion.Crear();
                String stringSql = "UPDATE Deportes SET PorEquipos = '" + pE + "', Anotaciones = '" + a + "', Sets = '" + s + "', CantParticipantes = '" + cantParticipantes + "', NombreDeporte = '" + nombreDeporte + "', TamAlineacion = '" + tamAlineacion + "' WHERE IdDeporte = '" + id + "';";
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
