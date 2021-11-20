using System;
using System.Windows.Forms;

namespace Conversion_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                private void Form1_Load(object sender, EventArgs e)
        {

        }
                private void E(object sender, EventArgs e)
        {

        }
                private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCurrency.Text = "Select A Currency ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbcurrency2.Text = "Select For Value ";           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {
            float exchangeRate = CurrencyConverter.GetExchangeRate(cmbCurrency.Text, cmbcurrency2.Text,float.Parse(inputcurr.Text));
            outputcurr.Text = exchangeRate.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void outputcurr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
