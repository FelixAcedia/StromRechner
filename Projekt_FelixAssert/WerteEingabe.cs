using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_FelixAssert
{
    [Version("F. Assert", classVersion = "1.0.0")]
    internal class WerteEingabe
    {
        public static double GetDouble()
        {

            ConsoleKeyInfo taste;

            StringBuilder meineEingabe = new StringBuilder();
            // Achtung -> Syntax:
            // ich habe hier ein Objekt mit dem Namen "meineEingabe" 
            // vom Typ "Klasse StringBuilder" erzeugt
            // das Objekt meineEingabe ist in diesem Augenblick (bis auf EOS) noch leer!
            int pos = 0;
            bool ersterLauf = true;
            bool kommaGesetzt = false;
            bool eGesetzt = false;
            do
            {
                if (meineEingabe.ToString().Contains(','))
                    kommaGesetzt = true;
                else
                    kommaGesetzt = false;
                if (meineEingabe.ToString().Contains('e'))
                    eGesetzt = true;
                else
                    eGesetzt = false;
                taste = Console.ReadKey(true);
                switch (taste.Key) // Kontrollstruktur
                {
                    case ConsoleKey.Backspace:
                        if (pos > 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            //Write: Console.Write(taste.KeyChar + " " + taste.KeyChar);
                            meineEingabe.Remove(--pos, 1);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (pos > 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            pos--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (pos < meineEingabe.Length)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                            pos++;
                        }
                        break;
                    case ConsoleKey.E:
                    case ConsoleKey.D0:
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                    case ConsoleKey.OemMinus:
                    case ConsoleKey.OemComma:
                        if (pos < 1)
                            ersterLauf = true;
                        if ((Char.IsDigit(taste.KeyChar)) || (taste.Key == ConsoleKey.E && eGesetzt == false) ||
                            (taste.Key == ConsoleKey.OemMinus && ersterLauf == true) || (taste.Key == ConsoleKey.OemComma && kommaGesetzt == false))
                        {
                            // Methode Append() hängt Zeichen an das Ende des Objekts meineEingabe an!
                            Console.Write(taste.KeyChar);
                            if (pos > meineEingabe.Length - 1)
                                meineEingabe.Append(" ");
                            meineEingabe[pos++] = taste.KeyChar;
                            ersterLauf = false;
                        }
                        if (taste.Key == ConsoleKey.E)
                            ersterLauf = true;
                        break;
                }
            }
            while (taste.Key != ConsoleKey.Enter); //String ist durch EOS terminiert!
            if (meineEingabe.Length == 0)
                return 0;
            if (eGesetzt)
            {
                string[] pow = meineEingabe.ToString().Split('e');
                return Math.Round(double.Parse(pow[0]) * (Math.Pow(10, int.Parse(pow[1]))));
            }
            return double.Parse(meineEingabe.ToString());

        }
    }
}
