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
            this.archivo = new System.Windows.Forms.OpenFileDialog();
            this.archivos = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selectImages = new System.Windows.Forms.ToolStripButton();
            this.salir = new System.Windows.Forms.ToolStripButton();
            this.rotarIzquierda = new System.Windows.Forms.Button();
            this.rotarDerecha = new System.Windows.Forms.Button();
            this.historial = new System.Windows.Forms.Button();
            this.Imagen = new System.Windows.Forms.PictureBox();
            this.espejo = new System.Windows.Forms.Button();
            this.zoom = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // archivo
            // 
            this.archivo.FileName = "openFileDialog1";
            // 
            // archivos
            // 
            this.archivos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.archivos.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.archivos.FormattingEnabled = true;
            this.archivos.Location = new System.Drawing.Point(634, 11);
            this.archivos.Name = "archivos";
            this.archivos.Size = new System.Drawing.Size(396, 420);
            this.archivos.TabIndex = 3;
            this.archivos.SelectedIndexChanged += new System.EventHandler(this.archivos_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectImages,
            this.salir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 449);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selectImages
            // 
            this.selectImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectImages.Image = ((System.Drawing.Image)(resources.GetObject("selectImages.Image")));
            this.selectImages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectImages.Name = "selectImages";
            this.selectImages.Size = new System.Drawing.Size(21, 20);
            this.selectImages.Text = "toolStripButton1";
            this.selectImages.Click += new System.EventHandler(this.selectImages_Click);
            // 
            // salir
            // 
            this.salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.salir.Image = ((System.Drawing.Image)(resources.GetObject("salir.Image")));
            this.salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(21, 20);
            this.salir.Text = "toolStripButton2";
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // rotarIzquierda
            // 
            this.rotarIzquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.25F);
            this.rotarIzquierda.Location = new System.Drawing.Point(27, 12);
            this.rotarIzquierda.Name = "rotarIzquierda";
            this.rotarIzquierda.Size = new System.Drawing.Size(38, 36);
            this.rotarIzquierda.TabIndex = 5;
            this.rotarIzquierda.Text = "<";
            this.rotarIzquierda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rotarIzquierda.UseMnemonic = false;
            this.rotarIzquierda.UseVisualStyleBackColor = false;
            this.rotarIzquierda.Click += new System.EventHandler(this.rotarIzquierda_Click);
            // 
            // rotarDerecha
            // 
            this.rotarDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.25F);
            this.rotarDerecha.Image = global::editor_imagenes.Properties.Resources.right_arrow;
            this.rotarDerecha.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rotarDerecha.Location = new System.Drawing.Point(65, 12);
            this.rotarDerecha.Name = "rotarDerecha";
            this.rotarDerecha.Size = new System.Drawing.Size(38, 36);
            this.rotarDerecha.TabIndex = 4;
            this.rotarDerecha.Text = ">";
            this.rotarDerecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rotarDerecha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rotarDerecha.UseMnemonic = false;
            this.rotarDerecha.UseVisualStyleBackColor = false;
            this.rotarDerecha.Click += new System.EventHandler(this.rotarDerecha_Click);
            // 
            // historial
            // 
            this.historial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.historial.BackgroundImage = global::editor_imagenes.Properties.Resources.historial;
            this.historial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.historial.Location = new System.Drawing.Point(995, 11);
            this.historial.Name = "historial";
            this.historial.Size = new System.Drawing.Size(35, 36);
            this.historial.TabIndex = 2;
            this.historial.UseVisualStyleBackColor = true;
            this.historial.Click += new System.EventHandler(this.historial_Click);
            // 
            // Imagen
            // 
            this.Imagen.Location = new System.Drawing.Point(0, 0);
            this.Imagen.Name = "Imagen";
            this.Imagen.Size = new System.Drawing.Size(519, 425);
            this.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Imagen.TabIndex = 0;
            this.Imagen.TabStop = false;
            // 
            // espejo
            // 
            this.espejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.espejo.Image = global::editor_imagenes.Properties.Resources.right_arrow;
            this.espejo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.espejo.Location = new System.Drawing.Point(27, 54);
            this.espejo.Name = "espejo";
            this.espejo.Size = new System.Drawing.Size(38, 36);
            this.espejo.TabIndex = 6;
            this.espejo.Text = "↔";
            this.espejo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.espejo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.espejo.UseMnemonic = false;
            this.espejo.UseVisualStyleBackColor = false;
            this.espejo.Click += new System.EventHandler(this.espejo_Click);
            // 
            // zoom
            // 
            this.zoom.Location = new System.Drawing.Point(-1, 425);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(104, 45);
            this.zoom.TabIndex = 7;
            this.zoom.Scroll += new System.EventHandler(this.zoom_Scroll);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Imagen);
            this.panel1.Location = new System.Drawing.Point(109, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 425);
            this.panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1042, 449);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zoom);
            this.Controls.Add(this.espejo);
            this.Controls.Add(this.rotarIzquierda);
            this.Controls.Add(this.rotarDerecha);
            this.Controls.Add(this.historial);
            this.Controls.Add(this.archivos);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Imagen;
        private System.Windows.Forms.OpenFileDialog archivo;
        private System.Windows.Forms.Button historial;
        private System.Windows.Forms.ListBox archivos;
        private System.Windows.Forms.ToolStripButton selectImages;
        private System.Windows.Forms.ToolStripButton salir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button rotarDerecha;
        private System.Windows.Forms.Button rotarIzquierda;
        private System.Windows.Forms.Button espejo;
        private System.Windows.Forms.TrackBar zoom;
        private System.Windows.Forms.Panel panel1;
    }
}

