namespace Presentación
{
    partial class FrmSolicitarDato
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
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.textBox_DNI = new System.Windows.Forms.TextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Location = new System.Drawing.Point(225, 147);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(49, 16);
            this.lblEtiqueta.TabIndex = 0;
            this.lblEtiqueta.Text = "funcion";
            // 
            // textBox_DNI
            // 
            this.textBox_DNI.Location = new System.Drawing.Point(394, 147);
            this.textBox_DNI.Name = "textBox_DNI";
            this.textBox_DNI.Size = new System.Drawing.Size(100, 22);
            this.textBox_DNI.TabIndex = 1;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(228, 261);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 2;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(394, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmSolicitarDato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.textBox_DNI);
            this.Controls.Add(this.lblEtiqueta);
            this.Name = "FrmSolicitarDato";
            this.Text = "FrmSolicitarDato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEtiqueta;
        private System.Windows.Forms.TextBox textBox_DNI;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button2;
    }
}