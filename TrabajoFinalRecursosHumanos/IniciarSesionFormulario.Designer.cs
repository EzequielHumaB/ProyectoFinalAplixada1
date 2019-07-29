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
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Mostrarbutton = new System.Windows.Forms.Button();
            this.Encriptadolabel = new System.Windows.Forms.Label();
            this.Desencriptadolabel = new System.Windows.Forms.Label();
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
            // Guardarbutton
            // 
            this.Guardarbutton.Location = new System.Drawing.Point(40, 143);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(75, 23);
            this.Guardarbutton.TabIndex = 4;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Mostrarbutton
            // 
            this.Mostrarbutton.Location = new System.Drawing.Point(204, 143);
            this.Mostrarbutton.Name = "Mostrarbutton";
            this.Mostrarbutton.Size = new System.Drawing.Size(75, 23);
            this.Mostrarbutton.TabIndex = 5;
            this.Mostrarbutton.Text = "Mostrar";
            this.Mostrarbutton.UseVisualStyleBackColor = true;
            // 
            // Encriptadolabel
            // 
            this.Encriptadolabel.AutoSize = true;
            this.Encriptadolabel.Location = new System.Drawing.Point(49, 190);
            this.Encriptadolabel.Name = "Encriptadolabel";
            this.Encriptadolabel.Size = new System.Drawing.Size(35, 13);
            this.Encriptadolabel.TabIndex = 6;
            this.Encriptadolabel.Text = "label3";
            // 
            // Desencriptadolabel
            // 
            this.Desencriptadolabel.AutoSize = true;
            this.Desencriptadolabel.Location = new System.Drawing.Point(49, 237);
            this.Desencriptadolabel.Name = "Desencriptadolabel";
            this.Desencriptadolabel.Size = new System.Drawing.Size(35, 13);
            this.Desencriptadolabel.TabIndex = 7;
            this.Desencriptadolabel.Text = "label4";
            // 
            // IniciarSesionFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 308);
            this.Controls.Add(this.Desencriptadolabel);
            this.Controls.Add(this.Encriptadolabel);
            this.Controls.Add(this.Mostrarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.ClaveUsuarioTextBox);
            this.Controls.Add(this.UsuariotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IniciarSesionFormulario";
            this.Text = "IniciarSesionFormulario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsuariotextBox;
        private System.Windows.Forms.TextBox ClaveUsuarioTextBox;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Mostrarbutton;
        private System.Windows.Forms.Label Encriptadolabel;
        private System.Windows.Forms.Label Desencriptadolabel;
    }
}