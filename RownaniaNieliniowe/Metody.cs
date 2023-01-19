using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RownaniaNieliniowe
{
    public static class Metody
    {
        public delegate double OneArgFunc(double x);

        public delegate double TwoArgFunc(double x, double y);

        public static double Pochodna(OneArgFunc Func, double x, double dx)
            => (Func(x + dx) - Func(x)) / dx;

        public static void MetodaBisekcji(double a, double b, double e, OneArgFunc Func)
        {
            double c = a;
            Console.WriteLine("Metoda bisekcji");
            Console.WriteLine("------------------------------");
            int i = 1;

            while (true)
            {
                c = (a + b) / 2;
                if (Math.Abs(Func(c)) <= e)
                {
                    break;
                }
                else if (Func(c) * Func(a) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }

                Console.Write(i + " | ");
                Console.Write("f({0:F10})= ", c);
                Console.Write("{0:F10}\n", Func(c));
                i++;
            }
            Console.WriteLine("x0= {0:F6}", c);
        }

        public static void MetodaFalsi(double a, double b, double e, OneArgFunc Func)
        {
            double x0 = a;
            double fa = Func(a);
            double fb = Func(b);
            int i = 1;
            Console.WriteLine("Metoda Falsi");
            Console.WriteLine("------------------------------");

            while (true)
            {
                x0 = (Func(a) * b - Func(b) * a) / (Func(a) - Func(b));
                if (Math.Abs(Func(x0)) <= e)
                {
                    break;
                }
                Console.Write(i + " | ");
                Console.Write("f({0:F10})= ", x0);
                Console.Write("{0:F10}\n", Func(x0));
                if (Func(a) * Func(x0) < 0)
                {
                    b = x0;
                }
                else
                {
                    a = x0;
                }
                i++;
            }
            Console.WriteLine("x0= {0:F6}", x0);
        }

        public static void MetodaSiecznych(double a, double b, double e, OneArgFunc Func)
        {
            int i = 1;
            double x1 = a;
            double x2 = b;
            double x0 = 0;
            Console.WriteLine("Metoda Siecznych");
            Console.WriteLine("------------------------------");

            while (true)
            {
                x0 = x1 - Func(x1) * (x1 - x2) / (Func(x1) - Func(x2));
                if (Math.Abs(Func(x0)) <= e)
                {
                    break;
                }
                Console.Write(i + " | ");
                Console.Write("f({0:F10})= ", x0);
                Console.Write("{0:F10}\n", Func(x0));
                x2 = x1;
                x1 = x0;
                i++;
            }
            Console.WriteLine("x0= {0:F6}", x0);
        }

        public static void MetodaNewtona(double a, double b, double e, OneArgFunc Func)
        {
            double i = 1;
            double x0 = 0;
            double x1 = a;
            Console.WriteLine("Metoda Newtona");
            Console.WriteLine("------------------------------");

            double dx = 0.00001;
            while (true)
            {
                x0 = x1 - (Func(x1) / Pochodna(Func, x1, dx));
                if (Math.Abs(Func(x0)) <= e || Math.Abs(x1 - x0) <= e)
                {
                    break;
                }
                x1 = x0;
                Console.Write(i + " | ");
                Console.Write("f({0:F10})= ", x0);
                Console.Write("{0:F10}\n", Func(x0));
            }
            Console.WriteLine("x0= {0:F6}", x0);
        }

        public static void ZbieznoscBisekcji(double a, double b, double e)
        {
            var potega = Math.Pow(2, -7);
            var log21 = Math.Log2(potega);
            var log22 = Math.Log2(b - a);

            Console.WriteLine(log21 / log22);
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Metody.ZbieznoscBisekcji(1, 3, 0.0078125);
            double a;
            double b;
            double e;
            Console.WriteLine("Zadanie 1:\n");
            a = -3;
            b = -2;
            e = 0.0001;
            Metody.MetodaBisekcji(a, b, e, Funkcje.F1);
            Console.WriteLine();
            Metody.MetodaFalsi(a, b, e, Funkcje.F1);
            Console.WriteLine();
            Metody.MetodaSiecznych(a, b, e, Funkcje.F1);
            Console.WriteLine();
            Metody.MetodaNewtona(a, b, e, Funkcje.F1);
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Zadanie 2:\n");
            a = -1.5;
            b = 0;
            e = 0.00001;
            Metody.MetodaBisekcji(a, b, e, Funkcje.F2);
            Console.WriteLine();
            Metody.MetodaFalsi(a, b, e, Funkcje.F2);
            Console.WriteLine();
            Metody.MetodaSiecznych(a, b, e, Funkcje.F2);
            Console.WriteLine();
            Metody.MetodaNewtona(a, b, e, Funkcje.F2);
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Zadanie 3:\n");
            a = -1.2;
            b = -0.4;
            e = 0.00001;
            // Metody.MetodaBisekcji(a, b, e, Funkcje.F3);
            Console.WriteLine();
            //Metody.MetodaFalsi(a, b, e, Funkcje.F3);
            Console.WriteLine();
            //Metody.MetodaSiecznych(a, b, e, Funkcje.F3);
            Console.WriteLine();
            //Metody.MetodaNewtona(a, b, e, Funkcje.F3);
            Console.WriteLine("------------------------------\n");
        }
    }
}