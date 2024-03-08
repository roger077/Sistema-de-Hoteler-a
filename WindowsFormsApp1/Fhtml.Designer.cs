namespace WindowsFormsApp1
{
    partial class Fhtml
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
            this.wbCasosUso = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbCasosUso
            // 
            this.wbCasosUso.Location = new System.Drawing.Point(12, 12);
            this.wbCasosUso.Name = "wbCasosUso";
            this.wbCasosUso.Size = new System.Drawing.Size(776, 426);
            this.wbCasosUso.TabIndex = 1;
            // 
            // Fhtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wbCasosUso);
            this.Name = "Fhtml";
            this.Text = "Fhtml";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser wbCasosUso;
    }
}