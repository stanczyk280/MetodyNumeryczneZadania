using EliminacjaGaussa;
using RozkladLU;

namespace Interpolacja
{
    public static class MetodyInterpolacji
    {
        public static double[] RozwiazGauss(double[,] macierzWspl, double[] macierzWyrazowWolnych, int n)
        {
            double[] x = new double[n];

            double[,] tmpMacierzWspl = new double[n, n + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmpMacierzWspl[i, j] = macierzWspl[i, j];
                }
                tmpMacierzWspl[i, n] = macierzWyrazowWolnych[i];
            }

            double tmp = 0;

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    tmp = tmpMacierzWspl[i, k] / tmpMacierzWspl[k, k];
                    for (int j = k; j < n + 1; j++)
                    {
                        tmpMacierzWspl[i, j] -= tmp * tmpMacierzWspl[k, j];
                    }
                }
            }
            //Console.WriteLine("=================");
            //Macierz.Wypisz(tmpMacierzWspl);
            //Console.WriteLine("=================");
            for (int k = n - 1; k >= 0; k--)
            {
                tmp = 0;
                for (int j = k + 1; j < n; j++)
                {
                    tmp += tmpMacierzWspl[k, j] * x[j];
                }
                x[k] = (tmpMacierzWspl[k, n] - tmp) / tmpMacierzWspl[k, k];
            }

            return x;

            //for (var i = 0; i < x.Length; i++)
            //{
            //    Console.WriteLine("x" + (i + 1) + "= " + Math.Round(x[i]));
            //}
        }

        public static double[] Interpolacja(double[,] macierz, double[] wektor)
        {
            int n = macierz.GetLength(0);
            double[] wektorWynikowy = new double[n];
            wektorWynikowy = Gauss.RozwiazGauss(macierz, wektor, n);

            return wektorWynikowy;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            //[1,x,x^2,x^3]
            double[,] macierzBaza2 = { { 1, 0, 0, 0 }, { 1, 1.5, 2.25, 3.375 }, { 1, 3, 9, 27 }, { 1, 4, 16, 64 } };
            //[1,x,cosx,sinx]
            double[,] macierzBaza1 = { { 1, 0, 1, 0 }, { 1, 1.5, 0.99965732, 0.02617695 }, { 1, 3, 0.99862953, 0.05233596 }, { 1, 4, 0.99756405, 0.06975647 } };
            double[] wektor = { 2, 3, 1, 3 };
            //chyba baza 1 jest zle skonstruowana
            double[] wynik1 = MetodyInterpolacji.Interpolacja(macierzBaza1, wektor);
            double[] wynik2 = MetodyInterpolacji.Interpolacja(macierzBaza2, wektor);
            for (var i = 0; i < wynik2.Length; i++)
            {
                Console.WriteLine(wynik2[i]);
            }
            Console.WriteLine();
            for (var i = 0; i < wynik1.Length; i++)
            {
                Console.WriteLine(wynik1[i]);
            }
        }
    }
}