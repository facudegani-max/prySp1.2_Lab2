using System;
using System; // importa tipos base como AppDomain
using System.Collections.Generic; // importa colecciones genéricas (List<T>)
using System.IO; // importa IO para leer/escribir archivos
using System.Linq; // importa extensiones LINQ para consultas

namespace ClinicaApp // define el espacio de nombres del proyecto
{
    // Clase para manejar archivos de texto con especialidades y médicos
    public class Archivo
    {
        // Propiedad que almacena la ruta del archivo de especialidades
        public string NombreArchivoEspecialidades { get; set; }

        // Propiedad que almacena la ruta del archivo de médicos
        public string NombreArchivoMedicos { get; set; }

        // Constructor: determina las rutas de los archivos en la carpeta base de la aplicación
        public Archivo()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory; // ruta base de la aplicación
            NombreArchivoEspecialidades = Path.Combine(baseDir, "Especialidades.txt"); // archivo de especialidades
            NombreArchivoMedicos = Path.Combine(baseDir, "Medicos.txt"); // archivo de médicos
        }

        // Elimina los archivos de datos para iniciar limpio
        public void LimpiarDatos()
        {
            try
            {
                if (File.Exists(NombreArchivoEspecialidades)) // si existe el archivo de especialidades
                    File.Delete(NombreArchivoEspecialidades); // eliminarlo
                if (File.Exists(NombreArchivoMedicos)) // si existe el archivo de médicos
                    File.Delete(NombreArchivoMedicos); // eliminarlo
            }
            catch
            {
                // ignorar errores en la eliminación (no interrumpe la app)
            }
        }

        // Verifica si existe una especialidad por número
        public bool ExisteEspecialidad(int numero)
        {
            var lista = LeerEspecialidades(); // leer lista desde archivo
            return lista.Any(e => e.Numero == numero); // devuelve true si existe el número
        }

        // Verifica si existe un médico por matrícula
        public bool ExisteMedico(int matricula)
        {
            var lista = LeerMedicos(); // leer lista de médicos
            return lista.Any(m => m.Matricula == matricula); // devuelve true si existe la matrícula
        }

        // Graba una especialidad en modo append (añade al final)
        public void GrabarEspecialidad(Especialidad esp)
        {
            using (var sw = new StreamWriter(NombreArchivoEspecialidades, append: true)) // abre stream en modo append
            {
                sw.WriteLine($"{esp.Numero};{esp.Nombre}"); // escribe la línea con formato número;nombre
            } // el using cierra el stream automáticamente
        }

        // Graba un médico en modo append (añade al final)
        public void GrabarMedico(Medico med)
        {
            using (var sw = new StreamWriter(NombreArchivoMedicos, append: true)) // abre stream en modo append
            {
                sw.WriteLine($"{med.Matricula};{med.Nombre};{med.NumeroEspecialidad}"); // escribe matrícula;nombre;especialidad
            }
        }

        // Lee todas las especialidades desde el archivo y devuelve una lista
        public List<Especialidad> LeerEspecialidades()
        {
            var lista = new List<Especialidad>(); // lista resultado
            if (!File.Exists(NombreArchivoEspecialidades)) return lista; // si no existe el archivo devuelve lista vacía

            using (var sr = new StreamReader(NombreArchivoEspecialidades)) // abre lector de archivo
            {
                string? line; // variable para cada línea
                while ((line = sr.ReadLine()) != null) // mientras haya líneas
                {
                    if (string.IsNullOrWhiteSpace(line)) continue; // ignora líneas vacías
                    var parts = line.Split(';'); // separa por ';'
                    if (parts.Length >= 2 && int.TryParse(parts[0], out int numero)) // valida campos
                    {
                        lista.Add(new Especialidad(numero, parts[1])); // añade la especialidad
                    }
                }
            }

            return lista; // devuelve la lista de especialidades
        }

        // Lee todos los médicos desde el archivo y devuelve una lista
        public List<Medico> LeerMedicos()
        {
            var lista = new List<Medico>(); // lista resultado
            if (!File.Exists(NombreArchivoMedicos)) return lista; // si no existe el archivo devuelve lista vacía

            using (var sr = new StreamReader(NombreArchivoMedicos)) // abre lector de archivo
            {
                string? line; // variable para cada línea
                while ((line = sr.ReadLine()) != null) // mientras haya líneas
                {
                    if (string.IsNullOrWhiteSpace(line)) continue; // ignora líneas vacías
                    var parts = line.Split(';'); // separa por ';'
                    if (parts.Length >= 3 && int.TryParse(parts[0], out int matricula) && int.TryParse(parts[2], out int numeroEsp)) // valida campos
                    {
                        lista.Add(new Medico(matricula, parts[1], numeroEsp)); // añade el médico a la lista
                    }
                }
            }

            return lista; // devuelve la lista de médicos
        }

        // Obtiene médicos por número de especialidad
        public List<Medico> ObtenerMedicosPorEspecialidad(int numeroEspecialidad)
        {
            var medicos = LeerMedicos(); // lee todos los médicos
            return medicos.Where(m => m.NumeroEspecialidad == numeroEspecialidad).ToList(); // filtra por especialidad y devuelve
        }
    }
}
