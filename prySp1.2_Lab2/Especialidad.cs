using System; // importa tipos base

namespace ClinicaApp // espacio de nombres de la aplicación
{
    // Clase que representa una especialidad
    public class Especialidad
    {
        // Número identificador de la especialidad
        public int Numero { get; set; }

        // Nombre de la especialidad
        public string Nombre { get; set; }

        // Constructor por defecto
        public Especialidad() { }

        // Constructor que inicializa número y nombre
        public Especialidad(int numero, string nombre)
        {
            Numero = numero; // asigna número
            Nombre = nombre; // asigna nombre
        }

        // Representación en texto: devolver el nombre
        public override string ToString() => Nombre;
    }
}
