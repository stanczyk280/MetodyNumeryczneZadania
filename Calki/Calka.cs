using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static double GetDoubleRandom(double xa, double xb)
        {
            var random = new Random();
            var doubleRandom = random.NextDouble();
            var rangeDoubleRandom = doubleRandom * (xb - xa) + xa;
            return rangeDoubleRandom;
        }

        public static double MetodaStohastyczna(OneArgFunc Func, double xa, double xb, int n)
        {
            Random rnd = new Random();
            double przedzial = xb - xa;
            double h = przedzial / n;
            double sum = 0;
            for (var i = 1; i <= n; i++)
            {
                sum += Func(GetDoubleRandom(xa, xb));
            }
            sum = h * sum;
            return sum;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            int dokladnosc = 1000;
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
            Console.WriteLine("Metoda stohastyczna:");
            Console.WriteLine(Calka.MetodaStohastyczna(Funkcje.Custom3, -1, 1, dokladnosc));
        }
    }
}