namespace MoviesManagement.Services.Models.JWT
{
    public class JWTConfiguration
    {
        public string Secret { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
