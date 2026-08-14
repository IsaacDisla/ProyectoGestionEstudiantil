using Capa.Datos;
using Capa.Entidades;
using System.Data;

namespace Capa.Negocios
{
    public class EstudianteMateriaBL
    {
        EstudianteMateriaDAL dal = new EstudianteMateriaDAL();

        public DataTable Listar()
        {
            return dal.Listar();
        }

        public void Insertar(EstudianteMateria em)
        {
            dal.Insertar(em);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }

        public void Actualizar(EstudianteMateria em)
        {
            dal.Actualizar(em);
        }

        public bool Existe(int idEstudiante, int idMateria)
        {
            return dal.Existe(idEstudiante, idMateria);
        }

    }
}
