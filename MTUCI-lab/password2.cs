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
    public partial class password2 : Form
    {
        public password2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "1111")
                {
                    lab2 frm = new lab2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Неправильный пароль");
                }
            }
            catch
            {
                MessageBox.Show("Введите пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 close = new Form1();
            close.Show();
            this.Hide();
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)13))
                button1.Focus();
        }
    }
}
