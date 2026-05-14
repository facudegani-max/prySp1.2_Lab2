using System;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ClinicaApp
{
    /// <summary>
    /// Clase que administra el acceso a datos usando Access (.accdb) vía OleDb.
    /// Contiene métodos para crear tablas si no existen, insertar, leer y comprobar
    /// la existencia de registros en las tablas 'Especialidades' y 'Medicos'.
    /// La clase utiliza la clase estática <see cref="clsConexion"/> para abrir/cerrar
    /// la conexión y ejecutar comandos OleDb.
    /// </summary>
    public class Archivo
    {
        /// <summary>
        /// Constructor. Al crear la instancia intenta asegurar que las tablas
        /// necesarias existan en la base de datos llamando a <see cref="EnsureTables"/>.
        /// Cualquier error se muestra al usuario mediante MessageBox.
        /// </summary>
        public Archivo()
        {
            try
            {
                // Crear tablas si no existen
                EnsureTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verifica la existencia de las tablas necesarias en la base de datos.
        /// - Intenta abrir la conexión.
        /// - Ejecuta una consulta simple sobre cada tabla; si falla, crea la tabla
        ///   con la definición esperada (campos y tipos) para la aplicación.
        /// </summary>
        private void EnsureTables()
        {
            if (!clsConexion.AbrirConexion())
                throw new Exception("No se pudo abrir la conexión a la base de datos.");

            try
            {
                var conn = clsConexion.Conexion;

                // Comprobar existencia de la tabla Especialidades realizando una consulta simple
                try
                {
                    using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM Especialidades", conn))
                    {
                        cmd.ExecuteScalar();
                    }
                }
                catch
                {
                    // Si la consulta falla asumimos que la tabla no existe: crear tabla
                    // Definimos IdEspecialidad como clave primaria y NombreEspecialidad como texto
                    using (var cmd = new OleDbCommand("CREATE TABLE Especialidades (IdEspecialidad INT PRIMARY KEY, NombreEspecialidad TEXT(255))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // Comprobar existencia de la tabla Medicos
                try
                {
                    using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM Medicos", conn))
                    {
                        cmd.ExecuteScalar();
                    }
                }
                catch
                {
                    // Si la tabla Medicos no existe la creamos con los campos esperados
                    // Matricula (clave primaria), NombreMedico y FK IdEspecialidad
                    using (var cmd = new OleDbCommand("CREATE TABLE Medicos (Matricula INT PRIMARY KEY, NombreMedico TEXT(255), IdEspecialidad INT)", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                clsConexion.CerrarConexion();
            }
        }

        /// <summary>
        /// Borra todos los registros de las tablas 'Medicos' y 'Especialidades'.
        /// Útil para iniciar la aplicación con datos limpios durante pruebas.
        /// </summary>
        public void LimpiarDatos()
        {
            if (!clsConexion.AbrirConexion())
                return;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("DELETE FROM Medicos", conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new OleDbCommand("DELETE FROM Especialidades", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clsConexion.CerrarConexion();
            }
        }

        /// <summary>
        /// Verifica si existe una especialidad con el identificador proporcionado.
        /// </summary>
        /// <param name="numero">IdEspecialidad a buscar.</param>
        /// <returns>True si existe, false en caso contrario o si hay error al abrir la conexión.</returns>
        public bool ExisteEspecialidad(int numero)
        {
            if (!clsConexion.AbrirConexion())
                return false;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM Especialidades WHERE IdEspecialidad = ?", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", numero);
                    var o = cmd.ExecuteScalar();
                    return Convert.ToInt32(o) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                clsConexion.CerrarConexion();
            }
        }

        /// <summary>
        /// Verifica si existe un médico con la matrícula dada.
        /// </summary>
        /// <param name="matricula">Matrícula a buscar.</param>
        /// <returns>True si existe, false en caso contrario o si hay error al abrir la conexión.</returns>
        public bool ExisteMedico(int matricula)
        {
            if (!clsConexion.AbrirConexion())
                return false;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM Medicos WHERE Matricula = ?", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", matricula);
                    var o = cmd.ExecuteScalar();
                    return Convert.ToInt32(o) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar médico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                clsConexion.CerrarConexion();
            }
        }

        /// <summary>
        /// Inserta una nueva especialidad en la tabla 'Especialidades'.
        /// </summary>
        /// <param name="esp">Objeto Especialidad con IdEspecialidad y NombreEspecialidad.</param>
        /// <exception cref="Exception">Si no se puede abrir la conexión o falla la inserción se relanza la excepción.</exception>
        public void GrabarEspecialidad(Especialidad esp)
        {
            if (!clsConexion.AbrirConexion())
                throw new Exception("No se pudo abrir la conexión a la base de datos.");

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("INSERT INTO Especialidades (IdEspecialidad, NombreEspecialidad) VALUES (?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", esp.IdEspecialidad);
                    cmd.Parameters.AddWithValue("@p2", esp.NombreEspecialidad);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al grabar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                clsConexion.CerrarConexion();
            }
        }

        /// <summary>
        /// Inserta un nuevo médico en la tabla 'Medicos'.
        /// </summary>
        /// <param name="med">Objeto Medico con Matricula, NombreMedico e IdEspecialidad.</param>
        public void GrabarMedico(Medico med)
        {
            if (!clsConexion.AbrirConexion())
                throw new Exception("No se pudo abrir la conexión a la base de datos.");

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("INSERT INTO Medicos (Matricula, NombreMedico, IdEspecialidad) VALUES (?, ?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", med.Matricula);
                    cmd.Parameters.AddWithValue("@p2", med.NombreMedico);
                    cmd.Parameters.AddWithValue("@p3", med.IdEspecialidad);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al grabar médico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                clsConexion.CerrarConexion();
            }
        }

        /// <summary>
        /// Lee todas las especialidades desde la base de datos y devuelve una lista
        /// de objetos <see cref="Especialidad"/> ordenadas por IdEspecialidad.
        /// </summary>
        /// <returns>Lista de Especialidad (vacía si no se puede abrir la conexión o no hay registros).</returns>
        public List<Especialidad> LeerEspecialidades()
        {
            var lista = new List<Especialidad>();
            if (!clsConexion.AbrirConexion())
                return lista;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT IdEspecialidad, NombreEspecialidad FROM Especialidades ORDER BY IdEspecialidad", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        string nombreEsp = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                        lista.Add(new Especialidad(id, nombreEsp));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clsConexion.CerrarConexion();
            }

            return lista;
        }

        /// <summary>
        /// Lee todos los médicos desde la base de datos y devuelve una lista
        /// de objetos <see cref="Medico"/> ordenadas por Matricula.
        /// </summary>
        /// <returns>Lista de Medico (vacía si no se puede abrir la conexión o no hay registros).</returns>
        public List<Medico> LeerMedicos()
        {
            var lista = new List<Medico>();
            if (!clsConexion.AbrirConexion())
                return lista;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT Matricula, NombreMedico, IdEspecialidad FROM Medicos ORDER BY Matricula", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int matricula = rdr.GetInt32(0);
                        string nombreMed = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                        int idEsp = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);
                        lista.Add(new Medico(matricula, nombreMed, idEsp));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer médicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clsConexion.CerrarConexion();
            }

            return lista;
        }

        /// <summary>
        /// Obtiene los médicos que pertenecen a una especialidad determinada.
        /// </summary>
        /// <param name="numeroEspecialidad">IdEspecialidad a filtrar.</param>
        /// <returns>Lista de Medico asociados a la especialidad indicada.</returns>
        public List<Medico> ObtenerMedicosPorEspecialidad(int numeroEspecialidad)
        {
            var lista = new List<Medico>();
            if (!clsConexion.AbrirConexion())
                return lista;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT Matricula, NombreMedico, IdEspecialidad FROM Medicos WHERE IdEspecialidad = ? ORDER BY Matricula", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", numeroEspecialidad);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int matricula = rdr.GetInt32(0);
                            string nombreMed = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                            int idEsp = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);
                            lista.Add(new Medico(matricula, nombreMed, idEsp));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener médicos por especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clsConexion.CerrarConexion();
            }

            return lista;
        }
    }
}
