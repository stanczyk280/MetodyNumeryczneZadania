using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RownaniaNieliniowe
{
    public static class Funkcje
    {
        public static double Sqrt(double x)
            => Math.Sqrt(x);

        // x kwadrat
        public static double Square(double x)
            => x * x;

        //Sinus x
        public static double Sinx(double x)
            => Math.Sin(x);

        //funkcja liniowa dwóch ziennych
        public static double MultipleFunctionOfxy(double x, double y)
            => x * y;

        // dowolna funkcja dwóch zmiennych
        public static double FunctiononOfx2y(double x, double y)
            => x * x * y;

        public static double Exp(double x)
            => Math.Exp(x);

        //f(x)=2x2+4x−1.0

        public static double F1(double x)
            => 2 * x * x + 4 * x - 1;

        //f(x)=xsin(x^2)+1
        public static double Custom1(double x)
            => x * Math.Sin(x * x) + 1;

        //f(x)=3x^3−2x^2+1
        public static double Custom2(double x)
            => 3 * x * x * x - 2 * x * x + 1;

        public static double Custom3(double x)
            => 4 * x * x * x + 5 * x * x + 1;

        public static double Custom4(double x)
            => (2 / (Math.Sqrt(Math.PI))) * Math.Exp(-(x * x));

        public static double Custom5(double x)
            => Math.Cos(x) + Math.Exp(x) + Math.Tan(x);
    }
}