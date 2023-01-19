using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RownaniaNieliniowe
{
    public static class Metody
    {
        public delegate double OneArgFunc(double x);

        public delegate double TwoArgFunc(double x, double y);

        public static void MetodaBisekcji(double a, double b, double e, OneArgFunc Func)
        {
            double c = a;
            Console.WriteLine("Metoda bisekcji");
            Console.WriteLine("------------------------------");
            int i = 1;

            while ((b - a) >= e)
            {
                c = (a + b) / 2;
                if (Func(c) == 0.0)
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
                Console.Write("f({0:F6})= ", c);
                Console.Write("{0:F6}\n", Func(c));
                i++;
            }
            Console.WriteLine("x0= {0:F6}", c);
        }

        public static void MetodaFalsi(double a, double b, double e, OneArgFunc Func)
        {
            double c = a;
            int i = 1;
            Console.WriteLine("Metoda Falsi");
            Console.WriteLine("------------------------------");

            while ((b - a) >= e)
            {
                c = c - (Func(c) / (Func(b) - Func(c))) * (b - c);

                //Console.WriteLine("{0:F15}", Func(c));

                Console.Write(i + " | ");
                Console.Write("f({0:F10})= ", c);
                Console.Write("{0:F10}\n", Func(c));
                i++;
                if (Math.Abs(Func(c)) <= e)
                {
                    break;
                }
            }
            Console.WriteLine("x0= {0:F6}", c);
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            double e = 0.0001;

            Metody.MetodaBisekcji(-3, -2, e, Funkcje.F1);
            Console.WriteLine();
            Metody.MetodaFalsi(-3, -2, e, Funkcje.F1);
        }
    }
}