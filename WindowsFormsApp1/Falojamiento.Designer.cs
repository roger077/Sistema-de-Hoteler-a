namespace WindowsFormsApp1
{
    partial class Falojamiento
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
            this.rbCasa = new System.Windows.Forms.RadioButton();
            this.rbHotel = new System.Windows.Forms.RadioButton();
            this.rbCasaFinde = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.tbPrecioBase = new System.Windows.Forms.TextBox();
            this.gbHotel = new System.Windows.Forms.GroupBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.nudNroHab = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudEstrellas = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNombreHotel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbCochera = new System.Windows.Forms.CheckBox();
            this.chbAc = new System.Windows.Forms.CheckBox();
            this.chbWifi = new System.Windows.Forms.CheckBox();
            this.chbPiscina = new System.Windows.Forms.CheckBox();
            this.chbDesayuno = new System.Windows.Forms.CheckBox();
            this.nudMaxHues = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.gbCasa = new System.Windows.Forms.GroupBox();
            this.nudMinimoDias = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNomPropietario = new System.Windows.Forms.TextBox();
            this.tbApePropietario = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.Label();
            this.tbDniPropietario = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCiudad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroHab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstrellas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxHues)).BeginInit();
            this.gbCasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimoDias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbCasa
            // 
            this.rbCasa.AutoSize = true;
            this.rbCasa.Location = new System.Drawing.Point(31, 13);
            this.rbCasa.Name = "rbCasa";
            this.rbCasa.Size = new System.Drawing.Size(49, 17);
            this.rbCasa.TabIndex = 0;
            this.rbCasa.TabStop = true;
            this.rbCasa.Text = "Casa";
            this.rbCasa.UseVisualStyleBackColor = true;
            this.rbCasa.CheckedChanged += new System.EventHandler(this.rbCasa_CheckedChanged);
            // 
            // rbHotel
            // 
            this.rbHotel.AutoSize = true;
            this.rbHotel.Location = new System.Drawing.Point(31, 36);
            this.rbHotel.Name = "rbHotel";
            this.rbHotel.Size = new System.Drawing.Size(50, 17);
            this.rbHotel.TabIndex = 1;
            this.rbHotel.TabStop = true;
            this.rbHotel.Text = "Hotel";
            this.rbHotel.UseVisualStyleBackColor = true;
            this.rbHotel.CheckedChanged += new System.EventHandler(this.rbHotel_CheckedChanged);
            // 
            // rbCasaFinde
            // 
            this.rbCasaFinde.AutoSize = true;
            this.rbCasaFinde.Location = new System.Drawing.Point(31, 56);
            this.rbCasaFinde.Name = "rbCasaFinde";
            this.rbCasaFinde.Size = new System.Drawing.Size(118, 17);
            this.rbCasaFinde.TabIndex = 2;
            this.rbCasaFinde.TabStop = true;
            this.rbCasaFinde.Text = "Casa fin de semana";
            this.rbCasaFinde.UseVisualStyleBackColor = true;
            this.rbCasaFinde.CheckedChanged += new System.EventHandler(this.rbCasaFinde_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dirección";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precio base";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(119, 119);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(100, 20);
            this.tbDireccion.TabIndex = 5;
            // 
            // tbPrecioBase
            // 
            this.tbPrecioBase.Location = new System.Drawing.Point(119, 148);
            this.tbPrecioBase.Name = "tbPrecioBase";
            this.tbPrecioBase.Size = new System.Drawing.Size(100, 20);
            this.tbPrecioBase.TabIndex = 6;
            // 
            // gbHotel
            // 
            this.gbHotel.Controls.Add(this.cbTipo);
            this.gbHotel.Controls.Add(this.nudNroHab);
            this.gbHotel.Controls.Add(this.label6);
            this.gbHotel.Controls.Add(this.nudEstrellas);
            this.gbHotel.Controls.Add(this.label5);
            this.gbHotel.Controls.Add(this.tbNombreHotel);
            this.gbHotel.Controls.Add(this.label4);
            this.gbHotel.Controls.Add(this.label3);
            this.gbHotel.Enabled = false;
            this.gbHotel.Location = new System.Drawing.Point(22, 205);
            this.gbHotel.Name = "gbHotel";
            this.gbHotel.Size = new System.Drawing.Size(230, 153);
            this.gbHotel.TabIndex = 7;
            this.gbHotel.TabStop = false;
            this.gbHotel.Text = "Habitación de hotel";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "simple",
            "doble",
            "triple"});
            this.cbTipo.Location = new System.Drawing.Point(100, 90);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(100, 21);
            this.cbTipo.TabIndex = 17;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // nudNroHab
            // 
            this.nudNroHab.Location = new System.Drawing.Point(100, 122);
            this.nudNroHab.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudNroHab.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNroHab.Name = "nudNroHab";
            this.nudNroHab.Size = new System.Drawing.Size(100, 20);
            this.nudNroHab.TabIndex = 16;
            this.nudNroHab.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nro Habitación";
            // 
            // nudEstrellas
            // 
            this.nudEstrellas.Location = new System.Drawing.Point(100, 31);
            this.nudEstrellas.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudEstrellas.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudEstrellas.Name = "nudEstrellas";
            this.nudEstrellas.Size = new System.Drawing.Size(100, 20);
            this.nudEstrellas.TabIndex = 14;
            this.nudEstrellas.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo";
            // 
            // tbNombreHotel
            // 
            this.tbNombreHotel.Location = new System.Drawing.Point(100, 64);
            this.tbNombreHotel.Name = "tbNombreHotel";
            this.tbNombreHotel.Size = new System.Drawing.Size(100, 20);
            this.tbNombreHotel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Estrellas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre del hotel";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(22, 551);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(177, 551);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbCochera);
            this.groupBox2.Controls.Add(this.chbAc);
            this.groupBox2.Controls.Add(this.chbWifi);
            this.groupBox2.Controls.Add(this.chbPiscina);
            this.groupBox2.Controls.Add(this.chbDesayuno);
            this.groupBox2.Location = new System.Drawing.Point(22, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 135);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servicios";
            // 
            // chbCochera
            // 
            this.chbCochera.AutoSize = true;
            this.chbCochera.Location = new System.Drawing.Point(12, 111);
            this.chbCochera.Name = "chbCochera";
            this.chbCochera.Size = new System.Drawing.Size(66, 17);
            this.chbCochera.TabIndex = 24;
            this.chbCochera.Text = "Cochera";
            this.chbCochera.UseVisualStyleBackColor = true;
            // 
            // chbAc
            // 
            this.chbAc.AutoSize = true;
            this.chbAc.Location = new System.Drawing.Point(12, 88);
            this.chbAc.Name = "chbAc";
            this.chbAc.Size = new System.Drawing.Size(117, 17);
            this.chbAc.TabIndex = 23;
            this.chbAc.Text = "Aire acondicionado";
            this.chbAc.UseVisualStyleBackColor = true;
            // 
            // chbWifi
            // 
            this.chbWifi.AutoSize = true;
            this.chbWifi.Location = new System.Drawing.Point(12, 65);
            this.chbWifi.Name = "chbWifi";
            this.chbWifi.Size = new System.Drawing.Size(50, 17);
            this.chbWifi.TabIndex = 22;
            this.chbWifi.Text = "Wi-Fi";
            this.chbWifi.UseVisualStyleBackColor = true;
            // 
            // chbPiscina
            // 
            this.chbPiscina.AutoSize = true;
            this.chbPiscina.Location = new System.Drawing.Point(12, 41);
            this.chbPiscina.Name = "chbPiscina";
            this.chbPiscina.Size = new System.Drawing.Size(60, 17);
            this.chbPiscina.TabIndex = 21;
            this.chbPiscina.Text = "Piscina";
            this.chbPiscina.UseVisualStyleBackColor = true;
            // 
            // chbDesayuno
            // 
            this.chbDesayuno.AutoSize = true;
            this.chbDesayuno.Location = new System.Drawing.Point(12, 19);
            this.chbDesayuno.Name = "chbDesayuno";
            this.chbDesayuno.Size = new System.Drawing.Size(74, 17);
            this.chbDesayuno.TabIndex = 20;
            this.chbDesayuno.Text = "Desayuno";
            this.chbDesayuno.UseVisualStyleBackColor = true;
            // 
            // nudMaxHues
            // 
            this.nudMaxHues.Location = new System.Drawing.Point(138, 179);
            this.nudMaxHues.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMaxHues.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxHues.Name = "nudMaxHues";
            this.nudMaxHues.Size = new System.Drawing.Size(81, 20);
            this.nudMaxHues.TabIndex = 22;
            this.nudMaxHues.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Limite de huespedes";
            // 
            // gbCasa
            // 
            this.gbCasa.Controls.Add(this.nudMinimoDias);
            this.gbCasa.Controls.Add(this.label8);
            this.gbCasa.Enabled = false;
            this.gbCasa.Location = new System.Drawing.Point(22, 364);
            this.gbCasa.Name = "gbCasa";
            this.gbCasa.Size = new System.Drawing.Size(230, 40);
            this.gbCasa.TabIndex = 23;
            this.gbCasa.TabStop = false;
            this.gbCasa.Text = "Casa";
            // 
            // nudMinimoDias
            // 
            this.nudMinimoDias.Location = new System.Drawing.Point(100, 14);
            this.nudMinimoDias.Name = "nudMinimoDias";
            this.nudMinimoDias.Size = new System.Drawing.Size(100, 20);
            this.nudMinimoDias.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Minimo de días:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Nombre";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tbNomPropietario
            // 
            this.tbNomPropietario.Location = new System.Drawing.Point(78, 22);
            this.tbNomPropietario.Name = "tbNomPropietario";
            this.tbNomPropietario.Size = new System.Drawing.Size(100, 20);
            this.tbNomPropietario.TabIndex = 25;
            this.tbNomPropietario.TextChanged += new System.EventHandler(this.tbNomPropietario_TextChanged);
            // 
            // tbApePropietario
            // 
            this.tbApePropietario.Location = new System.Drawing.Point(78, 63);
            this.tbApePropietario.Name = "tbApePropietario";
            this.tbApePropietario.Size = new System.Drawing.Size(100, 20);
            this.tbApePropietario.TabIndex = 26;
            this.tbApePropietario.TextChanged += new System.EventHandler(this.tbApePropietario_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Apellido";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.Location = new System.Drawing.Point(28, 98);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(26, 13);
            this.DNI.TabIndex = 28;
            this.DNI.Text = "DNI";
            this.DNI.Click += new System.EventHandler(this.DNI_Click);
            // 
            // tbDniPropietario
            // 
            this.tbDniPropietario.Location = new System.Drawing.Point(78, 95);
            this.tbDniPropietario.Name = "tbDniPropietario";
            this.tbDniPropietario.Size = new System.Drawing.Size(100, 20);
            this.tbDniPropietario.TabIndex = 29;
            this.tbDniPropietario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbApePropietario);
            this.groupBox1.Controls.Add(this.tbDniPropietario);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Controls.Add(this.tbNomPropietario);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(267, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 131);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Propietario";
            // 
            // tbCiudad
            // 
            this.tbCiudad.Location = new System.Drawing.Point(119, 90);
            this.tbCiudad.Name = "tbCiudad";
            this.tbCiudad.Size = new System.Drawing.Size(100, 20);
            this.tbCiudad.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Ciudad";
            // 
            // Falojamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 619);
            this.Controls.Add(this.tbCiudad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbCasa);
            this.Controls.Add(this.nudMaxHues);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbHotel);
            this.Controls.Add(this.tbPrecioBase);
            this.Controls.Add(this.tbDireccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbCasaFinde);
            this.Controls.Add(this.rbHotel);
            this.Controls.Add(this.rbCasa);
            this.Name = "Falojamiento";
            this.Text = "Falojamiento";
            this.gbHotel.ResumeLayout(false);
            this.gbHotel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroHab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstrellas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxHues)).EndInit();
            this.gbCasa.ResumeLayout(false);
            this.gbCasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimoDias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbHotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.RadioButton rbCasa;
        public System.Windows.Forms.RadioButton rbHotel;
        public System.Windows.Forms.RadioButton rbCasaFinde;
        public System.Windows.Forms.TextBox tbDireccion;
        public System.Windows.Forms.TextBox tbPrecioBase;
        public System.Windows.Forms.TextBox tbNombreHotel;
        public System.Windows.Forms.NumericUpDown nudEstrellas;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.NumericUpDown nudNroHab;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown nudMaxHues;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbCasa;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown nudMinimoDias;
        public System.Windows.Forms.CheckBox chbPiscina;
        public System.Windows.Forms.CheckBox chbDesayuno;
        public System.Windows.Forms.CheckBox chbCochera;
        public System.Windows.Forms.CheckBox chbAc;
        public System.Windows.Forms.CheckBox chbWifi;
        public System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label DNI;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox tbNomPropietario;
        public System.Windows.Forms.TextBox tbApePropietario;
        public System.Windows.Forms.TextBox tbDniPropietario;
        public System.Windows.Forms.TextBox tbCiudad;
        private System.Windows.Forms.Label label11;
    }
}