using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryTechnology;

namespace project
{
    public partial class lab3 : Form
    {
        public lab3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double side_a_ref = 0, side_b_ref = 0;
            double side_a_out, side_b_out;
            double side_c, angle_alpha, angle_beta;
            side_c = Main.Input(textBox1);
            angle_alpha = Main.Input(textBox2);
            angle_beta = Main.Input(textBox3);

            Main.Side_ref(side_c, angle_alpha, angle_beta, ref side_a_ref, ref side_b_ref);

            Main.Side_out(side_c, angle_alpha, angle_beta, out side_a_out, out side_b_out);

            Main.Output(side_a_ref, textBox4);
            Main.Output(side_b_ref, textBox5);

            Main.Output(side_a_out, textBox6);
            Main.Output(side_b_out, textBox7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
