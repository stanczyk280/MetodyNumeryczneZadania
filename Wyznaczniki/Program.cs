using OperacjeMacierzy;

namespace Wyznaczniki
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            double[,] macierzA = { { 2, 7, -1, 3, 2 }, { 0, 0, 1, 0, 1 }, { -2, 0, 7, 0, 2 }, { -3, -2, 4, 5, 3 }, { 1, 0, 0, 0, 1 } };
            double[,] macierzB = { { 1, 3, 2 }, { 4, -1, 2 }, { 1, -1, 0 } };
            double[,] macierzC = { { 6, 4 }, { 5, -3 } };

            Console.WriteLine("Macierz A: ");
            Macierz.Wypisz(macierzA);
            Console.WriteLine();
            Console.WriteLine("Macierz B: ");
            Macierz.Wypisz(macierzB);
            Console.WriteLine();
            Console.WriteLine("Wyznacznik metodą Sarrusa dla macierzy nie większej niż 3x3: \n" +
                "det= " + Sarrus.WyznacznikSarrus(macierzB));

            Console.WriteLine("Wyznacznik macierzy A za pomocą rozwinięcia Laplace'a: \n"
                + "det= " + Laplace.RozwiniecieLaplace(macierzA));
            Console.WriteLine("Wyznacznik macierzy B za pomocą rozwinięcia Laplace'a: \n"
                + "det= " + Laplace.RozwiniecieLaplace(macierzB));
            Console.WriteLine("Wyznacznik macierzy C za pomocą rozwinięcia Laplace'a: \n"
                + "det= " + Laplace.RozwiniecieLaplace(macierzC));
        }
    }
}