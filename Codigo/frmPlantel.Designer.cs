using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    partial class frmPlantel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader  = new Panel();
            this.lblTitulo  = new Label();
            this.lblInfo    = new Label();
            this.dgvPlantel = new DataGridView();
            this.btnVolver  = new Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvPlantel).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(31, 56, 100);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Size = new Size(760, 55);

            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Dock      = DockStyle.Fill;
            this.lblTitulo.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Text      = "Plantel de Profesores";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblInfo
            this.lblInfo.AutoSize  = false;
            this.lblInfo.Font      = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblInfo.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblInfo.Location  = new Point(20, 65);
            this.lblInfo.Size      = new Size(720, 20);
            this.lblInfo.Text      = "Vista de solo lectura — profesores registrados en el club";

            // dgvPlantel
            this.dgvPlantel.AllowUserToAddRows    = false;
            this.dgvPlantel.AllowUserToDeleteRows = false;
            this.dgvPlantel.ReadOnly              = true;
            this.dgvPlantel.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlantel.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlantel.ColumnHeadersHeight   = 30;
            this.dgvPlantel.RowHeadersVisible     = false;
            this.dgvPlantel.BackgroundColor       = Color.White;
            this.dgvPlantel.BorderStyle           = BorderStyle.None;
            this.dgvPlantel.Font                  = new Font("Segoe UI", 9F);
            this.dgvPlantel.Location              = new Point(20, 93);
            this.dgvPlantel.Size                  = new Size(720, 330);
            this.dgvPlantel.TabIndex              = 0;

            // Columnas
            this.dgvPlantel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNro",      HeaderText = "N°",             FillWeight = 5  });
            this.dgvPlantel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre",   HeaderText = "Nombre",         FillWeight = 15 });
            this.dgvPlantel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colApellido", HeaderText = "Apellido",       FillWeight = 15 });
            this.dgvPlantel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEspec",    HeaderText = "Especialidad",   FillWeight = 20 });
            this.dgvPlantel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHorario",  HeaderText = "Horario",        FillWeight = 30 });
            this.dgvPlantel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSueldo",   HeaderText = "Sueldo mensual", FillWeight = 15 });

            // Estilo encabezado
            this.dgvPlantel.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 116, 181);
            this.dgvPlantel.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPlantel.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.dgvPlantel.EnableHeadersVisualStyles               = false;

            // btnVolver
            this.btnVolver.BackColor = Color.FromArgb(100, 100, 100);
            this.btnVolver.FlatStyle = FlatStyle.Flat;
            this.btnVolver.ForeColor = Color.White;
            this.btnVolver.Font      = new Font("Segoe UI", 9F);
            this.btnVolver.Location  = new Point(620, 438);
            this.btnVolver.Size      = new Size(120, 32);
            this.btnVolver.TabIndex  = 1;
            this.btnVolver.Text      = "Volver";
            this.btnVolver.Click    += new System.EventHandler(this.btnVolver_Click);

            // frmPlantel
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.WhiteSmoke;
            this.ClientSize          = new Size(760, 488);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.dgvPlantel);
            this.Controls.Add(this.btnVolver);
            this.Font            = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.Text            = "Plantel — Club Deportivo";
            this.Load           += new System.EventHandler(this.frmPlantel_Load);

            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvPlantel).EndInit();
            this.ResumeLayout(false);
        }

        private Panel            pnlHeader;
        private Label            lblTitulo;
        private Label            lblInfo;
        private DataGridView     dgvPlantel;
        private Button           btnVolver;
    }
}
