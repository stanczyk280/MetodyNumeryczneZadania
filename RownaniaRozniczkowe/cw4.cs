using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RownaniaRozniczkowe
{
    public static class cw4
    {
        public static double PredkoscChlodzenia(double T)
            => -0.0245 * (T - 300);

        public static void Print(Dictionary<double, double> functionParams)
        {
            foreach (var kvp in functionParams)
            {
                Console.WriteLine("x= {0:F6}, y= {1:F6}", kvp.Key, kvp.Value);
            }
        }

        public static Dictionary<double, double> RK1(double t0, double tk, double T, double h)
        {
            double Tn;

            List<double> listT = new List<double>();
            List<double> listTime = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            while (t0 <= tk)
            {
                listT.Add(T);
                listTime.Add(t0);

                Tn = T + (h * PredkoscChlodzenia(T));
                T = Tn;
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listTime[i], listT[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK2(double t0, double tk, double T, double h)
        {
            double k1;
            double k2;

            List<double> listT = new List<double>();
            List<double> listTime = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            while (t0 <= tk)
            {
                listT.Add(T);
                listTime.Add(t0);

                k1 = PredkoscChlodzenia(T);
                k2 = PredkoscChlodzenia(T + k1);

                T += (0.5) * (k1 + k2);
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listTime[i], listT[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK2MidPoint(double t0, double tk, double T, double h)
        {
            double k1;
            double k2;

            List<double> listT = new List<double>();
            List<double> listTime = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            while (t0 <= tk)
            {
                listT.Add(T);
                listTime.Add(t0);

                k1 = PredkoscChlodzenia(T);
                k2 = PredkoscChlodzenia(T + (0.5 * k1));

                T += k2;
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listTime[i], listT[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK4(double t0, double tk, double T, double h)
        {
            double k1;
            double k2;
            double k3;
            double k4;

            List<double> listT = new List<double>();
            List<double> listTime = new List<double>();
            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            while (t0 <= tk)
            {
                listT.Add(T);
                listTime.Add(t0);

                k1 = PredkoscChlodzenia(T);
                k2 = h * PredkoscChlodzenia(T + (0.5 * k1));
                k3 = h * PredkoscChlodzenia(T + (0.5 * k2));
                k4 = h * PredkoscChlodzenia(T + k3);

                T += (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);
                t0 += h;
            }

            for (var i = 0; i < listT.Count; i++)
            {
                functionParams.Add(listTime[i], listT[i]);
            }

            return functionParams;
        }
    }
}