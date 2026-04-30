using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicaApp
{
    // Formulario para gestionar médicos
    public partial class frmMedicos : Form
    {
        private Label lblMatricula;
        private TextBox txtMatricula;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblEspecialidad;
        private ComboBox cmbEspecialidad;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnSalir;

        private Archivo archivo = new Archivo();

        public frmMedicos()
        {
            Text = "Médicos";
            Size = new Size(420, 240);
            StartPosition = FormStartPosition.CenterParent;

            InitializeComponent();
            CargarEspecialidades();
        }

        private void InitializeComponent()
        {
            lblMatricula = new Label { Text = "Matrícula", Location = new Point(20, 20), AutoSize = true };
            txtMatricula = new TextBox { Location = new Point(120, 18), Width = 200 };

            lblNombre = new Label { Text = "Nombre", Location = new Point(20, 60), AutoSize = true };
            txtNombre = new TextBox { Location = new Point(120, 58), Width = 250 };

            lblEspecialidad = new Label { Text = "Especialidad", Location = new Point(20, 100), AutoSize = true };
            cmbEspecialidad = new ComboBox { Location = new Point(120, 98), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList }; 

            btnAceptar = new Button { Text = "Aceptar", Location = new Point(20, 150), Width = 90 };
            btnAceptar.Click += BtnAceptar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(120, 150), Width = 90 };
            btnCancelar.Click += (s, e) => LimpiarCampos();

            btnSalir = new Button { Text = "Salir", Location = new Point(220, 150), Width = 90 };
            btnSalir.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { lblMatricula, txtMatricula, lblNombre, txtNombre, lblEspecialidad, cmbEspecialidad, btnAceptar, btnCancelar, btnSalir });
        }

        // Carga especialidades en el combo
        private void CargarEspecialidades()
        {
            var list = archivo.LeerEspecialidades();
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.DataSource = list;
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "Numero";
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

            int numeroEspecialidad = (int)cmbEspecialidad.SelectedValue;
            var med = new Medico(matricula, nombre, numeroEspecialidad);
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
    }
}
