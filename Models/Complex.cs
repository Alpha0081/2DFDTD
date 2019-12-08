using System;
using System.Collections.Generic;


namespace _2DFDTD.Models
{
    ///<summary>
    ///Предоставляет возможность работать с комплексными числами.
    ///</summary>
    public class Complex
    {
        double A { get; }
        double B { get; }
        public Complex(double a, double b)
        {
            this.A = a;
            this.B = b;
        }
        public static implicit operator Complex(double a)
        {
            return new Complex(a, 0);
        }
        /// <summary>
        /// Возвращает комплексное число, полученное путём нахождения квадратного корня из указанного числа. Число может быть отрицательным.
        /// </summary>
        /// <param name="x">Число с плавающей точкой</param>
        /// <returns>Комплексное представление действительного числа</returns>
        public static Complex sqrt(double x)
        {
            return x < 0 ? new Complex(0, Math.Sqrt(-x)) : new Complex(Math.Sqrt(x), 0);
        }
        /// <summary>
        /// Метод поиска модуля комплексного числа.
        /// </summary>
        /// <returns>Возвращает модуль комплексного числа</returns>
        public double hypot()
        {
            return Math.Pow(A * A + B * B, 0.5);
        }
        /// <summary>
        /// Метод поиска аргумента комплексного числа.
        /// </summary>
        /// <returns>Возвращает аргумент комплексного числа</returns>
        protected double get_angle()
        {
            return Math.Atan2(B, A);
        }
        /// <summary>
        /// Метод создания сопряжённого комплексного числа из данного.
        /// </summary>
        /// <returns>Возращает соответсвующее сопряжённое комплексное число</returns>
        public Complex reflection()
        {
            return new Complex(A, -B);
        }
        /// <summary>
        /// Метод арифметического представления комплексного числа.
        /// </summary>
        /// <returns>Возвращает строку с арифметическим представлением комплексного числа</returns>
        public override string ToString()
        {
            return B >= 0 ? String.Format("{0}+{1}j", A, B) : String.Format("{0}{1}j", A, B);
        }
        /// <summary>
        /// Метод сложения двух комплексных чисел.
        /// </summary>
        /// <param name="self">Комплексное число</param>
        /// <param name="other">Комплесное число</param>
        /// <returns>Возвращает комплексное число, равное сумме двух указанных чисел</returns>
        public static Complex operator +(Complex self, Complex other)
        {
            return new Complex(self.A + other.A, self.B + other.B);
        }
        /// <summary>
        /// Метод вычисления разности двух комплексных чисел.
        /// </summary>
        /// <param name="self">Комплексное число</param>
        /// <param name="other">Комплексное число</param>
        /// <returns>Возвращает комплексное число равное разности двух указанных чисел</returns>
        public static Complex operator -(Complex self, Complex other)
        {
            return new Complex(self.A - other.A, self.B - other.B);
        }
        /// <summary>
        /// Метод умножения двух комплексных чисел.
        /// </summary>
        /// <param name="self">Комплексное число</param>
        /// <param name="other">Косплексное число</param>
        /// <returns>Возвращает комплексное число равное произведению двух чисел</returns>
        public static Complex operator *(Complex self, Complex other)
        {
            return new Complex(self.A * other.A - self.B * other.B, self.A * other.B + other.A * self.B);
        }
        /// <summary>
        /// Метод деления двух комплексных чисел.
        /// </summary>
        /// <param name="self">Комплексное число.</param>
        /// <param name="other">Комплексное число.</param>
        /// <returns>Возвращает комплексное число равное отношению двух указанных чисел</returns>
        public static Complex operator /(Complex self, Complex other)
        {
            return (self * other.reflection()) / (other.A * other.A + other.B * other.B);
        }
        /// <summary>
        /// Метод деления комплексного числа на действительное.
        /// </summary>
        /// <param name="self">Комплексное число</param>
        /// <param name="x">Действительное число</param>
        /// <returns>Возвращает комплексное число равное отношению двух указанных</returns>
        public static Complex operator /(Complex self, double x)
        {
            return new Complex(self.A / x, self.B / x);
        }
        /// <summary>
        /// Метод возведения комплексного числа в целую степень.
        /// </summary>
        /// <param name="power">Целое число</param>
        /// <returns>Возвращает комплексное</returns>
        public Complex pow(int power)
        {
            double r = Math.Pow(hypot(), power);
            return new Complex(r * Math.Cos(power * get_angle()), r * Math.Sin(power * get_angle()));
        }
        /// <summary>
        /// Метод поиска корней n-й степени из ненулевого комплексного числа.
        /// </summary>
        /// <param name="power">Степень корня, равное целому числу.</param>
        /// <returns>Возращает список из комплексных чисел.</returns>
        public List<Complex> roots(int power)
        {
            double r = Math.Pow(hypot(), 1.0 / power);
            double phi = get_angle();
            List<Complex> x = new List<Complex>();
            for (int i = 0; i < power; ++i)
            {
                x.Add(new Complex(r * Math.Cos((phi + 2 * Math.PI * i) / power), r * Math.Sin((phi + 2 * Math.PI * i) / power)));
            }
            return x;
        }
        /// <summary>
        /// Метод проверки на равентво двух комплексных чисел.
        /// </summary>
        /// <param name="self">Комплексное число</param>
        /// <param name="other">Комплексное число</param>
        /// <returns>Возвращает true или false</returns>
        public static bool operator ==(Complex self, Complex other)
        {
            return self.A == other.A && self.B == other.B;
        }
        /// <summary>
        /// Метод проверки на неравенство двух комплексных чисел.
        /// </summary>
        /// <param name="self">Комплексное число</param>
        /// <param name="other">Комплексное число</param>
        /// <returns>Возвращает true или false</returns>
        public static bool operator !=(Complex self, Complex other)
        {
            return !(self == other);
        }
        public static Complex Exp(double n)
        {
            return new Complex(Math.Cos(n), Math.Sin(n));
        }
    }
}
