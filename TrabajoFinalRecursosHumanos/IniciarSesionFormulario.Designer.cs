namespace TrabajoFinalRecursosHumanos
{
    partial class IniciarSesionFormulario
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsuariotextBox = new System.Windows.Forms.TextBox();
            this.ClaveUsuarioTextBox = new System.Windows.Forms.TextBox();
            this.Cancelarbutton = new System.Windows.Forms.Button();
            this.IniciarSesionbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // UsuariotextBox
            // 
            this.UsuariotextBox.Location = new System.Drawing.Point(132, 34);
            this.UsuariotextBox.Multiline = true;
            this.UsuariotextBox.Name = "UsuariotextBox";
            this.UsuariotextBox.Size = new System.Drawing.Size(187, 33);
            this.UsuariotextBox.TabIndex = 2;
            // 
            // ClaveUsuarioTextBox
            // 
            this.ClaveUsuarioTextBox.Location = new System.Drawing.Point(132, 91);
            this.ClaveUsuarioTextBox.Multiline = true;
            this.ClaveUsuarioTextBox.Name = "ClaveUsuarioTextBox";
            this.ClaveUsuarioTextBox.Size = new System.Drawing.Size(187, 33);
            this.ClaveUsuarioTextBox.TabIndex = 3;
            // 
            // Cancelarbutton
            // 
            this.Cancelarbutton.Location = new System.Drawing.Point(132, 143);
            this.Cancelarbutton.Name = "Cancelarbutton";
            this.Cancelarbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelarbutton.TabIndex = 4;
            this.Cancelarbutton.Text = "Cancelar";
            this.Cancelarbutton.UseVisualStyleBackColor = true;
            this.Cancelarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // IniciarSesionbutton
            // 
            this.IniciarSesionbutton.Location = new System.Drawing.Point(227, 143);
            this.IniciarSesionbutton.Name = "IniciarSesionbutton";
            this.IniciarSesionbutton.Size = new System.Drawing.Size(92, 23);
            this.IniciarSesionbutton.TabIndex = 5;
            this.IniciarSesionbutton.Text = "Iniciar sesion";
            this.IniciarSesionbutton.UseVisualStyleBackColor = true;
            this.IniciarSesionbutton.Click += new System.EventHandler(this.IniciarSesionbutton_Click);
            // 
            // IniciarSesionFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(349, 196);
            this.Controls.Add(this.IniciarSesionbutton);
            this.Controls.Add(this.Cancelarbutton);
            this.Controls.Add(this.ClaveUsuarioTextBox);
            this.Controls.Add(this.UsuariotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IniciarSesionFormulario";
            this.Text = "Inicio de sesión ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IniciarSesionFormulario_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IniciarSesionFormulario_FormClosed);
            this.Load += new System.EventHandler(this.IniciarSesionFormulario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsuariotextBox;
        private System.Windows.Forms.TextBox ClaveUsuarioTextBox;
        private System.Windows.Forms.Button Cancelarbutton;
        private System.Windows.Forms.Button IniciarSesionbutton;
    }
}