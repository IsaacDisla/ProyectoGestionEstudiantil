using Capa.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa.Datos
{
    public class AreaTecnicaDAL
    {
        public DataTable Listar()
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_ListarAreaTecnica", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public void Insertar(AreaTecnica area)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_InsertarAreaTecnica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Area", area.Nombre_Area);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(AreaTecnica area)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarAreaTecnica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_AreaTecnica", area.id_AreaTecnica);
                cmd.Parameters.AddWithValue("@Nombre_Area", area.Nombre_Area);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarAreaTecnica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_AreaTecnica", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_BuscarAreaTecnicaPorNombre", cn);
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
            throw new NotImplementedException();
        }
    }
}

