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
    public partial class lab51 : Form
    {
        private int num;
        private int[] unres_tasks = new int[16];
        private int[] res_tasks = new int[16];

        public lab51(int n, int[] un_tasks, int[] tasks)
        {
            unres_tasks = un_tasks;
            res_tasks = tasks;
            num = n;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab5 frm1 = new lab5(num, unres_tasks, res_tasks);
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ans = textBox1.Text.ToLower();
            if (ans != "")
            {
                if (ans == "http")
                {
                    num++;
                    var numbersList = unres_tasks.ToList();
                    numbersList.Remove(1);
                    var b = numbersList.ToArray();
                    res_tasks[0] = 1;
                    lab52 frm2 = new lab52(num, b, res_tasks);
                    frm2.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Ответ неверный");
            }
            else
                MessageBox.Show("Введите ответ");
        }

        private void lab51_Load(object sender, EventArgs e)
        {
            progressBar1.Value = num;
        }
    }
}
