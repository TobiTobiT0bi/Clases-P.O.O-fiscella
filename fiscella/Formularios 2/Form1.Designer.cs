namespace Formularios_2
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
            this.agregaLeft = new System.Windows.Forms.Button();
            this.boxLeft = new System.Windows.Forms.ListBox();
            this.boxRight = new System.Windows.Forms.ListBox();
            this.agregaRight = new System.Windows.Forms.Button();
            this.allToLeft = new System.Windows.Forms.Button();
            this.toLeft = new System.Windows.Forms.Button();
            this.allToRight = new System.Windows.Forms.Button();
            this.toRight = new System.Windows.Forms.Button();
            this.textLeft = new System.Windows.Forms.TextBox();
            this.textRight = new System.Windows.Forms.TextBox();
            this.trashRight = new System.Windows.Forms.Button();
            this.trashLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // agregaLeft
            // 
            this.agregaLeft.Location = new System.Drawing.Point(12, 269);
            this.agregaLeft.Name = "agregaLeft";
            this.agregaLeft.Size = new System.Drawing.Size(173, 23);
            this.agregaLeft.TabIndex = 9;
            this.agregaLeft.Text = "agregar";
            this.agregaLeft.UseVisualStyleBackColor = true;
            this.agregaLeft.Click += new System.EventHandler(this.agregaLeft_Click);
            // 
            // boxLeft
            // 
            this.boxLeft.FormattingEnabled = true;
            this.boxLeft.Location = new System.Drawing.Point(12, 12);
            this.boxLeft.Name = "boxLeft";
            this.boxLeft.Size = new System.Drawing.Size(173, 225);
            this.boxLeft.TabIndex = 1;
            this.boxLeft.TabStop = false;
            // 
            // boxRight
            // 
            this.boxRight.FormattingEnabled = true;
            this.boxRight.Location = new System.Drawing.Point(293, 12);
            this.boxRight.Name = "boxRight";
            this.boxRight.Size = new System.Drawing.Size(173, 225);
            this.boxRight.TabIndex = 10;
            this.boxRight.TabStop = false;
            // 
            // agregaRight
            // 
            this.agregaRight.Location = new System.Drawing.Point(293, 269);
            this.agregaRight.Name = "agregaRight";
            this.agregaRight.Size = new System.Drawing.Size(173, 23);
            this.agregaRight.TabIndex = 11;
            this.agregaRight.Text = "agregar";
            this.agregaRight.UseVisualStyleBackColor = true;
            this.agregaRight.Click += new System.EventHandler(this.agregaRight_Click);
            // 
            // allToLeft
            // 
            this.allToLeft.Location = new System.Drawing.Point(191, 12);
            this.allToLeft.Name = "allToLeft";
            this.allToLeft.Size = new System.Drawing.Size(96, 37);
            this.allToLeft.TabIndex = 0;
            this.allToLeft.Text = "<<";
            this.allToLeft.UseVisualStyleBackColor = true;
            this.allToLeft.Click += new System.EventHandler(this.allToLeft_Click);
            // 
            // toLeft
            // 
            this.toLeft.Location = new System.Drawing.Point(191, 55);
            this.toLeft.Name = "toLeft";
            this.toLeft.Size = new System.Drawing.Size(96, 37);
            this.toLeft.TabIndex = 1;
            this.toLeft.Text = "<";
            this.toLeft.UseVisualStyleBackColor = true;
            this.toLeft.Click += new System.EventHandler(this.toLeft_Click);
            // 
            // allToRight
            // 
            this.allToRight.Location = new System.Drawing.Point(191, 200);
            this.allToRight.Name = "allToRight";
            this.allToRight.Size = new System.Drawing.Size(96, 37);
            this.allToRight.TabIndex = 3;
            this.allToRight.Text = ">>";
            this.allToRight.UseVisualStyleBackColor = true;
            this.allToRight.Click += new System.EventHandler(this.allToRight_Click);
            // 
            // toRight
            // 
            this.toRight.Location = new System.Drawing.Point(191, 157);
            this.toRight.Name = "toRight";
            this.toRight.Size = new System.Drawing.Size(96, 37);
            this.toRight.TabIndex = 2;
            this.toRight.Text = ">";
            this.toRight.UseVisualStyleBackColor = true;
            this.toRight.Click += new System.EventHandler(this.toRight_Click);
            // 
            // textLeft
            // 
            this.textLeft.Location = new System.Drawing.Point(12, 243);
            this.textLeft.Name = "textLeft";
            this.textLeft.Size = new System.Drawing.Size(173, 20);
            this.textLeft.TabIndex = 8;
            this.textLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLeft_KeyPress);
            // 
            // textRight
            // 
            this.textRight.Location = new System.Drawing.Point(293, 243);
            this.textRight.Name = "textRight";
            this.textRight.Size = new System.Drawing.Size(173, 20);
            this.textRight.TabIndex = 9;
            this.textRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textRight_KeyPress);
            // 
            // trashRight
            // 
            this.trashRight.Location = new System.Drawing.Point(441, 214);
            this.trashRight.Name = "trashRight";
            this.trashRight.Size = new System.Drawing.Size(25, 23);
            this.trashRight.TabIndex = 12;
            this.trashRight.Text = "🗑";
            this.trashRight.UseVisualStyleBackColor = true;
            this.trashRight.Click += new System.EventHandler(this.trashRight_Click);
            // 
            // trashLeft
            // 
            this.trashLeft.Location = new System.Drawing.Point(160, 214);
            this.trashLeft.Name = "trashLeft";
            this.trashLeft.Size = new System.Drawing.Size(25, 23);
            this.trashLeft.TabIndex = 13;
            this.trashLeft.Text = "🗑";
            this.trashLeft.UseVisualStyleBackColor = true;
            this.trashLeft.Click += new System.EventHandler(this.trashLeft_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 299);
            this.Controls.Add(this.trashLeft);
            this.Controls.Add(this.trashRight);
            this.Controls.Add(this.textRight);
            this.Controls.Add(this.textLeft);
            this.Controls.Add(this.toRight);
            this.Controls.Add(this.allToRight);
            this.Controls.Add(this.toLeft);
            this.Controls.Add(this.allToLeft);
            this.Controls.Add(this.boxRight);
            this.Controls.Add(this.agregaRight);
            this.Controls.Add(this.boxLeft);
            this.Controls.Add(this.agregaLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button agregaLeft;
        private System.Windows.Forms.ListBox boxLeft;
        private System.Windows.Forms.ListBox boxRight;
        private System.Windows.Forms.Button agregaRight;
        private System.Windows.Forms.Button allToLeft;
        private System.Windows.Forms.Button toLeft;
        private System.Windows.Forms.Button allToRight;
        private System.Windows.Forms.Button toRight;
        private System.Windows.Forms.TextBox textLeft;
        private System.Windows.Forms.TextBox textRight;
        private System.Windows.Forms.Button trashRight;
        private System.Windows.Forms.Button trashLeft;
    }
}

