using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    class ClassLab2
    {
        /// <summary>
        /// Получает введенное в TextBox значение
        /// </summary>
        /// <param name="t">TextBox</param>
        /// <returns>Значение TextBox</returns>
        public static double Input(TextBox t)
        {
            return Convert.ToDouble(t.Text);
        }

        /// <summary>
        /// Выводит значение в TextBox
        /// </summary>
        /// <param name="x">Выводимое значение</param>
        /// <param name="t">TextBox</param>
        public static void Output(double x, TextBox t)
        {
            t.Text = Convert.ToString(x);
        }

        /// <summary>
        /// Рассчитывает значение D по исходным данным
        /// </summary>
        /// <param name="x">Значение x</param>
        /// <param name="y">Значение y</param>
        /// <returns>Значение D</returns>
        public static double CalcD(double x, double y)
        {
            double d = Math.Log(y - Math.Sqrt(Math.Abs(x))) * (x - y / (x + Math.Pow(x, 2) / 4));
            return Math.Round(d, 3, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Рассчитывает значение Z по исходным данным
        /// </summary>
        /// <param name="x">Значение x</param>
        /// <param name="y">Значение y</param>
        /// <returns>Значение Z</returns>
        public static double CalcZ(double x, double y)
        {
            double z = Math.Pow(1 - Math.Tan(x), Math.Tan(x)) + Math.Cos(x - y);
            return Math.Round(z, 3, MidpointRounding.AwayFromZero);
        }
    }
}
