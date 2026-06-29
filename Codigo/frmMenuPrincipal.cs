using System;
using System.Windows.Forms;

namespace ClubDeportivo
{
    // Formulario del menú principal.
    // Se muestra después de un login exitoso.
    // Permite acceder a los tres procesos del sistema mediante botones.
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        // Abre el formulario de Registro de Socios y No Socios (CU1)
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            new frmRegistroSocio().ShowDialog();
        }

        // Abre el formulario de Cobro de Cuota y Entrega de Carnet (CU2)
        private void btnCobrarCuota_Click(object sender, EventArgs e)
        {
            new frmCobrarCuota().ShowDialog();
        }

        // Abre el formulario de Listado Diario de Vencimientos (CU3)
        private void btnListado_Click(object sender, EventArgs e)
        {
            new frmListadoVencimientos().ShowDialog();
        }

        // Abre la vista de solo lectura del plantel de profesores
        private void btnPlantel_Click(object sender, EventArgs e)
        {
            new frmPlantel().ShowDialog();
        }

        // Cierra la conexión y termina la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Conexion.Instancia.CerrarConexion();
            Application.Exit();
        }

        // Al cerrar el menú principal se cierra toda la aplicación
        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Conexion.Instancia.CerrarConexion();
            Application.Exit();
        }
    }
}
