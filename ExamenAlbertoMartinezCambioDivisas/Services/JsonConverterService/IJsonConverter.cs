using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAlbertoMartinezCambioDivisas.Services.JsonConverterService
{
    public interface IJsonConverter<T> where T : class
    {
        List<T> DeserializeJson(string contenido);

    }
}
