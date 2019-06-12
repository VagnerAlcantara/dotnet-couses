using System.Configuration;

namespace TesteImposto.Data
{
    public static class DbContext 
    {
        public static readonly string SqlConn = ConfigurationManager.ConnectionStrings["connTeste"].ConnectionString;
    }
}
