using System;

using System; // importa tipos base del sistema

namespace ClinicaApp // espacio de nombres de la aplicación
{
    // Clase que representa un médico
    public class Medico
    {
        // Propiedad que almacena la matrícula del médico
        public int Matricula { get; set; }

        // Propiedad que almacena el nombre del médico
        public string Nombre { get; set; }

        // Propiedad que almacena el número de la especialidad del médico
        public int NumeroEspecialidad { get; set; }

        // Constructor por defecto (sin parámetros)
        public Medico() { }

        // Constructor que inicializa todas las propiedades
        public Medico(int matricula, string nombre, int numeroEspecialidad)
        {
            Matricula = matricula; // asigna la matrícula
            Nombre = nombre; // asigna el nombre
            NumeroEspecialidad = numeroEspecialidad; // asigna la especialidad
        }
    }
}
