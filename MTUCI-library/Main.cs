using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryTechnology
{
    public static class Main
    {
        public static double Input(TextBox t)
        {
            return Convert.ToDouble(t.Text);
        }

        public static void Output(double x, TextBox t)
        {
            t.Text = Convert.ToString(x);
        }

        public static double Deg_rad(double deg)
        {
            return deg * Math.PI / 180;
        }

        public static void Side_ref(double side_c, double angle_alpha, double angle_beta, ref double side_a, ref double side_b)
        {
            double angle_gamma_rad, angle_beta_rad, angle_alpha_rad;

            angle_gamma_rad = Deg_rad(180 - angle_alpha - angle_beta);
            angle_beta_rad = Deg_rad(angle_beta);
            angle_alpha_rad = Deg_rad(angle_alpha);

            side_a = side_c * (Math.Sin(angle_alpha_rad) / Math.Sin(angle_gamma_rad));
            side_b = side_a * (Math.Sin(angle_beta_rad) / Math.Sin(angle_alpha_rad));
        }

        public static void Side_out(double side_c, double angle_alpha, double angle_beta, out double side_a, out double side_b)
        {
            double angle_gamma_rad, angle_beta_rad, angle_alpha_rad;

            angle_gamma_rad = Deg_rad(180 - angle_alpha - angle_beta);
            angle_beta_rad = Deg_rad(angle_beta);
            angle_alpha_rad = Deg_rad(angle_alpha);

            side_a = side_c * (Math.Sin(angle_alpha_rad) / Math.Sin(angle_gamma_rad));
            side_b = side_a * (Math.Sin(angle_beta_rad) / Math.Sin(angle_alpha_rad));
        }
    }
}
