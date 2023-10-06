namespace Examen_Formularios
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
            this.Ordenar = new System.Windows.Forms.Button();
            this.Borrar = new System.Windows.Forms.Button();
            this.intercambiar = new System.Windows.Forms.Button();
            this.FirstLast = new System.Windows.Forms.Button();
            this.NombresIzq = new System.Windows.Forms.ListBox();
            this.NombresDer = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Ordenar
            // 
            this.Ordenar.Location = new System.Drawing.Point(55, 370);
            this.Ordenar.Name = "Ordenar";
            this.Ordenar.Size = new System.Drawing.Size(75, 23);
            this.Ordenar.TabIndex = 0;
            this.Ordenar.Text = "Ordenar";
            this.Ordenar.UseVisualStyleBackColor = true;
            this.Ordenar.Click += new System.EventHandler(this.Ordenar_Click);
            // 
            // Borrar
            // 
            this.Borrar.Location = new System.Drawing.Point(185, 370);
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(75, 23);
            this.Borrar.TabIndex = 1;
            this.Borrar.Text = "Borrar";
            this.Borrar.UseVisualStyleBackColor = true;
            this.Borrar.Click += new System.EventHandler(this.Borrar_Click);
            // 
            // intercambiar
            // 
            this.intercambiar.Location = new System.Drawing.Point(533, 370);
            this.intercambiar.Name = "intercambiar";
            this.intercambiar.Size = new System.Drawing.Size(75, 23);
            this.intercambiar.TabIndex = 2;
            this.intercambiar.Text = "intercambiar";
            this.intercambiar.UseVisualStyleBackColor = true;
            this.intercambiar.Click += new System.EventHandler(this.intercambiar_Click);
            // 
            // FirstLast
            // 
            this.FirstLast.Location = new System.Drawing.Point(665, 370);
            this.FirstLast.Name = "FirstLast";
            this.FirstLast.Size = new System.Drawing.Size(79, 23);
            this.FirstLast.TabIndex = 3;
            this.FirstLast.Text = "1ro <-> ultimo";
            this.FirstLast.UseVisualStyleBackColor = true;
            this.FirstLast.Click += new System.EventHandler(this.FirstLast_Click);
            // 
            // NombresIzq
            // 
            this.NombresIzq.FormattingEnabled = true;
            this.NombresIzq.Location = new System.Drawing.Point(12, 12);
            this.NombresIzq.Name = "NombresIzq";
            this.NombresIzq.Size = new System.Drawing.Size(303, 316);
            this.NombresIzq.TabIndex = 4;
            // 
            // NombresDer
            // 
            this.NombresDer.FormattingEnabled = true;
            this.NombresDer.Location = new System.Drawing.Point(485, 12);
            this.NombresDer.Name = "NombresDer";
            this.NombresDer.Size = new System.Drawing.Size(303, 316);
            this.NombresDer.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NombresDer);
            this.Controls.Add(this.NombresIzq);
            this.Controls.Add(this.FirstLast);
            this.Controls.Add(this.intercambiar);
            this.Controls.Add(this.Borrar);
            this.Controls.Add(this.Ordenar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ordenar;
        private System.Windows.Forms.Button Borrar;
        private System.Windows.Forms.Button intercambiar;
        private System.Windows.Forms.Button FirstLast;
        private System.Windows.Forms.ListBox NombresIzq;
        private System.Windows.Forms.ListBox NombresDer;
    }
}

