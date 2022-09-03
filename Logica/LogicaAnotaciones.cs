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
    public class LogicaAnotaciones
    {
        DatosAnotacion datosAnotacion;

        public LogicaAnotaciones()
        {
            datosAnotacion = new DatosAnotacion();
        }

        public List<Anotacion> devolverAnotacionesPorEncuentro(int idEncuentro)
        {
            //Devuelve una lista con las anotaciones pertenecientes a un encuentro en la BD
            return datosAnotacion.getAnotacionesByEncuentro(idEncuentro);
        }

        public List<Anotacion> devolverAnotacionesPorEncuentroYEquipo(int idEncuentro, int idEquipo)
        {
            //Devuelve una lista con las anotaciones de un equipo pertenecientes a un encuentro en la BD
            return datosAnotacion.getAnotacionesByEncuentroAndEquipo(idEncuentro, idEquipo);
        }

        public int devolverAnotacionesEquipo(int idEncuentro, int idEquipo)
        {
            //Suma las anotaciones de un equipo en un encuentro para determinar su puntaje
            return datosAnotacion.getCountAnotaciones(idEncuentro, idEquipo);
        }

        public bool agregarAnotacion(int idJugador, int minuto, int idEquipo, int idEncuentro)
        {
            //Agrega una anotación a un equipo en determinado encuentro
            return datosAnotacion.agregarAnotacion(idJugador, minuto, idEquipo, idEncuentro);
        }


        public bool eliminarAnotacion(int id)
        {
            //Intenta eliminar una anotación de la BD con la id dada
            return datosAnotacion.eliminarAnotacion(id);
        }

        public bool eliminarAnotacionesDeEncuentro(int idEncuentro)
        {
            //Intenta eliminar todas las anotaciones de un encuentro
            return datosAnotacion.eliminarAnotacionesDeEncuentro(idEncuentro);
        }

        public RespuestaAnotaciones devolverAnotacionesEquipoEnObjeto(int idEncuentro, int idEquipo)
        {
            //Suma las anotaciones de un equipo en un encuentro para determinar su puntaje y lo devuelve en un objeto de respuesta
            int puntaje = datosAnotacion.getCountAnotaciones(idEncuentro, idEquipo);
            RespuestaAnotaciones res = new RespuestaAnotaciones(puntaje);
            return res;
        }
    }
}
