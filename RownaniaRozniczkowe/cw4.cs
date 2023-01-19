using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RownaniaRozniczkowe
{
    public static class cw4
    {
        public static double TempCiala(double temp)
            => (-0.0245) * (temp - 300);

        public static void Print(Dictionary<double, double> functionParams)
        {
            foreach (var kvp in functionParams)
            {
                Console.WriteLine("x= {0:F6}, y= {1:F6}", kvp.Key, kvp.Value);
            }
        }

        public static Dictionary<double, double> RK1(double t0, double tk, double temp, double h)
        {
            List<double> listTemp = new List<double>();
            List<double> listTime = new List<double>();

            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            double tempN = 0.0;

            while (t0 < tk)
            {
                listTemp.Add(temp);
                listTime.Add(t0);
                tempN = temp + (h * TempCiala(temp));
                temp = tempN;
                t0 += h;
            }

            for (var i = 0; i < listTemp.Count; i++)
            {
                functionParams.Add(listTemp[i], listTime[i]);
            }

            return functionParams;
        }

        public static Dictionary<double, double> RK4(double t0, double tk, double temp, double h)
        {
            List<double> listTemp = new List<double>();
            List<double> listTime = new List<double>();

            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            double kT1;
            double kT2;
            double kT3;
            double kT4;

            while (t0 <= tk)
            {
                listTemp.Add(temp);
                listTime.Add(t0);

                kT1 = h * TempCiala(temp);

                kT2 = h * TempCiala(temp + (0.5 * kT1));

                kT3 = h * TempCiala(temp + (0.5 * kT2));

                kT4 = h * TempCiala(temp + kT3);

                temp = temp + (1.0 / 6.0) * (kT1 + 2 * kT2 + 2 * kT3 + kT4); ;

                t0 += h;
            }

            for (var i = 0; i < listTemp.Count; i++)
            {
                functionParams.Add(listTemp[i], listTime[i]);
            }

            return functionParams;
        }
    }
}