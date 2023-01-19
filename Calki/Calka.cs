using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calki
{
    public static class Calka
    {
        public delegate double OneArgFunc(double x);

        public delegate double TwoArgFunc(double x, double y);

        public static double MetodaProstokatowLeftPoint(OneArgFunc Func, double xa, double xb, int n)
        {
            double przedzial = xb - xa;
            double h = przedzial / n;
            double sum = 0;
            for (var i = 0; i <= n - 1; i++)
            {
                sum += (Func(xa + i * h));
            }
            sum = h * sum;
            return sum;
        }

        public static double MetodaProstokatowRightPoint(OneArgFunc Func, double xa, double xb, int n)
        {
            double przedzial = xb - xa;
            double h = przedzial / n;
            double sum = 0;
            for (var i = 0; i <= n - 1; i++)
            {
                sum += (Func(xb - i * h));
            }
            sum = h * sum;
            return sum;
        }

        public static double MetodaProstokatowMidPoint(OneArgFunc Func, double xa, double xb, int n)
        {
            double przedzial = xb - xa;
            double h = przedzial / n;
            double sum = 0;
            for (var i = 0; i <= n - 1; i++)
            {
                sum += Func(xa + (h / 2 + (i * h)));
            }
            sum = h * sum;
            return sum;
        }

        public static double MetodaTrapezow(OneArgFunc Func, double xa, double xb, int n)
        {
            double h = (xb - xa) / n;
            //double alfa = (Func(xa) * xb - Func(xb) * xa) / (xb - xa);
            //double beta = (Func(xb) - Func(xa)) / (xb - xa);
            double sum = 0;
            for (var i = 0; i <= n - 1; i++)
            {
                sum += 2 * Func(xa + i * h);
            }
            sum = (h / 2) * sum;
            return sum;
        }

        public static double MetodaSimpsona(OneArgFunc Func, double xa, double xb, int n)
        {
            double przedzial = xb - xa;
            double h = przedzial / n;
            double sum = 0;
            for (var i = 0; i <= n - 1; i++)
            {
                sum += Func(xa + i * h) + 4 * Func(xa + i * h) + Func(xa + (i + 1) * h);
            }
            sum = (h / 6) * sum;
            return sum;
        }

        public static double MetodaGaussaLegrande(OneArgFunc Func, double xa, double xb, int n, double[] waga, double[] wezly)
        {
            double przedzial = xb - xa;
            double h = przedzial / 2;
            double sum = 0;
            for (var i = 0; i < n; i++)
            {
                sum += waga[i] * Func(((xb - xa) / 2 * wezly[i]) + ((xb + xa) / 2));
            }
            return sum * h;
        }

        public static double MetodaGaussaZlozona(OneArgFunc Func, double xa, double xb, int n, int N, double[] waga, double[] wezly)
        {
            double h = (xb - xa) / N;
            double sum = 0;
            double ai = 0;
            double bi = 0;
            double si = 0;
            for (var k = 0; k < N; k++)
            {
                ai = xa + k * h;
                bi = xa + (k + 1) * h;
                si = 0;
                for (var i = 0; i < n; i++)
                {
                    si += waga[i] * Func((h / 2) * wezly[i] + ((ai + bi) / 2));
                }
                sum += (h / 2) * si;
            }
            return sum;
        }

        //public static double GetDoubleRandom(double xa, double xb)
        //{
        //    var random = new Random();
        //    var doubleRandom = random.NextDouble();
        //    var rangeDoubleRandom = doubleRandom * (xb - xa) + xa;
        //    return rangeDoubleRandom;
        //}

        public static double MetodaStohastyczna(OneArgFunc Func, double xa, double xb, int n)
        {
            Random rnd = new Random();
            double przedzial = xb - xa;
            double h = przedzial / n;
            double sum = 0;
            for (var i = 1; i <= n; i++)
            {
                //Console.WriteLine(rnd.NextDouble(xa,xb));
                sum += Func(rnd.NextDouble(xa, xb));
            }
            sum = h * sum;
            return sum;
        }
    }

    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue
            )
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            int dokladnosc = 1000;
            double[] wagi2 = { 1.0, 1.0 };
            double[] wezly2 = { -0.577350269, 0.577350269 };
            double[] wagi3 = { 5.0 / 9.0, 8.0 / 9.0, 5.0 / 9.0 };
            double[] wezly3 = { -0.774596669, 0.0, 0.774596669 };
            double[] wagi4 = { 0.347854845, 0.652145155, 0.652145155, 0.347854845 };
            double[] wezly4 = { -0.861136312, -0.339981044, 0.339981044, 0.861136312 };
            Console.WriteLine("Dokladnosc calkowania: " + dokladnosc);
            Console.WriteLine("===============================================================");
            Console.WriteLine("Metoda prostokatow:");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow left point:");
            Console.WriteLine(Calka.MetodaProstokatowLeftPoint(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow right point:");
            Console.WriteLine(Calka.MetodaProstokatowRightPoint(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow mid point:");
            Console.WriteLine(Calka.MetodaProstokatowMidPoint(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  trapezow:");
            Console.WriteLine(Calka.MetodaTrapezow(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  Simpsona:");
            Console.WriteLine(Calka.MetodaSimpsona(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow:");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow left point:");
            Console.WriteLine(Calka.MetodaProstokatowLeftPoint(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow right point:");
            Console.WriteLine(Calka.MetodaProstokatowRightPoint(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow mid point:");
            Console.WriteLine(Calka.MetodaProstokatowMidPoint(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  trapezow:");
            Console.WriteLine(Calka.MetodaTrapezow(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  Simpsona:");
            Console.WriteLine(Calka.MetodaSimpsona(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow:");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow left point:");
            Console.WriteLine(Calka.MetodaProstokatowLeftPoint(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow right point:");
            Console.WriteLine(Calka.MetodaProstokatowRightPoint(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow mid point:");
            Console.WriteLine(Calka.MetodaProstokatowMidPoint(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  trapezow:");
            Console.WriteLine(Calka.MetodaTrapezow(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  Simpsona:");
            Console.WriteLine(Calka.MetodaSimpsona(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda gl:");
            Console.WriteLine("Cwiczenie:1");
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom3, 0, 1, 2, wagi2, wezly2));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom3, 0, 1, 3, wagi3, wezly3));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom3, 0, 1, 4, wagi4, wezly4));
            Console.WriteLine("Cwiczenie:3");
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom5, 0, 1, 2, wagi2, wezly2));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom5, 0, 1, 3, wagi3, wezly3));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom5, 0, 1, 4, wagi4, wezly4));
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda GaussaZlozona:");
            Console.WriteLine("Cwiczenie:1");
            Console.WriteLine(Calka.MetodaGaussaZlozona(Funkcje.Custom3, 0, 1, 2, 5, wagi2, wezly2));
            Console.WriteLine("Cwiczenie:3");
            Console.WriteLine(Calka.MetodaGaussaZlozona(Funkcje.Custom5, 0, 1, 2, 5, wagi2, wezly2));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda stohastyczna:");
            Console.WriteLine(Calka.MetodaStohastyczna(Funkcje.Custom3, -1, 1, dokladnosc));
        }
    }
}