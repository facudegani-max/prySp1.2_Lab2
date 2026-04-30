using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicaApp
{
    // Formulario para gestionar especialidades
    public partial class frmEspecialidades : Form
    {
        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnIrMedicos;
        private Button btnConsultar;
        private Button btnSalir;

        private Archivo archivo = new Archivo();

        public frmEspecialidades()
        {
            Text = "Especialidades";
            Size = new Size(400, 260);
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            lblNumero = new Label { Text = "Número", Location = new Point(20, 20), AutoSize = true };
            txtNumero = new TextBox { Location = new Point(100, 18), Width = 200 };

            lblNombre = new Label { Text = "Nombre", Location = new Point(20, 60), AutoSize = true };
            txtNombre = new TextBox { Location = new Point(100, 58), Width = 250 };

            btnAceptar = new Button { Text = "Aceptar", Location = new Point(20, 110), Width = 90 };
            btnAceptar.Click += BtnAceptar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(120, 110), Width = 90 };
            btnCancelar.Click += BtnCancelar_Click;

            btnIrMedicos = new Button { Text = "Ir a Médicos", Location = new Point(220, 110), Width = 110 };
            btnIrMedicos.Click += BtnIrMedicos_Click;

            btnConsultar = new Button { Text = "Consultar", Location = new Point(20, 150), Width = 90 };
            btnConsultar.Click += BtnConsultar_Click;

            btnSalir = new Button { Text = "Salir", Location = new Point(120, 150), Width = 90 };
            btnSalir.Click += (s, e) => Application.Exit();

            Controls.AddRange(new Control[] { lblNumero, txtNumero, lblNombre, txtNombre, btnAceptar, btnCancelar, btnIrMedicos, btnConsultar, btnSalir });
        }

        // Evento Aceptar: valida y graba especialidad
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumero.Text.Trim(), out int numero))
            {
                MessageBox.Show("Número inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Nombre obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (archivo.ExisteEspecialidad(numero))
            {
                MessageBox.Show("Número de especialidad repetido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var esp = new Especialidad(numero, nombre);
            try
            {
                archivo.GrabarEspecialidad(esp);
                MessageBox.Show("Especialidad grabada correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al grabar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BtnIrMedicos_Click(object sender, EventArgs e)
        {
            var frm = new frmMedicos();
            frm.ShowDialog();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            var frm = new frmConsulta();
            frm.ShowDialog();
        }

        private void LimpiarCampos()
        {
            txtNumero.Clear();
            txtNombre.Clear();
            txtNumero.Focus();
        }
    }
}
