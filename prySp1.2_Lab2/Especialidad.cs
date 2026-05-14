using System; // importa tipos base

namespace ClinicaApp // espacio de nombres de la aplicación
{
    // Clase que representa una especialidad
    public class Especialidad
    {
        // Identificador de la especialidad
        public int IdEspecialidad { get; set; }

        // Nombre de la especialidad
        public string NombreEspecialidad { get; set; }

        // Constructor por defecto
        public Especialidad() { }

        // Constructor que inicializa número y nombre
        public Especialidad(int idEspecialidad, string nombreEspecialidad)
        {
            IdEspecialidad = idEspecialidad; // asigna id
            NombreEspecialidad = nombreEspecialidad; // asigna nombre
        }

        // Representación en texto: devolver el nombre
        public override string ToString() => NombreEspecialidad;
    }
}
