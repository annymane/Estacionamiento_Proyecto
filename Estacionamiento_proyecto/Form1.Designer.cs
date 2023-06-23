namespace Estacionamiento_proyecto
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbxCarrito = new System.Windows.Forms.PictureBox();
            this.pbxCarrito2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCarrito2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1238, 757);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbxCarrito
            // 
            this.pbxCarrito.Location = new System.Drawing.Point(12, 248);
            this.pbxCarrito.Name = "pbxCarrito";
            this.pbxCarrito.Size = new System.Drawing.Size(100, 69);
            this.pbxCarrito.TabIndex = 1;
            this.pbxCarrito.TabStop = false;
            // 
            // pbxCarrito2
            // 
            this.pbxCarrito2.Location = new System.Drawing.Point(13, 431);
            this.pbxCarrito2.Name = "pbxCarrito2";
            this.pbxCarrito2.Size = new System.Drawing.Size(100, 66);
            this.pbxCarrito2.TabIndex = 2;
            this.pbxCarrito2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 747);
            this.Controls.Add(this.pbxCarrito2);
            this.Controls.Add(this.pbxCarrito);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCarrito2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbxCarrito;
        private System.Windows.Forms.PictureBox pbxCarrito2;
    }
}

