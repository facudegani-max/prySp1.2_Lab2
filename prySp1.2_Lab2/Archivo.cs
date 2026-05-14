using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ClinicaApp
{
    // Clase que administra el acceso a datos usando Access (.accdb) vía OleDb
    public class Archivo
    {
        // Constructor: intenta asegurar que las tablas necesarias existan
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

        // Asegura que existan las tablas 'Especialidades' y 'Medicos' en la base de datos
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
                    // Si falla, crear la tabla Especialidades
                    using (var cmd = new OleDbCommand("CREATE TABLE Especialidades (Numero INT PRIMARY KEY, Nombre TEXT(255))", conn))
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
                    // Si falla, crear la tabla Medicos
                    using (var cmd = new OleDbCommand("CREATE TABLE Medicos (Matricula INT PRIMARY KEY, Nombre TEXT(255), NumeroEspecialidad INT)", conn))
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

        // Borra todos los registros de las tablas para iniciar limpio
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

        // Verifica si existe una especialidad por número
        public bool ExisteEspecialidad(int numero)
        {
            if (!clsConexion.AbrirConexion())
                return false;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM Especialidades WHERE Numero = ?", conn))
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

        // Verifica si existe un médico por matrícula
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

        // Inserta una especialidad en la base de datos
        public void GrabarEspecialidad(Especialidad esp)
        {
            if (!clsConexion.AbrirConexion())
                throw new Exception("No se pudo abrir la conexión a la base de datos.");

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("INSERT INTO Especialidades (Numero, Nombre) VALUES (?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", esp.Numero);
                    cmd.Parameters.AddWithValue("@p2", esp.Nombre);
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

        // Inserta un médico en la base de datos
        public void GrabarMedico(Medico med)
        {
            if (!clsConexion.AbrirConexion())
                throw new Exception("No se pudo abrir la conexión a la base de datos.");

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("INSERT INTO Medicos (Matricula, Nombre, NumeroEspecialidad) VALUES (?, ?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", med.Matricula);
                    cmd.Parameters.AddWithValue("@p2", med.Nombre);
                    cmd.Parameters.AddWithValue("@p3", med.NumeroEspecialidad);
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

        // Lee todas las especialidades desde la base de datos
        public List<Especialidad> LeerEspecialidades()
        {
            var lista = new List<Especialidad>();
            if (!clsConexion.AbrirConexion())
                return lista;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT Numero, Nombre FROM Especialidades ORDER BY Numero", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int numero = rdr.GetInt32(0);
                        string nombre = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                        lista.Add(new Especialidad(numero, nombre));
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

        // Lee todos los médicos desde la base de datos
        public List<Medico> LeerMedicos()
        {
            var lista = new List<Medico>();
            if (!clsConexion.AbrirConexion())
                return lista;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT Matricula, Nombre, NumeroEspecialidad FROM Medicos ORDER BY Matricula", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int matricula = rdr.GetInt32(0);
                        string nombre = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                        int numEsp = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);
                        lista.Add(new Medico(matricula, nombre, numEsp));
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

        // Obtiene médicos por número de especialidad
        public List<Medico> ObtenerMedicosPorEspecialidad(int numeroEspecialidad)
        {
            var lista = new List<Medico>();
            if (!clsConexion.AbrirConexion())
                return lista;

            try
            {
                var conn = clsConexion.Conexion;
                using (var cmd = new OleDbCommand("SELECT Matricula, Nombre, NumeroEspecialidad FROM Medicos WHERE NumeroEspecialidad = ? ORDER BY Matricula", conn))
                {
                    cmd.Parameters.AddWithValue("@p1", numeroEspecialidad);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int matricula = rdr.GetInt32(0);
                            string nombre = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                            int numEsp = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);
                            lista.Add(new Medico(matricula, nombre, numEsp));
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
