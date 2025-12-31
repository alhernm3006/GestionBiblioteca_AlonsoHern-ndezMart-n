namespace Presentación
{
    partial class AltaDocumentos
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
            this.label_ISBN = new System.Windows.Forms.Label();
            this.label_titulo = new System.Windows.Forms.Label();
            this.label_autor = new System.Windows.Forms.Label();
            this.label_editorial = new System.Windows.Forms.Label();
            this.button_añadirEjemplar = new System.Windows.Forms.Button();
            this.button_darAlta = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.radioButton_Audiolibro = new System.Windows.Forms.RadioButton();
            this.radioButton_libro = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ISBN = new System.Windows.Forms.TextBox();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.textBox_autor = new System.Windows.Forms.TextBox();
            this.textBox_editorial = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ISBN
            // 
            this.label_ISBN.AutoSize = true;
            this.label_ISBN.Location = new System.Drawing.Point(154, 82);
            this.label_ISBN.Name = "label_ISBN";
            this.label_ISBN.Size = new System.Drawing.Size(41, 16);
            this.label_ISBN.TabIndex = 0;
            this.label_ISBN.Text = "ISBN:";
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Location = new System.Drawing.Point(154, 134);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(43, 16);
            this.label_titulo.TabIndex = 1;
            this.label_titulo.Text = "Título:";
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(154, 185);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(41, 16);
            this.label_autor.TabIndex = 2;
            this.label_autor.Text = "Autor:";
            // 
            // label_editorial
            // 
            this.label_editorial.AutoSize = true;
            this.label_editorial.Location = new System.Drawing.Point(154, 236);
            this.label_editorial.Name = "label_editorial";
            this.label_editorial.Size = new System.Drawing.Size(59, 16);
            this.label_editorial.TabIndex = 3;
            this.label_editorial.Text = "Editorial:";
            // 
            // button_añadirEjemplar
            // 
            this.button_añadirEjemplar.Location = new System.Drawing.Point(125, 413);
            this.button_añadirEjemplar.Name = "button_añadirEjemplar";
            this.button_añadirEjemplar.Size = new System.Drawing.Size(150, 23);
            this.button_añadirEjemplar.TabIndex = 4;
            this.button_añadirEjemplar.Text = "Añadir ejemplares";
            this.button_añadirEjemplar.UseVisualStyleBackColor = true;
            // 
            // button_darAlta
            // 
            this.button_darAlta.Location = new System.Drawing.Point(405, 413);
            this.button_darAlta.Name = "button_darAlta";
            this.button_darAlta.Size = new System.Drawing.Size(75, 23);
            this.button_darAlta.TabIndex = 5;
            this.button_darAlta.Text = "Dar alta";
            this.button_darAlta.UseVisualStyleBackColor = true;
            this.button_darAlta.Click += new System.EventHandler(this.button_darAlta_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(623, 413);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 6;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            // 
            // radioButton_Audiolibro
            // 
            this.radioButton_Audiolibro.AutoSize = true;
            this.radioButton_Audiolibro.Location = new System.Drawing.Point(16, 47);
            this.radioButton_Audiolibro.Name = "radioButton_Audiolibro";
            this.radioButton_Audiolibro.Size = new System.Drawing.Size(89, 20);
            this.radioButton_Audiolibro.TabIndex = 7;
            this.radioButton_Audiolibro.TabStop = true;
            this.radioButton_Audiolibro.Text = "Audiolibro";
            this.radioButton_Audiolibro.UseVisualStyleBackColor = true;
            // 
            // radioButton_libro
            // 
            this.radioButton_libro.AutoSize = true;
            this.radioButton_libro.Location = new System.Drawing.Point(16, 21);
            this.radioButton_libro.Name = "radioButton_libro";
            this.radioButton_libro.Size = new System.Drawing.Size(58, 20);
            this.radioButton_libro.TabIndex = 8;
            this.radioButton_libro.TabStop = true;
            this.radioButton_libro.Text = "Libro";
            this.radioButton_libro.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_libro);
            this.groupBox1.Controls.Add(this.radioButton_Audiolibro);
            this.groupBox1.Location = new System.Drawing.Point(280, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de documento";
            // 
            // textBox_ISBN
            // 
            this.textBox_ISBN.Location = new System.Drawing.Point(296, 82);
            this.textBox_ISBN.Name = "textBox_ISBN";
            this.textBox_ISBN.Size = new System.Drawing.Size(89, 22);
            this.textBox_ISBN.TabIndex = 10;
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Location = new System.Drawing.Point(296, 134);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(436, 22);
            this.textBox_titulo.TabIndex = 11;
            // 
            // textBox_autor
            // 
            this.textBox_autor.Location = new System.Drawing.Point(296, 185);
            this.textBox_autor.Name = "textBox_autor";
            this.textBox_autor.Size = new System.Drawing.Size(436, 22);
            this.textBox_autor.TabIndex = 12;
            // 
            // textBox_editorial
            // 
            this.textBox_editorial.Location = new System.Drawing.Point(296, 236);
            this.textBox_editorial.Name = "textBox_editorial";
            this.textBox_editorial.Size = new System.Drawing.Size(436, 22);
            this.textBox_editorial.TabIndex = 13;
            // 
            // AltaDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 478);
            this.Controls.Add(this.textBox_editorial);
            this.Controls.Add(this.textBox_autor);
            this.Controls.Add(this.textBox_titulo);
            this.Controls.Add(this.textBox_ISBN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_darAlta);
            this.Controls.Add(this.button_añadirEjemplar);
            this.Controls.Add(this.label_editorial);
            this.Controls.Add(this.label_autor);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.label_ISBN);
            this.Name = "AltaDocumentos";
            this.Text = "AltaDocumentos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ISBN;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.Label label_editorial;
        private System.Windows.Forms.Button button_añadirEjemplar;
        private System.Windows.Forms.Button button_darAlta;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.RadioButton radioButton_Audiolibro;
        private System.Windows.Forms.RadioButton radioButton_libro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_ISBN;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.TextBox textBox_autor;
        private System.Windows.Forms.TextBox textBox_editorial;
    }
}