namespace Presentación
{
    partial class FormUsuario
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
            this.label_DNI = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_salir = new System.Windows.Forms.Button();
            this.textBox_DNI = new System.Windows.Forms.TextBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_DNI
            // 
            this.label_DNI.AutoSize = true;
            this.label_DNI.Location = new System.Drawing.Point(277, 102);
            this.label_DNI.Name = "label_DNI";
            this.label_DNI.Size = new System.Drawing.Size(33, 16);
            this.label_DNI.TabIndex = 0;
            this.label_DNI.Text = "DNI:";
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(277, 178);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(59, 16);
            this.label_nombre.TabIndex = 1;
            this.label_nombre.Text = "Nombre:";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(280, 268);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 2;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(451, 268);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(75, 23);
            this.button_salir.TabIndex = 3;
            this.button_salir.Text = "Cancelar";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // textBox_DNI
            // 
            this.textBox_DNI.Location = new System.Drawing.Point(442, 102);
            this.textBox_DNI.Name = "textBox_DNI";
            this.textBox_DNI.ReadOnly = true;
            this.textBox_DNI.Size = new System.Drawing.Size(100, 22);
            this.textBox_DNI.TabIndex = 4;
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(442, 172);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(100, 22);
            this.textBox_Nombre.TabIndex = 5;
            // 
            // FrmDetalleUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_Nombre);
            this.Controls.Add(this.textBox_DNI);
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.label_nombre);
            this.Controls.Add(this.label_DNI);
            this.Name = "FrmDetalleUsuario";
            this.Text = "FrmDetalleUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_DNI;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.TextBox textBox_DNI;
        private System.Windows.Forms.TextBox textBox_Nombre;
    }
}