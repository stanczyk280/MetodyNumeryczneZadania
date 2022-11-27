using OperacjeMacierzy;

namespace EliminacjaGaussa
{
    public static class Gauss
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
            Console.WriteLine("=================");
            Macierz.Wypisz(tmpMacierzWspl);
            Console.WriteLine("=================");
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
    }
}