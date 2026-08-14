using Capa.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa.Datos
{
    public class EstudianteMateriaDAL
    {
        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarEstudianteMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


        public void Insertar(EstudianteMateria em)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarEstudianteMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Estudiante", em.IdEstudiante);
                cmd.Parameters.AddWithValue("@id_Materia", em.IdMateria);
                cmd.Parameters.AddWithValue("@id_profesor", em.IdProfesor);
                cmd.Parameters.AddWithValue("@id_AreaTecnica", em.IdAreaTecnica);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void Eliminar(int id)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarEstudianteMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Estudiantes_Materia", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(EstudianteMateria em)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarEstudianteMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_estudiantes_materia", em.IdEstudiantesMateria);
                cmd.Parameters.AddWithValue("@id_estudiante", em.IdEstudiante);
                cmd.Parameters.AddWithValue("@id_materia", em.IdMateria);
                cmd.Parameters.AddWithValue("@id_profesor", em.IdProfesor);
                cmd.Parameters.AddWithValue("@id_areaTecnica", em.IdAreaTecnica);
                cmd.Parameters.AddWithValue("@estado", em.Estado);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ListarPorEstudiante(int idEstudiante)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMateriasPorEstudiante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Estudiante", idEstudiante);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }


        public bool Existe(int idEstudiante, int idMateria)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarEstudianteMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Estudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@id_Materia", idMateria);


                cn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }


    }
}

