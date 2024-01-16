namespace API_EF_Hash_Token.API.Infrastructure
{
    public class TokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _secret;
        private readonly string issuer;
        private readonly string _audience;
    }
}
