using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    partial class frmCobrarCuota
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader       = new Panel();
            this.lblTitulo       = new Label();
            this.grpTipoPersona  = new GroupBox();
            this.rbEsSocio       = new RadioButton();
            this.rbEsNoSocio     = new RadioButton();
            this.grpBuscar       = new GroupBox();
            this.lblBuscarLabel  = new Label();
            this.txtBusqueda     = new TextBox();
            this.btnBuscar       = new Button();
            this.grpInfo         = new GroupBox();
            this.lblNombreVal    = new Label();
            this.lblEstadoVal    = new Label();
            // Pago socio
            this.grpPagoSocio    = new GroupBox();
            this.lblMedioPago    = new Label();
            this.rbEfectivo      = new RadioButton();
            this.rbTarjeta       = new RadioButton();
            this.lblCuotasLabel  = new Label();
            this.cmbCuotas       = new ComboBox();
            this.lblPromoSocio   = new Label();
            this.lblMonto        = new Label();
            this.txtMonto        = new TextBox();
            // Pago no socio
            this.grpPagoNoSocio  = new GroupBox();
            this.lblActividad    = new Label();
            this.cmbActividad    = new ComboBox();
            this.lblPrecioLabel  = new Label();
            this.lblPrecioVal    = new Label();
            this.lblMedioPagoNS  = new Label();
            this.rbEfectivoNS    = new RadioButton();
            this.rbTarjetaNS     = new RadioButton();
            this.lblCuotasNSLabel= new Label();
            this.cmbCuotasNS     = new ComboBox();
            this.lblPromoNS      = new Label();
            // Botones
            this.btnCobrar       = new Button();
            this.btnVolver       = new Button();

            this.pnlHeader.SuspendLayout();
            this.grpTipoPersona.SuspendLayout();
            this.grpBuscar.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.grpPagoSocio.SuspendLayout();
            this.grpPagoNoSocio.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(31, 56, 100);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Size = new Size(580, 55);

            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Dock      = DockStyle.Fill;
            this.lblTitulo.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Text      = "Cobrar Cuota y Entregar Carnet";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // grpTipoPersona
            this.grpTipoPersona.Controls.Add(this.rbEsSocio);
            this.grpTipoPersona.Controls.Add(this.rbEsNoSocio);
            this.grpTipoPersona.Font     = new Font("Segoe UI", 9F);
            this.grpTipoPersona.Location = new Point(20, 70);
            this.grpTipoPersona.Size     = new Size(540, 50);
            this.grpTipoPersona.Text     = "Tipo de persona";

            this.rbEsSocio.AutoSize        = true;
            this.rbEsSocio.Checked         = true;
            this.rbEsSocio.Location        = new Point(40, 20);
            this.rbEsSocio.Text            = "Socio (cuota mensual)";
            this.rbEsSocio.TabIndex        = 0;
            this.rbEsSocio.CheckedChanged += new System.EventHandler(this.rbEsSocio_CheckedChanged);

            this.rbEsNoSocio.AutoSize = true;
            this.rbEsNoSocio.Location = new Point(250, 20);
            this.rbEsNoSocio.Text     = "No Socio (pago por actividad)";
            this.rbEsNoSocio.TabIndex = 1;

            // grpBuscar
            this.grpBuscar.Controls.Add(this.lblBuscarLabel);
            this.grpBuscar.Controls.Add(this.txtBusqueda);
            this.grpBuscar.Controls.Add(this.btnBuscar);
            this.grpBuscar.Font     = new Font("Segoe UI", 9F);
            this.grpBuscar.Location = new Point(20, 135);
            this.grpBuscar.Size     = new Size(540, 55);
            this.grpBuscar.Text     = "Buscar";

            this.lblBuscarLabel.AutoSize = true;
            this.lblBuscarLabel.Location = new Point(15, 23);
            this.lblBuscarLabel.Text     = "N° Socio:";

            this.txtBusqueda.Location = new Point(100, 20);
            this.txtBusqueda.Size     = new Size(130, 23);
            this.txtBusqueda.TabIndex = 2;

            this.btnBuscar.BackColor = Color.FromArgb(46, 116, 181);
            this.btnBuscar.FlatStyle = FlatStyle.Flat;
            this.btnBuscar.ForeColor = Color.White;
            this.btnBuscar.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnBuscar.Location  = new Point(250, 18);
            this.btnBuscar.Size      = new Size(90, 27);
            this.btnBuscar.TabIndex  = 3;
            this.btnBuscar.Text      = "Buscar";
            this.btnBuscar.Click    += new System.EventHandler(this.btnBuscar_Click);

            // grpInfo
            this.grpInfo.Controls.Add(this.lblNombreVal);
            this.grpInfo.Controls.Add(this.lblEstadoVal);
            this.grpInfo.Font     = new Font("Segoe UI", 9F);
            this.grpInfo.Location = new Point(20, 205);
            this.grpInfo.Size     = new Size(540, 70);
            this.grpInfo.Text     = "Datos";

            this.lblNombreVal.AutoSize  = true;
            this.lblNombreVal.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblNombreVal.Location  = new Point(15, 22);
            this.lblNombreVal.Text      = "—";

            this.lblEstadoVal.AutoSize  = true;
            this.lblEstadoVal.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblEstadoVal.Location  = new Point(15, 46);
            this.lblEstadoVal.Text      = "";

            // ── grpPagoSocio ──────────────────────────────────────────────────
            this.grpPagoSocio.Controls.Add(this.lblMedioPago);
            this.grpPagoSocio.Controls.Add(this.rbEfectivo);
            this.grpPagoSocio.Controls.Add(this.rbTarjeta);
            this.grpPagoSocio.Controls.Add(this.lblCuotasLabel);
            this.grpPagoSocio.Controls.Add(this.cmbCuotas);
            this.grpPagoSocio.Controls.Add(this.lblPromoSocio);
            this.grpPagoSocio.Controls.Add(this.lblMonto);
            this.grpPagoSocio.Controls.Add(this.txtMonto);
            this.grpPagoSocio.Enabled  = false;
            this.grpPagoSocio.Font     = new Font("Segoe UI", 9F);
            this.grpPagoSocio.Location = new Point(20, 290);
            this.grpPagoSocio.Size     = new Size(540, 145);
            this.grpPagoSocio.Text     = "Cuota mensual y medio de pago";

            this.lblMedioPago.AutoSize = true;
            this.lblMedioPago.Location = new Point(15, 28);
            this.lblMedioPago.Text     = "Medio de pago:";

            this.rbEfectivo.AutoSize        = true;
            this.rbEfectivo.Checked         = true;
            this.rbEfectivo.Location        = new Point(125, 26);
            this.rbEfectivo.Text            = "Efectivo";
            this.rbEfectivo.TabIndex        = 4;
            this.rbEfectivo.CheckedChanged += new System.EventHandler(this.rbMedioPago_ChangedSocio);

            this.rbTarjeta.AutoSize        = true;
            this.rbTarjeta.Location        = new Point(225, 26);
            this.rbTarjeta.Text            = "Tarjeta de crédito";
            this.rbTarjeta.TabIndex        = 5;
            this.rbTarjeta.CheckedChanged += new System.EventHandler(this.rbTarjeta_CheckedChanged);

            this.lblCuotasLabel.AutoSize = true;
            this.lblCuotasLabel.Location = new Point(15, 65);
            this.lblCuotasLabel.Text     = "Cuotas:";

            this.cmbCuotas.DropDownStyle        = ComboBoxStyle.DropDownList;
            this.cmbCuotas.Enabled              = false;
            this.cmbCuotas.Location             = new Point(80, 62);
            this.cmbCuotas.Size                 = new Size(140, 23);
            this.cmbCuotas.TabIndex             = 6;
            this.cmbCuotas.Items.AddRange(new object[] { "1 cuota", "3 cuotas  ✓ Promo", "6 cuotas  ✓ Promo", "12 cuotas" });
            this.cmbCuotas.SelectedIndex        = 0;
            this.cmbCuotas.SelectedIndexChanged += new System.EventHandler(this.cmbCuotas_SelectedIndexChanged);

            this.lblPromoSocio.AutoSize  = true;
            this.lblPromoSocio.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPromoSocio.ForeColor = Color.FromArgb(0, 140, 0);
            this.lblPromoSocio.Location  = new Point(235, 65);
            this.lblPromoSocio.Text      = "¡Aplica promo!";
            this.lblPromoSocio.Visible   = false;

            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new Point(15, 105);
            this.lblMonto.Text     = "Monto ($):";

            this.txtMonto.Location = new Point(100, 102);
            this.txtMonto.Size     = new Size(120, 23);
            this.txtMonto.TabIndex = 7;

            // ── grpPagoNoSocio ────────────────────────────────────────────────
            this.grpPagoNoSocio.Controls.Add(this.lblActividad);
            this.grpPagoNoSocio.Controls.Add(this.cmbActividad);
            this.grpPagoNoSocio.Controls.Add(this.lblPrecioLabel);
            this.grpPagoNoSocio.Controls.Add(this.lblPrecioVal);
            this.grpPagoNoSocio.Controls.Add(this.lblMedioPagoNS);
            this.grpPagoNoSocio.Controls.Add(this.rbEfectivoNS);
            this.grpPagoNoSocio.Controls.Add(this.rbTarjetaNS);
            this.grpPagoNoSocio.Controls.Add(this.lblCuotasNSLabel);
            this.grpPagoNoSocio.Controls.Add(this.cmbCuotasNS);
            this.grpPagoNoSocio.Controls.Add(this.lblPromoNS);
            this.grpPagoNoSocio.Enabled  = false;
            this.grpPagoNoSocio.Font     = new Font("Segoe UI", 9F);
            this.grpPagoNoSocio.Location = new Point(20, 290);
            this.grpPagoNoSocio.Size     = new Size(540, 145);
            this.grpPagoNoSocio.Visible  = false;
            this.grpPagoNoSocio.Text     = "Actividad y cobro";

            this.lblActividad.AutoSize = true;
            this.lblActividad.Location = new Point(15, 28);
            this.lblActividad.Text     = "Actividad:";

            this.cmbActividad.DropDownStyle        = ComboBoxStyle.DropDownList;
            this.cmbActividad.Location             = new Point(90, 25);
            this.cmbActividad.Size                 = new Size(240, 23);
            this.cmbActividad.TabIndex             = 8;
            this.cmbActividad.SelectedIndexChanged += new System.EventHandler(this.cmbActividad_SelectedIndexChanged);

            this.lblPrecioLabel.AutoSize = true;
            this.lblPrecioLabel.Location = new Point(345, 28);
            this.lblPrecioLabel.Text     = "Precio:";

            this.lblPrecioVal.AutoSize  = true;
            this.lblPrecioVal.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPrecioVal.ForeColor = Color.FromArgb(31, 56, 100);
            this.lblPrecioVal.Location  = new Point(395, 28);
            this.lblPrecioVal.Text      = "—";

            this.lblMedioPagoNS.AutoSize = true;
            this.lblMedioPagoNS.Location = new Point(15, 65);
            this.lblMedioPagoNS.Text     = "Medio de pago:";

            this.rbEfectivoNS.AutoSize        = true;
            this.rbEfectivoNS.Checked         = true;
            this.rbEfectivoNS.Location        = new Point(125, 63);
            this.rbEfectivoNS.Text            = "Efectivo";
            this.rbEfectivoNS.TabIndex        = 9;
            this.rbEfectivoNS.CheckedChanged += new System.EventHandler(this.rbMedioPago_ChangedNS);

            this.rbTarjetaNS.AutoSize        = true;
            this.rbTarjetaNS.Location        = new Point(225, 63);
            this.rbTarjetaNS.Text            = "Tarjeta de crédito";
            this.rbTarjetaNS.TabIndex        = 10;
            this.rbTarjetaNS.CheckedChanged += new System.EventHandler(this.rbTarjetaNS_CheckedChanged);

            this.lblCuotasNSLabel.AutoSize = true;
            this.lblCuotasNSLabel.Location = new Point(15, 103);
            this.lblCuotasNSLabel.Text     = "Cuotas:";

            this.cmbCuotasNS.DropDownStyle        = ComboBoxStyle.DropDownList;
            this.cmbCuotasNS.Enabled              = false;
            this.cmbCuotasNS.Location             = new Point(80, 100);
            this.cmbCuotasNS.Size                 = new Size(140, 23);
            this.cmbCuotasNS.TabIndex             = 11;
            this.cmbCuotasNS.Items.AddRange(new object[] { "1 cuota", "3 cuotas  ✓ Promo", "6 cuotas  ✓ Promo", "12 cuotas" });
            this.cmbCuotasNS.SelectedIndex        = 0;
            this.cmbCuotasNS.SelectedIndexChanged += new System.EventHandler(this.cmbCuotasNS_SelectedIndexChanged);

            this.lblPromoNS.AutoSize  = true;
            this.lblPromoNS.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPromoNS.ForeColor = Color.FromArgb(0, 140, 0);
            this.lblPromoNS.Location  = new Point(235, 103);
            this.lblPromoNS.Text      = "¡Aplica promo!";
            this.lblPromoNS.Visible   = false;

            // btnCobrar / btnVolver
            this.btnCobrar.BackColor = Color.FromArgb(46, 116, 181);
            this.btnCobrar.Enabled   = false;
            this.btnCobrar.FlatStyle = FlatStyle.Flat;
            this.btnCobrar.ForeColor = Color.White;
            this.btnCobrar.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCobrar.Location  = new Point(20, 453);
            this.btnCobrar.Size      = new Size(160, 35);
            this.btnCobrar.TabIndex  = 12;
            this.btnCobrar.Text      = "Cobrar y Emitir Carnet";
            this.btnCobrar.Click    += new System.EventHandler(this.btnCobrar_Click);

            this.btnVolver.BackColor = Color.FromArgb(100, 100, 100);
            this.btnVolver.FlatStyle = FlatStyle.Flat;
            this.btnVolver.ForeColor = Color.White;
            this.btnVolver.Font      = new Font("Segoe UI", 9F);
            this.btnVolver.Location  = new Point(420, 453);
            this.btnVolver.Size      = new Size(120, 35);
            this.btnVolver.TabIndex  = 13;
            this.btnVolver.Text      = "Volver";
            this.btnVolver.Click    += new System.EventHandler(this.btnVolver_Click);

            // frmCobrarCuota
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.WhiteSmoke;
            this.ClientSize          = new Size(580, 505);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.grpTipoPersona);
            this.Controls.Add(this.grpBuscar);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpPagoSocio);
            this.Controls.Add(this.grpPagoNoSocio);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.btnVolver);
            this.Font            = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.Text            = "Cobrar Cuota — Club Deportivo";

            this.pnlHeader.ResumeLayout(false);
            this.grpTipoPersona.ResumeLayout(false);
            this.grpTipoPersona.PerformLayout();
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpPagoSocio.ResumeLayout(false);
            this.grpPagoSocio.PerformLayout();
            this.grpPagoNoSocio.ResumeLayout(false);
            this.grpPagoNoSocio.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel       pnlHeader;
        private Label       lblTitulo;
        private GroupBox    grpTipoPersona;
        private RadioButton rbEsSocio;
        private RadioButton rbEsNoSocio;
        private GroupBox    grpBuscar;
        private Label       lblBuscarLabel;
        private TextBox     txtBusqueda;
        private Button      btnBuscar;
        private GroupBox    grpInfo;
        private Label       lblNombreVal;
        private Label       lblEstadoVal;
        private GroupBox    grpPagoSocio;
        private Label       lblMedioPago;
        private RadioButton rbEfectivo;
        private RadioButton rbTarjeta;
        private Label       lblCuotasLabel;
        private ComboBox    cmbCuotas;
        private Label       lblPromoSocio;
        private Label       lblMonto;
        private TextBox     txtMonto;
        private GroupBox    grpPagoNoSocio;
        private Label       lblActividad;
        private ComboBox    cmbActividad;
        private Label       lblPrecioLabel;
        private Label       lblPrecioVal;
        private Label       lblMedioPagoNS;
        private RadioButton rbEfectivoNS;
        private RadioButton rbTarjetaNS;
        private Label       lblCuotasNSLabel;
        private ComboBox    cmbCuotasNS;
        private Label       lblPromoNS;
        private Button      btnCobrar;
        private Button      btnVolver;
    }
}
