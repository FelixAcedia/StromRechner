using System.Data;

namespace Projekt_FelixAssert
{
    [Version("F. Assert", programVersion = "1.0.1.2")]
    internal class Program
    {
        private static string[] menupoints = { "Spannung (U = R * I)", "Wiederstand (R = U / I)", "Stromstaerke (I = U / R)" };
        static KonsoleMenu menu;
        public static ConsoleKeyInfo taste;

        [STAThread]
        static void Main(string[] args)
        {
            taste = Console.ReadKey();
            double ergebnis= 0;
            string endzeichen = "";
            bool ESCwait = false;
            Thread ClosingApplicationSupervisitor = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (taste.Key == ConsoleKey.Escape)
                    {
                        ESCwait = true;
                        Thread.Sleep(200);
                        Console.Clear();
                        Console.WriteLine("Rechner verlassen? [ESC/ any key]");
                        taste = Console.ReadKey();
                        if(taste.Key == ConsoleKey.Escape)
                        {
                            Environment.Exit(0);
                        }
                        else
                            ESCwait = false;
                    }
                }
            }));
            ClosingApplicationSupervisitor.Start();
            while (true)
            {
                while (true)
                {
                    menu = new KonsoleMenu(menupoints);
                    KonsoleMenu.CenteredVoidConsoleMenu();
                    taste = Console.ReadKey();

                    if (KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49))
                        break;
                    KonsoleMenu.CenteredWriteCursour("Ungültige eingabe", Console.CursorTop + 1);
                    Thread.Sleep(1000);
                    if (ESCwait)
                    {
                        while (ESCwait)
                        {
                            Thread.Sleep(200);
                        }
                    }
                    Console.Clear();

                }
                switch (KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49])
                {
                    case "Spannung (U = R * I)":
                        ergebnis = Rechner.Spannung(KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49]);
                        endzeichen = " A";
                        break;
                    case "Wiederstand (R = U / I)":
                        ergebnis = Rechner.Wiederstand(KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49]);
                        endzeichen = " Ohm";
                        break;
                    case "Stromstaerke (I = U / R)":
                        ergebnis = Rechner.Stromstaerke(KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49]);
                        endzeichen = " V";
                        break;
                }
                Console.WriteLine($"\n{KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49]}: {Math.Round(ergebnis, 2) + endzeichen}");


                Console.WriteLine("Rechner verlassen? [ESC/ any key]");
                taste = Console.ReadKey();
                Thread.Sleep(200);
                if (ESCwait)
                {
                    while (ESCwait)
                    {
                        Thread.Sleep(200);
                    }
                }
            }
        }
    }
}