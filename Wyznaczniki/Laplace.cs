using OperacjeMacierzy;

namespace Wyznaczniki
{
    public static class Laplace
    {
        public static double RozwiniecieLaplace(double[,] macierz)
        {
            int n = macierz.GetLength(0);
            double detLap = 0;
            double[,] macierzHelper = new double[n - 1, n - 1];
            if (n == 1)
            {
                return macierz[0, 0];
            }
            if (n == 2)
            {
                detLap = macierz[0, 0] * macierz[1, 1] - macierz[1, 0] * macierz[0, 1];
                return detLap;
            }
            for (var i = 0; i < n; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    for (var k = 0; k < i; k++)
                    {
                        macierzHelper[j - 1, k] = macierz[j, k];
                    }
                    for (var k = i + 1; k < n; k++)
                    {
                        macierzHelper[j - 1, k - 1] = macierz[j, k];
                    }
                }
                double temp_det = RozwiniecieLaplace(macierzHelper);
                detLap += (Convert.ToBoolean(i & 1) ? -1 : 1) * macierz[0, i] * temp_det;
            }
            return detLap;
        }
    }
}