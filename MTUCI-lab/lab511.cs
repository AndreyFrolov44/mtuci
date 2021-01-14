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
    public partial class lab511 : Form
    {
        private int num;
        private int[] unres_tasks = new int[16];
        private int[] res_tasks = new int[16];

        public lab511(int n, int[] un_tasks, int[] tasks)
        {
            unres_tasks = un_tasks;
            res_tasks = tasks;
            num = n;
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = "Ваш ответ: " + hScrollBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hScrollBar1.Value == 1992)
            {
                num++;
                var numbersList = unres_tasks.ToList();
                numbersList.Remove(11);
                var b = numbersList.ToArray();
                res_tasks[10] = 11;
                lab512 frm2 = new lab512(num, unres_tasks, res_tasks);
                frm2.Show();
                this.Hide();
            }
            else MessageBox.Show("Ответ неверный");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab5 frm1 = new lab5(num, unres_tasks, res_tasks);
            frm1.Show();
            this.Hide();
        }

        private void lab511_Load(object sender, EventArgs e)
        {
            progressBar1.Value = num;
        }
    }
}
