using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Falojamiento : Form
    {
        public Falojamiento()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rbHotel_CheckedChanged(object sender, EventArgs e)
        {
            gbHotel.Enabled = true;
            gbCasa.Enabled = false;
        }

        private void rbCasa_CheckedChanged(object sender, EventArgs e)
        {
            gbHotel.Enabled = false;
            gbCasa.Enabled = true;
        }

        private void rbCasaFinde_CheckedChanged(object sender, EventArgs e)
        {
            gbHotel.Enabled = false;
            gbCasa.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DNI_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tbApePropietario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbNomPropietario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //Este metodo sirve para evitar que se pongan mal las cantidades de huespedes
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = (string)cbTipo.SelectedItem;

            if (tipo == "simple")
            {
                nudMaxHues.Minimum = 1;
            }
            else if (tipo == "doble")
            {
                if (nudMaxHues.Value < 2)
                {
                    MessageBox.Show("Las habitaciones dobles tienen como minimo de huespedes dos personas");
                    nudMaxHues.Minimum = 2;
                }                       
            }
            else if (tipo == "triple")
            {
                if (nudMaxHues.Value < 3)
                {
                    MessageBox.Show("Las habitaciones triples tienen como minimo de huespedes tres personas");
                    nudMaxHues.Minimum = 3;
                }
            }
        }
    }
}
