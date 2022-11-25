using OperacjeMacierzy;
using Wyznaczniki;

namespace MetodaCramera
{
    public static class Cramer
    {
        public static void RozwiazCramer(double[,] wspl)
        {
            //deklaruje w ten sposób dla wygody i przejrzystości
            double[,] d = new double[,]
            {
                { wspl[0, 0], wspl[0, 1], wspl[0, 2] },
                { wspl[1, 0], wspl[1, 1], wspl[1, 2] },
                { wspl[2, 0], wspl[2, 1], wspl[2, 2] },
             };

            double[,] d1 = new double[,]
            {
                { wspl[0,3], wspl[0,1], wspl[0,2] },
                { wspl[1,3], wspl[1,1], wspl[1,2] },
                { wspl[2,3], wspl[2,1], wspl[2,2] },
            };
            double[,] d2 = new double[,]
            {
                { wspl[0,0], wspl[0,3], wspl[0,2] },
                { wspl[1,0], wspl[1,3], wspl[1,2] },
                { wspl[2,0], wspl[2,3], wspl[2,2] },
            };

            double[,] d3 = new double[,]
            {
                { wspl[0,0], wspl[0,1], wspl[0,3] },
                { wspl[1,0], wspl[1,1], wspl[1,3] },
                { wspl[2,0], wspl[2,1], wspl[2,3] },
            };

            double D = Laplace.RozwiniecieLaplace(d);
            double D1 = Laplace.RozwiniecieLaplace(d1);
            double D2 = Laplace.RozwiniecieLaplace(d2);
            double D3 = Laplace.RozwiniecieLaplace(d3);

            if (D != 0)
            {
                double x = D1 / D;
                double y = D2 / D;
                double z = D3 / D;
                Console.WriteLine("x = {0:F3}", x);
                Console.WriteLine("y = {0:F3}", y);
                Console.WriteLine("z = {0:F3}", z);
                return;
            }
            if (D1 == 0 && D2 == 0 && D3 == 0)
            {
                Console.WriteLine("Nieskonczona ilosc rozwiazan");
            }
            else if (D1 != 0 || D2 != 0 || D3 != 0)
            {
                Console.WriteLine("Brak rozwiazan");
            }
        }

        internal static class Program
        {
            private static void Main(string[] args)
            {
                double[,] wspl = {
                { 5, -2, 3, 21 },
                { -2, 3, 1, -4 },
                { -1, 2, 3, 5 }};
                Cramer.RozwiazCramer(wspl);
            }
        }
    }
}