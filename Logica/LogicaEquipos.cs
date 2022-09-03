using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaResultadosDeportivos.AccesoADatos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Modelos;

namespace SistemaResultadosDeportivos.Logica
{
    public class LogicaEquipos
    {
        DatosEquipo datosEquipo;

        public LogicaEquipos()
        {
            datosEquipo = new DatosEquipo();
        }

        public List<Equipo> devolverEquipos()
        {
            //Devuelve una lista con los equipos en la BD
            return datosEquipo.getEquipos();
        }

        public Equipo devolverEquipoPorID(int id)
        {
            //Devuelve un equipo en específico por ID
            return datosEquipo.getEquipoByID(id);
        }

        public List<Equipo> devolverEquiposPorDeporte(int idDeporte)
        {
            //Devuelve una lista con los equipos pertenecientes a un deporte en la BD
            return datosEquipo.getEquiposByDeporte(idDeporte);
        }

        public List<Equipo> devolverEquiposPorTorneo(int idTorneo)
        {
            //Devuelve una lista con los equipos pertenecientes a un torneo en la BD
            return datosEquipo.getEquiposByTorneo(idTorneo);
        }

        public List<Equipo> devolverEquiposPorEncuentro(int idEncuentro)
        {
            //Devuelve una lista con los equipos pertenecientes a un encuentro en la BD
            return datosEquipo.getEquiposByEncuentro(idEncuentro);
        }

        public bool agregarEquipo(String nombrePais, String nombreEquipo, int idDeporte)
        {
            //Intenta agregar un equipo a la BD, con los datos dados
            return datosEquipo.agregarEquipo(nombrePais, nombreEquipo, idDeporte);
        }

        public bool eliminarEquipo(int id)
        {
            //Intenta eliminar un equipo de la BD con la id dada
            return datosEquipo.eliminarEquipo(id);
        }

        public bool modificarEquipo(int id, String nombrePais, String nombreEquipo, int idDeporte)
        {
            //Intenta modificar un equipo en la BD, con los datos dados
            return datosEquipo.modificarEquipo(id, nombrePais, nombreEquipo, idDeporte);
        }

        public int devolverUltimaID()
        {
            //Devuelve la última ID generada.
            return datosEquipo.getLastID();
        }
    }
}
