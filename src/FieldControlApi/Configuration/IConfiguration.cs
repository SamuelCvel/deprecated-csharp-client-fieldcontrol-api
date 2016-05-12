namespace FieldControlApi
{
    public interface IConfiguration
    {
        string BaseUrl { get; }
        string Username { get; }
        string Password { get; }
    }
}