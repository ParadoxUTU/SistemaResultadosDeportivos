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
    internal class LogicaJugadores
    {
        DatosJugador datosJugador;

        public LogicaJugadores()
        {
            datosJugador = new DatosJugador();
        }

        public List<Jugador> devolverJugadores()
        {
            //Devuelve una lista con los jugadores en la BD
            return datosJugador.getJugadores();
        }

        public Jugador devolverJugadorPorID(int id)
        {
            //Devuelve un jugador en específico por ID
            return datosJugador.getJugadorByID(id);
        }

        public List<Jugador> devolverJugadoresPorDeporte(int idDeporte)
        {
            //Devuelve una lista con los jugadores pertenecientes a un deporte en la BD
            return datosJugador.getJugadoresByDeporte(idDeporte);
        }

        public List<Jugador> devolverJugadoresPorTorneo(int idTorneo)
        {
            //Devuelve una lista con los jugadores pertenecientes a un torneo en la BD
            return datosJugador.getJugadoresByTorneo(idTorneo);
        }

        public List<Jugador> devolverJugadoresPorEncuentro(int idEncuentro)
        {
            //Devuelve una lista con los jugadores pertenecientes a un encuentro en la BD
            return datosJugador.getJugadoresByEncuentro(idEncuentro);
        }

        public List<Jugador> devolverJugadoresPorEquipo(int idEquipo)
        {
            //Devuelve una lista con los jugadores pertenecientes a un equipo en la BD
            return datosJugador.getJugadoresByEquipo(idEquipo);
        }

        public bool agregarJugador(String nombreJugador, int edad, int peso, int estatura, String pais, int idDeporte)
        {
            //Intenta agregar un jugador a la BD, con los datos dados
            return datosJugador.agregarJugador(nombreJugador, edad, peso, estatura, pais, idDeporte);
        }

        public bool agregarJugadorAPlantel(int idJugador, int idEquipo)
        {
            //Intenta agregar un jugador a un plantel de la BD, con los datos dados
            return datosJugador.agregarJugadorAPlantel(idJugador, idEquipo);
        }

        public bool agregarJugadorAAlineacion(int idJugador, int idEquipo, int idEncuentro, int numero)
        {
            //Intenta agregar un jugador a una alineacion de la BD, con los datos dados
            return datosJugador.agregarJugadorAAlineacion(idJugador, idEquipo, idEncuentro, numero);
        }

        public bool eliminarJugador(int id)
        {
            //Intenta eliminar un jugador de la BD con la id dada
            return datosJugador.eliminarJugador(id);
        }

        public bool modificarJugador(int id, String nombreJugador, int edad, int peso, int estatura, String pais, int idDeporte)
        {
            //Intenta modificar un jugador en la BD, con los datos dados
            return datosJugador.modificarJugador(id, nombreJugador, edad, peso, estatura, pais, idDeporte);
        }

        public int devolverUltimaID()
        {
            //Devuelve la última ID generada.
            return datosJugador.getLastID();
        }
    }
}
