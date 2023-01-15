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
            double przedzial = xb - xa;
            double h = przedzial / 2 * N;
            double x1 = 0;
            double x2 = 0;
            double xik = 0;
            double sum = 0;

            for (var k = 1; k <= N; k++)
            {
                for (var i = 0; i <= n; i++)
                {
                    x1 = (wezly[k] + wezly[k + 1]) / 2;
                    x2 = (wezly[k + 1] - wezly[k]) / 2;
                    xik = x1 + x2 * wezly[i];
                    sum += waga[i] * Func(xik);
                }
            }
            return sum * h;
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
            int n = 3;
            int N = 5;
            double[] wagi = { 5.0 / 9.0, 8.0 / 9.0, 5.0 / 9.0 };
            double[] wezly = { -0.774596669, 0.0, 0.774596669 };
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
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom5, 0, 1, n, wagi, wezly));
            Console.WriteLine(Calka.MetodaGaussaZlozona(Funkcje.Custom5, 0, 1, n, N, wagi, wezly));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda stohastyczna:");
            Console.WriteLine(Calka.MetodaStohastyczna(Funkcje.Custom3, -1, 1, dokladnosc));

            Console.Read();
        }
    }
}