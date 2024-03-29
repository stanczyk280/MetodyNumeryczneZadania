﻿using ScottPlot;
using System.Drawing;

namespace TlumienieSprezyny
{
    public static class PlotLinear
    {
        public static void Plot(List<double> x, List<double> y, string title, string yaxis, string xaxis, double xMin, double xMax, double yMin, double yMax, string file)
        {
            double[] xArray = x.ToArray();
            double[] yArray = y.ToArray();

            var plt = new Plot(1600, 1200);
            var splt = new ScottPlot.Plottable.ScatterPlot(yArray, xArray);
            splt.Color = Color.Navy;
            splt.MarkerSize = 0;
            splt.LineWidth = 2;
            plt.Add(splt);
            plt.Title(title, true, Color.Black, 24, "Open Sans");
            //plt.XLabel("t[s]");
            //plt.YLabel("x[m]");
            plt.YAxis.Label(yaxis, Color.Black, size: 24, fontName: "Open Sans");
            plt.XAxis.Label(xaxis, Color.Black, size: 24, fontName: "Open Sans");
            plt.YAxis.TickLabelStyle(fontSize: 15);
            plt.XAxis.TickLabelStyle(fontSize: 15);
            plt.SetAxisLimits(xMin, xMax, yMin, yMax);

            plt.SaveFig("C:\\Users\\barte\\Desktop\\zadaniemenu\\" + file + ".png");
        }

        public static void DoublePlot(List<double> x, List<double> y, List<double> z, List<double> w, string title, string yaxis, string xaxis, double xMin, double xMax, double yMin, double yMax, string file)
        {
            double[] xArray = x.ToArray();
            double[] yArray = y.ToArray();
            double[] zArray = z.ToArray();
            double[] wArray = w.ToArray();

            var splt1 = new ScottPlot.Plottable.ScatterPlot(yArray, xArray);
            splt1.Color = Color.Green;
            splt1.MarkerSize = 0;
            splt1.LineWidth = 2;
            splt1.Label = "Euler";
            var splt2 = new ScottPlot.Plottable.ScatterPlot(wArray, zArray);
            splt2.Color = Color.Red;
            splt2.MarkerSize = 0;
            splt2.LineWidth = 2;
            splt2.Label = "RK4";

            var plt = new Plot(1600, 1200);
            plt.Add(splt1);
            plt.Add(splt2);
            plt.Title(title, true, Color.Black, 24, "Open Sans");
            plt.YAxis.Label(yaxis, Color.Black, size: 24, fontName: "Open Sans");
            plt.XAxis.Label(xaxis, Color.Black, size: 24, fontName: "Open Sans");
            plt.YAxis.TickLabelStyle(fontSize: 15);
            plt.XAxis.TickLabelStyle(fontSize: 15);
            plt.SetAxisLimits(xMin, xMax, yMin, yMax);
            plt.Legend();

            plt.SaveFig("C:\\Users\\barte\\Desktop\\zadaniemenu\\" + file + ".png");
        }
    }

    public static class Rozwiazanie
    {
        public static double F1(double t, double x, double z)
            => z;

        public static double F2(double t, double x, double z)
            => -2.0 * 1.8 * z - Math.Pow(10, 2) * x;

        public static string ConvertToReadable(double t, double x, double z)
        {
            string st = string.Format("{0:F6}", t);
            string sx = string.Format("{0:F6}", x);
            string sz = string.Format("{0:F6}", z);
            string final = "t: " + st + " x: " + sx + " z: " + sz;
            return final;
        }

        public static void CompareEulerRK4(double x0, double z0, double t0, double h, double tn)
        {
            double xn = 0.0;
            double zn = 0.0;
            double kx1 = 0.0;
            double kx2 = 0.0;
            double kx3 = 0.0;
            double kx4 = 0.0;
            double kz1 = 0.0;
            double kz2 = 0.0;
            double kz3 = 0.0;
            double kz4 = 0.0;
            List<double> listET = new List<double>();
            List<double> listEX = new List<double>();
            List<double> listEZ = new List<double>();
            List<double> listRT = new List<double>();
            List<double> listRX = new List<double>();
            List<double> listRZ = new List<double>();
            while (t0 <= tn)
            {
                listET.Add(t0);
                listEX.Add(x0);
                listEZ.Add(z0);

                xn = x0 + (h * F1(t0, x0, z0));
                //Console.WriteLine("{0:F6}, {0:F6}", t0, x0);
                x0 = xn;
                zn = z0 + (h * F2(t0, x0, z0));
                //Console.WriteLine("{0:F6}\t\n", z0);

                z0 = zn;
                t0 += h;
            }

            x0 = 1.0;
            z0 = 0.0;
            t0 = 0.0;
            tn = 6.0;
            xn = 0.0;
            zn = 0.0;

            while (t0 <= tn)
            {
                listRT.Add(t0);
                listRX.Add(x0);
                listRZ.Add(z0);

                kx1 = h * F1(t0, x0, z0);
                kz1 = h * F2(t0, x0, z0);

                kx2 = h * F1(t0 + (0.5 * h), x0 + (0.5 * kx1), z0 + (0.5 * kz1));
                kz2 = h * F2(t0 + (0.5 * h), x0 + (0.5 * kx1), z0 + (0.5 * kz1));

                kx3 = h * F1(t0 + (0.5 * h), x0 + (0.5 * kx2), z0 + (0.5 * kz2));
                kz3 = h * F2(t0 + (0.5 * h), x0 + (0.5 * kx2), z0 + (0.5 * kz2));

                kx4 = h * F1(t0 + h, x0 + kx3, z0 + kz3);
                kz4 = h * F2(t0 + h, x0 + kx3, z0 + kz3);

                x0 = x0 + (1.0 / 6.0) * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                z0 = z0 + (1.0 / 6.0) * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                t0 += h;
            }

            PlotLinear.DoublePlot
                (
                listEX, listET, listRX, listRT,
                "Wykres zależności amplitudy położenia od czasu (porównanie)",
                "x[m]", "t[s]",
                0, 5.0, -0.8, 1.2,
                "rk4EulerPlotxt"
                );
            PlotLinear.DoublePlot
                (
                listEZ, listET, listRZ, listRT,
                "Wykres zależności prędkości od czasu (porównanie)",
                "v[m/s]", "t[s]",
                0, 5.0, -8.0, 5.0,
                "rk4EulerPlotvt"
                );
        }

