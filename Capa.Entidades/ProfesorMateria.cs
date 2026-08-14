namespace Capa.Entidades
{
    internal class ProfesorMateria
    {
        public int IdProfesorMateria { get; set; }
        public int IdProfesor { get; set; }
        public int IdMateria { get; set; }
        public bool Estado { get; set; }

        public string Profesor { get; set; }
        public string Materia { get; set; }

    }
}
