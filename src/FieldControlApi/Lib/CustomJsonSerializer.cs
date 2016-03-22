using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Serializers;
using System.Globalization;

namespace FieldControlApi.Lib
{
    public class CustomJsonSerializer : ISerializer
    {
        public CustomJsonSerializer()
        {
            ContentType = "application/json";
        }

        public string Serialize(object obj)
        {
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            return json;
        }

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string DateFormat { get; set; }

        public string ContentType { get; set; }

    }
}
