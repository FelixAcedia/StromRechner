using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_FelixAssert
{
    [System.AttributeUsage(System.AttributeTargets.Class | 
        System.AttributeTargets.Struct)]
    [Version("F. Assert", classVersion = "1.0.0")]
    public class VersionAttribute : Attribute
    {
        private string autor;
        public string Autor
        {
            get { return autor; }
        }
        public string programVersion;
        public string classVersion;

        public VersionAttribute(string autor)
        {
            this.autor = autor;
            programVersion = "0.0.0.0";
            classVersion = "0.0.0";
        }
    }
}
