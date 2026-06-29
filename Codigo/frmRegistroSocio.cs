using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class frmRegistroSocio : Form
    {
        public frmRegistroSocio()
        {
            InitializeComponent();
        }

        private void rbSocio_CheckedChanged(object sender, EventArgs e)
        {
            // El apto físico solo aplica al registro de socios
            chkAptoFisico.Visible = rbSocio.Checked;
            if (!rbSocio.Checked)
                chkAptoFisico.Checked = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)   ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de apto físico: obligatorio para socios
            if (rbSocio.Checked && !chkAptoFisico.Checked)
            {
                MessageBox.Show(
                    "El postulante debe presentar el certificado de apto físico para inscribirse como socio.",
                    "Apto físico requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Persona persona = rbSocio.Checked
                    ? (Persona)new Socio(
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        txtDni.Text.Trim(),
                        chkAptoFisico.Checked)
                    : new NoSocio(
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        txtDni.Text.Trim());

                persona.Registrar(Conexion.Instancia.ObtenerConexion());

                string tipo = rbSocio.Checked ? "Socio" : "No Socio";
                MessageBox.Show($"{tipo} registrado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message,
                    "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            chkAptoFisico.Checked = false;
            rbSocio.Checked       = true;
            txtNombre.Focus();
        }
    }
}
