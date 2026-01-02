namespace Presentación
{
    partial class AltaEjemplar
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
            this.label_codigo = new System.Windows.Forms.Label();
            this.label_documento = new System.Windows.Forms.Label();
            this.label_personañ = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.radioButton_prestado = new System.Windows.Forms.RadioButton();
            this.textBox_codigo = new System.Windows.Forms.TextBox();
            this.comboBox_documentos = new System.Windows.Forms.ComboBox();
            this.textBox1_personal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_codigo
            // 
            this.label_codigo.AutoSize = true;
            this.label_codigo.Location = new System.Drawing.Point(279, 118);
            this.label_codigo.Name = "label_codigo";
            this.label_codigo.Size = new System.Drawing.Size(51, 16);
            this.label_codigo.TabIndex = 0;
            this.label_codigo.Text = "Código";
            // 
            // label_documento
            // 
            this.label_documento.AutoSize = true;
            this.label_documento.Location = new System.Drawing.Point(278, 194);
            this.label_documento.Name = "label_documento";
            this.label_documento.Size = new System.Drawing.Size(107, 16);
            this.label_documento.TabIndex = 1;
            this.label_documento.Text = "Dcumento(ISBN)";
            // 
            // label_personañ
            // 
            this.label_personañ.AutoSize = true;
            this.label_personañ.Location = new System.Drawing.Point(282, 282);
            this.label_personañ.Name = "label_personañ";
            this.label_personañ.Size = new System.Drawing.Size(61, 16);
            this.label_personañ.TabIndex = 2;
            this.label_personañ.Text = "Personal";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(267, 382);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 3;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(438, 382);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 4;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // radioButton_prestado
            // 
            this.radioButton_prestado.AutoSize = true;
            this.radioButton_prestado.Location = new System.Drawing.Point(373, 328);
            this.radioButton_prestado.Name = "radioButton_prestado";
            this.radioButton_prestado.Size = new System.Drawing.Size(83, 20);
            this.radioButton_prestado.TabIndex = 5;
            this.radioButton_prestado.TabStop = true;
            this.radioButton_prestado.Text = "Prestado";
            this.radioButton_prestado.UseVisualStyleBackColor = true;
            // 
            // textBox_codigo
            // 
            this.textBox_codigo.Location = new System.Drawing.Point(477, 118);
            this.textBox_codigo.Name = "textBox_codigo";
            this.textBox_codigo.Size = new System.Drawing.Size(100, 22);
            this.textBox_codigo.TabIndex = 6;
            // 
            // comboBox_documentos
            // 
            this.comboBox_documentos.FormattingEnabled = true;
            this.comboBox_documentos.Location = new System.Drawing.Point(477, 194);
            this.comboBox_documentos.Name = "comboBox_documentos";
            this.comboBox_documentos.Size = new System.Drawing.Size(121, 24);
            this.comboBox_documentos.TabIndex = 7;
            // 
            // textBox1_personal
            // 
            this.textBox1_personal.Location = new System.Drawing.Point(477, 282);
            this.textBox1_personal.Name = "textBox1_personal";
            this.textBox1_personal.Size = new System.Drawing.Size(100, 22);
            this.textBox1_personal.TabIndex = 8;
            // 
            // AltaEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1_personal);
            this.Controls.Add(this.comboBox_documentos);
            this.Controls.Add(this.textBox_codigo);
            this.Controls.Add(this.radioButton_prestado);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.label_personañ);
            this.Controls.Add(this.label_documento);
            this.Controls.Add(this.label_codigo);
            this.Name = "AltaEjemplar";
            this.Text = "AltaEjemplar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_codigo;
        private System.Windows.Forms.Label label_documento;
        private System.Windows.Forms.Label label_personañ;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.RadioButton radioButton_prestado;
        private System.Windows.Forms.TextBox textBox_codigo;
        private System.Windows.Forms.ComboBox comboBox_documentos;
        private System.Windows.Forms.TextBox textBox1_personal;
    }
}