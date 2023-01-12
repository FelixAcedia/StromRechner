using static System.Net.Mime.MediaTypeNames;

namespace Projekt_FelixAssert
{
    /// <summary>
    /// Eine Klasse mit Methoden zur Erstellung verschiedener von vschiedenen Konsolen Menüen.
    /// </summary>
    [Version("F. Assert", classVersion = "1.0.0")]
    internal class KonsoleMenu
    {
        public KonsoleMenu(ConsoleColor bg = ConsoleColor.White, ConsoleColor fg = ConsoleColor.Black) { Bg = bg; Fg = fg; Console.Clear(); }
        public KonsoleMenu(string[] mp, ConsoleColor bg = ConsoleColor.White, ConsoleColor fg = ConsoleColor.Black) { Mp = mp; Bg = bg; Fg = fg; Console.Clear(); }
        public static Dictionary<int, string> konsolePoints = new Dictionary<int, string>();
        private static string[] mp;
        public static string[] Mp 
        { 
            get { return mp; }
            set 
            { 
                mp = value;
                for(int i = 0; i < mp.Length; i++)
                    konsolePoints[i]=mp[i];
            }
        }
        public static ConsoleColor Bg { get => Console.BackgroundColor; set => Console.BackgroundColor = value; }
        public static ConsoleColor Fg { get => Console.ForegroundColor; set => Console.ForegroundColor = value; }
        public static void CenteredCredits(string name, int y = 2)
        {
            CenteredWriteCursour("Credits", y += 2);
            CenteredWriteCursour(name, y += 2);
            CenteredWriteCursour("-  ESC fuer Programm Abbruch und Beliebige Taste um zum Menu zu kommen -", y += 2);
        }
        public static void CenteredCredits(string name, string[] links, int y = 2, int a = 2)
        {
            CenteredWriteCursour("Credits", y += a);
            CenteredWriteCursour(name, y+=a);
            foreach(var link in links)
                CenteredWriteCursour(link, y += a);
            CenteredWriteCursour("-  ESC fuer Programm Abbruch und Beliebige Taste um zum Menu zu kommen -", y += a);
        }
        public static void WriteCursour(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
        }
        public static void CenteredWriteCursour(string text, int y)
        {
            Console.SetCursorPosition(Console.WindowWidth/2 - text.Length/2, y);
            Console.WriteLine(text);
        }
        /// <summary>
        /// Eine Methode zur Erstellung eines Konsolen Menües mit Rückgabewert. Parameter y: Stellt die Y-kordinate dar, Parameter a: Stellt den Allgemeinen abstand der Menu Punkte dar, Parameter x: Stellt die X-Kordinate dar.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="a"></param>
        public static ConsoleKeyInfo ConsoleMenu(int x = 3, int y = 2, int a = 2)
        {
            VoidConsoleMenu(x, y, a);
            return Console.ReadKey();
        }
        /// <summary>
        /// Eine Methode zur Erstellung eines Konsolen Menües ohne Rückgabewert. Parameter y: Stellt die Y-kordinate dar, Parameter a: Stellt den Allgemeinen abstand der Menu Punkte dar, Parameter x: Stellt die X-Kordinate dar.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="a"></param>
        public static void VoidConsoleMenu(int x = 3, int y = 2, int a = 2)
        {
            WriteCursour("Konsolen Menue", x, y);
            for (int i = 0; i < Mp.Length; i++)
            {
                y += a;
                WriteCursour($"{Mp[i]} <{i + 1}>", x, y);
            }
            WriteCursour("-  ESC fuer Programm Abbruch  -", x, y += a);
            Console.SetCursorPosition(x, y + 4);
            Console.Write("Ihre Eingabe: ");
        }
        /// <summary>
        /// Eine Methode zur Erstellung eines zentrierten Konsolen Menües mit Rückgabewert. Parameter y: Stellt die Y-kordinate dar, Parameter a: Stellt den Allgemeinen abstand der Menu Punkte dar.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="a"></param>
        public static ConsoleKeyInfo CenteredConsoleMenu(int y = 2, int a = 2)
        {
            CenteredVoidConsoleMenu(y, a);
            return Console.ReadKey();
        }
        /// <summary>
        /// Eine Methode zur Erstellung eines zentrierten Konsolen Menües ohne Rückgabewert. Parameter y: Stellt die Y-kordinate dar, Parameter a: Stellt den Allgemeinen abstand der Menu Punkte dar.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="a"></param>
        public static void CenteredVoidConsoleMenu(int y = 2, int a = 2)
        {
            CenteredWriteCursour("Konsolen Menue", y);
            for (int i = 0; i < Mp.Length; i++)
            {
                y += a;
                CenteredWriteCursour($"{Mp[i]} <{i + 1}>", y);
            }
            CenteredWriteCursour("-  ESC fuer Programm Abbruch  -", y += a);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 14/2, y + 4);
            Console.Write("Ihre Eingabe: ");
        }
    }
}
