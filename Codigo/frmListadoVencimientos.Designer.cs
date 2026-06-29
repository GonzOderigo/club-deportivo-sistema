using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    partial class frmListadoVencimientos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader    = new Panel();
            this.lblTitulo    = new Label();
            this.lblFecha     = new Label();
            this.dgvListado   = new DataGridView();
            this.lblTotal     = new Label();
            this.btnActualizar= new Button();
            this.btnVolver    = new Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvListado).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(31, 56, 100);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblFecha);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Size = new Size(680, 65);

            // lblTitulo
            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location  = new Point(0, 8);
            this.lblTitulo.Size      = new Size(680, 26);
            this.lblTitulo.Text      = "Listado Diario de Socios con Cuota Vencida";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblFecha
            this.lblFecha.AutoSize  = false;
            this.lblFecha.Font      = new Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = Color.FromArgb(180, 210, 240);
            this.lblFecha.Location  = new Point(0, 38);
            this.lblFecha.Size      = new Size(680, 20);
            this.lblFecha.Text      = "Fecha: " + System.DateTime.Today.ToLongDateString();
            this.lblFecha.TextAlign = ContentAlignment.MiddleCenter;

            // dgvListado
            this.dgvListado.AllowUserToAddRows    = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.BackgroundColor       = Color.White;
            this.dgvListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 116, 181);
            this.dgvListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvListado.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.EnableHeadersVisualStyles   = false;
            this.dgvListado.Location          = new Point(20, 80);
            this.dgvListado.MultiSelect        = false;
            this.dgvListado.ReadOnly           = true;
            this.dgvListado.RowHeadersVisible  = false;
            this.dgvListado.SelectionMode      = DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size               = new Size(640, 290);
            this.dgvListado.TabIndex           = 0;
            this.dgvListado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 246, 253);

            // lblTotal
            this.lblTotal.AutoSize  = false;
            this.lblTotal.Font      = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblTotal.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblTotal.Location  = new Point(20, 382);
            this.lblTotal.Size      = new Size(400, 20);
            this.lblTotal.Text      = "Total: —";

            // btnActualizar
            this.btnActualizar.BackColor  = Color.FromArgb(46, 116, 181);
            this.btnActualizar.FlatStyle  = FlatStyle.Flat;
            this.btnActualizar.ForeColor  = Color.White;
            this.btnActualizar.Font       = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnActualizar.Location   = new Point(420, 408);
            this.btnActualizar.Size       = new Size(110, 35);
            this.btnActualizar.TabIndex   = 1;
            this.btnActualizar.Text       = "Actualizar";
            this.btnActualizar.Click     += new System.EventHandler(this.btnActualizar_Click);

            // btnVolver
            this.btnVolver.BackColor  = Color.FromArgb(100, 100, 100);
            this.btnVolver.FlatStyle  = FlatStyle.Flat;
            this.btnVolver.ForeColor  = Color.White;
            this.btnVolver.Font       = new Font("Segoe UI", 9F);
            this.btnVolver.Location   = new Point(545, 408);
            this.btnVolver.Size       = new Size(110, 35);
            this.btnVolver.TabIndex   = 2;
            this.btnVolver.Text       = "Volver";
            this.btnVolver.Click     += new System.EventHandler(this.btnVolver_Click);

            // frmListadoVencimientos
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.WhiteSmoke;
            this.ClientSize          = new Size(680, 460);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnVolver);
            this.Font            = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.Text            = "Listado de Vencimientos — Club Deportivo";

            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvListado).EndInit();
            this.ResumeLayout(false);
        }

        private Panel         pnlHeader;
        private Label         lblTitulo;
        private Label         lblFecha;
        private DataGridView  dgvListado;
        private Label         lblTotal;
        private Button        btnActualizar;
        private Button        btnVolver;
    }
}
