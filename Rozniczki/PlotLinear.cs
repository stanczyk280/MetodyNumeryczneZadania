using ScottPlot.Plottable;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.SymbolStore;

namespace Rozniczki
{
    public static class PlotLinear
    {
        //    plt.SaveFig("C:\\Users\\barte\\Desktop\\" + file + ".png");

        //z kazdej metody tworzony jest sctrplot
        //tworzony plot
        //plot + sctrplt

        public static Plot CreatePlot(string title, string yaxis, string xaxis, double xMin, double xMax, double yMin, double yMax)
        {
            var plt = new Plot(1600, 1200);
            plt.Title(title, true, Color.Black, 24, "Open Sans");
            plt.YAxis.Label(yaxis, Color.Black, size: 20, fontName: "Open Sans");
            plt.XAxis.Label(xaxis, Color.Black, size: 20, fontName: "Open Sans");
            plt.YAxis.TickLabelStyle(fontSize: 15);
            plt.XAxis.TickLabelStyle(fontSize: 15);
            plt.SetAxisLimits(xMin, xMax, yMin, yMax);
            plt.Legend();
            return plt;
        }

        public static ScatterPlot CreateScatterPlot(Dictionary<double, double> functionParams, Color color, string label)
        {
            double[] xArray = functionParams.Keys.ToArray();
            double[] yArray = functionParams.Values.ToArray();
            var splt = new ScatterPlot(xArray, yArray);
            splt.Color = color;
            splt.MarkerSize = 0;
            splt.LineWidth = 2;
            splt.Label = label;
            return splt;
        }
    }
}