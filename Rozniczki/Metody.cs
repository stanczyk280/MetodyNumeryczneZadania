using ScottPlot;
using ScottPlot.Plottable;
using ScottPlot.Renderable;
using System;
using System.Drawing;
using System.Net;
using System.Xml.Linq;

namespace Rozniczki
{
    public static class Metody
    {
        public delegate double TwoArgFunc(double x, double y);

        public static double F1(double x, double y)
            => -y - Math.Exp(-x);

        public static double F2(double x, double y)
            => -((-0.5) * Math.Pow(x, 4) + 4 * Math.Pow(x, 3) - 10 * Math.Pow(x, 2) + 8.5 * x + 1);

        public static double F3(double T, double y)
            => -(0.0245 * (T - 300));

        public static Dictionary<double, double> RK1(double a, double b, double y, double h, TwoArgFunc Func)
        {
            List<double> listX = new List<double>();
            List<double> listY = new List<double>();
            List<string> wyniki = new List<string>();

            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            double yn;
            double x = a;

            while (x <= b)
            {
                listX.Add(x);
                listY.Add(y);

                yn = y + Func(x, y) * h;
                y = yn;
                x += h;
            }

            for (var i = 0; i < listX.Count; i++)
            {
                functionParams.Add(listX[i], listY[i]);
            }
            foreach (var wynik in wyniki)
            {
                Console.WriteLine(wynik);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK2(double a, double b, double y, double h, TwoArgFunc Func)
        {
            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            double yn;
            double x = a;
            double k1;
            double k2;

            while (x <= b)
            {
                listX.Add(x);
                listY.Add(y);

                k1 = h * Func(x, y);
                k2 = h * Func(x + h, y + k1);
                yn = y + 0.5 * (k1 + k2);
                y = yn;
                x += h;
            }

            for (var i = 0; i < listX.Count; i++)
            {
                functionParams.Add(listX[i], listY[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK4(double a, double b, double y, double h, TwoArgFunc Func)
        {
            List<double> listX = new List<double>();
            List<double> listY = new List<double>();
            List<string> wyniki = new List<string>();

            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            double yn;
            double x = a;

            double k1 = 0.0;
            double k2 = 0.0;
            double k3 = 0.0;
            double k4 = 0.0;

            while (x <= b)
            {
                listX.Add(x);
                listY.Add(y);

                k1 = Func(x, y);
                k2 = h * Func(x + (0.5 * h), y + (0.5 * k1));
                k3 = h * Func(x + (0.5 * h), y + (0.5 * k2));
                k4 = h * Func(x + h, y + k3);

                yn = y + (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);
                y = yn;
                x += h;
            }

            for (var i = 0; i < listX.Count; i++)
            {
                functionParams.Add(listX[i], listY[i]);
            }

            return functionParams;
        }

        public static void Print(Dictionary<double, double> functionParams)
        {
            foreach (var kvp in functionParams)
            {
                Console.WriteLine("x= {0:F6}, y= {1:F6}", kvp.Key, kvp.Value);
            }
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            double h = 0.35;

            #region cw2

            Plot plt = PlotLinear.CreatePlot("cw1", "y", "x", 0, 5, -2, 2);
            ScatterPlot spltRK1 = PlotLinear.CreateScatterPlot(Metody.RK1(0, 4, 1, h, Metody.F1), Color.Navy, "RK1");
            ScatterPlot spltRK2 = PlotLinear.CreateScatterPlot(Metody.RK2(0, 4, 1, h, Metody.F1), Color.Crimson, "RK2");
            ScatterPlot spltRK4 = PlotLinear.CreateScatterPlot(Metody.RK4(0, 4, 1, h, Metody.F1), Color.Indigo, "RK4");

            Console.WriteLine("RK1");
            Metody.Print(Metody.RK1(0, 4, 1, h, Metody.F1));
            Console.WriteLine("===========================================");
            Console.WriteLine("RK2");
            Metody.Print(Metody.RK2(0, 4, 1, h, Metody.F1)); ;
            Console.WriteLine("===========================================");
            Console.WriteLine("RK4");
            Metody.Print(Metody.RK4(0, 4, 1, h, Metody.F1));
            Console.WriteLine("===========================================");

            plt.Add(spltRK1);
            plt.Add(spltRK2);
            plt.Add(spltRK4);
            plt.SaveFig("C:\\Users\\barte\\Desktop\\" + "cw1" + ".png");

            #endregion cw2

            #region cw3

            Plot plt2 = PlotLinear.CreatePlot("cw2", "y", "x", 0, 5, -11, 1.5);
            ScatterPlot splt2RK1 = PlotLinear.CreateScatterPlot(Metody.RK1(0, 4, 1, h, Metody.F2), Color.Navy, "RK1");
            ScatterPlot splt2RK2 = PlotLinear.CreateScatterPlot(Metody.RK2(0, 4, 1, h, Metody.F2), Color.Crimson, "RK2");
            ScatterPlot splt2RK4 = PlotLinear.CreateScatterPlot(Metody.RK4(0, 4, 1, h, Metody.F2), Color.Indigo, "RK4");

            Console.WriteLine("RK1");
            Metody.Print(Metody.RK1(0, 4, 1, h, Metody.F2));
            Console.WriteLine("===========================================");
            Console.WriteLine("RK2");
            Metody.Print(Metody.RK2(0, 4, 1, h, Metody.F2)); ;
            Console.WriteLine("===========================================");
            Console.WriteLine("RK4");
            Metody.Print(Metody.RK4(0, 4, 1, h, Metody.F2));
            Console.WriteLine("===========================================");

            plt2.Add(splt2RK1);
            plt2.Add(splt2RK2);
            plt2.Add(splt2RK4);
            plt2.SaveFig("C:\\Users\\barte\\Desktop\\" + "cw2" + ".png");

            #endregion cw3
        }
    }
}