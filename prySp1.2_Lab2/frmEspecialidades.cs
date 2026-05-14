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
        private Archivo archivo = new Archivo();

        public frmEspecialidades()
        {
            InitializeComponent();

            Text = "Especialidades";
            Size = new Size(400, 260);
            StartPosition = FormStartPosition.CenterScreen;
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


        private void LimpiarCampos()
        {
            txtNumero.Clear();
            txtNombre.Clear();
            txtNumero.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar este formulario para volver al menú principal
            Close();
        }
    }
}
