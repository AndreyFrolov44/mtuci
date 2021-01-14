using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arrayLibrary;
using LibraryTechnology;
using Microsoft.VisualBasic;

namespace project
{
    public partial class lab61 : Form
    {
        public lab61()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String g = textBox2.Text;
            int n = Convert.ToInt32(g);
            double[] masPtr = new double[n];
            int min = Convert.ToInt32(textBox3.Text);
            int max = Convert.ToInt32(textBox4.Text);

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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
