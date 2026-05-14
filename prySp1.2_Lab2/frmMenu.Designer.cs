using System.Windows.Forms;
using System.Drawing;

namespace ClinicaApp
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            btnEspecialidades = new Button();
            btnMedicos = new Button();
            btnConsulta = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnEspecialidades
            // 
            btnEspecialidades.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnEspecialidades.Location = new Point(40, 20);
            btnEspecialidades.Name = "btnEspecialidades";
            btnEspecialidades.Size = new Size(320, 80);
            btnEspecialidades.TabIndex = 0;
            btnEspecialidades.Text = "Especialidades";
            btnEspecialidades.UseVisualStyleBackColor = true;
            btnEspecialidades.Click += btnEspecialidades_Click;
            // 
            // btnMedicos
            // 
            btnMedicos.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnMedicos.Location = new Point(40, 110);
            btnMedicos.Name = "btnMedicos";
            btnMedicos.Size = new Size(320, 80);
            btnMedicos.TabIndex = 1;
            btnMedicos.Text = "Médicos";
            btnMedicos.UseVisualStyleBackColor = true;
            btnMedicos.Click += btnMedicos_Click;
            // 
            // btnConsulta
            // 
            btnConsulta.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnConsulta.Location = new Point(40, 200);
            btnConsulta.Name = "btnConsulta";
            btnConsulta.Size = new Size(320, 80);
            btnConsulta.TabIndex = 2;
            btnConsulta.Text = "Consulta";
            btnConsulta.UseVisualStyleBackColor = true;
            btnConsulta.Click += btnConsulta_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.IndianRed;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(40, 295);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(320, 50);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmMenu
            // 
            ClientSize = new Size(400, 370);
            Controls.Add(btnEspecialidades);
            Controls.Add(btnMedicos);
            Controls.Add(btnConsulta);
            Controls.Add(btnSalir);
            // statusStrip
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelConexion = new ToolStripStatusLabel();
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabelConexion });
            statusStrip1.Location = new Point(0, 348);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(400, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            toolStripStatusLabelConexion.Name = "toolStripStatusLabelConexion";
            toolStripStatusLabelConexion.Text = "Estado: Desconocido";
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            ResumeLayout(false);
        }

        private Button btnEspecialidades;
        private Button btnMedicos;
        private Button btnConsulta;
        private Button btnSalir;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelConexion;
    }
}
