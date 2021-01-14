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
    public partial class lab510 : Form
    {
        private int num;
        private int[] unres_tasks = new int[16];
        private int[] res_tasks = new int[16];

        public lab510(int n, int[] un_tasks, int[] tasks)
        {
            unres_tasks = un_tasks;
            res_tasks = tasks;
            num = n;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedIndices.Contains(0) && checkedListBox1.CheckedIndices.Contains(2) && checkedListBox1.CheckedIndices.Contains(4) && checkedListBox1.CheckedIndices.Contains(5))
            {
                num++;
                var numbersList = unres_tasks.ToList();
                numbersList.Remove(10);
                var b = numbersList.ToArray();
                res_tasks[9] = 10;
                lab511 frm2 = new lab511(num, unres_tasks, res_tasks);
                frm2.Show();
                this.Hide();
            }
            else MessageBox.Show("Ответ неверный");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab5 frm5 = new lab5(num, unres_tasks, res_tasks);
            frm5.Show();
            this.Hide();
        }

        private void lab510_Load(object sender, EventArgs e)
        {
            progressBar1.Value = num;
        }
    }
}
