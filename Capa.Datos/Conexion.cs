using System.Configuration;
using System.Data.SqlClient;

namespace Capa.Datos
{
    public class Conexion
    {
        private static string cadena =
            ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}

