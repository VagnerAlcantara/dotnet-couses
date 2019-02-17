using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace YouLearn.API.Security
{
    //TODO: Microsoft.AspNetCore.Authentication.JwtBearer 
    //pacote de instalação para autenticação da api
    public class SigningConfigurations
    {
        private const string SECRET_KEY = "59F7C365-9D78-4ED6-872E-207E83AC1810";
        public SigningCredentials SigningCredentials { get; }
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
