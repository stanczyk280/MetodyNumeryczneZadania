namespace EliminacjaGaussa
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Macierz wpsolczynnikow: ");
            double[,] macierzWspl =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            Console.WriteLine();
            Console.WriteLine("Macierz wyrazow wolnych");
            double[] macierzWyrazowWolnych = { 56, 62, -10, 14, 28 };
            int n = macierzWspl.GetLength(0);
            Console.WriteLine();
            Console.WriteLine("Eliminacja Gaussa: ");
            double[] x1 = Gauss.RozwiazGauss(macierzWspl, macierzWyrazowWolnych, n);
            for (var i = 0; i < x1.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + x1[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Eliminacja GaussaJordana");
            double[] x2 = GaussJordan.RozwiazGaussJordan(macierzWspl, macierzWyrazowWolnych, n);
            for (var i = 0; i < x2.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + x2[i]);
            }
        }
    }
}