using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    // Formulario de inicio de sesión.
    // Es el primer formulario que se muestra al ejecutar el sistema.
    // Valida las credenciales contra la tabla 'usuarios' mediante el stored procedure sp_ValidarLogin.
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // Evento del botón Ingresar: valida usuario y contraseña contra la base de datos
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Verificar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Complete los campos de usuario y contraseña.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener la conexión a través del Singleton
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();

                // Llamar al stored procedure que verifica las credenciales
                MySqlCommand cmd = new MySqlCommand("sp_ValidarLogin", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("p_usuario",    txtUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("p_contrasena", txtContrasena.Text);

                // Parámetro de salida: 1 si las credenciales son correctas, 0 si no
                cmd.Parameters.Add("p_resultado", MySqlDbType.Int32).Direction =
                    System.Data.ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                int resultado = Convert.ToInt32(cmd.Parameters["p_resultado"].Value);

                if (resultado > 0)
                {
                    // Credenciales correctas: abrir el menú principal y ocultar el login
                    frmMenuPrincipal menu = new frmMenuPrincipal();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    // Credenciales incorrectas: informar y limpiar la contraseña
                    MessageBox.Show("Usuario o contraseña incorrectos.",
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasena.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón Cancelar: cierra la aplicación
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Permite presionar Enter desde el campo contraseña para iniciar sesión
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnIngresar_Click(sender, e);
        }
    }
}
