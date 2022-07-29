using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaResultadosDeportivos.Logica;

namespace SistemaResultadosDeportivos.APIs
{
    public class APIpublicidad
    {
        private LogicaPublicidad lgp;

        public APIpublicidad()
        {
            lgp = new LogicaPublicidad();
        }

        public String publicidadToJSON()
        {
            //Devuelve la respuesta de publicidad en formato JSON
            var json = JObject.FromObject(lgp.publicidadRandom());
            return json.ToString();
        }
    }
}
