using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RownaniaRozniczkowe
{
    public static class cw5
    {
        public static double WysokoscRakiety(double m, double t)
            => 2.77 * (Math.Log(541 / (m - 1.26 * t)));

        public static void Print(Dictionary<double, double> functionParams)
        {
            foreach (var kvp in functionParams)
            {
                Console.WriteLine("x= {0:F6}, y= {1:F6}", kvp.Key, kvp.Value);
            }
        }

        public static Dictionary<double, double> RK1(double t0, double tk, double m, double h)
        {
            double H = 0;

            List<double> listH = new List<double>();
            List<double> listT = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            double HN = 0.0;

            while (t0 <= tk)
            {
                listH.Add(H);
                listT.Add(t0);
                HN = H + (h * WysokoscRakiety(m, t0));
                H = HN;
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listT[i], listH[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK2(double t0, double tk, double m, double h)
        {
            double k1;
            double k2;
            double H = 0;

            List<double> listH = new List<double>();
            List<double> listT = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            while (t0 <= tk)
            {
                listH.Add(H);
                listT.Add(t0);

                k1 = h * WysokoscRakiety(m, t0);
                k2 = h * WysokoscRakiety(m + k1, t0 + h);

                H += (0.5) * (k1 + k2);
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listT[i], listH[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK2MidPoint(double t0, double tk, double m, double h)
        {
            double k1;
            double k2;
            double H = 0;

            List<double> listH = new List<double>();
            List<double> listT = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            while (t0 <= tk)
            {
                listH.Add(H);
                listT.Add(t0);

                k1 = h * WysokoscRakiety(m, t0);
                k2 = h * WysokoscRakiety(m + (0.5 * k1), t0 + (0.5 * h));

                H += k2;
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listT[i], listH[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK4(double t0, double tk, double m, double h)
        {
            double k1;
            double k2;
            double k3;
            double k4;
            double H = 0;

            List<double> listH = new List<double>();
            List<double> listT = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            while (t0 <= tk)
            {
                listH.Add(H);
                listT.Add(t0);

                k1 = h * WysokoscRakiety(m, t0 + (0.5 * h));
                k2 = h * WysokoscRakiety(m + (0.5 * k1), t0 + (0.5 * h));
                k3 = h * WysokoscRakiety(m + (0.5 * k2), t0 + (0.5 * h));
                k4 = h * WysokoscRakiety(m + k3, t0 + h);

                H += (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listT[i], listH[i]);
            }

            return functionParams;
        }
    }
}