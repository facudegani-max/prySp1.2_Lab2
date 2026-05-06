using System.Windows.Forms;

namespace ClinicaApp
{
    partial class frmConsulta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsulta));
            lblEspecialidad = new Label();
            cmbEspecialidad = new ComboBox();
            btnConsultar = new Button();
            btnSalir = new Button();
            dgvMedicos = new DataGridView();
            colMat = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).BeginInit();
            SuspendLayout();
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(20, 20);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(72, 15);
            lblEspecialidad.TabIndex = 0;
            lblEspecialidad.Text = "Especialidad";
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.Location = new Point(110, 18);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(360, 23);
            cmbEspecialidad.TabIndex = 1;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(480, 16);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(90, 26);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.Click += BtnConsultar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(480, 52);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(90, 26);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.Click += BtnSalir_Click;
            // 
            // dgvMedicos
            // 
            dgvMedicos.AllowUserToAddRows = false;
            dgvMedicos.Columns.AddRange(new DataGridViewColumn[] { colMat, colNom });
            dgvMedicos.Location = new Point(20, 84);
            dgvMedicos.Name = "dgvMedicos";
            dgvMedicos.ReadOnly = true;
            dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicos.Size = new Size(560, 280);
            dgvMedicos.TabIndex = 4;
            dgvMedicos.CellContentClick += dgvMedicos_CellContentClick;
            // 
            // colMat
            // 
            colMat.DataPropertyName = "Matricula";
            colMat.HeaderText = "Matrícula";
            colMat.Name = "colMat";
            colMat.ReadOnly = true;
            colMat.Width = 120;
            // 
            // colNom
            // 
            colNom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNom.DataPropertyName = "Nombre";
            colNom.HeaderText = "Nombre";
            colNom.Name = "colNom";
            colNom.ReadOnly = true;
            // 
            // frmConsulta
            // 
            ClientSize = new Size(620, 396);
            Controls.Add(lblEspecialidad);
            Controls.Add(cmbEspecialidad);
            Controls.Add(btnConsultar);
            Controls.Add(btnSalir);
            Controls.Add(dgvMedicos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmConsulta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta";
            Load += frmConsulta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
    }
}