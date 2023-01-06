using static Pochodne.PierwszaPochodna;

namespace Pochodne
{
    public static class PierwszaPochodna
    {
        public delegate double OneArgFunc(double x);

        public delegate double TwoArgFunc(double x, double y);

        public static double Pochodna(OneArgFunc Func, double x, double dx)
            => (Func(x + dx) - Func(x)) / dx;

        public static double PochodnaX(TwoArgFunc Func, double x, double y, double dx)
            => (Func(x + dx, y) - Func(x, y)) / dx;

        public static double PochodnaY(TwoArgFunc Func, double x, double y, double dy)
            => (Func(x, y + dy) - Func(x, y)) / dy;

        public static double DwuPunktoweRozniceZwykle(OneArgFunc Func, double x, double h)
            => (Func(x + h) - Func(x)) / h;

        public static double DwuPunktoweRozniceCentralne(OneArgFunc Func, double x, double h)
            => (Func(x + h) - Func(x - h)) / 2 * h;

        public static double TrzyPunktoweRozniceZwykle(OneArgFunc Func, double x, double h)
            => ((-3) * Func(x) + 4 * Func(x + h) - Func(x + 2 * h)) / (2 * h);
    }

    public static class DrugaPochodna
    {
        public delegate double OneArgFunc(double x);

        public delegate double TwoArgFunc(double x, double y);

        public static double TrzyPunktoweRozniceZwykle(OneArgFunc Func, double x, double h)
            => (Func(x) - 2 * Func(x + h) + Func(x + 2 * h)) / (h * h);

        public static double TrzyPunktoweRozniceCentralne(OneArgFunc Func, double x, double h)
            => (Func(x - h) - 2 * Func(x) + Func(x + h)) / (h * h);
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            const double dx = 0.00001;
            double h = 0.001;

            Console.WriteLine("Pochodne Pierwszego Stopnia");
            Console.WriteLine();
            Console.WriteLine("Pochodna funkcji: f(x)=xsin(x^2)+1 w punkcie x=0");
            Console.WriteLine("f'(0)= " + PierwszaPochodna.Pochodna(Funkcje.Custom1, 0, dx));

            Console.WriteLine("Pochodna funkcji: f(x)=xsin(x^2)+1 w punkcie x=1");
            Console.WriteLine("f'(1)= " + PierwszaPochodna.Pochodna(Funkcje.Custom1, 1, dx));

            Console.WriteLine("=================================================================================");

            Console.WriteLine("Dwu punktowe roznice zwykle: f(x)=3x^3−2x^2+1  w punkcie x=0.75");
            Console.WriteLine("f'(0.75)= " + PierwszaPochodna.DwuPunktoweRozniceZwykle(Funkcje.Custom2, 0.75, h));

            Console.WriteLine("Dwu punktowe roznice centralne: f(x)=3x^3−2x^2+1  w punkcie x=0.75 : ");
            Console.WriteLine("f'(0.75)= " + PierwszaPochodna.DwuPunktoweRozniceCentralne(Funkcje.Custom2, 0.75, h));

            Console.WriteLine("Trzy punktowe roznice zwykle: f(x)=3x^3−2x^2+1  w punkcie x=0.75 : ");
            Console.WriteLine("f'(0.75)= " + PierwszaPochodna.TrzyPunktoweRozniceZwykle(Funkcje.Custom2, 0.75, h));

            Console.WriteLine("=================================================================================");

            Console.WriteLine("Dwu punktowe roznice zwykle: f(x)=xsin(x^2)+1  w punkcie x=1");
            Console.WriteLine("f'(1)= " + PierwszaPochodna.DwuPunktoweRozniceZwykle(Funkcje.Custom1, 1, h));
            Console.WriteLine("Dwu punktowa roznice centralne: f(x)=xsin(x^2)+1  w punkcie x=1 : ");
            Console.WriteLine("f'(1)= " + PierwszaPochodna.DwuPunktoweRozniceCentralne(Funkcje.Custom1, 1, h));

            Console.WriteLine("=================================================================================");

            Console.WriteLine("Dwu punktowe roznice centralne: f(x)=e^x  w punkcie x=0 : ");
            Console.WriteLine("f'(0)= " + PierwszaPochodna.DwuPunktoweRozniceCentralne(Funkcje.Exp, 0, h));

            Console.WriteLine("Trzy punktowe roznice zwykle: f(x)=e^x  w punkcie x=0 : ");
            Console.WriteLine("f'(0)= " + PierwszaPochodna.TrzyPunktoweRozniceZwykle(Funkcje.Exp, 0, h));
            Console.WriteLine();

            Console.WriteLine("=================================================================================");

            Console.WriteLine("Pochodne drugiego Stopnia");
            Console.WriteLine();

            Console.WriteLine("Trzy punktowe roznice zwykle: f(x)=3x^3−2x^2+1  w punkcie x=0.75 : ");
            Console.WriteLine("f''(0)= " + DrugaPochodna.TrzyPunktoweRozniceZwykle(Funkcje.Custom2, 0.75, h));

            Console.WriteLine("Trzy punktowe roznice centralne: f(x)=3x^3−2x^2+1  w punkcie x=0.75 : ");
            Console.WriteLine("f''(0)= " + DrugaPochodna.TrzyPunktoweRozniceCentralne(Funkcje.Custom2, 0.75, h));
        }
    }
}