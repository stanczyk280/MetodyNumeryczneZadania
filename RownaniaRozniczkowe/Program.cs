using RownaniaRozniczkowe;
using ScottPlot.Plottable;
using ScottPlot;
using System.Drawing;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("cw4 RK1");
        cw4.Print(cw4.RK1(0, 60, 550, 1));
        ScatterPlot spltCw4RK1 = PlotLinear.CreateScatterPlot(cw4.RK1(0, 60, 550, 1), Color.Green, "RK1");

        Console.WriteLine("==================================");
        Console.WriteLine("cw4 RK2");
        cw4.Print(cw4.RK2(0, 60, 550, 1));
        ScatterPlot spltCw4RK2 = PlotLinear.CreateScatterPlot(cw4.RK2(0, 60, 550, 1), Color.Goldenrod, "RK1");

        Console.WriteLine("==================================");
        Console.WriteLine("cw4 RK2MidPoint");
        cw4.Print(cw4.RK2MidPoint(0, 60, 550, 1));
        ScatterPlot spltCw4RK2MidPoint = PlotLinear.CreateScatterPlot(cw4.RK2MidPoint(0, 60, 550, 1), Color.Crimson, "RK1");

        Console.WriteLine("==================================");
        Console.WriteLine("cw4 RK4");
        cw4.Print(cw4.RK4(0, 60, 550, 1));
        ScatterPlot spltCw4RK4 = PlotLinear.CreateScatterPlot(cw4.RK4(0, 60, 550, 1), Color.Indigo, "RK1");

        Console.WriteLine("==================================");

        Console.WriteLine("cw5 RK1");
        cw4.Print(cw5.RK1(0, 40, 541, 1));
        ScatterPlot spltCw5RK1 = PlotLinear.CreateScatterPlot(cw5.RK1(0, 40, 541, 1), Color.Green, "RK1");

        Console.WriteLine("==================================");
        Console.WriteLine("cw5 RK2");
        cw4.Print(cw5.RK2(0, 40, 541, 1));
        ScatterPlot spltCw5RK2 = PlotLinear.CreateScatterPlot(cw5.RK2(0, 40, 541, 1), Color.Goldenrod, "RK2");

        Console.WriteLine("==================================");
        Console.WriteLine("cw5 RK2 Midpoint");
        cw4.Print(cw5.RK2MidPoint(0, 40, 541, 1));
        ScatterPlot spltCw5RK2MidPoint = PlotLinear.CreateScatterPlot(cw5.RK2MidPoint(0, 40, 541, 1), Color.Crimson, "RK2MidPoint");

        Console.WriteLine("==================================");
        Console.WriteLine("cw5 RK4");
        cw4.Print(cw5.RK4(0, 40, 541, 1));
        ScatterPlot spltCw5RK4 = PlotLinear.CreateScatterPlot(cw5.RK4(0, 40, 541, 1), Color.Indigo, "RK4");

        Plot pltCw4 = PlotLinear.CreatePlot("Temperatura ciała po 60s wykres zależności temperatury od czasu", "T[K]", "t[s]", 0, 60, 300, 600);
        Plot pltCw5 = PlotLinear.CreatePlot("Wysokosc Rakiety Falcon9 po 40s wykres zależności wysokości od czasu", "H[km]", "t[s]", 0, 45, 0, 6);

        pltCw4.Add(spltCw4RK1);
        pltCw4.Add(spltCw4RK2);
        pltCw4.Add(spltCw4RK2MidPoint);
        pltCw4.Add(spltCw4RK4);
        pltCw4.SaveFig("C:\\Users\\barte\\Desktop\\" + "cw4" + ".png");

        pltCw5.Add(spltCw5RK1);
        pltCw5.Add(spltCw5RK2);
        pltCw5.Add(spltCw5RK2MidPoint);
        pltCw5.Add(spltCw5RK4);
        pltCw5.SaveFig("C:\\Users\\barte\\Desktop\\" + "cw5" + ".png");
    }
}