using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logarytm_e
{
    public class Logarytm
    {
        public decimal ObliczSilnie(decimal stopien)
        {
            try
            {
                decimal wynik = 1;
                if (stopien != 0)
                {
                    for (var i = stopien; i > 1; i--)
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
            catch
            {
                Console.WriteLine("Liczba zbyt duza lub zbyt mala");
                throw new ArgumentException();
            }
        }

        public decimal ObliczLogarytm(decimal n)
        {
            decimal e = 1;
            if (n != 0)
            {
                while (n > 0)
                {
                    e += 1 / ObliczSilnie(n);
                    n--;
                }
            }
            return e;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Logarytm l1 = new Logarytm();
            Console.Write("Logarytm e =" + l1.ObliczLogarytm(5));
        }
    }
}