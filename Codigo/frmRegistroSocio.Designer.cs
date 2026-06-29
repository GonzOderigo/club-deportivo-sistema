using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    partial class frmRegistroSocio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader     = new Panel();
            this.lblTitulo     = new Label();
            this.grpTipo       = new GroupBox();
            this.rbSocio       = new RadioButton();
            this.rbNoSocio     = new RadioButton();
            this.grpDatos      = new GroupBox();
            this.lblNombre     = new Label();
            this.txtNombre     = new TextBox();
            this.lblApellido   = new Label();
            this.txtApellido   = new TextBox();
            this.lblDni        = new Label();
            this.txtDni        = new TextBox();
            this.chkAptoFisico = new CheckBox();
            this.btnRegistrar  = new Button();
            this.btnLimpiar    = new Button();
            this.btnVolver     = new Button();

            this.pnlHeader.SuspendLayout();
            this.grpTipo.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(31, 56, 100);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Size = new Size(560, 55);

            // lblTitulo
            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Dock      = DockStyle.Fill;
            this.lblTitulo.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Text      = "Registro de Socios y No Socios";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // grpTipo
            this.grpTipo.Controls.Add(this.rbSocio);
            this.grpTipo.Controls.Add(this.rbNoSocio);
            this.grpTipo.Font     = new Font("Segoe UI", 9F);
            this.grpTipo.Location = new Point(20, 70);
            this.grpTipo.Size     = new Size(520, 50);
            this.grpTipo.Text     = "Tipo de registro";

            this.rbSocio.AutoSize        = true;
            this.rbSocio.Checked         = true;
            this.rbSocio.Location        = new Point(40, 20);
            this.rbSocio.Text            = "Socio";
            this.rbSocio.CheckedChanged += new System.EventHandler(this.rbSocio_CheckedChanged);

            this.rbNoSocio.AutoSize = true;
            this.rbNoSocio.Location = new Point(180, 20);
            this.rbNoSocio.Text     = "No Socio";

            // grpDatos
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblApellido);
            this.grpDatos.Controls.Add(this.txtApellido);
            this.grpDatos.Controls.Add(this.lblDni);
            this.grpDatos.Controls.Add(this.txtDni);
            this.grpDatos.Controls.Add(this.chkAptoFisico);
            this.grpDatos.Font     = new Font("Segoe UI", 9F);
            this.grpDatos.Location = new Point(20, 135);
            this.grpDatos.Size     = new Size(520, 195);
            this.grpDatos.Text     = "Datos personales";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(15, 33);
            this.lblNombre.Text     = "Nombre:";

            this.txtNombre.Location = new Point(120, 30);
            this.txtNombre.Size     = new Size(380, 23);
            this.txtNombre.TabIndex = 0;

            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(15, 73);
            this.lblApellido.Text     = "Apellido:";

            this.txtApellido.Location = new Point(120, 70);
            this.txtApellido.Size     = new Size(380, 23);
            this.txtApellido.TabIndex = 1;

            this.lblDni.AutoSize = true;
            this.lblDni.Location = new Point(15, 113);
            this.lblDni.Text     = "DNI:";

            this.txtDni.Location = new Point(120, 110);
            this.txtDni.Size     = new Size(200, 23);
            this.txtDni.TabIndex = 2;

            // chkAptoFisico — visible solo para Socio
            this.chkAptoFisico.AutoSize  = true;
            this.chkAptoFisico.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.chkAptoFisico.ForeColor = Color.FromArgb(31, 56, 100);
            this.chkAptoFisico.Location  = new Point(15, 153);
            this.chkAptoFisico.Size      = new Size(460, 22);
            this.chkAptoFisico.TabIndex  = 3;
            this.chkAptoFisico.Text      = "El postulante presentó certificado de apto físico";

            // Botones
            this.btnRegistrar.BackColor  = Color.FromArgb(46, 116, 181);
            this.btnRegistrar.FlatStyle  = FlatStyle.Flat;
            this.btnRegistrar.ForeColor  = Color.White;
            this.btnRegistrar.Font       = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRegistrar.Location   = new Point(20, 355);
            this.btnRegistrar.Size       = new Size(140, 35);
            this.btnRegistrar.TabIndex   = 4;
            this.btnRegistrar.Text       = "Registrar";
            this.btnRegistrar.Click     += new System.EventHandler(this.btnRegistrar_Click);

            this.btnLimpiar.BackColor  = Color.FromArgb(80, 130, 80);
            this.btnLimpiar.FlatStyle  = FlatStyle.Flat;
            this.btnLimpiar.ForeColor  = Color.White;
            this.btnLimpiar.Font       = new Font("Segoe UI", 9F);
            this.btnLimpiar.Location   = new Point(200, 355);
            this.btnLimpiar.Size       = new Size(120, 35);
            this.btnLimpiar.TabIndex   = 5;
            this.btnLimpiar.Text       = "Limpiar";
            this.btnLimpiar.Click     += new System.EventHandler(this.btnLimpiar_Click);

            this.btnVolver.BackColor  = Color.FromArgb(100, 100, 100);
            this.btnVolver.FlatStyle  = FlatStyle.Flat;
            this.btnVolver.ForeColor  = Color.White;
            this.btnVolver.Font       = new Font("Segoe UI", 9F);
            this.btnVolver.Location   = new Point(400, 355);
            this.btnVolver.Size       = new Size(120, 35);
            this.btnVolver.TabIndex   = 6;
            this.btnVolver.Text       = "Volver";
            this.btnVolver.Click     += new System.EventHandler(this.btnVolver_Click);

            // frmRegistroSocio
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.WhiteSmoke;
            this.ClientSize          = new Size(560, 415);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.grpTipo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnVolver);
            this.Font            = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.Text            = "Registro — Club Deportivo";

            this.pnlHeader.ResumeLayout(false);
            this.grpTipo.ResumeLayout(false);
            this.grpTipo.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel       pnlHeader;
        private Label       lblTitulo;
        private GroupBox    grpTipo;
        private RadioButton rbSocio;
        private RadioButton rbNoSocio;
        private GroupBox    grpDatos;
        private Label       lblNombre;
        private TextBox     txtNombre;
        private Label       lblApellido;
        private TextBox     txtApellido;
        private Label       lblDni;
        private TextBox     txtDni;
        private CheckBox    chkAptoFisico;
        private Button      btnRegistrar;
        private Button      btnLimpiar;
        private Button      btnVolver;
    }
}
