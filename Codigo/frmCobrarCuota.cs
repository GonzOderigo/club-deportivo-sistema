using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class frmCobrarCuota : Form
    {
        private int _nroSocioActual  = -1;
        private int _idNoSocioActual = -1;
        private int _nroActividadActual = -1;

        public frmCobrarCuota()
        {
            InitializeComponent();
            CargarActividades();
        }

        // ── Cambio tipo persona ───────────────────────────────────────────────

        private void rbEsSocio_CheckedChanged(object sender, EventArgs e)
        {
            bool esSocio = rbEsSocio.Checked;
            lblBuscarLabel.Text    = esSocio ? "N° Socio:" : "DNI:";
            grpPagoSocio.Visible   = esSocio;
            grpPagoNoSocio.Visible = !esSocio;
            btnCobrar.Text         = esSocio ? "Cobrar y Emitir Carnet" : "Registrar Cobro";
            LimpiarBusqueda();
        }

        // ── Carga actividades ─────────────────────────────────────────────────

        private void CargarActividades()
        {
            try
            {
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT nroActividad, nombre, precio FROM actividades ORDER BY nombre", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                cmbActividad.Items.Clear();
                while (dr.Read())
                    cmbActividad.Items.Add(new ActividadItem(
                        Convert.ToInt32(dr["nroActividad"]),
                        dr["nombre"]?.ToString() ?? string.Empty,
                        Convert.ToDecimal(dr["precio"])));
                dr.Close();
                if (cmbActividad.Items.Count > 0)
                    cmbActividad.SelectedIndex = 0;
            }
            catch { }
        }

        private void cmbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActividad.SelectedItem is ActividadItem act)
            {
                _nroActividadActual = act.NroActividad;
                lblPrecioVal.Text   = $"$ {act.Precio:N2}";
            }
        }

        // ── Eventos medio de pago — SOCIO ─────────────────────────────────────

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            cmbCuotas.Enabled = rbTarjeta.Checked;
            if (!rbTarjeta.Checked)
            {
                cmbCuotas.SelectedIndex = 0;
                lblPromoSocio.Visible   = false;
            }
        }

        private void rbMedioPago_ChangedSocio(object sender, EventArgs e)
        {
            if (rbEfectivo.Checked) lblPromoSocio.Visible = false;
        }

        private void cmbCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = CuotasDesdeCombo(cmbCuotas);
            lblPromoSocio.Visible = rbTarjeta.Checked && (c == 3 || c == 6);
        }

        // ── Eventos medio de pago — NO SOCIO ─────────────────────────────────

        private void rbTarjetaNS_CheckedChanged(object sender, EventArgs e)
        {
            cmbCuotasNS.Enabled = rbTarjetaNS.Checked;
            if (!rbTarjetaNS.Checked)
            {
                cmbCuotasNS.SelectedIndex = 0;
                lblPromoNS.Visible        = false;
            }
        }

        private void rbMedioPago_ChangedNS(object sender, EventArgs e)
        {
            if (rbEfectivoNS.Checked) lblPromoNS.Visible = false;
        }

        private void cmbCuotasNS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = CuotasDesdeCombo(cmbCuotasNS);
            lblPromoNS.Visible = rbTarjetaNS.Checked && (c == 3 || c == 6);
        }

        // ── Buscar ────────────────────────────────────────────────────────────

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                MessageBox.Show("Ingrese el dato de búsqueda.",
                    "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rbEsSocio.Checked) BuscarSocio();
            else                   BuscarNoSocio();
        }

        private void BuscarSocio()
        {
            if (!int.TryParse(txtBusqueda.Text, out int nro))
            {
                MessageBox.Show("Ingrese un número de socio válido.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();

                // Actualizar estado de socios vencidos antes de mostrar datos
                new MySqlCommand("sp_ActualizarEstadoVencidos", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                }.ExecuteNonQuery();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT nombre, apellido, estado FROM socios WHERE nroSocio = @nro", con);
                cmd.Parameters.AddWithValue("@nro", nro);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    _nroSocioActual       = nro;
                    string estado         = dr["estado"]?.ToString() ?? "activo";
                    lblNombreVal.Text     = $"{dr["nombre"]} {dr["apellido"]}";
                    lblEstadoVal.Text     = $"Estado: {estado}";
                    lblEstadoVal.ForeColor = estado == "activo"
                        ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                    grpPagoSocio.Enabled  = true;
                    btnCobrar.Enabled     = true;
                }
                else
                {
                    MessageBox.Show("No se encontró un socio con ese número.",
                        "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarBusqueda();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarNoSocio()
        {
            try
            {
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT idNoSocio, nombre, apellido FROM no_socios WHERE dni = @dni", con);
                cmd.Parameters.AddWithValue("@dni", txtBusqueda.Text.Trim());
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    _idNoSocioActual       = Convert.ToInt32(dr["idNoSocio"]);
                    lblNombreVal.Text      = $"{dr["nombre"]} {dr["apellido"]}";
                    lblEstadoVal.Text      = "No Socio";
                    lblEstadoVal.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
                    grpPagoNoSocio.Enabled = true;
                    btnCobrar.Enabled      = true;
                }
                else
                {
                    MessageBox.Show("No se encontró un no socio con ese DNI.",
                        "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarBusqueda();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Cobrar ────────────────────────────────────────────────────────────

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (rbEsSocio.Checked) CobrarSocio();
            else                   CobrarNoSocio();
        }

        private void CobrarSocio()
        {
            if (_nroSocioActual < 0) return;
            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string medioPago = rbEfectivo.Checked ? "efectivo" : "tarjeta";
            int cantCuotas   = CuotasDesdeCombo(cmbCuotas);

            try
            {
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();
                MySqlCommand cmd = new MySqlCommand("sp_CobrarCuota", con)
                    { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("p_nroSocio",   _nroSocioActual);
                cmd.Parameters.AddWithValue("p_monto",      monto);
                cmd.Parameters.AddWithValue("p_fechaPago",  DateTime.Today);
                cmd.Parameters.AddWithValue("p_medioPago",  medioPago);
                cmd.Parameters.AddWithValue("p_cantCuotas", cantCuotas);
                cmd.ExecuteNonQuery();

                string detalle = medioPago == "tarjeta"
                    ? $"tarjeta — {cantCuotas} cuota{(cantCuotas > 1 ? "s" : "")}" +
                      (cantCuotas == 3 || cantCuotas == 6 ? "  ¡Promo!" : "")
                    : "efectivo";

                MessageBox.Show(
                    $"Cuota mensual cobrada.\nMedio de pago: {detalle}\nCarnet emitido y entregado.",
                    "Cobro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cobrar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CobrarNoSocio()
        {
            if (_idNoSocioActual < 0) return;

            ActividadItem? act = cmbActividad.SelectedItem as ActividadItem;
            if (act == null || act.Precio <= 0)
            {
                MessageBox.Show("Seleccione una actividad válida.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string medioPago = rbEfectivoNS.Checked ? "efectivo" : "tarjeta";
            int cantCuotas   = CuotasDesdeCombo(cmbCuotasNS);

            try
            {
                MySqlConnection con = Conexion.Instancia.ObtenerConexion();
                MySqlCommand cmd = new MySqlCommand("sp_CobrarNoSocio", con)
                    { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("p_idNoSocio",    _idNoSocioActual);
                cmd.Parameters.AddWithValue("p_nroActividad", _nroActividadActual);
                cmd.Parameters.AddWithValue("p_monto",        act.Precio);
                cmd.Parameters.AddWithValue("p_medioPago",    medioPago);
                cmd.Parameters.AddWithValue("p_cantCuotas",   cantCuotas);
                cmd.Parameters.AddWithValue("p_fechaCobro",   DateTime.Today);
                cmd.ExecuteNonQuery();

                string detalle = medioPago == "tarjeta"
                    ? $"tarjeta — {cantCuotas} cuota{(cantCuotas > 1 ? "s" : "")}" +
                      (cantCuotas == 3 || cantCuotas == 6 ? "  ¡Promo!" : "")
                    : "efectivo";

                MessageBox.Show(
                    $"Cobro registrado.\nActividad: {act.Nombre}\nMonto: $ {act.Precio:N2}\nMedio de pago: {detalle}",
                    "Cobro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cobrar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();

        // ── Helpers ───────────────────────────────────────────────────────────

        private static int CuotasDesdeCombo(ComboBox cmb)
        {
            return cmb.SelectedIndex switch
            {
                1 => 3,
                2 => 6,
                3 => 12,
                _ => 1
            };
        }

        private void LimpiarBusqueda()
        {
            _nroSocioActual        = -1;
            _idNoSocioActual       = -1;
            lblNombreVal.Text      = "—";
            lblEstadoVal.Text      = "";
            grpPagoSocio.Enabled   = false;
            grpPagoNoSocio.Enabled = false;
            btnCobrar.Enabled      = false;
            lblPromoSocio.Visible  = false;
            lblPromoNS.Visible     = false;
        }

        private void LimpiarTodo()
        {
            txtBusqueda.Clear();
            txtMonto.Clear();
            rbEfectivo.Checked    = true;
            rbEfectivoNS.Checked  = true;
            cmbCuotas.SelectedIndex   = 0;
            cmbCuotasNS.SelectedIndex = 0;
            if (cmbActividad.Items.Count > 0) cmbActividad.SelectedIndex = 0;
            LimpiarBusqueda();
        }

        // ── Clase auxiliar ────────────────────────────────────────────────────

        private class ActividadItem
        {
            public int     NroActividad { get; }
            public string  Nombre       { get; }
            public decimal Precio       { get; }

            public ActividadItem(int nro, string? nombre, decimal precio)
            {
                NroActividad = nro;
                Nombre       = nombre ?? string.Empty;
                Precio       = precio;
            }

            public override string ToString() => $"{Nombre}  ($ {Precio:N2})";
        }
    }
}
