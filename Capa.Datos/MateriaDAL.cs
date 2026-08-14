using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa.Datos
{
    public class MateriaDAL
    {
        public List<Materia> Listar()
        {
            List<Materia> lista = new List<Materia>();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMaterias", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Materia
                    {
                        IdMateria = (int)dr["id_Materia"],
                        NombreMateria = dr["Nombre_Materia"].ToString()
                    });
                }
            }
            return lista;
        }

        public List<Materia> Buscar(string texto)
        {
            List<Materia> lista = new List<Materia>();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@texto", texto);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Materia
                    {
                        IdMateria = Convert.ToInt32(dr["id_Materia"]),
                        NombreMateria = dr["Nombre_Materia"].ToString()
                    });
                }
            }
            return lista;
        }

        // 🔹 INSERTAR
        public void Insertar(Materia m)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre_Materia", m.NombreMateria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🔹 ACTUALIZAR
        public void Actualizar(Materia m)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Materia", m.IdMateria);
                cmd.Parameters.AddWithValue("@Nombre_Materia", m.NombreMateria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarPorArea(int idArea)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())

            {
                SqlCommand cmd = new SqlCommand("sp_ListarMateriasPorArea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idArea", idArea);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


        // 🔹 ELIMINACIÓN LÓGICA
        public void Eliminar(int idMateria)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarMateria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Materia", idMateria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarMateriaConProfesor()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMateriaConProfesor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }



    }

}

