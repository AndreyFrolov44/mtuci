using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class lab1 : Form
    {
        public lab1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        public static double CalcD(double x, double y)
        {
            double d = Math.Log(y - Math.Sqrt(Math.Abs(x))) * (x - y / (x + Math.Pow(x, 2) / 4));
            return Math.Round(d, 3, MidpointRounding.AwayFromZero);
        }

        public static double CalcZ(double x, double y)
        {
            double z = Math.Pow(1 - Math.Tan(x), Math.Tan(x)) + Math.Cos(x - y);
            return Math.Round(z, 3, MidpointRounding.AwayFromZero);
        }

        double Input(TextBox t)
        {
            return Convert.ToDouble(t.Text);
        }

        void Output(double x, TextBox t)
        {
            t.Text = Convert.ToString(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            try
            {
                double x = Input(textBox1);
                double y = Input(textBox2);

                double d = CalcD(x, y);
                double z = CalcZ(x, y);

                Output(d, textBox3);
                Output(z, textBox4);
            }
            catch
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Ошибка");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
                if (!(e.KeyChar.ToString() == "," && textBox1.Text.IndexOf(",") == -1) && !(e.KeyChar.ToString() == "-"))
                    e.Handled = true;
            if (e.KeyChar.Equals((char)13))
                textBox2.Focus();
        
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
                if (!(e.KeyChar.ToString() == "," && textBox2.Text.IndexOf(",") == -1) && !(e.KeyChar.ToString() == "-"))
                    e.Handled = true;
            if (e.KeyChar.Equals((char)13))
                button1.Focus();
        }
    }
}
