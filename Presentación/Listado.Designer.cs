namespace Presentación
{
    partial class Listado
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
            this.button_dni = new System.Windows.Forms.Button();
            this.button_nombre = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox_dni = new System.Windows.Forms.ListBox();
            this.listBox_nombre = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_dni
            // 
            this.button_dni.Location = new System.Drawing.Point(239, 70);
            this.button_dni.Name = "button_dni";
            this.button_dni.Size = new System.Drawing.Size(75, 23);
            this.button_dni.TabIndex = 0;
            this.button_dni.Text = "DNI";
            this.button_dni.UseVisualStyleBackColor = true;
            this.button_dni.Click += new System.EventHandler(this.button_dni_Click);
            // 
            // button_nombre
            // 
            this.button_nombre.Location = new System.Drawing.Point(486, 70);
            this.button_nombre.Name = "button_nombre";
            this.button_nombre.Size = new System.Drawing.Size(75, 23);
            this.button_nombre.TabIndex = 1;
            this.button_nombre.Text = "Nombre";
            this.button_nombre.UseVisualStyleBackColor = true;
            this.button_nombre.Click += new System.EventHandler(this.button_nombre_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(369, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox_dni
            // 
            this.listBox_dni.FormattingEnabled = true;
            this.listBox_dni.ItemHeight = 16;
            this.listBox_dni.Location = new System.Drawing.Point(222, 122);
            this.listBox_dni.Name = "listBox_dni";
            this.listBox_dni.Size = new System.Drawing.Size(120, 196);
            this.listBox_dni.TabIndex = 3;
            this.listBox_dni.SelectedIndexChanged += new System.EventHandler(this.listBox_dni_SelectedIndexChanged);
            // 
            // listBox_nombre
            // 
            this.listBox_nombre.FormattingEnabled = true;
            this.listBox_nombre.ItemHeight = 16;
            this.listBox_nombre.Location = new System.Drawing.Point(474, 122);
            this.listBox_nombre.Name = "listBox_nombre";
            this.listBox_nombre.Size = new System.Drawing.Size(120, 196);
            this.listBox_nombre.TabIndex = 4;
            this.listBox_nombre.SelectedIndexChanged += new System.EventHandler(this.listBox_nombre_SelectedIndexChanged);
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox_nombre);
            this.Controls.Add(this.listBox_dni);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_nombre);
            this.Controls.Add(this.button_dni);
            this.Name = "Listado";
            this.Text = "Listado";
            this.Load += new System.EventHandler(this.Listado_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_dni;
        private System.Windows.Forms.Button button_nombre;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox_dni;
        private System.Windows.Forms.ListBox listBox_nombre;
    }
}