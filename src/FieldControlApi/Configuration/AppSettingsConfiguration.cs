using System.Configuration;

namespace FieldControlApi.Configuration
{
    public class AppSettingsConfiguration : IConfiguration
    {
        public string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["fieldcontrol.baseUrl"];
            }
        }

        public string Username
        {
            get
            {
                return ConfigurationManager.AppSettings["fieldcontrol.username"];
            }
        }

        public string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["fieldcontrol.password"];
            }
        }
    }
}
