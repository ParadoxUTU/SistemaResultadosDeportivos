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
    public partial class LogicaPublicidad
    {
        DatosPublicidad datosPublicidad;
        Random random;

        public LogicaPublicidad()
        {
            datosPublicidad = new DatosPublicidad();
            random = new Random();
        }

        public RespuestaPublicidad publicidadRandom()
        {
            /*Elige una publicidad al azar de la BD, y devuelve una respuesta con la ruta
            de su banner, y la url del sitio correspondiente*/
            List<Publicidad> lista = datosPublicidad.getPublicidades();
            RespuestaPublicidad res;
            if(lista != null)
            {
                Publicidad publicidad = lista[random.Next(0, lista.Count)];
                String pathBanner = publicidad.pathBanner;
                String urlSitio = publicidad.urlSitio;
                res = new RespuestaPublicidad(pathBanner, urlSitio);
            }
            else
            {
                res = new RespuestaPublicidad("", "");
            }
            return res;
        }

        public List<Publicidad> devolverPublicidades()
        {
            //Devuelve una lista con las publicidades de la BD
            return datosPublicidad.getPublicidades();
        }

        public bool agregarPublicidad(String marca, String pathBanner, String urlSitio)
        {
            //Intenta agregar una publicidad a la BD, con los datos dados
            return datosPublicidad.agregarPublicidad(marca, pathBanner, urlSitio);
        }

        public bool eliminarPublicidad(String id)
        {
            //Intenta eliminar una publicidad de la BD, con la id dada
            return datosPublicidad.eliminarPublicidad(id);
        }

        public bool modificarPublicidad(int id, String marca, String pathBanner, String urlSitio)
        {
            //Intenta modificar una publicidad de la BD, con los datos dados
            return datosPublicidad.modificarPublicidad(id, marca, pathBanner, urlSitio);
        }
    }
}

