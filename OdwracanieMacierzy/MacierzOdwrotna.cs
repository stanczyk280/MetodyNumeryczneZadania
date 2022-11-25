using OperacjeMacierzy;
using Wyznaczniki;

namespace OdwracanieMacierzy
{
    public static class MacierzOdwrotna
    {
        public static double[,] ZnajdzMinor(double[,] macierz, int rowN, int colN)
        {
            int minorRow;
            int minorCol;
            double[,] minor = new double[macierz.GetLength(0) - 1, macierz.GetLength(1) - 1];
            for (var i = 0; i < macierz.GetLength(0); i++)
            {
                minorRow = i;
                if (i > rowN)
                {
                    minorRow--;
                }
                for (var j = 0; j < macierz.GetLength(1); j++)
                {
                    minorCol = j;
                    if (j > colN)
                    {
                        minorCol--;
                    }
                    if (i != rowN && j != colN)
                    {
                        minor[minorRow, minorCol] = macierz[i, j];
                    }
                }
            }
            return minor;
        }

        public static double[,] OdwrocMacierz(double[,] macierzA)
        {
            double detA = Laplace.RozwiniecieLaplace(macierzA);
            double[,] macierzB = new double[macierzA.GetLength(0), macierzA.GetLength(1)];
            int counter = 1;
            if (detA == 0)
            {
                Console.WriteLine("Macierz jest osobliwa, wiec nie istnieje jej macierz odwrotna");
                return null;
            }

            for (var i = 0; i < macierzA.GetLength(0); i++)
            {
                for (var j = 0; j < macierzA.GetLength(0); j++)
                {
                    if (counter % 2 == 0)
                    {
                        macierzB[i, j] = Laplace.RozwiniecieLaplace(ZnajdzMinor(macierzA, i, j)) * (-1);
                    }
                    else
                    {
                        macierzB[i, j] = Laplace.RozwiniecieLaplace(ZnajdzMinor(macierzA, i, j));
                    }
                    counter++;
                }
            }
            double[,] macierzBT = Macierz.Transponuj(macierzB);

            for (var i = 0; i < macierzBT.GetLength(0); i++)
            {
                for (var j = 0; j < macierzBT.GetLength(0); j++)
                {
                    macierzBT[i, j] = macierzBT[i, j] / detA;
                }
            }
            return macierzBT;
        }

        public static class Program
        {
            public static void Main(string[] args)
            {
                double[,] macierz = { { 1, 3, 2 }, { 4, -1, 2 }, { 1, -1, 0 } };

                Macierz.Wypisz(MacierzOdwrotna.OdwrocMacierz(macierz));
            }
        }
    }
}