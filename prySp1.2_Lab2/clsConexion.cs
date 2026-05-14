using System; // tipos base
using System.Data.OleDb; // proveedor OLE DB para Access
using System.IO; // para manipular rutas de archivos
using System.Windows.Forms; // para Application.StartupPath y MessageBox

namespace ClinicaApp
{
    /// <summary>
    /// Clase estática que administra la conexión a una base de datos Access (.accdb)
    /// - Construye la cadena de conexión usando Application.StartupPath
    /// - Provee métodos para abrir y cerrar la conexión con manejo de errores
    /// </summary>
    public static class clsConexion
    {
        // ======================================================================
        // Cadena de conexión pública y estática
        // - Visible y reutilizable desde formularios u otras clases
        // - Usa el proveedor ACE OLE DB para archivos .accdb
        // ======================================================================
        public static string CadenaConexion { get; private set; }

        // Objeto de conexión público y estático listo para usar desde formularios
        public static OleDbConnection Conexion { get; private set; }

        // Constructor estático: se ejecuta una vez al acceder a la clase
        static clsConexion()
        {
            try
            {
                // Application.StartupPath devuelve la carpeta donde se inició la aplicación
                // Se asume que dentro del proyecto/publicación existe la carpeta "BaseDatos"
                // y dentro de ella el archivo "Clinica1.accdb".
                string rutaBaseDatos = Path.Combine(Application.StartupPath, "BaseDatos", "Clinica1.accdb");

                // Validación mínima: informar si el archivo no existe
                if (!File.Exists(rutaBaseDatos))
                {
                    // Mostrar un mensaje informativo; la aplicación puede continuar y crear el archivo más tarde
                    MessageBox.Show($"Archivo de base de datos no encontrado:\n{rutaBaseDatos}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Formar la cadena de conexión para Access (.accdb)
                // Nota: el proveedor 'Microsoft.ACE.OLEDB.12.0' debe estar instalado en el sistema.
                CadenaConexion = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={rutaBaseDatos};Persist Security Info=False;";

                // Inicializar el objeto de conexión con la cadena creada (no abre todavía)
                Conexion = new OleDbConnection(CadenaConexion);
            }
            catch (Exception ex)
            {
                // Capturar cualquier error al construir la cadena o inicializar la conexión
                MessageBox.Show($"Error al inicializar la conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Dejar propiedades en estado seguro
                CadenaConexion = string.Empty;
                Conexion = null;
            }
        }

        // ======================================================================
        // Abre la conexión y devuelve true si tuvo éxito
        // Maneja errores con try-catch y muestra mensajes al usuario
        // ======================================================================
        public static bool AbrirConexion()
        {
            try
            {
                // Si el objeto Conexion es nulo, intentar crear uno nuevo usando la cadena actual
                if (Conexion == null)
                {
                    if (string.IsNullOrWhiteSpace(CadenaConexion))
                    {
                        MessageBox.Show("La cadena de conexión no está configurada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    Conexion = new OleDbConnection(CadenaConexion);
                }

                // Si la conexión ya está abierta, no hacer nada
                if (Conexion.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Conexión abierta correctamente");
                }
                    return true;

                // Intentar abrir la conexión
                Conexion.Open();
                return true; // apertura exitosa
            }
            catch (Exception ex)
            {
                // Mostrar el error y devolver false para indicar falla
                MessageBox.Show($"No se pudo abrir la conexión:\n{ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ======================================================================
        // Cierra la conexión de manera segura
        // ======================================================================
        public static void CerrarConexion()
        {
            try
            {
                if (Conexion != null && Conexion.State != System.Data.ConnectionState.Closed)
                {
                    // Cerrar la conexión si está abierta
                    Conexion.Close();
                    Conexion.Dispose();

                    // Crear una nueva instancia vacía para evitar referencias obsoletas
                    Conexion = new OleDbConnection(CadenaConexion);
                }
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error ocurrido al cerrar la conexión
                MessageBox.Show($"Error al cerrar la conexión:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================================
        // Método de utilidad: devuelve la cadena de conexión actual en caso de necesitarla
        // ======================================================================
        public static string ObtenerCadena()
        {
            return CadenaConexion;
        }
    }
}
