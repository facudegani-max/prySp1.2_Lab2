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
        public string NombreMedico { get; set; }

        // Propiedad que almacena el id de la especialidad del médico
        public int IdEspecialidad { get; set; }

        // Constructor por defecto (sin parámetros)
        public Medico() { }

        // Constructor que inicializa todas las propiedades
        public Medico(int matricula, string nombreMedico, int idEspecialidad)
        {
            Matricula = matricula; // asigna la matrícula
            NombreMedico = nombreMedico; // asigna el nombre
            IdEspecialidad = idEspecialidad; // asigna la especialidad
        }
    }
}
