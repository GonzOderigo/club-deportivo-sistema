using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    partial class frmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader      = new Panel();
            this.lblTitulo      = new Label();
            this.lblSubtitulo   = new Label();
            this.btnRegistro    = new Button();
            this.btnCobrarCuota = new Button();
            this.btnListado     = new Button();
            this.btnPlantel     = new Button();
            this.btnSalir       = new Button();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(31, 56, 100);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Size = new Size(480, 70);

            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Font      = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location  = new Point(0, 8);
            this.lblTitulo.Size      = new Size(480, 28);
            this.lblTitulo.Text      = "Club Deportivo";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            this.lblSubtitulo.AutoSize  = false;
            this.lblSubtitulo.Font      = new Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = Color.FromArgb(180, 210, 240);
            this.lblSubtitulo.Location  = new Point(0, 40);
            this.lblSubtitulo.Size      = new Size(480, 22);
            this.lblSubtitulo.Text      = "Menú Principal";
            this.lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            // btnRegistro
            this.btnRegistro.BackColor = Color.FromArgb(46, 116, 181);
            this.btnRegistro.FlatStyle = FlatStyle.Flat;
            this.btnRegistro.ForeColor = Color.White;
            this.btnRegistro.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRegistro.Location  = new Point(60, 100);
            this.btnRegistro.Size      = new Size(360, 50);
            this.btnRegistro.TabIndex  = 0;
            this.btnRegistro.Text      = "1.  Registro de Socios / No Socios";
            this.btnRegistro.Click    += new System.EventHandler(this.btnRegistro_Click);

            // btnCobrarCuota
            this.btnCobrarCuota.BackColor = Color.FromArgb(46, 116, 181);
            this.btnCobrarCuota.FlatStyle = FlatStyle.Flat;
            this.btnCobrarCuota.ForeColor = Color.White;
            this.btnCobrarCuota.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCobrarCuota.Location  = new Point(60, 168);
            this.btnCobrarCuota.Size      = new Size(360, 50);
            this.btnCobrarCuota.TabIndex  = 1;
            this.btnCobrarCuota.Text      = "2.  Cobrar Cuota y Entregar Carnet";
            this.btnCobrarCuota.Click    += new System.EventHandler(this.btnCobrarCuota_Click);

            // btnListado
            this.btnListado.BackColor = Color.FromArgb(46, 116, 181);
            this.btnListado.FlatStyle = FlatStyle.Flat;
            this.btnListado.ForeColor = Color.White;
            this.btnListado.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnListado.Location  = new Point(60, 236);
            this.btnListado.Size      = new Size(360, 50);
            this.btnListado.TabIndex  = 2;
            this.btnListado.Text      = "3.  Listado Diario de Vencimientos";
            this.btnListado.Click    += new System.EventHandler(this.btnListado_Click);

            // btnPlantel
            this.btnPlantel.BackColor = Color.FromArgb(46, 116, 181);
            this.btnPlantel.FlatStyle = FlatStyle.Flat;
            this.btnPlantel.ForeColor = Color.White;
            this.btnPlantel.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnPlantel.Location  = new Point(60, 304);
            this.btnPlantel.Size      = new Size(360, 50);
            this.btnPlantel.TabIndex  = 3;
            this.btnPlantel.Text      = "4.  Plantel de Profesores";
            this.btnPlantel.Click    += new System.EventHandler(this.btnPlantel_Click);

            // btnSalir
            this.btnSalir.BackColor = Color.FromArgb(100, 100, 100);
            this.btnSalir.FlatStyle = FlatStyle.Flat;
            this.btnSalir.ForeColor = Color.White;
            this.btnSalir.Font      = new Font("Segoe UI", 9F);
            this.btnSalir.Location  = new Point(170, 378);
            this.btnSalir.Size      = new Size(140, 32);
            this.btnSalir.TabIndex  = 4;
            this.btnSalir.Text      = "Salir";
            this.btnSalir.Click    += new System.EventHandler(this.btnSalir_Click);

            // frmMenuPrincipal
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.WhiteSmoke;
            this.ClientSize          = new Size(480, 432);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.btnCobrarCuota);
            this.Controls.Add(this.btnListado);
            this.Controls.Add(this.btnPlantel);
            this.Controls.Add(this.btnSalir);
            this.Font            = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.Text            = "Menú Principal — Club Deportivo";
            this.FormClosed     += new FormClosedEventHandler(this.frmMenuPrincipal_FormClosed);

            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel  pnlHeader;
        private Label  lblTitulo;
        private Label  lblSubtitulo;
        private Button btnRegistro;
        private Button btnCobrarCuota;
        private Button btnListado;
        private Button btnPlantel;
        private Button btnSalir;
    }
}
