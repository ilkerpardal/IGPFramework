using Microsoft.IdentityModel.Tokens;

namespace IgpFramework.Api.Security.Token
{
    public class SignHandler
    {
        
        public static SecurityKey GetSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
