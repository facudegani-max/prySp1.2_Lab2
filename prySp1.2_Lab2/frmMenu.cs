using System;
using System.Windows.Forms;

namespace ClinicaApp
{
    // Formulario de menú principal con botones para navegar a los otros formularios
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            // Actualizar estado de conexión al iniciar el formulario
            UpdateConnectionStatus();
        }

        // Actualiza el label del statusstrip indicando si la base de datos está accesible
        private void UpdateConnectionStatus()
        {
            try
            {
                if (clsConexion.AbrirConexion())
                {
                    toolStripStatusLabelConexion.Text = "Conectado";
                    clsConexion.CerrarConexion();
                }
                else
                {
                    toolStripStatusLabelConexion.Text = "Desconectado";
                }
            }
            catch
            {
                toolStripStatusLabelConexion.Text = "Desconectado";
            }
        }

        // Abre el formulario de Especialidades de forma modal
        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEspecialidades())
            {
                frm.ShowDialog();
            }
        }

        // Abre el formulario de Médicos de forma modal
        private void btnMedicos_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMedicos())
            {
                frm.ShowDialog();
            }
        }

        // Abre el formulario de Consulta de forma modal
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            using (var frm = new frmConsulta())
            {
                frm.ShowDialog();
            }
        }

        // Sale de la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
