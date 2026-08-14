using Capa.Datos;
using Capa.Entidades;
using System.Data;

namespace Capa.Negocios
{
    public class AreaTecnicaBL
    {
        private AreaTecnicaDAL dal = new AreaTecnicaDAL();

        public DataTable Listar()
        {
            return dal.Listar();
        }

        public void Insertar(AreaTecnica area)
        {
            dal.Insertar(area);
        }

        public void Actualizar(AreaTecnica area)
        {
            dal.Actualizar(area);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            return dal.BuscarPorNombre(nombre);
        }
    }
}

