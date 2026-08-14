using System.Data.SqlClient;

namespace Capa.Presentacion
{
    internal class ConexionGestionEscolar
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Gestion_Escolar;Integrated Security=True");
            return cn;
        }
    }
}
