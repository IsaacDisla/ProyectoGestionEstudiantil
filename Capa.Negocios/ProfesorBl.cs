using Capa.Datos;
using Capa.Entidades;
using System.Data;

namespace Capa.Negocios
{
    public class ProfesorBl
    {

        public class ProfesorBL
        {
            private ProfesorDAL profesorDAL = new ProfesorDAL();

            // LISTAR
            public DataTable Listar()
            {
                return profesorDAL.Listar();
            }

            // INSERTAR
            public void Insertar(Profesor profesor)
            {
                profesorDAL.Insertar(profesor);
            }

            // ACTUALIZAR
            public void Actualizar(Profesor profesor)
            {
                profesorDAL.Actualizar(profesor);
            }

            // ELIMINAR
            public void Eliminar(int idProfesor)
            {
                profesorDAL.Eliminar(idProfesor);
            }

            // BUSCAR
            public DataTable Buscar(string nombre)
            {
                return profesorDAL.Buscar(nombre);
            }

        }
    }
}
