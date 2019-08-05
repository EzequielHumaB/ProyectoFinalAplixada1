namespace TrabajoFinalRecursosHumanos
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.UsuarioStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpleadosStrio = new System.Windows.Forms.ToolStripMenuItem();
            this.ContratosStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultaStrio = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contratosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TipoVacanteStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Permisolabel = new System.Windows.Forms.Label();
            this.VacantesStrio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsuarioStrip,
            this.EmpleadosStrio,
            this.VacantesStrio,
            this.ContratosStrip,
            this.LogOutStrip,
            this.ConsultaStrio});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UsuarioStrip
            // 
            this.UsuarioStrip.Name = "UsuarioStrip";
            this.UsuarioStrip.Size = new System.Drawing.Size(59, 20);
            this.UsuarioStrip.Text = "Usuario";
            this.UsuarioStrip.Click += new System.EventHandler(this.EmpleadoToolStripMenuItem_Click);
            // 
            // EmpleadosStrio
            // 
            this.EmpleadosStrio.Name = "EmpleadosStrio";
            this.EmpleadosStrio.Size = new System.Drawing.Size(72, 20);
            this.EmpleadosStrio.Text = "Empleado";
            this.EmpleadosStrio.Click += new System.EventHandler(this.HorarioToolStripMenuItem_Click);
            // 
            // ContratosStrip
            // 
            this.ContratosStrip.Checked = true;
            this.ContratosStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContratosStrip.Name = "ContratosStrip";
            this.ContratosStrip.Size = new System.Drawing.Size(71, 20);
            this.ContratosStrip.Text = "Contratos";
            this.ContratosStrip.Click += new System.EventHandler(this.ContratosStrip_Click);
            // 
            // ConsultaStrio
            // 
            this.ConsultaStrio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.eToolStripMenuItem,
            this.contratosToolStripMenuItem,
            this.departamentosToolStripMenuItem,
            this.TipoVacanteStrip});
            this.ConsultaStrio.Name = "ConsultaStrio";
            this.ConsultaStrio.Size = new System.Drawing.Size(71, 20);
            this.ConsultaStrio.Text = "Consultas";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario ";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.UsuarioToolStripMenuItem_Click_1);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eToolStripMenuItem.Text = "Empleados ";
            this.eToolStripMenuItem.Click += new System.EventHandler(this.EToolStripMenuItem_Click);
            // 
            // contratosToolStripMenuItem
            // 
            this.contratosToolStripMenuItem.Name = "contratosToolStripMenuItem";
            this.contratosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.contratosToolStripMenuItem.Text = "Contratos";
            this.contratosToolStripMenuItem.Click += new System.EventHandler(this.ContratosToolStripMenuItem_Click_1);
            // 
            // departamentosToolStripMenuItem
            // 
            this.departamentosToolStripMenuItem.Name = "departamentosToolStripMenuItem";
            this.departamentosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.departamentosToolStripMenuItem.Text = "Departamentos";
            this.departamentosToolStripMenuItem.Click += new System.EventHandler(this.DepartamentosToolStripMenuItem_Click);
            // 
            // TipoVacanteStrip
            // 
            this.TipoVacanteStrip.Name = "TipoVacanteStrip";
            this.TipoVacanteStrip.Size = new System.Drawing.Size(180, 22);
            this.TipoVacanteStrip.Text = "Tipo de vacante ";
            this.TipoVacanteStrip.Click += new System.EventHandler(this.TipoDeVacanteToolStripMenuItem_Click);
            // 
            // LogOutStrip
            // 
            this.LogOutStrip.Name = "LogOutStrip";
            this.LogOutStrip.Size = new System.Drawing.Size(59, 20);
            this.LogOutStrip.Text = "LogOut";
            this.LogOutStrip.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
            // 
            // Permisolabel
            // 
            this.Permisolabel.AutoSize = true;
            this.Permisolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Permisolabel.Location = new System.Drawing.Point(489, 3);
            this.Permisolabel.Name = "Permisolabel";
            this.Permisolabel.Size = new System.Drawing.Size(51, 16);
            this.Permisolabel.TabIndex = 2;
            this.Permisolabel.Text = "label1";
            // 
            // VacantesStrio
            // 
            this.VacantesStrio.Name = "VacantesStrio";
            this.VacantesStrio.Size = new System.Drawing.Size(65, 20);
            this.VacantesStrio.Text = "Vacantes";
            this.VacantesStrio.Click += new System.EventHandler(this.VacantesStrio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 349);
            this.Controls.Add(this.Permisolabel);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Departamento de recursos humanos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem UsuarioStrip;
        private System.Windows.Forms.ToolStripMenuItem EmpleadosStrio;
        private System.Windows.Forms.ToolStripMenuItem ContratosStrip;
        private System.Windows.Forms.ToolStripMenuItem ConsultaStrio;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contratosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TipoVacanteStrip;
        private System.Windows.Forms.Label Permisolabel;
        private System.Windows.Forms.ToolStripMenuItem LogOutStrip;
        private System.Windows.Forms.ToolStripMenuItem VacantesStrio;
    }
}

