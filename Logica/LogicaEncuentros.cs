using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaResultadosDeportivos.AccesoADatos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaResultadosDeportivos.Modelos;
using SistemaResultadosDeportivos.APIs;

namespace SistemaResultadosDeportivos.Logica
{
    public class LogicaEncuentros
    {
        DatosEncuentro datosEncuentro;
        public LogicaEncuentros()
        {
            datosEncuentro = new DatosEncuentro();
        }

        public List<Encuentro> devolverEncuentros()
        {
            //Devuelve una lista con los encuentros en la BD
            return datosEncuentro.getEncuentros();
        }

        public List<Encuentro> devolverEncuentrosPorTorneo(int idTorneo)
        {
            //Devuelve una lista con los encuentros de un torneo en la BD
            return datosEncuentro.getEncuentrosByTorneo(idTorneo);
        }

        public List<Alineacion> devolverAlineacion(int idEquipo, int idEncuentro)
        {
            //Devuelve una lista de la alineacion de un equipo en un encuentro dado de la BD
            return datosEncuentro.getAlineacion(idEquipo, idEncuentro);
        }

        public bool agregarEncuentro(String fecha, String hora, bool pausado, int minActual, bool comenzo, bool finalizo, String nombreEncuentro, int idDeporte)
        {
            //Intenta agregar un encuentro a la BD, con los datos dados
            return datosEncuentro.agregarEncuentro(fecha, hora, pausado, minActual, comenzo, finalizo, nombreEncuentro, idDeporte);
        }

        public bool agregarEncInd(int idEncuentro)
        {
            //Intenta agregar un encuentro individual a la BD con los datos dados
            return datosEncuentro.agregarEncInd(idEncuentro);
        }

        public bool agregarEncCol(int idEncuentro, int cantCambios)
        {
            //Intenta agregar un encuentro colectivo a la BD con los datos dados
            return datosEncuentro.agregarEncCol(idEncuentro, cantCambios);
        }

        public bool agregarEncuentroTorneo(int idEncuentro, int idTorneo, String etapa)
        {
            //Intenta agregar un encuentro de torneo a la BD, con los datos dados
            return datosEncuentro.agregarEncuentroTorneo(idEncuentro, idTorneo, etapa);
        }

        public bool agregarEncuentroJugador(int idEncuentro, int idJugador, int puesto, int puntuacion)
        {
            //Intenta agregar un encuentro de jugador a la BD con los datos dados
            return datosEncuentro.agregarEncuentroJugador(idEncuentro, idJugador, puesto, puntuacion);
        }

        public bool eliminarEncuentroJugadorPorEncuentro(int id)
        {
            //Intenta eliminar un encuentro de jugador de la BD con la id dada
            return datosEncuentro.eliminarEncuentroJugadorPorEncuentro(id);
        }

        public bool agregarEncuentroEquipo(int idEncuentro, int idEquipo, int ganador, int puntuacion)
        {
            //Intenta agregar un encuentro de equipo a la BD con los datos dados
            return datosEncuentro.agregarEncuentroEquipo(idEncuentro, idEquipo, ganador, puntuacion);
        }

        public bool eliminarEncuentroEquipoPorEncuentro(int id)
        {
            //Intenta eliminar un encuentro de equipo de la BD con la id dada
            return datosEncuentro.eliminarEncuentroEquipoPorEncuentro(id);
        }

        public bool eliminarEncuentro(int id)
        {
            //Intenta eliminar un encuentro de la BD con la id dada
            return datosEncuentro.eliminarEncuentro(id);
        }

        public bool eliminarEncInd(int id)
        {
            //Intenta eliminar un encuentro individual de la BD con la id dada
            return datosEncuentro.eliminarEncInd(id);
        }

        public bool eliminarEncCol(int id)
        {
            //Intenta eliminar un encuentro colectivo de la BD con la id dada
            return datosEncuentro.eliminarEncCol(id);
        }

        public bool eliminarEncuentroTorneo(int id)
        {
            //Intenta eliminar un encuentro de torneo de la BD con la id dada
            return datosEncuentro.eliminarEncuentroTorneo(id);
        }

        public bool eliminarAlineacionesDeEncuentro(int id)
        {
            //Intenta eliminar las alineaciones de un encuentro en la BD 
            return datosEncuentro.eliminarAlineacionesDeEncuentro(id);
        }

        public bool modificarEncuentro(int id, String fecha, String hora, bool pausado, int minActual, bool comenzo, bool finalizo, String nombreEncuentro, int idDeporte)
        {
            //Intenta modificar un encuentro en la BD, con los datos dados
            return datosEncuentro.modificarEncuentro(id, fecha, hora, pausado, minActual, comenzo, finalizo, nombreEncuentro, idDeporte);
        }

        public int devolverUltimaID()
        {
            //Devuelve la última ID generada.
            return datosEncuentro.getLastID();  
        }
    }
}
