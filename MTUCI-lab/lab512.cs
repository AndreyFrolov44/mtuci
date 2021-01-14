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
    public partial class lab512 : Form
    {
        private int num;
        private int[] unres_tasks = new int[16];
        private int[] res_tasks = new int[16];

        public lab512(int n, int[] un_tasks, int[] tasks)
        {
            unres_tasks = un_tasks;
            res_tasks = tasks;
            num = n;
            InitializeComponent();
        }

        private void lab512_Load(object sender, EventArgs e)
        {
            progressBar1.Value = num;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string current = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(current);
            listBox4.Items.Add(current);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string current = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(current);
            listBox2.Items.Add(current);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string current = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(current);
            listBox3.Items.Add(current);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.FindString("GET") >= 0 && listBox3.FindString("POST") >= 0 && listBox4.FindString("PUT") >= 0)
            {
                num++;
                var numbersList = unres_tasks.ToList();
                numbersList.Remove(12);
                var b = numbersList.ToArray();
                res_tasks[11] = 12;
                lab513 frm2 = new lab513(num, unres_tasks, res_tasks);
                frm2.Show();
                this.Hide();
            }
            else MessageBox.Show("Ответ неверный");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lab5 frm1 = new lab5(num, unres_tasks, res_tasks);
            frm1.Show();
            this.Hide();
        }
    }
}
