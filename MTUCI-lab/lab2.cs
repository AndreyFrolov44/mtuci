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
    public partial class lab2 : Form
    {
        public lab2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";

            try
            {
                double x = ClassLab2.Input(textBox1);
                double y = ClassLab2.Input(textBox2);

                double d = ClassLab2.CalcD(x, y);
                double z = ClassLab2.CalcZ(x, y);

                ClassLab2.Output(d, textBox3);
                ClassLab2.Output(z, textBox4);
            }
            catch
            {
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
                if (!(e.KeyChar.ToString() == "," && textBox1.Text.IndexOf(",") == -1) && !(e.KeyChar.ToString() == "-"))
                    e.Handled = true;
            if (e.KeyChar.Equals((char)13))
                button1.Focus();
        }
    }
}
