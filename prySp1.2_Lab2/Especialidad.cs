using System;

namespace ClinicaApp
{
    // Clase que representa una especialidad
    public class Especialidad
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }

        public Especialidad() { }

        public Especialidad(int numero, string nombre)
        {
            Numero = numero;
            Nombre = nombre;
        }

        public override string ToString() => Nombre;
    }
}
