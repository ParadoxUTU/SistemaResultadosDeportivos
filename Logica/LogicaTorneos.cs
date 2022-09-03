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
    public class LogicaTorneos
    {
        DatosTorneo datosTorneo;
        public LogicaTorneos()
        {
            datosTorneo = new DatosTorneo();
        }

        public List<Torneo> devolverTorneos()
        {
            //Devuelve una lista con los torneos en la BD
            return datosTorneo.getTorneos();
        }

        public List<Torneo> devolverTorneosPorDeporte(int idDeporte)
        {
            //Devuelve todos los torneos pertenecientes a un deporte
            return datosTorneo.getTorneosByDeporte(idDeporte);
        }

        public Torneo devolverTorneoPorID(int id)
        {
            //Devuelve un torneo en específico por ID
            return datosTorneo.getTorneoByID(id);
        }

        public Torneo devolverTorneoPorEncuentro(int idEncuentro)
        {
            //Devuelve un torneo en específico por encuentro
            return datosTorneo.getTorneoByEncuentro(idEncuentro);
        }

        public bool agregarTorneo(String fechaComienzo, String fechaFin, string nombrePais, string nombreTorneo, int idDeporte)
        {
            //Intenta agregar un torneo a la BD, con los datos dados
            return datosTorneo.agregarTorneo(fechaComienzo, fechaFin, nombrePais, nombreTorneo, idDeporte);
        }

        public bool eliminarTorneo(int id)
        {
            //Intenta eliminar un torneo de la BD con la id dada
            return datosTorneo.eliminarTorneo(id);
        }

        public bool modificarTorneo(int id, String fechaComienzo, String fechaFin, string nombrePais, string nombreTorneo, int idDeporte)
        {
            //Intenta modificar un torneo en la BD, con los datos dados
            return datosTorneo.modificarTorneo(id, fechaComienzo, fechaFin, nombrePais, nombreTorneo, idDeporte);
        }

        public int devolverUltimaID()
        {
            //Devuelve la última ID generada.
            return datosTorneo.getLastID();
        }
    }
}
