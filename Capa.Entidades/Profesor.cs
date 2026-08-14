namespace Capa.Entidades
{
    public class Profesor
    {
        public int Id_Profesor { get; set; }
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }

        public bool Estado { get; set; }

        public Profesor()
        {
        }

        public Profesor(int Id_Profesor, string nombre, string apellidos, string telefono,
                       string email, string direccion, bool estado)
        {
            this.Id_Profesor = Id_Profesor;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Email = email;
            this.Direccion = direccion;
            this.Estado = estado;
        }

    }
}
