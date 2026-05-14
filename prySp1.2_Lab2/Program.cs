using System;
using System; // importa tipos base
using System.Windows.Forms; // necesario para la ejecución de WinForms
using ClinicaApp; // importa el espacio de nombres de los formularios y clases de negocio

namespace prySp1._2_Lab2 // namespace del proyecto
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread] // indica que el hilo principal usa el modelo de subprocesamiento STA necesario para WinForms
        static void Main()
        {
            // Inicializa la configuración de la aplicación (DPI, fuente por defecto, etc.)
            ApplicationConfiguration.Initialize();

            // Inicia la aplicación mostrando el formulario de menú principal
            Application.Run(new frmMenu());
        }
    }
}
