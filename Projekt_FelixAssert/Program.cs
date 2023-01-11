using System.Data;

namespace Projekt_FelixAssert
{
    [Version("F. Assert", programVersion = "1.0.3.2")]
    internal class Program
    {
        private static string[] startMenupoints = { "Rechner", "Credits" };
        private static string[] rechnerMenupoints = { "Spannung (U = R * I)", "Wiederstand (R = U / I)", "Stromstaerke (I = U / R)" };
        public static ConsoleKeyInfo taste;

        [STAThread]
        static void Main(string[] args)
        {
            bool ESCwait = false;
            Thread ClosingApplicationSupervisitor = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (taste.Key == ConsoleKey.Escape)
                    {
                        ESCwait = true;
                        WaitForESC(false);
                        Console.WriteLine("Rechner verlassen? [ESC/ any key]");
                        taste = Console.ReadKey();
                        if(taste.Key == ConsoleKey.Escape)
                            Environment.Exit(0);
                        else
                            ESCwait = false;
                    }
                }
            }));
            ClosingApplicationSupervisitor.Start();
            while (true)
            {
                CreateNewMenu(startMenupoints, ESCwait);
                switch(KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49])
                {
                    case "Rechner":
                        RechnerMenu(ESCwait);
                        break;
                }
            }
        }
        private static void WaitForESC(bool ESCwait)
        {
            Thread.Sleep(200);
            Console.Clear();
            if (ESCwait)
                while (ESCwait)
                    Thread.Sleep(200);
        }
        private static void RechnerMenu(bool ESCwait)
        {
            double ergebnis = 0;
            string endzeichen = "";
            while (!KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49))
                CreateNewMenu(rechnerMenupoints, ESCwait);
            
            while (true)
            {
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
                Console.WriteLine($"\n{KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49]}: {(Math.Round(ergebnis, 3) == 0 ? ergebnis : Math.Round(ergebnis, 3)) + endzeichen}");

                Console.WriteLine("Drücke...");
                for (int i = 0; i < KonsoleMenu.konsolePoints.Count; i++)
                {
                    Console.WriteLine($"\tfür {KonsoleMenu.konsolePoints[i]}: {i + 1}");
                }
                Console.WriteLine("\nRechner verlassen mit ESC und um zum Menue zu kommen drücke beliebige taste. [ESC/ any key]");
                taste = Console.ReadKey();
                if (!KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49) && taste.Key != ConsoleKey.Escape)
                    break;
                WaitForESC(ESCwait);
            }
        }
        private static void CreateNewMenu(string[] menuPoints, bool ESCwait)
        {
            KonsoleMenu menu = new KonsoleMenu(menuPoints);
            KonsoleMenu.CenteredVoidConsoleMenu();
            taste = Console.ReadKey(true);

            if (!KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49))
                KonsoleMenu.CenteredWriteCursour("Ungültige eingabe", Console.CursorTop + 1);
            WaitForESC(ESCwait);
        }
    }
}