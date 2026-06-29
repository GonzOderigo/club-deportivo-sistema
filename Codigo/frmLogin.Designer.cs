using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    partial class frmLogin
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
            this.grpAcceso      = new GroupBox();
            this.lblUsuario     = new Label();
            this.txtUsuario     = new TextBox();
            this.lblContrasena  = new Label();
            this.txtContrasena  = new TextBox();
            this.btnIngresar    = new Button();
            this.btnCancelar    = new Button();

            this.pnlHeader.SuspendLayout();
            this.grpAcceso.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(31, 56, 100);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock    = DockStyle.Top;
            this.pnlHeader.Size    = new Size(380, 55);

            // lblTitulo
            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Dock      = DockStyle.Fill;
            this.lblTitulo.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Text      = "Club Deportivo";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // grpAcceso
            this.grpAcceso.Controls.Add(this.lblUsuario);
            this.grpAcceso.Controls.Add(this.txtUsuario);
            this.grpAcceso.Controls.Add(this.lblContrasena);
            this.grpAcceso.Controls.Add(this.txtContrasena);
            this.grpAcceso.Font     = new Font("Segoe UI", 9F);
            this.grpAcceso.Location = new Point(20, 70);
            this.grpAcceso.Size     = new Size(340, 120);
            this.grpAcceso.Text     = "Acceso al sistema";

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new Point(15, 30);
            this.lblUsuario.Text     = "Usuario:";

            // txtUsuario
            this.txtUsuario.Location = new Point(110, 27);
            this.txtUsuario.Size     = new Size(210, 23);
            this.txtUsuario.TabIndex = 0;

            // lblContrasena
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new Point(15, 70);
            this.lblContrasena.Text     = "Contraseña:";

            // txtContrasena
            this.txtContrasena.Location     = new Point(110, 67);
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size         = new Size(210, 23);
            this.txtContrasena.TabIndex     = 1;
            this.txtContrasena.KeyDown     += new KeyEventHandler(this.txtContrasena_KeyDown);

            // btnIngresar
            this.btnIngresar.BackColor  = Color.FromArgb(46, 116, 181);
            this.btnIngresar.FlatStyle  = FlatStyle.Flat;
            this.btnIngresar.ForeColor  = Color.White;
            this.btnIngresar.Font       = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnIngresar.Location   = new Point(50, 210);
            this.btnIngresar.Size       = new Size(120, 35);
            this.btnIngresar.TabIndex   = 2;
            this.btnIngresar.Text       = "Ingresar";
            this.btnIngresar.Click     += new System.EventHandler(this.btnIngresar_Click);

            // btnCancelar
            this.btnCancelar.BackColor  = Color.FromArgb(100, 100, 100);
            this.btnCancelar.FlatStyle  = FlatStyle.Flat;
            this.btnCancelar.ForeColor  = Color.White;
            this.btnCancelar.Font       = new Font("Segoe UI", 9F);
            this.btnCancelar.Location   = new Point(210, 210);
            this.btnCancelar.Size       = new Size(120, 35);
            this.btnCancelar.TabIndex   = 3;
            this.btnCancelar.Text       = "Cancelar";
            this.btnCancelar.Click     += new System.EventHandler(this.btnCancelar_Click);

            // frmLogin
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.WhiteSmoke;
            this.ClientSize          = new Size(380, 270);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.grpAcceso);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnCancelar);
            this.Font            = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.Text            = "Login — Club Deportivo";

            this.pnlHeader.ResumeLayout(false);
            this.grpAcceso.ResumeLayout(false);
            this.grpAcceso.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel    pnlHeader;
        private Label    lblTitulo;
        private GroupBox grpAcceso;
        private Label    lblUsuario;
        private TextBox  txtUsuario;
        private Label    lblContrasena;
        private TextBox  txtContrasena;
        private Button   btnIngresar;
        private Button   btnCancelar;
    }
}
