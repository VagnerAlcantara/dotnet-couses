using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace GerenciadorUsuarioService.Infra.SQL.Database
{
    public class SqlDatabaseConnection
    {
        private static string _connectionStringPecReceptor
        {
            get
            {
#if (DEBUG)
                return @" Data Source       =homsqlefap.database.windows.net; 
                       Password              =Data&homologac@o;
                       Persist Security Info =True;
                       User ID               =efapdbhom;
                       Initial Catalog       =Pec_receptor;
                       Application Name      =Pec_receptor;
                       Connect Timeout       =12000";
#endif
                 return ConfigurationManager.ConnectionStrings["PecReceptor"].ToString();

            }
        }
        private static string _connectionStringGestaoCorp
        {
            get
            {
#if (DEBUG)

                return @" Data Source       =homsqlefap.database.windows.net; 
                       Password              =Data&homologac@o;
                       Persist Security Info =True;
                       User ID               =efapdbhom;
                       Initial Catalog       =GestaoCorp;
                       Application Name      =GestaoCorp;
                       Connect Timeout       =12000";

#endif
                return ConfigurationManager.ConnectionStrings["GestaoCorp"].ToString();
            }
        }
        private static string _connectionStringRsdbcorp
        {
            get
            {
#if (DEBUG)

                return @" Data Source       =homsqlefap.database.windows.net; 
                       Password              =Data&homologac@o;
                       Persist Security Info =True;
                       User ID               =efapdbhom;
                       Initial Catalog       =Rs_dbcorp;
                       Application Name      =Rs_dbcorp;
                       Connect Timeout       =12000";
#endif
                return ConfigurationManager.ConnectionStrings["RSDBCorp"].ToString();
            }
        }

        private static string _connectionStringCep
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Cep"].ToString();
            }
        }

        private static DbConnection _conn { get; set; }
        public static DbConnection GetOpenConnectionPecReceptor()
        {
            _conn = new SqlConnection(_connectionStringPecReceptor);


            if (_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.ConnectionString = _connectionStringPecReceptor;
                _conn.Open();
            }

            return _conn;
        }
        public static DbConnection GetOpenConnectionGestaoCorp()
        {
            _conn = new SqlConnection(_connectionStringGestaoCorp);


            if (_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.ConnectionString = _connectionStringGestaoCorp;
                _conn.Open();
            }

            return _conn;
        }
        public static DbConnection GetOpenConnectionRsdbcorp()
        {
            _conn = new SqlConnection(_connectionStringRsdbcorp);


            if (_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.ConnectionString = _connectionStringRsdbcorp;
                _conn.Open();
            }

            return _conn;
        }
        public static DbConnection GetOpenConnectionCep()
        {
            _conn = new SqlConnection(_connectionStringCep);


            if (_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.ConnectionString = _connectionStringCep;
                _conn.Open();
            }

            return _conn;
        }

    }
}
