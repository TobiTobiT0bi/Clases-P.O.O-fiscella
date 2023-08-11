namespace editor_imagenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Imagen = new System.Windows.Forms.PictureBox();
            this.archivo = new System.Windows.Forms.OpenFileDialog();
            this.selectImages = new System.Windows.Forms.ToolStripButton();
            this.salir = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.historial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Imagen
            // 
            this.Imagen.Location = new System.Drawing.Point(190, 58);
            this.Imagen.Name = "Imagen";
            this.Imagen.Size = new System.Drawing.Size(355, 274);
            this.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Imagen.TabIndex = 0;
            this.Imagen.TabStop = false;
            // 
            // archivo
            // 
            this.archivo.FileName = "openFileDialog1";
            // 
            // selectImages
            // 
            this.selectImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectImages.Image = ((System.Drawing.Image)(resources.GetObject("selectImages.Image")));
            this.selectImages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectImages.Name = "selectImages";
            this.selectImages.Size = new System.Drawing.Size(23, 22);
            this.selectImages.Text = "toolStripButton1";
            this.selectImages.Click += new System.EventHandler(this.selectImages_Click);
            // 
            // salir
            // 
            this.salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.salir.Image = ((System.Drawing.Image)(resources.GetObject("salir.Image")));
            this.salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(23, 22);
            this.salir.Text = "toolStripButton2";
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salir,
            this.selectImages});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // historial
            // 
            this.historial.BackgroundImage = global::editor_imagenes.Properties.Resources.historial;
            this.historial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.historial.Location = new System.Drawing.Point(12, 58);
            this.historial.Name = "historial";
            this.historial.Size = new System.Drawing.Size(35, 36);
            this.historial.TabIndex = 2;
            this.historial.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.historial);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Imagen);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Imagen;
        private System.Windows.Forms.OpenFileDialog archivo;
        private System.Windows.Forms.ToolStripButton selectImages;
        private System.Windows.Forms.ToolStripButton salir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button historial;
    }
}

