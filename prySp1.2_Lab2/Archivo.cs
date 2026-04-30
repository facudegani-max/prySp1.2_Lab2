using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClinicaApp
{
    // Clase para manejar archivos de texto con especialidades y médicos
    public class Archivo
    {
        public string NombreArchivoEspecialidades { get; set; }
        public string NombreArchivoMedicos { get; set; }

        public Archivo()
        {
            // Ubicar archivos en la carpeta del ejecutable
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            NombreArchivoEspecialidades = Path.Combine(baseDir, "Especialidades.txt");
            NombreArchivoMedicos = Path.Combine(baseDir, "Medicos.txt");
        }

        // Verifica si existe una especialidad por número
        public bool ExisteEspecialidad(int numero)
        {
            var lista = LeerEspecialidades();
            return lista.Any(e => e.Numero == numero);
        }

        // Verifica si existe un médico por matrícula
        public bool ExisteMedico(int matricula)
        {
            var lista = LeerMedicos();
            return lista.Any(m => m.Matricula == matricula);
        }

        // Graba una especialidad en modo append
        public void GrabarEspecialidad(Especialidad esp)
        {
            using (var sw = new StreamWriter(NombreArchivoEspecialidades, append: true))
            {
                sw.WriteLine($"{esp.Numero};{esp.Nombre}");
            }
        }

        // Graba un médico en modo append
        public void GrabarMedico(Medico med)
        {
            using (var sw = new StreamWriter(NombreArchivoMedicos, append: true))
            {
                sw.WriteLine($"{med.Matricula};{med.Nombre};{med.NumeroEspecialidad}");
            }
        }

        // Lee todas las especialidades desde el archivo
        public List<Especialidad> LeerEspecialidades()
        {
            var lista = new List<Especialidad>();
            if (!File.Exists(NombreArchivoEspecialidades)) return lista;

            using (var sr = new StreamReader(NombreArchivoEspecialidades))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(';');
                    if (parts.Length >= 2 && int.TryParse(parts[0], out int numero))
                    {
                        lista.Add(new Especialidad(numero, parts[1]));
                    }
                }
            }

            return lista;
        }

        // Lee todos los médicos desde el archivo
        public List<Medico> LeerMedicos()
        {
            var lista = new List<Medico>();
            if (!File.Exists(NombreArchivoMedicos)) return lista;

            using (var sr = new StreamReader(NombreArchivoMedicos))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(';');
                    if (parts.Length >= 3 && int.TryParse(parts[0], out int matricula) && int.TryParse(parts[2], out int numeroEsp))
                    {
                        lista.Add(new Medico(matricula, parts[1], numeroEsp));
                    }
                }
            }

            return lista;
        }

        // Obtiene médicos por número de especialidad
        public List<Medico> ObtenerMedicosPorEspecialidad(int numeroEspecialidad)
        {
            var medicos = LeerMedicos();
            return medicos.Where(m => m.NumeroEspecialidad == numeroEspecialidad).ToList();
        }
    }
}
