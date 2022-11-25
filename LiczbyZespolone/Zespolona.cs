using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodyNumeryczneZadania
{
    public class Zespolona
    {
        public double re { get; set; } = 0;

        //public float re { get; set; } = 0;
        public double im { get; set; } = 0;

        //public float re { get; set; } = 0;

        public Zespolona()
        {
        }

        public Zespolona(double Re, double Im)
        {
            re = Re;
            im = Im;
        }

        public static Zespolona operator +(Zespolona z)
            => z;

        public static Zespolona operator -(Zespolona z)
            => new Zespolona(-z.re, -z.im);

        public static Zespolona operator +(Zespolona z1, Zespolona z2)
            => new Zespolona(z1.re + z2.re, z1.im + z2.im);

        public static Zespolona operator +(Zespolona z, int c)
            => new Zespolona(z.re + c, z.im);

        public static Zespolona operator *(Zespolona z1, Zespolona z2)
            => new Zespolona(z1.re * z2.re - z1.im * z2.im, z1.re * z2.im + z1.im * z2.re);

        public void Wypisz()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
             => $"{re} + {im}i";
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Zespolona z1 = new Zespolona(1.23456789123456789, 4 / 3);
            Zespolona z2 = new Zespolona(1, 2);
            Zespolona wynik = new Zespolona();

            wynik = z1 + z2;
            wynik.Wypisz();
            wynik = z1 * z2;
            wynik.Wypisz();
        }
    }
}