using Logarytm_e;
using MetodaCramera;
using MetodyNumeryczneZadania;
using OdwracanieMacierzy;
using OperacjeMacierzy;
using Silnia;
using Wyznaczniki;

namespace ControlMenu
{
    public static class Menu
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Wybierz zadanie:");
            Console.WriteLine("1) Zespolona");
            Console.WriteLine("2) Silnia");
            Console.WriteLine("3) Logarytm");
            Console.WriteLine("4) Mnozenie Macierzy");
            Console.WriteLine("5) Wyznaczniki Macierzy");
            Console.WriteLine("6) Odwroc Macierz");
            Console.WriteLine("7) Metoda Crammera");
            Console.WriteLine("8) Zakoncz");
        }

        public static bool MainMenu()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    LaunchZespolona();
                    ReturnToMenu();
                    return true;

                case "2":
                    Console.Clear();
                    LaunchSilnia();
                    ReturnToMenu();
                    return true;

                case "3":
                    Console.Clear();
                    LaunchLogarytm_e();
                    ReturnToMenu();
                    return true;

                case "4":
                    Console.Clear();
                    LaunchMacierzMnozenie();
                    ReturnToMenu();
                    return true;

                case "5":
                    Console.Clear();
                    LaunchMacierzWyznacznik();
                    ReturnToMenu();
                    return true;

                case "6":
                    Console.Clear();
                    LaunchOdwrocMacierz();
                    ReturnToMenu();
                    return true;

                case "7":
                    Console.Clear();
                    LaunchCramer();
                    ReturnToMenu();
                    return true;

                case "8":
                    Console.WriteLine("exiting...");
                    return false;

                default:
                    return true;
            }
        }

        private static void ReturnToMenu()
        {
            Console.WriteLine("\nKliknij dowolny przycisk aby powrócić do menu");
            Console.ReadLine();
            Console.Clear();
            DisplayMenu();
        }

        private static void LaunchCramer()
        {
            double[,] wspl = {
                { 5, -2, 3, 21 },
                { -2, 3, 1, -4 },
                { -1, 2, 3, 5 }};
            Console.WriteLine("Macierz zawierajaca wspolczynniki: ");
            Macierz.Wypisz(wspl);
            Console.WriteLine();
            Cramer.RozwiazCramer(wspl);
        }

        private static void LaunchOdwrocMacierz()
        {
            double[,] macierz = { { 1, 3, 2 }, { 4, -1, 2 }, { 1, -1, 0 } };
            Console.WriteLine("Macierz A: ");
            Macierz.Wypisz(macierz);
            Console.WriteLine();
            Console.WriteLine("Odwrotnosc macierzy A:");
            Macierz.Wypisz(MacierzOdwrotna.OdwrocMacierz(macierz));
        }

        private static void LaunchMacierzWyznacznik()
        {
            double[,] macierzA = { { 2, 7, -1, 3, 2 }, { 0, 0, 1, 0, 1 }, { -2, 0, 7, 0, 2 }, { -3, -2, 4, 5, 3 }, { 1, 0, 0, 0, 1 } };
            double[,] macierzB = { { 1, 3, 2 }, { 4, -1, 2 }, { 1, -1, 0 } };

            Console.WriteLine("Macierz A: ");
            Macierz.Wypisz(macierzA);
            Console.WriteLine();
            Console.WriteLine("Macierz B: ");
            Macierz.Wypisz(macierzB);
            Console.WriteLine();
            Console.WriteLine("Wyznacznik metodą Sarrusa dla macierzy nie większej niż 3x3: \n" +
                "det= " + Sarrus.WyznacznikSarrus(macierzB));

            Console.WriteLine("Wyznacznik macierzy A za pomocą rozwinięcia Laplace'a: \n"
                + "det= " + Laplace.RozwiniecieLaplace(macierzA));
            Console.WriteLine("Wyznacznik macierzy B za pomocą rozwinięcia Laplace'a: \n"
                + "det= " + Laplace.RozwiniecieLaplace(macierzB));
        }

        private static void LaunchMacierzMnozenie()
        {
            double[,] macierzA = { { -1, 4, 2, -2 }, { 1, 2, -3, 0 }, { -1, 0, 0, 5 } };
            double[,] macierzB = { { 2, -1 }, { 1, 3 }, { -2, 0 }, { 0, -4 } };
            Console.WriteLine("Macierz A:");
            Macierz.Wypisz(macierzA);
            Console.WriteLine();
            Console.WriteLine("Macierz B:");
            Macierz.Wypisz(macierzB);
            Console.WriteLine();
            Console.WriteLine("Wynik mnożenia macierzy:");
            Macierz.Wypisz(Macierz.Przemnoz(macierzA, macierzB));
        }

        private static void LaunchLogarytm_e()
        {
            Logarytm l1 = new Logarytm();
            Console.Write("Logarytm e =" + l1.ObliczLogarytm(5));
        }

        private static void LaunchSilnia()
        {
            Console.WriteLine("Wprowadz stopien silni: ");
            int stopien = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("16b silnia: " + Silnia.Silnia.ObliczSilnieShort(stopien));
            Console.WriteLine("32b silnia: " + Silnia.Silnia.ObliczSilnieInt(stopien));
            Console.WriteLine("64b silnia: " + Silnia.Silnia.ObliczSilnieLong(stopien));
        }

        private static void LaunchZespolona()
        {
            Zespolona z1 = new Zespolona(1.23456789123456789, 4 / 3);
            Zespolona z2 = new Zespolona(1, 2);
            Zespolona wynik = new Zespolona();

            wynik = z1 + z2;
            wynik.Wypisz();
            wynik = z1 * z2;
            wynik.Wypisz();
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Menu.DisplayMenu();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu.MainMenu();
            }
        }
    }
}