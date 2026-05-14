using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicaApp
{
    // Formulario para consultar médicos por especialidad
    public partial class frmConsulta : Form
    {
        private Archivo archivo = new Archivo();

        public frmConsulta()
        {
            InitializeComponent();

            Text = "Consulta de Médicos";
            Size = new Size(600, 400);
            StartPosition = FormStartPosition.CenterParent;

            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            var list = archivo.LeerEspecialidades();
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.DataSource = list;
            cmbEspecialidad.DisplayMember = "NombreEspecialidad";
            cmbEspecialidad.ValueMember = "IdEspecialidad";
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idEspecialidad = (int)cmbEspecialidad.SelectedValue;
            var medicos = archivo.ObtenerMedicosPorEspecialidad(idEspecialidad);

            if (medicos == null || medicos.Count == 0)
            {
                MessageBox.Show("No hay médicos para esta especialidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvMedicos.DataSource = null;
                return;
            }

            // Mostrar en DataGridView
            var tabla = medicos.Select(m => new { Matricula = m.Matricula, NombreMedico = m.NombreMedico }).ToList();
            dgvMedicos.DataSource = tabla;
        }

        private void dgvMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
