using Capa.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Capa.Datos
{
    public class EstudianteDAL
    {
        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarEstudiantes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


        public void Insertar(Estudiante e)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarEstudiante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", e.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", e.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", e.Telefono);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@id_AreaTecnica", e.Id_AreaTecnica);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_BuscarEstudiantePorNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarAreas()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarAreasTecnicas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        public void Actualizar(Estudiante e)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_ActualizarEstudiantes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Estudiante", e.IdEstudiante);
                cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", e.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", e.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", e.Telefono);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@id_AreaTecnica", e.Id_AreaTecnica);
                cmd.Parameters.AddWithValue("@Estado", e.Estado);


                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void Eliminar(int id)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarEstudiante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Estudiante", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}

