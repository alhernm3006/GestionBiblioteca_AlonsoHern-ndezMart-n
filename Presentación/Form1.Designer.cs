namespace Presentación
{
    partial class Form1
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
            this.label_nombre = new System.Windows.Forms.Label();
            this.label_contraseña = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.textBox_contraseña = new System.Windows.Forms.TextBox();
            this.button_entrar = new System.Windows.Forms.Button();
            this.groupBox_tipoEmpleado = new System.Windows.Forms.GroupBox();
            this.radioButton_personalAdquisiciones = new System.Windows.Forms.RadioButton();
            this.radioButton_personalSala = new System.Windows.Forms.RadioButton();
            this.groupBox_tipoEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(188, 90);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(56, 16);
            this.label_nombre.TabIndex = 0;
            this.label_nombre.Text = "Nombre";
            // 
            // label_contraseña
            // 
            this.label_contraseña.AutoSize = true;
            this.label_contraseña.Location = new System.Drawing.Point(188, 155);
            this.label_contraseña.Name = "label_contraseña";
            this.label_contraseña.Size = new System.Drawing.Size(76, 16);
            this.label_contraseña.TabIndex = 1;
            this.label_contraseña.Text = "Contraseña";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(436, 83);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(100, 22);
            this.textBox_nombre.TabIndex = 2;
            // 
            // textBox_contraseña
            // 
            this.textBox_contraseña.Location = new System.Drawing.Point(436, 155);
            this.textBox_contraseña.Name = "textBox_contraseña";
            this.textBox_contraseña.PasswordChar = '*';
            this.textBox_contraseña.Size = new System.Drawing.Size(100, 22);
            this.textBox_contraseña.TabIndex = 3;
            // 
            // button_entrar
            // 
            this.button_entrar.Location = new System.Drawing.Point(436, 342);
            this.button_entrar.Name = "button_entrar";
            this.button_entrar.Size = new System.Drawing.Size(75, 23);
            this.button_entrar.TabIndex = 4;
            this.button_entrar.Text = "Entrar";
            this.button_entrar.UseVisualStyleBackColor = true;
            this.button_entrar.Click += new System.EventHandler(this.button_entrar_Click);
            // 
            // groupBox_tipoEmpleado
            // 
            this.groupBox_tipoEmpleado.Controls.Add(this.radioButton_personalAdquisiciones);
            this.groupBox_tipoEmpleado.Controls.Add(this.radioButton_personalSala);
            this.groupBox_tipoEmpleado.Location = new System.Drawing.Point(258, 219);
            this.groupBox_tipoEmpleado.Name = "groupBox_tipoEmpleado";
            this.groupBox_tipoEmpleado.Size = new System.Drawing.Size(200, 117);
            this.groupBox_tipoEmpleado.TabIndex = 5;
            this.groupBox_tipoEmpleado.TabStop = false;
            this.groupBox_tipoEmpleado.Text = "Tipo empleado";
            // 
            // radioButton_personalAdquisiciones
            // 
            this.radioButton_personalAdquisiciones.AutoSize = true;
            this.radioButton_personalAdquisiciones.Location = new System.Drawing.Point(22, 59);
            this.radioButton_personalAdquisiciones.Name = "radioButton_personalAdquisiciones";
            this.radioButton_personalAdquisiciones.Size = new System.Drawing.Size(169, 20);
            this.radioButton_personalAdquisiciones.TabIndex = 1;
            this.radioButton_personalAdquisiciones.TabStop = true;
            this.radioButton_personalAdquisiciones.Text = "Personal adquisiciones";
            this.radioButton_personalAdquisiciones.UseVisualStyleBackColor = true;
            // 
            // radioButton_personalSala
            // 
            this.radioButton_personalSala.AutoSize = true;
            this.radioButton_personalSala.Location = new System.Drawing.Point(22, 32);
            this.radioButton_personalSala.Name = "radioButton_personalSala";
            this.radioButton_personalSala.Size = new System.Drawing.Size(111, 20);
            this.radioButton_personalSala.TabIndex = 0;
            this.radioButton_personalSala.TabStop = true;
            this.radioButton_personalSala.Text = "Personal sala";
            this.radioButton_personalSala.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox_tipoEmpleado);
            this.Controls.Add(this.button_entrar);
            this.Controls.Add(this.textBox_contraseña);
            this.Controls.Add(this.textBox_nombre);
            this.Controls.Add(this.label_contraseña);
            this.Controls.Add(this.label_nombre);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_tipoEmpleado.ResumeLayout(false);
            this.groupBox_tipoEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Label label_contraseña;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.TextBox textBox_contraseña;
        private System.Windows.Forms.Button button_entrar;
        private System.Windows.Forms.GroupBox groupBox_tipoEmpleado;
        private System.Windows.Forms.RadioButton radioButton_personalAdquisiciones;
        private System.Windows.Forms.RadioButton radioButton_personalSala;
    }
}

