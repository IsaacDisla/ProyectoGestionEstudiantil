using System.Data;
using System.Data.SqlClient;

namespace Capa.Datos
{
    public class ProfesorMateriaDAL
    {
        public DataTable Listar()
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarProfesorMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                return tabla;
            }
        }

        public void Insertar(int idProfesor, int idMateria)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProfesorMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Profesor", idProfesor);
                cmd.Parameters.AddWithValue("@id_Materia", idMateria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(int idProfesorMateria, int idProfesor, int idMateria, bool estado)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarProfesorMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_ProfesorMateria", idProfesorMateria);
                cmd.Parameters.AddWithValue("@id_Profesor", idProfesor);
                cmd.Parameters.AddWithValue("@id_Materia", idMateria);
                cmd.Parameters.AddWithValue("@Estado", estado);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idProfesorMateria)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarProfesorMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_ProfesorMateria", idProfesorMateria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
