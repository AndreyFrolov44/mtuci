using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib;

namespace project
{
    public partial class lab4 : Form
    {
        public lab4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c, d, res;

            a = Lib.Lib.readDouble(numericUpDown1);
            b = Lib.Lib.readDouble(numericUpDown2);
            c = Lib.Lib.readDouble(numericUpDown3);
            d = Lib.Lib.readDouble(numericUpDown4);

            Lib.Lib.arcLength(ref a, ref b, ref c, ref d, out res);

            Lib.Lib.printDouble(textBox5, res);
        }
    }
}
