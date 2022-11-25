using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnia
{
    public class Silnia
    {
        public int Stopien { get; set; }

        public Silnia(int stopien)
        {
            Stopien = stopien;
        }

        public short ObliczSilnieShort()
        {
            short wynik = 1;
            if (Stopien != 0)
            {
                for (short i = Convert.ToInt16(Stopien); i > 1; i--)
                {
                    wynik *= i;
                }
            }
            if (Stopien < 0)
            {
                throw new ArgumentException();
            }
            return wynik;
        }

        public int ObliczSilnieInt()
        {
            int wynik = 1;
            if (Stopien != 0)
            {
                for (int i = Stopien; i > 1; i--)
                {
                    wynik *= i;
                }
            }
            if (Stopien < 0)
            {
                throw new ArgumentException();
            }
            return wynik;
        }

        public long ObliczSilnieLong()
        {
            long wynik = 1;
            if (Stopien != 0)
            {
                for (long i = Convert.ToInt64(Stopien); i > 1; i--)
                {
                    wynik *= i;
                }
            }
            if (Stopien < 0)
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
            Console.WriteLine("Wprowadz stopien silni: ");
            Silnia s1 = new Silnia(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("16b silnia: " + s1.ObliczSilnieShort());
            Console.WriteLine("32b silnia: " + s1.ObliczSilnieInt());
            Console.WriteLine("64b silnia: " + s1.ObliczSilnieLong());
        }
    }
}