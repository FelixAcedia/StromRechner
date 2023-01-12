using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_FelixAssert
{
    /// <summary>
    /// Eine Klasse zum erstellen eines Attributes, welcher dafür zuständig ist die Version eines Programmes/einer Klasse, wie auch dessen Autoren zu zeigen.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class | 
        System.AttributeTargets.Struct)]
    [Version("F. Assert", classVersion = "1.0.0")]
    public class VersionAttribute : Attribute
    {
        private string autor;
        /// <summary>
        /// Propertie welcher den Autoren eines Programms und einer Klasse zeigt. Read-Only.
        /// </summary>
        public string Autor
        {
            get { return autor; }
        }
        public string programVersion;
        public string classVersion;
        /// <summary>
        /// Ein Konstruktor welcher die Eingabe eines Autoren voraus setzt und Program- und Klassenversion standartmäßig auf einen null wert setzt.
        /// </summary>
        /// <param name="autor"></param>
        public VersionAttribute(string autor)
        {
            this.autor = autor;
            programVersion = "0.0.0.0";
            classVersion = "0.0.0";
        }
    }
}
