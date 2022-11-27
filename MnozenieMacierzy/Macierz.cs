namespace OperacjeMacierzy
{
    public static class Macierz
    {
        public static double[,] StworzMacierzJednostkowa(int rows, int cols)
        {
            double[,] macierzJednostkowa = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    macierzJednostkowa[i, i] = 1;
                }
            }
            return macierzJednostkowa;
        }

        public static void Wypisz(double[,] macierz)
        {
            for (var i = 0; i < macierz.GetLength(0); i++)
            {
                for (var j = 0; j < macierz.GetLength(1); j++)
                {
                    Console.Write(("{0:F3}").PadRight(5, ' '), macierz[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static double[,] Transponuj(double[,] macierz)
        {
            double[,] macierzT = new double[macierz.GetLength(1), macierz.GetLength(0)];
            for (var i = 0; i < macierzT.GetLength(0); i++)
            {
                for (var j = 0; j < macierzT.GetLength(1); j++)
                {
                    macierzT[j, i] = macierz[i, j];
                }
            }
            return macierzT;
        }

        public static double[,] Przemnoz(double[,] macierzA, double[,] macierzB)
        {
            int Arows = macierzA.GetLength(0);
            int Acols = macierzA.GetLength(1);
            int Bcols = macierzB.GetLength(1);
            double[,] macierzWynikowa = new double[Arows, Bcols];
            for (var i = 0; i < Arows; i++)
            {
                for (var j = 0; j < Bcols; j++)
                {
                    for (var k = 0; k < Acols; k++)
                    {
                        macierzWynikowa[i, j] += macierzA[i, k] * macierzB[k, j];
                    }
                }
            }
            return macierzWynikowa;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            double[,] macierzA = { { -1, 4, 2, -2 }, { 1, 2, -3, 0 }, { -1, 0, 0, 5 } };
            double[,] macierzB = { { 2, -1 }, { 1, 3 }, { -2, 0 }, { 0, -4 } };
            Console.WriteLine("Macierz A:");
            Macierz.Wypisz(macierzA);
            Console.WriteLine();
            Console.WriteLine("Macierz B:");
            Macierz.Wypisz(macierzB);
            Console.WriteLine();
            Console.WriteLine("Wynik mnożenia macierzy:");
            Macierz.Wypisz(Macierz.Przemnoz(macierzA, macierzB));
        }
    }
}