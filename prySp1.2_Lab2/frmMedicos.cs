namespace ClinicaApp
{
    // Formulario para gestionar médicos
    public partial class frmMedicos : Form
    {
        private Archivo archivo = new Archivo();

        public frmMedicos()
        {
            Text = "Médicos";
            Size = new Size(420, 240);
            StartPosition = FormStartPosition.CenterParent;

            InitializeComponent();
            CargarEspecialidades();
        }

        // Carga especialidades en el combo
        private void CargarEspecialidades()
        {
            var list = archivo.LeerEspecialidades();
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.DataSource = list;
            cmbEspecialidad.DisplayMember = "NombreEspecialidad";
            cmbEspecialidad.ValueMember = "IdEspecialidad";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMatricula.Text.Trim(), out int matricula))
            {
                MessageBox.Show("Matrícula inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Nombre obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (archivo.ExisteMedico(matricula))
            {
                MessageBox.Show("Matrícula de médico repetida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idEspecialidad = (int)cmbEspecialidad.SelectedValue;
            var med = new Medico(matricula, nombre, idEspecialidad);
            try
            {
                archivo.GrabarMedico(med);
                MessageBox.Show("Médico grabado correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al grabar médico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtMatricula.Clear();
            txtNombre.Clear();
            if (cmbEspecialidad.Items.Count > 0) cmbEspecialidad.SelectedIndex = -1;
            txtMatricula.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
