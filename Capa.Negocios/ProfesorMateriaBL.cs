using Capa.Datos;
using System.Data;

namespace Capa.Negocio
{
    public class ProfesorMateriaBL
    {
        public ProfesorMateriaDAL profesorMateriaDAL = new ProfesorMateriaDAL();

        public DataTable Listar()
        {
            return profesorMateriaDAL.Listar();
        }

        public void Insertar(int idProfesor, int idMateria)
        {
            profesorMateriaDAL.Insertar(idProfesor, idMateria);
        }

        public void Actualizar(int idProfesorMateria, int idProfesor, int idMateria, bool estado)
        {
            profesorMateriaDAL.Actualizar(idProfesorMateria, idProfesor, idMateria, estado);
        }

        public void Eliminar(int idProfesorMateria)
        {
            profesorMateriaDAL.Eliminar(idProfesorMateria);
        }
    }
}
