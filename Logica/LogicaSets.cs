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
    public class LogicaSets
    {
        DatosSet datosSet;

        public LogicaSets()
        {
            datosSet = new DatosSet();
        }

        public List<Set> devolverSets()
        {
            //Devuelve una lista con todos los sets en la BD
            return datosSet.getSets();
        }

        public List<Set> devolverSetsEquipoEncuentro(int idEquipo, int idEncuentro)
        {
            //Devuelve una lista con los sets pertenecientes a un equipo en un encuentro dado
            return datosSet.getSetsEquipoEncuentro(idEquipo, idEncuentro);
        }

        public List<Set> devolverSetsJugadorEncuentro(int idJugador, int idEncuentro)
        {
            //Devuelve una lista con los sets pertenecientes a un jugador en un encuentro dado
            return datosSet.getSetsJugadorEncuentro(idJugador, idEncuentro);
        }

        public Set devolverSetPorID(int idSet)
        {
            //Devuelve un set dependiendo de su ID
            return datosSet.getSetByID(idSet);
        }

        public bool agregarSet(int numeroSet, int puntuacionSet)
        {
            //Agrega un set con los datos dados
            return datosSet.agregarSet(numeroSet, puntuacionSet);
        }

        public bool agregarSetEquipo(int idSet, int idEquipo, int idEncuentro)
        {
            //Agrega un set a un equipo en determinado encuentro
            return datosSet.agregarSetEquipo(idSet, idEquipo, idEncuentro);
        }

        public bool agregarSetJugador(int idSet, int idJugador, int idEncuentro)
        {
            //Agrega un set a un equipo en determinado encuentro
            return datosSet.agregarSetJugador(idSet, idJugador, idEncuentro);
        }

        public bool eliminarSetsEncuentroEquipos(int idEncuentro)
        {
            //Elimina todos los sets de un encuentro por equipos
            return datosSet.eliminarSetsEncuentroEquipo(idEncuentro);
        }

        public bool eliminarSetsEncuentroIndividual(int idEncuentro)
        {
            //Elimina todos los sets de un encuentro individual
            return datosSet.eliminarSetsEncuentroIndividual(idEncuentro);
        }

        public int devolverUltimaID()
        {
            //Devuelve la ultima ID generada en la tabla Sets
            return datosSet.getLastID();
        }
    }
}
