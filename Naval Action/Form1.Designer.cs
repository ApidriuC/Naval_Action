namespace Naval_Action
{
    partial class NavalAction1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavalAction1));
            this.Portada = new System.Windows.Forms.PictureBox();
            this.BotonBienvenida = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Portada)).BeginInit();
            this.SuspendLayout();
            // 
            // Portada
            // 
            this.Portada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Portada.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Portada.BackgroundImage = global::Naval_Action.Properties.Resources.BG;
            this.Portada.Location = new System.Drawing.Point(0, 0);
            this.Portada.Name = "Portada";
            this.Portada.Size = new System.Drawing.Size(1366, 772);
            this.Portada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Portada.TabIndex = 0;
            this.Portada.TabStop = false;
            // 
            // BotonBienvenida
            // 
            this.BotonBienvenida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonBienvenida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BotonBienvenida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BotonBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonBienvenida.Location = new System.Drawing.Point(600, 330);
            this.BotonBienvenida.Name = "BotonBienvenida";
            this.BotonBienvenida.Size = new System.Drawing.Size(200, 79);
            this.BotonBienvenida.TabIndex = 1;
            this.BotonBienvenida.Text = "JUGAR";
            this.BotonBienvenida.UseVisualStyleBackColor = true;
            this.BotonBienvenida.Click += new System.EventHandler(this.button1_Click);
            // 
            // NavalAction1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.BotonBienvenida);
            this.Controls.Add(this.Portada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "NavalAction1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naval Action";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NavalAction1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.Portada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Portada;
        private System.Windows.Forms.Button BotonBienvenida;
    }
}

