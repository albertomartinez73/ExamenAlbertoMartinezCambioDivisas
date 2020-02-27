using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ExamenAlbertoMartinezCambioDivisas.Services.JsonConverterService
{
    public class JsonConverter<T> : IJsonConverter<T> where T : class
    {
        public List<T> DeserializeJson(string contenido)
        {
            return JsonConvert.DeserializeObject<List<T>>(contenido);
        }
    }
}