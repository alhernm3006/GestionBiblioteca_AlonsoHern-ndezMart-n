namespace Presentación
{
    partial class FormPrestamo
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
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_añadirEjemplar = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.label_fecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_usuario = new System.Windows.Forms.ComboBox();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.textBox_idprestamo = new System.Windows.Forms.TextBox();
            this.groupBox_ejemplares = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_ejemplares.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(280, 367);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 0;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(440, 366);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 1;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_añadirEjemplar
            // 
            this.button_añadirEjemplar.Location = new System.Drawing.Point(103, 276);
            this.button_añadirEjemplar.Name = "button_añadirEjemplar";
            this.button_añadirEjemplar.Size = new System.Drawing.Size(161, 23);
            this.button_añadirEjemplar.TabIndex = 2;
            this.button_añadirEjemplar.Text = "Añadir ejemplar";
            this.button_añadirEjemplar.UseVisualStyleBackColor = true;
            this.button_añadirEjemplar.Click += new System.EventHandler(this.button_añadirEjemplar_Click);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(118, 67);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(23, 16);
            this.label_id.TabIndex = 3;
            this.label_id.Text = "ID:";
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Location = new System.Drawing.Point(118, 104);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(48, 16);
            this.label_fecha.TabIndex = 4;
            this.label_fecha.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario:";
            // 
            // comboBox_usuario
            // 
            this.comboBox_usuario.FormattingEnabled = true;
            this.comboBox_usuario.Location = new System.Drawing.Point(220, 160);
            this.comboBox_usuario.Name = "comboBox_usuario";
            this.comboBox_usuario.Size = new System.Drawing.Size(121, 24);
            this.comboBox_usuario.TabIndex = 6;
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Location = new System.Drawing.Point(220, 97);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.ReadOnly = true;
            this.textBox_fecha.Size = new System.Drawing.Size(100, 22);
            this.textBox_fecha.TabIndex = 7;
            // 
            // textBox_idprestamo
            // 
            this.textBox_idprestamo.Location = new System.Drawing.Point(220, 60);
            this.textBox_idprestamo.Name = "textBox_idprestamo";
            this.textBox_idprestamo.Size = new System.Drawing.Size(100, 22);
            this.textBox_idprestamo.TabIndex = 8;
            // 
            // groupBox_ejemplares
            // 
            this.groupBox_ejemplares.Controls.Add(this.flowLayoutPanel1);
            this.groupBox_ejemplares.Location = new System.Drawing.Point(431, 67);
            this.groupBox_ejemplares.Name = "groupBox_ejemplares";
            this.groupBox_ejemplares.Size = new System.Drawing.Size(308, 181);
            this.groupBox_ejemplares.TabIndex = 9;
            this.groupBox_ejemplares.TabStop = false;
            this.groupBox_ejemplares.Text = "Ejemplares añadidos";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(302, 160);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // FormPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox_ejemplares);
            this.Controls.Add(this.textBox_idprestamo);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.comboBox_usuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_fecha);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.button_añadirEjemplar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Name = "FormPrestamo";
            this.Text = "FormPrestamo";
            this.groupBox_ejemplares.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_añadirEjemplar;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_usuario;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.TextBox textBox_idprestamo;
        private System.Windows.Forms.GroupBox groupBox_ejemplares;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}