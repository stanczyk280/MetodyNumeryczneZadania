using OdwracanieMacierzy;
using OperacjeMacierzy;

namespace MetodaMacierzyOdwrotnej
{
    public static class RozwiazMacierzOdwrotna
    {
        public static void Rozwiaz(double[,] macierzWspl, double[,] macierzWyrazowWolnych)
        {
            Console.WriteLine("Macierz wspolczynnikow:");
            Macierz.Wypisz(macierzWspl);
            Console.WriteLine();
            Console.WriteLine("Macierz wyrazow wolnych:");
            Macierz.Wypisz(macierzWyrazowWolnych);
            Console.WriteLine();
            Console.WriteLine("Odwrcona macierz wspolczynnikow:");
            double[,] macierzWsplOdwrotna = MacierzOdwrotna.OdwrocMacierz(macierzWspl);
            Macierz.Wypisz(macierzWsplOdwrotna);
            Console.WriteLine();
            Console.WriteLine("Macierz wynikowa:");
            double[,] macierzWynikowa = Macierz.Przemnoz(macierzWsplOdwrotna, macierzWyrazowWolnych);
            Macierz.Wypisz(macierzWynikowa);
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            double[,] macierzWspl = { { 5, -2, 3 }, { -2, 3, 1 }, { -1, 2, 3 } };
            double[,] macierzWyrazowWolnych = { { 21 }, { -4 }, { 5 } };

            RozwiazMacierzOdwrotna.Rozwiaz(macierzWspl, macierzWyrazowWolnych);
        }
    }
}