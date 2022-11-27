using OperacjeMacierzy;

namespace RozkladLU
{
    public static class LU
    {
        public static double[,] GetUpper(double[,] macierz)
        {
            if (macierz.GetLength(0) != macierz.GetLength(1))
            {
                throw new ArgumentException("Macierz nie jest kwadratowa");
            }

            int n = macierz.GetLength(0);
            double tmp = 0;
            double[,] macierzU = new double[n, n];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    macierzU[i, j] = macierz[i, j];
                }
            }
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (j > i)
                    {
                        tmp = macierzU[j, i] / macierzU[i, i];
                        for (var k = 0; k < n; k++)
                        {
                            macierzU[j, k] = macierzU[j, k] - tmp * macierzU[i, k];
                        }
                    }
                }
            }

            return macierzU;
        }

        public static double[,] GetLower(double[,] macierz)
        {
            if (macierz.GetLength(0) != macierz.GetLength(1))
            {
                throw new ArgumentException("Macierz nie jest kwadratowa");
            }

            int n = macierz.GetLength(0);
            double tmp = 0;
            double[,] macierzU = new double[n, n];
            double[,] macierzL = new double[n, n];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    macierzU[i, j] = macierz[i, j];
                }
                macierzL[i, i] = 1;
            }
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (j > i)
                    {
                        tmp = macierzU[j, i] / macierzU[i, i];
                        macierzL[j, i] = tmp;
                        for (var k = 0; k < n; k++)
                        {
                            macierzU[j, k] = macierzU[j, k] - tmp * macierzU[i, k];
                        }
                    }
                }
            }
            return macierzL;
        }

        //public static void RozkladLU(double[,] macierz)
        //{
        //    if (macierz.GetLength(0) != macierz.GetLength(1))
        //    {
        //        throw new ArgumentException("Macierz nie jest kwadratowa");
        //    }

        //    int n = macierz.GetLength(0);
        //    double tmp = 0;
        //    double[,] macierzU = new double[n, n];
        //    double[,] macierzL = new double[n, n];

        //    for (var i = 0; i < n; i++)
        //    {
        //        for (var j = 0; j < n; j++)
        //        {
        //            macierzU[i, j] = macierz[i, j];
        //        }
        //        macierzL[i, i] = 1;
        //    }
        //    for (var i = 0; i < n; i++)
        //    {
        //        for (var j = 0; j < n; j++)
        //        {
        //            if (j > i)
        //            {
        //                tmp = macierzU[j, i] / macierzU[i, i];
        //                macierzL[j, i] = tmp;
        //                for (var k = 0; k < n; k++)
        //                {
        //                    macierzU[j, k] = macierzU[j, k] - tmp * macierzU[i, k];
        //                }
        //            }
        //        }
        //    }
        //    Console.WriteLine("Macierz wejsciowa:");
        //    Macierz.Wypisz(macierz);
        //    Console.WriteLine("======================");
        //    Console.WriteLine("Macierz U:");
        //    Macierz.Wypisz(macierzU);
        //    Console.WriteLine("======================");
        //    Console.WriteLine("Macierz L:");
        //    Macierz.Wypisz(macierzL);
        //    Console.WriteLine("======================");
        //    Console.WriteLine("Sprawdzenie L X U:");
        //    Macierz.Wypisz(Macierz.Przemnoz(macierzL, macierzU));
        //}

        public static void RozwiazLU(double[,] macierzWspl, double[] macierzWyrazowWolnych)
        {
            double[,] macierzU = GetUpper(macierzWspl);
            double[,] macierzL = GetLower(macierzWspl);
            int n = macierzWspl.GetLength(0);
            double tmp = 0;
            double[] x = new double[n];
            double[] y = new double[n];

            y = RozwiazMacierzL(macierzL, macierzWyrazowWolnych);
            x = RozwiazMacierzU(macierzU, y);

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine("y" + (i + 1) + "= " + y[i]);
            }
            Console.WriteLine("==============");
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + x[i]);
            }
        }

        public static double[] RozwiazMacierzL(double[,] macierzL, double[] macierzWyrazowWolnych)
        {
            int n = macierzL.GetLength(0);
            double[] x = new double[n];

            x[0] = macierzWyrazowWolnych[0] / macierzL[0, 0];
            double tmp;
            for (int i = 1; i < n; i++)
            {
                tmp = 0;
                for (int j = 0; j < i; j++)
                {
                    tmp += macierzL[i, j] * x[j];
                }
                x[i] = macierzWyrazowWolnych[i] - tmp;
            }

            return x;
        }

        public static double[] RozwiazMacierzU(double[,] macierzU, double[] macierzWyrazowWolnych)
        {
            int n = macierzU.GetLength(0);
            double[] x = new double[n];
            double tmp;

            for (int k = n - 1; k >= 0; k--)
            {
                tmp = 0;
                for (int j = k + 1; j < n; j++)
                {
                    tmp += macierzU[k, j] * x[j];
                }
                x[k] = (macierzWyrazowWolnych[k] - tmp) / macierzU[k, k];
            }

            return x;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            double[,] macierz = { { 2, -1, -2 }, { -4, 6, 3 }, { -4, -2, 8 } };
            double[,] macierzWspl =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            double[] macierzWyrazowWolnych = { 56, 62, -10, 14, 28 };
            Macierz.Wypisz(LU.GetUpper(macierz));
            Console.WriteLine("===================");
            Macierz.Wypisz(LU.GetLower(macierz));
            Console.WriteLine("===================");
            Macierz.Wypisz(Macierz.Przemnoz(LU.GetLower(macierz), LU.GetUpper(macierz)));

            LU.RozwiazLU(macierzWspl, macierzWyrazowWolnych);
        }
    }
}