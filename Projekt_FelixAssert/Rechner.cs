namespace Projekt_FelixAssert
{
    /// <summary>
    /// Eine Klasse für Rechnungsmethoden mit speziellen Regelungen.
    /// </summary>
    [Version("F. Assert", classVersion = "1.1.0")]
    internal class Rechner
    {
        private double u;
        /// <summary>
        /// Propertie für den Spannungswert.
        /// </summary>
        public static double U { get; set; }

        private double r;
        /// <summary>
        /// Propertie für den Wiederstandswert.
        /// </summary>
        public static double R { get; set; }

        private double i;
        /// <summary>
        /// Propetie für den Wert der Stromstärke.
        /// </summary>
        public static double I { get; set; }
        /// <summary>
        /// Eine Methode zur Eingabe des Spannungswertes.
        /// </summary>
        /// <returns></returns>
        private static double GetU()
        {
            Console.Write("\nBitte gib den Spannung ein: ");
            U = WerteEingabe.GetDouble();
            Console.Write(" A");
            return U;
        }
        /// <summary>
        /// Eine Methode zur Eingabe des Wiederstandswertes.
        /// </summary>
        /// <returns></returns>
        private static double GetR()
        {
            Console.Write("\nBitte gib die Wiederstand ein: ");
            R = WerteEingabe.GetDouble();
            Console.Write(" Ohm");
            if (R <= 0)
            {
                ClearLine(error: true);
                GetR();
            }
            return R;
        }
        /// <summary>
        /// Eine Methode zur Eingabe der Stromstärke.
        /// </summary>
        /// <returns></returns>
        private static double GetI()
        {
            Console.Write("\nBitte gib die Strommstärke ein: ");
            I = WerteEingabe.GetDouble();
            Console.Write(" V");
            if (I == 0)
            {
                ClearLine(error: true);
                GetI();
            }
            return I;
        }
        /// <summary>
        /// Eine Methode zur Berechnung des Wiederstands. Erwartet einen Parameter(header) für die Überschrift der Konsolenoberfläche.
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static double Wiederstand(string header)
        {
            Console.Clear();
            Console.WriteLine(header);
            double rechnen = (GetU() / GetI());
            if (rechnen <= 0)
            {
                Console.CursorTop += 2;
                Console.Write("Physikalisch nicht möglisch!");
                Thread.Sleep(1000);
                Wiederstand(header);
            }
            return rechnen;
        }
        /// <summary>
        /// Eine Methode zur Berechnung der Stromstärke. Erwartet einen Parameter(header) für die Überschrift der Konsolenoberfläche.
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static double Stromstaerke(string header)
        {
            Console.Clear();
            Console.WriteLine(header);
            return GetU() / GetR();
        }
        /// <summary>
        /// Eine Methode zur Berechnung des Spannungswertes. Erwartet einen Parameter(header) für die Überschrift der Konsolenoberfläche.
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static double Spannung(string header)
        {
            Console.Clear();
            Console.WriteLine(header);
            return GetR() * GetI();
        }
        /// <summary>
        /// Eine Methode zum Löschen einer einzelnen Linie in der Konsole. Erwartet einen bool Parameter welcher zeigt ob eine zusätzliche "Errror-Nachricht" geschrieben werden soll. Standart = false.
        /// </summary>
        /// <param name="error"></param>
        public static void ClearLine(bool error = false)
        {
            if(error)
            {
                Console.CursorTop += 2;
                Console.Write("Ungueltige eingabe!");
                Thread.Sleep(1000);
                Clear();
                Console.CursorTop -= 2;
            }
            Clear();
            Console.CursorTop--;
        }
        /// <summary>
        /// Eine Methode zum Löschen einer einzelnen Konsolen Linie. Nur für übergabe zwecken.
        /// </summary>
        private static void Clear()
        {
            for (int i = Console.CursorLeft, l = 0; i > 0; i--, l++)
            {
                Console.CursorLeft = l;
                Console.Write(' ');
            }
        }
    }
}
