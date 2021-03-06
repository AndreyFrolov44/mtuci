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
    public partial class lab59 : Form
    {
        private int num;
        private int[] unres_tasks = new int[16];
        private int[] res_tasks = new int[16];

        public lab59(int n, int[] un_tasks, int[] tasks)
        {
            unres_tasks = un_tasks;
            res_tasks = tasks;
            num = n;
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Ваш ответ: " + trackBar1.Value.ToString();
        }

        private void lab59_Load(object sender, EventArgs e)
        {
            progressBar1.Value = num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value == 2014)
            {
                num++;
                var numbersList = unres_tasks.ToList();
                numbersList.Remove(9);
                var b = numbersList.ToArray();
                res_tasks[8] = 9;
                lab510 frm2 = new lab510(num, b, res_tasks);
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
    }
}
