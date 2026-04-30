using System;

namespace ClinicaApp
{
    // Clase que representa un médico
    public class Medico
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public int NumeroEspecialidad { get; set; }

        public Medico() { }

        public Medico(int matricula, string nombre, int numeroEspecialidad)
        {
            Matricula = matricula;
            Nombre = nombre;
            NumeroEspecialidad = numeroEspecialidad;
        }
    }
}
