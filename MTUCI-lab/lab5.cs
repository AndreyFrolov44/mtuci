using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using arrayLibrary;

namespace project
{
    public partial class lab5 : Form
    {
        private int num;
        private int[] unres_tasks = new int[16];
        private int[] res_tasks = new int[16];

        public lab5(int n, int[] un_tasks, int[] tasks) 
        {
            unres_tasks = un_tasks;
            res_tasks = tasks;
            num = n;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lab51 frm2 = new lab51(num, unres_tasks, res_tasks);
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("book.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lab52 frm3 = new lab52(num, unres_tasks, res_tasks);
            frm3.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lab53 frm4 = new lab53(num, unres_tasks, res_tasks);
            frm4.Show();
            this.Hide();
        }


        private void lab5_Load(object sender, EventArgs e)
        {
            progressBar1.Value = num;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lab54 frm5 = new lab54(num, unres_tasks, res_tasks);
            frm5.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lab55 frm6 = new lab55(num, unres_tasks, res_tasks);
            frm6.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lab56 frm7 = new lab56(num, unres_tasks, res_tasks);
            frm7.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lab57 frm8 = new lab57(num, unres_tasks, res_tasks);
            frm8.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lab58 frm9 = new lab58(num, unres_tasks, res_tasks);
            frm9.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lab59 frm10 = new lab59(num, unres_tasks, res_tasks);
            frm10.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            lab510 frm11 = new lab510(num, unres_tasks, res_tasks);
            frm11.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            lab511 frm12 = new lab511(num, unres_tasks, res_tasks);
            frm12.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            lab512 frm13 = new lab512(num, unres_tasks, res_tasks);
            frm13.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            lab513 frm14 = new lab513(num, unres_tasks, res_tasks);
            frm14.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            lab514 frm13 = new lab514(num, unres_tasks, res_tasks);
            frm13.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            lab516 frm14 = new lab516(num, unres_tasks, res_tasks);
            frm14.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lab515 frm15 = new lab515(num, unres_tasks, res_tasks);
            frm15.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Class1.Excel(16, 16, res_tasks, unres_tasks);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Class1.WordIsx(16, 16, res_tasks, unres_tasks);
        }
    }
}
