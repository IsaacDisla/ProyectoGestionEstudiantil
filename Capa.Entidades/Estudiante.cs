namespace Capa.Entidades
{
    public class Estudiante
    {
        public object id_AreaTecnica;

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }   // ✅ SIN tilde
        public string Email { get; set; }

        public int Id_AreaTecnica { get; set; }
        public string NombreArea { get; set; }
        public bool Estado { get; set; }

        // ✅ CONSTRUCTOR VACÍO (OBLIGATORIO PARA DAL)
        public Estudiante()
        {
        }

        // Constructor con parámetros (puede quedarse)
        public Estudiante(int idEstudiante, string nombre, string apellidos,
                          string direccion, string telefono, string email,
                          int Id_AreaTecnica, string nombreArea)
        {
            this.IdEstudiante = idEstudiante;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Id_AreaTecnica = Id_AreaTecnica;
            this.NombreArea = nombreArea;
        }
    }
}


