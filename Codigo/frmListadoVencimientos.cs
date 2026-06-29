using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    // Formulario de Listado Diario de Socios con Cuota Vencida (CU3).
    // Consulta la tabla 'socios' y muestra en un DataGridView todos los socios
    // cuya fecha de vencimiento de cuota coincide con la fecha actual.
    public partial class frmListadoVencimientos : Form
    {
        public frmListadoVencimientos()
        {
            InitializeComponent();
            // Cargar el listado automáticamente al abrir el formulario
            CargarListado();
        }

        // Consulta los socios con vencimiento hoy y los muestra en la grilla
        private void CargarListado()
        {
            try
            {
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();

                // Actualizar estado de socios vencidos antes de consultar
                new MySqlCommand("sp_ActualizarEstadoVencidos", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                }.ExecuteNonQuery();

                // Seleccionar socios cuya fecha de vencimiento es hasta hoy
                string query =
                    "SELECT nroSocio        AS 'N° Socio', " +
                    "       nombre          AS 'Nombre', " +
                    "       apellido        AS 'Apellido', " +
                    "       fechaVencimientoCuota AS 'Fecha Vencimiento' " +
                    "FROM socios " +
                    "WHERE DATE(fechaVencimientoCuota) <= CURDATE() " +
                    "ORDER BY apellido, nombre";

                // Usar DataAdapter para llenar un DataTable y enlazarlo al DataGridView
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                dgvListado.DataSource = dt;
                lblTotal.Text = $"Total: {dt.Rows.Count} socio(s) con cuota vencida hoy.";

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay vencimientos para el día de hoy.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el listado:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Recarga el listado (útil si se registraron cobros mientras el formulario estaba abierto)
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        // Cierra el formulario y vuelve al menú principal
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
