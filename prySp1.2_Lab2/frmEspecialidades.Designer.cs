using System.Windows.Forms;

namespace ClinicaApp
{
    partial class frmEspecialidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspecialidades));
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(42, 20);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(51, 15);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(123, 17);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(194, 23);
            txtNumero.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(42, 63);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(123, 60);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 23);
            txtNombre.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(20, 110);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(111, 40);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += BtnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(137, 110);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 40);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.IndianRed;
            btnSalir.Location = new Point(254, 110);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(113, 40);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // frmEspecialidades
            // 
            ClientSize = new Size(378, 165);
            Controls.Add(lblNumero);
            Controls.Add(txtNumero);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEspecialidades";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carga Especialidad";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
    }
}
