namespace WindowsFormsApp1
{
    partial class Freserva
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
            this.calendarioReservas = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNomRes = new System.Windows.Forms.TextBox();
            this.tbApeRes = new System.Windows.Forms.TextBox();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCantHues = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantHues)).BeginInit();
            this.SuspendLayout();
            // 
            // calendarioReservas
            // 
            this.calendarioReservas.Location = new System.Drawing.Point(18, 18);
            this.calendarioReservas.Name = "calendarioReservas";
            this.calendarioReservas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del reservante";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido del reservante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "DNI";
            // 
            // tbNomRes
            // 
            this.tbNomRes.Location = new System.Drawing.Point(166, 224);
            this.tbNomRes.Name = "tbNomRes";
            this.tbNomRes.Size = new System.Drawing.Size(100, 20);
            this.tbNomRes.TabIndex = 4;
            // 
            // tbApeRes
            // 
            this.tbApeRes.Location = new System.Drawing.Point(166, 250);
            this.tbApeRes.Name = "tbApeRes";
            this.tbApeRes.Size = new System.Drawing.Size(100, 20);
            this.tbApeRes.TabIndex = 5;
            // 
            // tbDni
            // 
            this.tbDni.Location = new System.Drawing.Point(166, 285);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(100, 20);
            this.tbDni.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(18, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Agendar reserva";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(191, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cantidad de huespedes";
            // 
            // nudCantHues
            // 
            this.nudCantHues.Location = new System.Drawing.Point(166, 196);
            this.nudCantHues.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCantHues.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantHues.Name = "nudCantHues";
            this.nudCantHues.Size = new System.Drawing.Size(100, 20);
            this.nudCantHues.TabIndex = 11;
            this.nudCantHues.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Freserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 370);
            this.Controls.Add(this.nudCantHues);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbDni);
            this.Controls.Add(this.tbApeRes);
            this.Controls.Add(this.tbNomRes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calendarioReservas);
            this.Name = "Freserva";
            this.Text = "Freserva";
            this.Load += new System.EventHandler(this.Freserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantHues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.MonthCalendar calendarioReservas;
        public System.Windows.Forms.TextBox tbNomRes;
        public System.Windows.Forms.TextBox tbApeRes;
        public System.Windows.Forms.TextBox tbDni;
        public System.Windows.Forms.NumericUpDown nudCantHues;
    }
}