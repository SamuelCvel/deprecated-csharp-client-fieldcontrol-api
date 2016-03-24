using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp.Serializers;
using System.Globalization;

namespace FieldControlApi.Lib
{
    public class IntegerEnumConverter : StringEnumConverter
    {
        public override bool CanRead { get { return false; } }

        public override bool CanWrite { get { return false; } }
    }

    public class CustomJsonSerializer : ISerializer
    {
        public CustomJsonSerializer()
        {
            ContentType = "application/json";
        }

        public string Serialize(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            settings.Converters.Add(new StringEnumConverter()
            {
                AllowIntegerValues = true
            });

            var json = JsonConvert.SerializeObject(obj, settings);
            return json;
        }

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string DateFormat { get; set; }

        public string ContentType { get; set; }

    }
}
