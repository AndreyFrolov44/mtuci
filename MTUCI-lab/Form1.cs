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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password pw = new password();
            pw.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            password2 pw2 = new password2();
            pw2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lab3 frm3 = new lab3();
            frm3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lab4 frm4 = new lab4();
            frm4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] unres_tasks = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[] res_tasks = new int[16];
            lab5 frm5 = new lab5(0, unres_tasks, res_tasks);
            frm5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lab6 frm6 = new lab6();
            frm6.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lab61 frm61 = new lab61();
            frm61.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lab8 frm8 = new lab8();
            frm8.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lab90 frm9 = new lab90();
            frm9.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lab10 frm10 = new lab10();
            frm10.Show();
            this.Hide();
        }
    }
}
