﻿using System;
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
    public partial class lab54 : Form
    {
        private int num;
        private int[] unres_tasks = new int[16];
        private int[] res_tasks = new int[16];

        public lab54(int n, int[] un_tasks, int[] tasks)
        {
            unres_tasks = un_tasks;
            res_tasks = tasks;
            num = n;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked && checkBox4.Checked)
            {
                num++;
                var numbersList = unres_tasks.ToList();
                numbersList.Remove(4);
                var b = numbersList.ToArray();
                res_tasks[3] = 4;
                lab55 frm2 = new lab55(num, b, res_tasks);
                frm2.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Ответ неверный");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab5 frm1 = new lab5(num, unres_tasks, res_tasks);
            frm1.Show();
            this.Hide();
        }

        private void lab54_Load(object sender, EventArgs e)
        {
            progressBar1.Value = num;
        }
    }
}
