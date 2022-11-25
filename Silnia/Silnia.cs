using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnia
{
    public static class Silnia
    {
        public static short ObliczSilnieShort(int stopien)
        {
            short wynik = 1;
            if (stopien != 0)
            {
                for (short i = Convert.ToInt16(stopien); i > 1; i--)
                {
                    wynik *= i;
                }
            }
            if (stopien < 0)
            {
                throw new ArgumentException();
            }
            return wynik;
        }

        public static int ObliczSilnieInt(int stopien)
        {
            int wynik = 1;
            if (stopien != 0)
            {
                for (int i = stopien; i > 1; i--)
                {
                    wynik *= i;
                }
            }
            if (stopien < 0)
            {
                throw new ArgumentException();
            }
            return wynik;
        }

        public static long ObliczSilnieLong(int stopien)
        {
            long wynik = 1;
            if (stopien != 0)
            {
                for (long i = Convert.ToInt64(stopien); i > 1; i--)
                {
                    wynik *= i;
                }
            }
            if (stopien < 0)
            {
                throw new ArgumentException();
            }
            return wynik;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            int stopien = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("16b silnia: " + Silnia.ObliczSilnieShort(stopien));
            Console.WriteLine("32b silnia: " + Silnia.ObliczSilnieInt(stopien));
            Console.WriteLine("64b silnia: " + Silnia.ObliczSilnieLong(stopien));
        }
    }
}