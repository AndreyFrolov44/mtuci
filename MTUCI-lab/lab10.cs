using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using arrayLibrary;
using Microsoft.VisualBasic;

namespace project
{
    public partial class lab10 : Form
    {
        public lab10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String g = Interaction.InputBox("Введите количество элементов массива = ", "Введите значение", "", -1);

            int n = Convert.ToInt32(g);
            double[] masPtr = new double[n];
            int min = Convert.ToInt32(Interaction.InputBox("Введите минимальное значение элементов массива = ", "Введите значение", "", -1));
            int max = Convert.ToInt32(Interaction.InputBox("Введите максимальное значение элементов массива = ", "Введите значение", "", -1));

            Class1.enter_mas(n, max, min, masPtr);
            Class1.output_mas(dataGridView1, masPtr);

            double sum = 0;
            int first = -1, last = -1, k = 0;

            Class1.set_count(n, ref k, ref sum, ref first, ref last, masPtr);

            double[] rezmasPtr = new double[k];

            Class1.set_mas(n, masPtr, first, last, rezmasPtr);

            Class1.output_mas(dataGridView2, rezmasPtr);

            MessageBox.Show("Сумма элементов массива, расположенных между первым и последним положительными элементами" + sum);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[] masPtr = new double[dataGridView1.ColumnCount];
            double[] rezmasPtr = new double[dataGridView2.ColumnCount];

            masPtr = Class1.get_mas(dataGridView1);
            rezmasPtr = Class1.get_mas(dataGridView2);

            Class1.add();
            Class1.add_structdouble();
            Class1.add_zap_double(masPtr, rezmasPtr, masPtr.GetLength(0), rezmasPtr.GetLength(0));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double[] masPtr = new double[dataGridView1.ColumnCount];
            double[] rezmasPtr = new double[dataGridView2.ColumnCount];

            masPtr = Class1.get_mas(dataGridView1);
            rezmasPtr = Class1.get_mas(dataGridView2);

            Class1.add_pdf(dataGridView1.ColumnCount, masPtr, rezmasPtr, dataGridView2.ColumnCount);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double[] masPtr = new double[dataGridView1.ColumnCount];
            double[] rezmasPtr = new double[dataGridView2.ColumnCount];

            masPtr = Class1.get_mas(dataGridView1);
            rezmasPtr = Class1.get_mas(dataGridView2);

            Class1.ZapisBloknot(dataGridView1.ColumnCount, dataGridView2.ColumnCount, masPtr, rezmasPtr);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double[] masPtr = new double[dataGridView1.ColumnCount];
            double[] rezmasPtr = new double[dataGridView2.ColumnCount];

            masPtr = Class1.get_mas(dataGridView1);
            rezmasPtr = Class1.get_mas(dataGridView2);

            Class1.ZapisWordIsx(dataGridView1.ColumnCount, dataGridView2.ColumnCount, masPtr, rezmasPtr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double[] masPtr = new double[dataGridView1.ColumnCount];
            double[] rezmasPtr = new double[dataGridView2.ColumnCount];

            masPtr = Class1.get_mas(dataGridView1);
            rezmasPtr = Class1.get_mas(dataGridView2);

            Class1.ZapisExcel(dataGridView1.ColumnCount, dataGridView2.ColumnCount, masPtr, rezmasPtr);
        }
    }
}
