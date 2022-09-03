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
    public class LogicaDeportes
    {
        DatosDeporte datosDeporte;
        public LogicaDeportes()
        {
            datosDeporte = new DatosDeporte();
        }

        public List<Deporte> devolverDeportes()
        {
            //Devuelve una lista con los deportes en la BD
            return datosDeporte.getDeportes();
        }

        public Deporte devolverDeportePorID(int id)
        {
            //Devuelve un deporte en específico por ID
            return datosDeporte.getDeporteByID(id);
        }

        public bool agregarDeporte(bool porEquipos, bool anotaciones, bool sets, int cantParticipantes, String nombreDeporte, int tamAlineacion)
        {
            //Intenta agregar un deporte a la BD, con los datos dados
            return datosDeporte.agregarDeporte(porEquipos, anotaciones, sets, cantParticipantes, nombreDeporte, tamAlineacion);
        }

        public bool eliminarDeporte(int id)
        {
            //Intenta eliminar un deporte de la BD con la id dada
            return datosDeporte.eliminarDeporte(id);
        }

        public bool modificarDeporte(int id, bool porEquipos, bool anotaciones, bool sets, int cantParticipantes, String nombreDeporte, int tamAlineacion)
        {
            //Intenta modificar un deporte en la BD, con los datos dados
            return datosDeporte.modificarDeporte(id, porEquipos, anotaciones, sets, cantParticipantes, nombreDeporte, tamAlineacion);
        }
    }
}
