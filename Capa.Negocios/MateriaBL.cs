using Capa.Datos;
using Capa.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Capa.Negocios
{
    public class MateriaBL
    {
        public MateriaDAL dal = new MateriaDAL();

        // 🔹 LISTAR
        public List<Materia> Listar()
        {
            return dal.Listar();
        }

        // 🔹 INSERTAR
        public void Insertar(Materia m)
        {
            dal.Insertar(m);
        }

        // 🔹 ACTUALIZAR
        public void Actualizar(Materia m)
        {
            dal.Actualizar(m);
        }

        // 🔹 ELIMINACIÓN LÓGICA
        public void Eliminar(int idMateria)
        {
            dal.Eliminar(idMateria);
        }

        public class BLMateria
        {
            private MateriaDAL dal = new MateriaDAL();

            public DataTable ListarPorArea(int idArea)
            {
                return dal.ListarPorArea(idArea);
            }
        }
        public DataTable ListarMateriaConProfesor()
        {
            return dal.ListarMateriaConProfesor();
        }
    }
}
