using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class frmPlantel : Form
    {
        public frmPlantel()
        {
            InitializeComponent();
        }

        private void frmPlantel_Load(object sender, EventArgs e)
        {
            CargarPlantel();
        }

        private void CargarPlantel()
        {
            dgvPlantel.Rows.Clear();
            try
            {
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();
                string q = "SELECT nroProfesor, nombre, apellido, especialidad, " +
                           "horarioAsignado, sueldo FROM profesores ORDER BY apellido, nombre";
                MySqlCommand    cmd = new MySqlCommand(q, con);
                MySqlDataReader dr  = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvPlantel.Rows.Add(
                        dr["nroProfesor"],
                        dr["nombre"],
                        dr["apellido"],
                        dr["especialidad"],
                        dr["horarioAsignado"],
                        $"$ {Convert.ToDecimal(dr["sueldo"]):N2}");
                }
                dr.Close();

                if (dgvPlantel.Rows.Count == 0)
                    dgvPlantel.Rows.Add("—", "No hay profesores registrados.", "", "", "", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el plantel:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();
    }
}
