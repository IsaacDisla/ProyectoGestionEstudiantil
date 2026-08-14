using Capa.Datos;
using Capa.Entidades;
using System.Data;

namespace Capa.Negocios
{
    public class EstudianteBL
    {
        public EstudianteDAL dal = new EstudianteDAL();

        public DataTable Listar()
        {
            return dal.Listar();
        }


        public void Guardar(Estudiante e)
        {
            if (e.IdEstudiante == 0)
                dal.Insertar(e);
            else
                dal.Actualizar(e);
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            return dal.BuscarPorNombre(nombre);
        }

        public class AreaTecnicaBL
        {
            AreaTecnicaDAL dalArea = new AreaTecnicaDAL();

            public DataTable Listar()
            {
                return dalArea.ListarAreas();
            }
        }


        public void Actualizar(Estudiante e)
        {
            dal.Actualizar(e);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
    }
}



