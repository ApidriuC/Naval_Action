namespace Naval_Action
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Portada2 = new System.Windows.Forms.PictureBox();
            this.BotonJugar = new System.Windows.Forms.Button();
            this.BotonOpciones = new System.Windows.Forms.Button();
            this.BotonSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Portada2)).BeginInit();
            this.SuspendLayout();
            // 
            // Portada2
            // 
            this.Portada2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Portada2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Portada2.BackgroundImage = global::Naval_Action.Properties.Resources.BG;
            this.Portada2.Location = new System.Drawing.Point(0, 0);
            this.Portada2.Name = "Portada2";
            this.Portada2.Size = new System.Drawing.Size(1366, 768);
            this.Portada2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Portada2.TabIndex = 1;
            this.Portada2.TabStop = false;
            // 
            // BotonJugar
            // 
            this.BotonJugar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonJugar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BotonJugar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BotonJugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonJugar.Location = new System.Drawing.Point(300, 594);
            this.BotonJugar.Name = "BotonJugar";
            this.BotonJugar.Size = new System.Drawing.Size(200, 75);
            this.BotonJugar.TabIndex = 2;
            this.BotonJugar.Text = "JUGAR";
            this.BotonJugar.UseVisualStyleBackColor = true;
            this.BotonJugar.Click += new System.EventHandler(this.BotonJugar_Click);
            // 
            // BotonOpciones
            // 
            this.BotonOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonOpciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BotonOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BotonOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonOpciones.Location = new System.Drawing.Point(575, 594);
            this.BotonOpciones.Name = "BotonOpciones";
            this.BotonOpciones.Size = new System.Drawing.Size(200, 75);
            this.BotonOpciones.TabIndex = 3;
            this.BotonOpciones.Text = "OPCIONES";
            this.BotonOpciones.UseVisualStyleBackColor = true;
            this.BotonOpciones.Click += new System.EventHandler(this.BotonOpciones_Click);
            // 
            // BotonSalir
            // 
            this.BotonSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BotonSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BotonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonSalir.Location = new System.Drawing.Point(850, 594);
            this.BotonSalir.Name = "BotonSalir";
            this.BotonSalir.Size = new System.Drawing.Size(200, 75);
            this.BotonSalir.TabIndex = 4;
            this.BotonSalir.Text = "SALIR";
            this.BotonSalir.UseVisualStyleBackColor = true;
            this.BotonSalir.Click += new System.EventHandler(this.BotonSalir_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.BotonSalir);
            this.Controls.Add(this.BotonOpciones);
            this.Controls.Add(this.BotonJugar);
            this.Controls.Add(this.Portada2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naval Action";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Portada2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Portada2;
        private System.Windows.Forms.Button BotonJugar;
        private System.Windows.Forms.Button BotonOpciones;
        private System.Windows.Forms.Button BotonSalir;
    }
}