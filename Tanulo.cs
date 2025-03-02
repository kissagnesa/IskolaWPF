using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IskolaWPF
{
    public class Tanulo
    {
        public int Ev { get; set; }
        public string Osztaly { get; set; }
        public string Nev { get; set; }
        public string Azonosito { get; set; }

        public override string ToString()
        {
            return $"{Ev} {Osztaly} {Nev}";
        }
    }
}
