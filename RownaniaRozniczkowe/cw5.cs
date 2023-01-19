using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RownaniaRozniczkowe
{
    public static class cw5
    {
        public static double WysokoscRakiety(double m)
            => Math.Log(541 / m);

        public static void Print(Dictionary<double, double> functionParams)
        {
            foreach (var kvp in functionParams)
            {
                Console.WriteLine("x= {0:F6}, y= {1:F6}", kvp.Key, kvp.Value);
            }
        }
    }
}