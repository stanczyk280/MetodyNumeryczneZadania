﻿using Calki;
using EliminacjaGaussa;
using Interpolacja;
using Logarytm_e;
using MetodaCramera;
using MetodaMacierzyOdwrotnej;
using MetodyNumeryczneZadania;
using OdwracanieMacierzy;
using OperacjeMacierzy;
using Pivotting;
using Pochodne;
using RozkladLU;
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
            Console.WriteLine("8) Metoda Macierzy Odwrotnej");
            Console.WriteLine("9) Eliminacja Gaussa i Eliminacja Gaussa-Jordana");
            Console.WriteLine("10) Odwróć macierz za pomocą eliminacji gaussa");
            Console.WriteLine("11) Pivotting w eliminacji gaussa");
            Console.WriteLine("12) Rozkład LU");
            Console.WriteLine("13) Rozwiązywanie układu równań za pomocą rozkładu LU");
            Console.WriteLine("14) Odwróć macierz za pomocą rozkładu LU");
            Console.WriteLine("15) Wyznacznik macierzy za pomocą rozkładu LU");
            Console.WriteLine("16) Zakoncz");
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
                    Console.Clear();
                    LaunchMetodaMacierzyOdwrotnej();
                    ReturnToMenu();
                    return true;

                case "9":
                    Console.Clear();
                    LaunchGaussJordan();
                    ReturnToMenu();
                    return true;

                case "10":
                    Console.Clear();
                    LaunchOdwrocMacierzGauss();
                    ReturnToMenu();
                    return true;

                case "11":
                    Console.Clear();
                    LaunchPivotGauss();
                    ReturnToMenu();
                    return true;

                case "12":
                    Console.Clear();
                    LaunchRozkladLU();
                    ReturnToMenu();
                    return true;

                case "13":
                    Console.Clear();
                    LaunchRozwiazLU();
                    ReturnToMenu();
                    return true;

                case "14":
                    Console.Clear();
                    LaunchOdwrocMacierzLU();
                    ReturnToMenu();
                    return true;

                case "15":
                    Console.Clear();
                    LaunchWyznacznikLU();
                    ReturnToMenu();
                    return true;

                case "16":
                    Console.Clear();
                    LaunchInterpolacja();
                    ReturnToMenu();
                    return true;

                case "17":
                    Console.Clear();
                    LaunchPochodne();
                    ReturnToMenu();
                    return true;

                case "18":
                    Console.Clear();
                    LaunchCalki();
                    ReturnToMenu();
                    return true;

                case "25":
                    Console.WriteLine("exiting...");
                    return false;

                default:
                    return true;
            }
        }

        private static void LaunchCalki()
        {
            int dokladnosc = 1000;
            double[] wagi2 = { 1.0, 1.0 };
            double[] wezly2 = { -0.577350269, 0.577350269 };
            double[] wagi3 = { 5.0 / 9.0, 8.0 / 9.0, 5.0 / 9.0 };
            double[] wezly3 = { -0.774596669, 0.0, 0.774596669 };
            double[] wagi4 = { 0.347854845, 0.652145155, 0.652145155, 0.347854845 };
            double[] wezly4 = { -0.861136312, -0.339981044, 0.339981044, 0.861136312 };
            Console.WriteLine("Dokladnosc calkowania: " + dokladnosc);
            Console.WriteLine("===============================================================");
            Console.WriteLine("Metoda prostokatow:");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow left point:");
            Console.WriteLine(Calka.MetodaProstokatowLeftPoint(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow right point:");
            Console.WriteLine(Calka.MetodaProstokatowRightPoint(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow mid point:");
            Console.WriteLine(Calka.MetodaProstokatowMidPoint(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  trapezow:");
            Console.WriteLine(Calka.MetodaTrapezow(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  Simpsona:");
            Console.WriteLine(Calka.MetodaSimpsona(Funkcje.Custom3, -1, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow:");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow left point:");
            Console.WriteLine(Calka.MetodaProstokatowLeftPoint(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow right point:");
            Console.WriteLine(Calka.MetodaProstokatowRightPoint(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow mid point:");
            Console.WriteLine(Calka.MetodaProstokatowMidPoint(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  trapezow:");
            Console.WriteLine(Calka.MetodaTrapezow(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  Simpsona:");
            Console.WriteLine(Calka.MetodaSimpsona(Funkcje.Custom4, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow:");
            Console.WriteLine();
            Console.WriteLine("Metoda prostokatow left point:");
            Console.WriteLine(Calka.MetodaProstokatowLeftPoint(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow right point:");
            Console.WriteLine(Calka.MetodaProstokatowRightPoint(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine("Metoda prostokatow mid point:");
            Console.WriteLine(Calka.MetodaProstokatowMidPoint(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  trapezow:");
            Console.WriteLine(Calka.MetodaTrapezow(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda  Simpsona:");
            Console.WriteLine(Calka.MetodaSimpsona(Funkcje.Custom5, 0, 1, dokladnosc));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda gl:");
            Console.WriteLine("Cwiczenie:1");
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom3, 0, 1, 2, wagi2, wezly2));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom3, 0, 1, 3, wagi3, wezly3));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom3, 0, 1, 4, wagi4, wezly4));
            Console.WriteLine("Cwiczenie:3");
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom5, 0, 1, 2, wagi2, wezly2));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom5, 0, 1, 3, wagi3, wezly3));
            Console.WriteLine(Calka.MetodaGaussaLegrande(Funkcje.Custom5, 0, 1, 4, wagi4, wezly4));
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda GaussaZlozona:");
            Console.WriteLine("Cwiczenie:1");
            Console.WriteLine(Calka.MetodaGaussaZlozona(Funkcje.Custom3, 0, 1, 2, 5, wagi2, wezly2));
            Console.WriteLine("Cwiczenie:3");
            Console.WriteLine(Calka.MetodaGaussaZlozona(Funkcje.Custom5, 0, 1, 2, 5, wagi2, wezly2));
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Metoda stohastyczna:");
            Console.WriteLine(Calka.MetodaStohastyczna(Funkcje.Custom3, -1, 1, dokladnosc));
        }

        private static void LaunchPochodne()
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

        private static void LaunchInterpolacja()
        {
            //[1,x,x^2,x^3]
            double[,] macierzBaza2 = { { 1, 0, 0, 0 }, { 1, 1.5, 2.25, 3.375 }, { 1, 3, 9, 27 }, { 1, 4, 16, 64 } };
            //[1,x,cosx,sinx]
            double[,] macierzBaza1 = { { 1, 0, 1, 0 }, { 1, 1.5, 0.0707372016677029, 0.9974949866040544 }, { 1, 3, -0.9899924966004454, 0.1411200080598672 }, { 1, 4, -0.6536436208636119, -0.7568024953079282 } };
            double[] wektor = { 2, 3, 1, 3 };
            //chyba baza 1 jest zle skonstruowana
            double[] wynik1 = MetodyInterpolacji.Interpolacja(macierzBaza1, wektor);
            double[] wynik2 = MetodyInterpolacji.Interpolacja(macierzBaza2, wektor);
            Console.WriteLine("Baza: [1, x, cosx, sinx]");
            Console.Write("[ ");
            for (var i = 0; i < wynik1.Length; i++)
            {
                Console.Write("{0:F5}" + " ", wynik1[i]);
            }
            Console.Write("]");
            Console.WriteLine("\n");
            Console.WriteLine("Baza: [1,x,cosx,sinx]");
            Console.Write("[ ");
            for (var i = 0; i < wynik2.Length; i++)
            {
                Console.Write("{0:F5}" + " ", wynik2[i]);
            }
            Console.Write("]");
        }

        private static void LaunchOdwrocMacierzGauss()
        {
            double[,] macierz =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            Macierz.Wypisz(Gauss.OdwrocMacierzGauss(macierz));
        }

        private static void LaunchOdwrocMacierzLU()
        {
            double[,] macierz =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };

            Console.WriteLine();
            Macierz.Wypisz(LU.OdwrocMacierzLU(macierz));
        }

        private static void ReturnToMenu()
        {
            Console.WriteLine("\nKliknij dowolny przycisk aby powrócić do menu");
            Console.ReadLine();
            Console.Clear();
            DisplayMenu();
        }

        private static void LaunchPivotGauss()
        {
            double[,] macierzWspl =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            double[] macierzWyrazowWolnych = { 56, 62, -10, 14, 28 };

            double[] x1 = Pivot.PivotMacierzGauss(macierzWspl, macierzWyrazowWolnych);
            for (var i = 0; i < x1.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + x1[i]);
            }
        }

        private static void LaunchWyznacznikLU()
        {
            double[,] macierz =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            Console.WriteLine("Macierz: ");
            Macierz.Wypisz(macierz);
            Console.WriteLine("Wyznacznik macierzyA= {0:F3}", LU.WyznacznikLU(macierz));
        }

        private static void LaunchRozkladLU()
        {
            double[,] macierz =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            Console.WriteLine("Macierz: ");
            Macierz.Wypisz(macierz);
            Console.WriteLine();
            Console.WriteLine("Macierz U");
            Macierz.Wypisz(LU.GetUpper(macierz));
            Console.WriteLine();
            Console.WriteLine("Macierz L");
            Macierz.Wypisz(LU.GetLower(macierz));
            Console.WriteLine();
        }

        private static void LaunchRozwiazLU()
        {
            double[,] macierzWspl =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            double[] macierzWyrazowWolnych = { 56, 62, -10, 14, 28 };
            Console.WriteLine("Macierz wspołczynników: ");
            Macierz.Wypisz(macierzWspl);
            Console.WriteLine();
            Console.WriteLine("Macierz wyrazów wolnych: ");
            for (var i = 0; i < macierzWyrazowWolnych.Length; i++)
            {
                Console.WriteLine(macierzWyrazowWolnych[i]);
            }
            Console.WriteLine();
            LU.RozwiazLU(macierzWspl, macierzWyrazowWolnych);
        }

        private static void LaunchMetodaMacierzyOdwrotnej()
        {
            double[,] macierzWspl = { { 5, -2, 3 }, { -2, 3, 1 }, { -1, 2, 3 } };
            double[,] macierzWyrazowWolnych = { { 21 }, { -4 }, { 5 } };

            RozwiazMacierzOdwrotna.Rozwiaz(macierzWspl, macierzWyrazowWolnych);
        }

        private static void LaunchGaussJordan()
        {
            Console.WriteLine("Macierz wpsolczynnikow: ");
            double[,] macierzWspl =
            {
                { -1, 2, -3, 3, 5 },
                { 8, 0, 7, 4, -1 },
                { -3, 4, -3, 2, -2 },
                { 8, -3, -2, 1, 2 },
                { -2, -1, -6, 9, 0 }
            };
            Console.WriteLine();
            Console.WriteLine("Macierz wyrazow wolnych");
            double[] macierzWyrazowWolnych = { 56, 62, -10, 14, 28 };
            int n = macierzWspl.GetLength(0);
            Console.WriteLine();
            Console.WriteLine("Eliminacja Gaussa: ");
            double[] x1 = Gauss.RozwiazGauss(macierzWspl, macierzWyrazowWolnych, n);
            for (var i = 0; i < x1.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + x1[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Eliminacja GaussaJordana");
            double[] x2 = GaussJordan.RozwiazGaussJordan(macierzWspl, macierzWyrazowWolnych, n);
            for (var i = 0; i < x2.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + "= " + x2[i]);
            }
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