        public static void UseEulerMethod(double x0, double z0, double t0, double h, double tn)
        {
            double xn = 0.0;
            double zn = 0.0;
            List<double> listT = new List<double>();
            List<double> listX = new List<double>();
            List<double> listZ = new List<double>();
            List<string> wyniki = new List<string>();

            while (t0 <= tn)
            {
                listT.Add(t0);
                listX.Add(x0);
                listZ.Add(z0);

                wyniki.Add(ConvertToReadable(t0, x0, z0));
                xn = x0 + (h * F1(t0, x0, z0));
                //Console.WriteLine("{0:F6}, {0:F6}", t0, x0);
                x0 = xn;
                zn = z0 + (h * F2(t0, x0, z0));
                //Console.WriteLine("{0:F6}\t\n", z0);

                z0 = zn;
                t0 += h;
            }
            foreach (var wynik in wyniki)
            {
                Console.WriteLine(wynik);
            }
            File.WriteAllLines("C:\\Users\\barte\\Desktop\\zadaniemenu\\eulerwyniki.txt", wyniki);

            #region plotting

            PlotLinear.Plot
                (
                listX, listT,
                "Wykres zależności amplitudy położenia od czasu (metoda Eulera)",
                "x[m]", "t[s]",
                0, 5.0, -0.8, 1.2,
                "eulerPlotxt"
                );
            PlotLinear.Plot
                (
                listZ, listT,
                "Wykres zależności prędkości od czasu (metoda Eulera)",
                "v[m/s]", "t[s]",
                0, 5.0, -8.0, 5.0,
                "eulerPlotvt"
                );

            #endregion plotting
        }

        public static void UseRK4Method(double x0, double z0, double t0, double h, double tn)
        {
            double kx1 = 0.0;
            double kx2 = 0.0;
            double kx3 = 0.0;
            double kx4 = 0.0;
            double kz1 = 0.0;
            double kz2 = 0.0;
            double kz3 = 0.0;
            double kz4 = 0.0;

            List<double> listT = new List<double>();
            List<double> listX = new List<double>();
            List<double> listZ = new List<double>();
            List<string> wyniki = new List<string>();

            while (t0 <= tn)
            {
                listT.Add(t0);
                listX.Add(x0);
                listZ.Add(z0);

                wyniki.Add(ConvertToReadable(t0, x0, z0));
                kx1 = h * F1(t0, x0, z0);
                kz1 = h * F2(t0, x0, z0);

                kx2 = h * F1(t0 + (0.5 * h), x0 + (0.5 * kx1), z0 + (0.5 * kz1));
                kz2 = h * F2(t0 + (0.5 * h), x0 + (0.5 * kx1), z0 + (0.5 * kz1));

                kx3 = h * F1(t0 + (0.5 * h), x0 + (0.5 * kx2), z0 + (0.5 * kz2));
                kz3 = h * F2(t0 + (0.5 * h), x0 + (0.5 * kx2), z0 + (0.5 * kz2));

                kx4 = h * F1(t0 + h, x0 + kx3, z0 + kz3);
                kz4 = h * F2(t0 + h, x0 + kx3, z0 + kz3);

                x0 = x0 + (1.0 / 6.0) * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                z0 = z0 + (1.0 / 6.0) * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                t0 += h;
            }
            foreach (var wynik in wyniki)
            {
                Console.WriteLine(wynik);
            }
            File.WriteAllLines("C:\\Users\\barte\\Desktop\\zadaniemenu\\rk4wyniki.txt", wyniki);

            #region plotting

            PlotLinear.Plot
                (
                listX, listT,
                "Wykres zależności amplitudy położenia od czasu (metoda RK4)",
                "x[m]", "t[s]",
                0, 5.0, -0.8, 1.2,
                "rk4Plotxt"
                );
            PlotLinear.Plot
                (
                listZ, listT,
                "Wykres zależności prędkości od czasu (metoda RK4)",
                "v[m/s]", "t[s]",
                0, 5.0, -8.0, 5.0,
                "rk4Plotvt"
                );

            #endregion plotting
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            double x0 = 1.0;
            double z0 = 0.0;
            double t0 = 0.0;
            double tn = 6.0;
            double h = 0.01;

            Rozwiazanie.UseEulerMethod(x0, z0, t0, h, tn);
            Rozwiazanie.UseRK4Method(x0, z0, t0, h, tn);
            Rozwiazanie.CompareEulerRK4(x0, z0, t0, h, tn);
        }
    }
}