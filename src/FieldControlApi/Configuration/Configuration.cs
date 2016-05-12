namespace FieldControlApi.Configuration
{
    public class Configuration : IConfiguration
    {
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
