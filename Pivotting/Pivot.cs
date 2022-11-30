using OperacjeMacierzy;

namespace Pivotting
{
    public static class Pivot
    {
        private static double[,] macierz = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };

        public static double[] PivotMacierzGauss(double[,] macierz, double[] b)
        {
            int n = macierz.GetLength(0);
            if (n != macierz.GetLength(1) || n != b.Length)
                throw new Exception("Error");

            double[] X = new double[n];
            double[,] tmpMacierz = new double[n, n];
            double[] tmpB = new double[n];
            double tmp;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmpMacierz[i, j] = macierz[i, j];
                }
                tmpB[i] = b[i];
            }

            int rMax = 0;
            for (int i = 0; i < n; i++)
            {
                rMax = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(tmpMacierz[j, i]) > Math.Abs(tmpMacierz[rMax, i]))
                    {
                        rMax = j;
                    }
                }
                if (rMax != i)
                {
                    for (int k = i; k < n; k++)
                    {
                        tmp = tmpMacierz[i, k];
                        tmpMacierz[i, k] = tmpMacierz[rMax, k];
                        tmpMacierz[rMax, k] = tmp;
                    }
                    tmp = tmpB[i];
                    tmpB[i] = tmpB[rMax];
                    tmpB[rMax] = tmp;
                }
                for (int l = 0; l < n; l++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j != l)
                        {
                            tmp = tmpMacierz[j, l] / tmpMacierz[l, l];
                            for (int k = 0; k < n + 1; k++)
                            {
                                if (k != n)
                                {
                                    tmpMacierz[j, k] = tmpMacierz[j, k] - tmp * tmpMacierz[l, k];
                                }
                                else
                                {
                                    tmpB[j] = tmpB[j] - tmp * tmpB[l];
                                }
                            }
                        }
                    }
                }
            }
            for (int i = n - 1; i >= 0; i--)
            {
                tmp = tmpB[i];
                for (int j = i + 1; j < n; j++)
                {
                    tmp -= tmpMacierz[i, j] * X[j];
                }
                tmp /= tmpMacierz[i, i];
                X[i] = tmp;
            }
            return X;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            double[,] macierzWspl =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            double[] macierzWyrazowWolnych = { 56, 62, -10, 14, 28 };

            double[] x1 = Pivot.PivotMacierzGauss(macierzWspl, macierzWyrazowWolnych);
            for (var i = 0; i < x1.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + x1[i]);
            }
        }
    }
}