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
        private Label lblEspecialidad;
        private ComboBox cmbEspecialidad;
        private Button btnConsultar;
        private Button btnSalir;
        private DataGridView dgvMedicos;
        private DataGridViewTextBoxColumn colMat;
        private DataGridViewTextBoxColumn colNom;
        private Archivo archivo = new Archivo();

        public frmConsulta()
        {
            Text = "Consulta de Médicos";
            Size = new Size(600, 400);
            StartPosition = FormStartPosition.CenterParent;

            InitializeComponent();
            CargarEspecialidades();
        }

        private void InitializeComponent()
        {
            lblEspecialidad = new Label();
            cmbEspecialidad = new ComboBox();
            btnConsultar = new Button();
            btnSalir = new Button();
            dgvMedicos = new DataGridView();
            colMat = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).BeginInit();
            SuspendLayout();

            // lblEspecialidad
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(20, 20);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(80, 23);
            lblEspecialidad.TabIndex = 0;
            lblEspecialidad.Text = "Especialidad";

            // cmbEspecialidad
            cmbEspecialidad.Location = new Point(110, 18);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(360, 23);
            cmbEspecialidad.TabIndex = 1;

            // btnConsultar
            btnConsultar.Location = new Point(480, 16);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(90, 26);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.Click += BtnConsultar_Click;

            // btnSalir
            btnSalir.Location = new Point(480, 52);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(90, 26);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.Click += (s, e) => Close();

            // dgvMedicos
            dgvMedicos.AllowUserToAddRows = false;
            dgvMedicos.Columns.AddRange(new DataGridViewColumn[] { colMat, colNom });
            dgvMedicos.Location = new Point(20, 60);
            dgvMedicos.Name = "dgvMedicos";
            dgvMedicos.ReadOnly = true;
            dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicos.Size = new Size(560, 280);
            dgvMedicos.TabIndex = 4;
            dgvMedicos.CellContentClick += dgvMedicos_CellContentClick;

            // colMat
            colMat.Name = "colMat";
            colMat.HeaderText = "Matrícula";
            colMat.DataPropertyName = "Matricula";
            colMat.ReadOnly = true;
            colMat.Width = 120;

            // colNom
            colNom.Name = "colNom";
            colNom.HeaderText = "Nombre";
            colNom.DataPropertyName = "Nombre";
            colNom.ReadOnly = true;
            colNom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // frmConsulta
            ClientSize = new Size(620, 360);
            Controls.Add(lblEspecialidad);
            Controls.Add(cmbEspecialidad);
            Controls.Add(btnConsultar);
            Controls.Add(btnSalir);
            Controls.Add(dgvMedicos);
            Name = "frmConsulta";
            Load += frmConsulta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CargarEspecialidades()
        {
            var list = archivo.LeerEspecialidades();
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.DataSource = list;
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "Numero";
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int numero = (int)cmbEspecialidad.SelectedValue;
            var medicos = archivo.ObtenerMedicosPorEspecialidad(numero);

            if (medicos == null || medicos.Count == 0)
            {
                MessageBox.Show("No hay médicos para esta especialidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvMedicos.DataSource = null;
                return;
            }

            // Mostrar en DataGridView
            var tabla = medicos.Select(m => new { Matricula = m.Matricula, Nombre = m.Nombre }).ToList();
            dgvMedicos.DataSource = tabla;
        }

        private void dgvMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {

        }
    }
}
