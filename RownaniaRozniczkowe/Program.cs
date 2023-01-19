using RownaniaRozniczkowe;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("cw4 RK1");
        cw4.Print(cw4.RK1(0, 60, 550, 1));
        Console.WriteLine("==================================");
        Console.WriteLine("cw4 RK4");
        cw4.Print(cw4.RK4(0, 60, 550, 1));
    }
}