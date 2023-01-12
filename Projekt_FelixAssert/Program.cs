using System.Data;

namespace Projekt_FelixAssert
{
    [Version("F. Assert", programVersion = "1.0.4.2")]
    internal class Program
    {
        /// <summary>
        /// Eine Variable für die Allgemeine Tasten übergabe im Programm.
        /// </summary>
        public static ConsoleKeyInfo taste;
        /// <summary>
        /// Ein Array mit den Listenpunkten für das Start Menu.
        /// </summary>
        private static string[] startMenupoints = { "Rechner", "Credits" };
        /// <summary>
        /// Ein Array mit den Listenpunkten für das Rechner Menu.
        /// </summary>
        private static string[] rechnerMenupoints = { "Spannung (U = R * I)", "Wiederstand (R = U / I)", "Stromstaerke (I = U / R)" };
        /// <summary>
        /// Ein Bool welcher zeigt ob der Program ablauf auf die Escape-Sicherheitsabfrage warten soll.
        /// </summary>
        private static bool ESCwait = false;
        /// <summary>
        /// Ein Thread der dauerhaft abfragt ob die Taste "Escape" gedrückt wurden und nachdem eine erneute Sicherheitsabfrage zum Schließen des Programmes macht.
        /// </summary>
        private static Thread ClosingApplicationSupervisitor = new Thread(new ThreadStart(() =>
        {
            while (true)
                if (taste.Key == ConsoleKey.Escape)
                {
                    ESCwait = true;
                    WaitForESC();
                    Console.WriteLine("Rechner verlassen? [ESC/ any key]");
                    taste = Console.ReadKey();
                    if (taste.Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else
                        ESCwait = false;
                }
        }));
        [STAThread]
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ClosingApplicationSupervisitor.Start();
            while (true)
            {
                CreateNewMenu(startMenupoints);
                if (!KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49))
                    KonsoleMenu.CenteredWriteCursour("Ungültige eingabe", Console.CursorTop + 1);
                else
                {
                    switch (KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49])
                    {
                        case "Rechner":
                            RechnerMenu(rechnerMenupoints);
                            break;
                        case "Credits":
                            string[] links = { "https://github.com/FelixAcedia" };
                            KonsoleMenu.CenteredCredits("Felix Assert", links);
                            taste = Console.ReadKey(true);
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Eine Methode die den ablauf des Programmes stoppt und wartet bis die Escape Sicherheitsabfrage endet.
        /// </summary>
        private static void WaitForESC()
        {
            Thread.Sleep(200);
            Console.Clear();
            if (ESCwait)
                while (ESCwait)
                    Thread.Sleep(200);
        }
        /// <summary>
        /// Eine Methode für das Erstellen des Rechner Menu.
        /// </summary>
        /// <param name="rechnerMenupoints"></param>
        private static void RechnerMenu(string[] rechnerMenupoints)
        {
            double ergebnis = 0;
            string endzeichen = "";
            while (true)
            {
                CreateNewMenu(rechnerMenupoints);
                if (KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49))
                    break;
            } 
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
                taste = Console.ReadKey();
                if (!KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49) && taste.Key != ConsoleKey.Escape)
                    break;
                WaitForESC();
            }
        }
        /// <summary>
        /// Eine Methode zum Erstellen eines neuen Menus.
        /// </summary>
        /// <param name="menuPoints"></param>
        private static void CreateNewMenu(string[] menuPoints)
        {
            KonsoleMenu menu = new KonsoleMenu(menuPoints);
            Console.Write("Credits: Felix Assert");
            KonsoleMenu.CenteredVoidConsoleMenu();
            taste = Console.ReadKey(true);
            WaitForESC();
        }
    }
}