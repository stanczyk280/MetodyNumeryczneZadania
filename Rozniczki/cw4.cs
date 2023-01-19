using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozniczki
{
    public static class cw4
    {
        public delegate double TwoArgFunc(double x, double y);

        public static double TempCiala(double t, double temp, double chillSpeed)
            => temp - chillSpeed;

        public static double PredkoscChlodzenia(double temp)
            => (-0.0245) * (temp - 300);

        public static Dictionary<double, double> RK4(double t0, double tk, double temp, double chillSpeed, double h)
        {
            List<double> listTemp = new List<double>();
            List<double> listTime = new List<double>();
            List<string> wyniki = new List<string>();

            Dictionary<double, double> functionParams = new Dictionary<double, double>();

            double kT1;
            double kT2;
            double kT3;
            double kT4;
            double kt1;
            double kt2;
            double kt3;
            double kt4;
            double t = 0;

            while (t <= tk)
            {
                listTemp.Add(temp);
                listTime.Add(t);
                kT1 = h * TempCiala(t, temp, chillSpeed);
                kt1 = h * PredkoscChlodzenia(temp);

                kT2 = h * TempCiala(t + (0.5 * h), temp + (0.5 * kT1), chillSpeed + (0.5 * kt1));
                kt2 = h * PredkoscChlodzenia(temp + (0.5 * h));

                kT3 = h * TempCiala(t + (0.5 * h), temp + (0.5 * kT2), chillSpeed + (0.5 * kt2));
                kt3 = h * PredkoscChlodzenia(temp + (0.5 * h));

                kT4 = h * TempCiala(t * h, temp + kT3, chillSpeed + kt3);
                kt4 = h * PredkoscChlodzenia(temp * h);

                chillSpeed = chillSpeed + (1.0 / 6.0) * (kT1 + 2 * kT2 + 2 * kT3 + kT4);
                Console.WriteLine("next chill speed:" + chillSpeed);
                temp = temp + (1.0 / 6.0) * (kt1 + 2 * kt2 + 2 * kt3 + kt4);
                t += h;
            }

            for (var i = 0; i < listTemp.Count; i++)
            {
                functionParams.Add(listTemp[i], listTime[i]);
            }

            return functionParams;
        }
    }
}