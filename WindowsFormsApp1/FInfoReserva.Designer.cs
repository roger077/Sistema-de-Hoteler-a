namespace WindowsFormsApp1
{
    partial class FInfoReserva
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblIncio = new System.Windows.Forms.Label();
            this.lblPrecioPorDia = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCantDias = new System.Windows.Forms.Label();
            this.lblCantPersonas = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.btnModificar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nudCantDias = new System.Windows.Forms.NumericUpDown();
            this.nudCantPersonas = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fin:";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(91, 58);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(35, 13);
            this.lblFin.TabIndex = 2;
            this.lblFin.Text = "--/--/--";
            // 
            // lblIncio
            // 
            this.lblIncio.AutoSize = true;
            this.lblIncio.Location = new System.Drawing.Point(91, 36);
            this.lblIncio.Name = "lblIncio";
            this.lblIncio.Size = new System.Drawing.Size(35, 13);
            this.lblIncio.TabIndex = 3;
            this.lblIncio.Text = "--/--/--";
            // 
            // lblPrecioPorDia
            // 
            this.lblPrecioPorDia.AutoSize = true;
            this.lblPrecioPorDia.Location = new System.Drawing.Point(35, 80);
            this.lblPrecioPorDia.Name = "lblPrecioPorDia";
            this.lblPrecioPorDia.Size = new System.Drawing.Size(75, 13);
            this.lblPrecioPorDia.TabIndex = 4;
            this.lblPrecioPorDia.Text = "Precio por dia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "$";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(135, 80);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(10, 13);
            this.lblPrecio.TabIndex = 6;
            this.lblPrecio.Text = "-";
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Location = new System.Drawing.Point(135, 102);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(10, 13);
            this.lblPrecioTotal.TabIndex = 9;
            this.lblPrecioTotal.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Precio Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(83, 124);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(10, 13);
            this.lblCliente.TabIndex = 11;
            this.lblCliente.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "DNI:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(67, 147);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(10, 13);
            this.lblDni.TabIndex = 13;
            this.lblDni.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cantidad de días:";
            // 
            // lblCantDias
            // 
            this.lblCantDias.AutoSize = true;
            this.lblCantDias.Location = new System.Drawing.Point(141, 170);
            this.lblCantDias.Name = "lblCantDias";
            this.lblCantDias.Size = new System.Drawing.Size(10, 13);
            this.lblCantDias.TabIndex = 15;
            this.lblCantDias.Text = "-";
            // 
            // lblCantPersonas
            // 
            this.lblCantPersonas.AutoSize = true;
            this.lblCantPersonas.Location = new System.Drawing.Point(166, 194);
            this.lblCantPersonas.Name = "lblCantPersonas";
            this.lblCantPersonas.Size = new System.Drawing.Size(10, 13);
            this.lblCantPersonas.TabIndex = 17;
            this.lblCantPersonas.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Cantidad de presonas:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(182, 32);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpInicio.TabIndex = 18;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(182, 58);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 19;
            // 
            // btnModificar
            // 
            this.btnModificar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnModificar.Location = new System.Drawing.Point(38, 223);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(307, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // nudCantDias
            // 
            this.nudCantDias.Location = new System.Drawing.Point(182, 163);
            this.nudCantDias.Name = "nudCantDias";
            this.nudCantDias.Size = new System.Drawing.Size(120, 20);
            this.nudCantDias.TabIndex = 24;
            this.nudCantDias.Visible = false;
            // 
            // nudCantPersonas
            // 
            this.nudCantPersonas.Location = new System.Drawing.Point(215, 192);
            this.nudCantPersonas.Name = "nudCantPersonas";
            this.nudCantPersonas.Size = new System.Drawing.Size(120, 20);
            this.nudCantPersonas.TabIndex = 25;
            this.nudCantPersonas.Visible = false;
            // 
            // FInfoReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 258);
            this.Controls.Add(this.nudCantPersonas);
            this.Controls.Add(this.nudCantDias);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.lblCantPersonas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCantDias);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPrecioPorDia);
            this.Controls.Add(this.lblIncio);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FInfoReserva";
            this.Text = "FInfoReserva";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrecioPorDia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DateTimePicker dtpInicio;
        public System.Windows.Forms.DateTimePicker dtpFin;
        public System.Windows.Forms.Label lblFin;
        public System.Windows.Forms.Label lblIncio;
        public System.Windows.Forms.Label lblCantDias;
        public System.Windows.Forms.Label lblCantPersonas;
        public System.Windows.Forms.Label lblPrecio;
        public System.Windows.Forms.Label lblPrecioTotal;
        public System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.Label lblDni;
        public System.Windows.Forms.NumericUpDown nudCantDias;
        public System.Windows.Forms.NumericUpDown nudCantPersonas;
    }
}