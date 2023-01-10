using System.Data;

namespace Projekt_FelixAssert
{
    [Version("F. Assert", programVersion = "1.0.0.1")]
    internal class Program
    {
        private static string[] menupoints = { "Spannung", "Wiederstand", "Stromstaerke" };
        static KonsoleMenu menu;

        [STAThread]
        static void Main(string[] args)
        {
            ConsoleKeyInfo taste = Console.ReadKey();
            double ergebnis= 0;
            string endzeichen = "";
            while (true)
            {
                while (taste.Key != ConsoleKey.Escape)
                {
                    menu = new KonsoleMenu(menupoints);
                    KonsoleMenu.CenteredVoidConsoleMenu();
                    taste = Console.ReadKey();
                    if (KonsoleMenu.konsolePoints.ContainsKey((int)taste.KeyChar - 49))
                        break;
                    KonsoleMenu.CenteredWriteCursour("Ungültige eingabe", Console.CursorTop + 1);
                    Thread.Sleep(200);
                    Console.Clear();
                }
                if (taste.Key != ConsoleKey.Escape)
                {
                    switch (KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49])
                    {
                        case "Spannung":
                            ergebnis = Rechner.Spannung();
                            endzeichen = " A";
                            break;
                        case "Wiederstand":
                            ergebnis = Rechner.Wiederstand();
                            endzeichen = " Ohm";
                            break;
                        case "Stromstaerke":
                            ergebnis = Rechner.Stromstaerke();
                            endzeichen = " V";
                            break;
                    }
                    Console.WriteLine($"\n{KonsoleMenu.konsolePoints[(int)taste.KeyChar - 49]}: {Math.Round(ergebnis, 2) + endzeichen}");
                }
                Console.WriteLine("Rechner verlassen? [ESC/ any key]");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}