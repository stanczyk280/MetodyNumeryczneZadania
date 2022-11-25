using OperacjeMacierzy;

namespace Wyznaczniki
{
    public static class Sarrus
    {
        public static double WyznacznikSarrus(double[,] macierz)
        {
            double detSar = 0;
            if (macierz.GetLength(0) == 2 && macierz.GetLength(1) == 2)
            {
                detSar = macierz[0, 0] * macierz[1, 1] - macierz[0, 1] * macierz[1, 0];
            }
            else
            {
                for (var i = 0; i < 3; i++)
                {
                    detSar += macierz[0, i] * (macierz[1, (i + 1) % 3] * macierz[2, (i + 2) % 3]
                        - macierz[1, (i + 2) % 3] * macierz[2, (i + 1) % 3]);
                }
            }
            return detSar;
        }
    }
}