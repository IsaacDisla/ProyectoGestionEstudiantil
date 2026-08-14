namespace Capa.Entidades
{
    public class EstudianteMateria
    {
        public int IdEstudiantesMateria { get; set; }
        public int IdEstudiante { get; set; }
        public int IdMateria { get; set; }
        public int IdProfesor { get; set; }

        public int IdAreaTecnica { get; set; }

        public bool Estado { get; set; }
    }
}
