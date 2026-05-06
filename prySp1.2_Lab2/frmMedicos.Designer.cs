using System.Windows.Forms;

namespace ClinicaApp
{
    partial class frmMedicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicos));
            lblMatricula = new Label();
            txtMatricula = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblEspecialidad = new Label();
            cmbEspecialidad = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(20, 20);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(57, 15);
            lblMatricula.TabIndex = 0;
            lblMatricula.Text = "Matrícula";
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(120, 18);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(200, 23);
            txtMatricula.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 58);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(20, 100);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(72, 15);
            lblEspecialidad.TabIndex = 4;
            lblEspecialidad.Text = "Especialidad";
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecialidad.Location = new Point(120, 98);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(220, 23);
            cmbEspecialidad.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(20, 150);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(90, 23);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += BtnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(120, 150);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(220, 150);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(90, 23);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.Click += BtnSalir_Click;
            // 
            // frmMedicos
            // 
            ClientSize = new Size(420, 210);
            Controls.Add(lblMatricula);
            Controls.Add(txtMatricula);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblEspecialidad);
            Controls.Add(cmbEspecialidad);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMedicos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carga Medicos";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
    }
}