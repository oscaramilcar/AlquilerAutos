namespace Views
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAutos = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alquilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alquilarVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolverVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosReservadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosDisponiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNombreUser = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.toolStripMenuItem1,
            this.alquilerToolStripMenuItem,
            this.consularToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEmpleado,
            this.MenuAutos,
            this.clientesToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // MenuEmpleado
            // 
            this.MenuEmpleado.Name = "MenuEmpleado";
            this.MenuEmpleado.Size = new System.Drawing.Size(180, 22);
            this.MenuEmpleado.Text = "Empleados";
            this.MenuEmpleado.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // MenuAutos
            // 
            this.MenuAutos.Name = "MenuAutos";
            this.MenuAutos.Size = new System.Drawing.Size(180, 22);
            this.MenuAutos.Text = "Autos";
            this.MenuAutos.Click += new System.EventHandler(this.MenuAutos_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // alquilerToolStripMenuItem
            // 
            this.alquilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alquilarVehiculoToolStripMenuItem,
            this.devolverVehiculoToolStripMenuItem});
            this.alquilerToolStripMenuItem.Name = "alquilerToolStripMenuItem";
            this.alquilerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.alquilerToolStripMenuItem.Text = "Alquiler";
            // 
            // alquilarVehiculoToolStripMenuItem
            // 
            this.alquilarVehiculoToolStripMenuItem.Name = "alquilarVehiculoToolStripMenuItem";
            this.alquilarVehiculoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alquilarVehiculoToolStripMenuItem.Text = "Alquilar vehiculo";
            this.alquilarVehiculoToolStripMenuItem.Click += new System.EventHandler(this.alquilarVehiculoToolStripMenuItem_Click);
            // 
            // devolverVehiculoToolStripMenuItem
            // 
            this.devolverVehiculoToolStripMenuItem.Name = "devolverVehiculoToolStripMenuItem";
            this.devolverVehiculoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.devolverVehiculoToolStripMenuItem.Text = "Devolver vehiculo";
            this.devolverVehiculoToolStripMenuItem.Click += new System.EventHandler(this.devolverVehiculoToolStripMenuItem_Click);
            // 
            // consularToolStripMenuItem
            // 
            this.consularToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehiculosReservadosToolStripMenuItem,
            this.vehiculosDisponiblesToolStripMenuItem});
            this.consularToolStripMenuItem.Name = "consularToolStripMenuItem";
            this.consularToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consularToolStripMenuItem.Text = "Consular";
            // 
            // vehiculosReservadosToolStripMenuItem
            // 
            this.vehiculosReservadosToolStripMenuItem.Name = "vehiculosReservadosToolStripMenuItem";
            this.vehiculosReservadosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.vehiculosReservadosToolStripMenuItem.Text = "vehiculos reservados";
            // 
            // vehiculosDisponiblesToolStripMenuItem
            // 
            this.vehiculosDisponiblesToolStripMenuItem.Name = "vehiculosDisponiblesToolStripMenuItem";
            this.vehiculosDisponiblesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.vehiculosDisponiblesToolStripMenuItem.Text = "vehiculos disponibles";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // lblNombreUser
            // 
            this.lblNombreUser.AutoSize = true;
            this.lblNombreUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUser.Location = new System.Drawing.Point(581, 9);
            this.lblNombreUser.Name = "lblNombreUser";
            this.lblNombreUser.Size = new System.Drawing.Size(51, 16);
            this.lblNombreUser.TabIndex = 4;
            this.lblNombreUser.Text = "label1";
            this.lblNombreUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.lblNombreUser);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEmpleado;
        private System.Windows.Forms.ToolStripMenuItem MenuAutos;
        private System.Windows.Forms.Label lblNombreUser;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alquilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alquilarVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devolverVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculosReservadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculosDisponiblesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
    }
}



