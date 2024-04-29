using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_databáze_1
{
    internal class Car
    {
        public int AutoID { get; private set; }
        public string nazev { get; set; }
        public int cena { get; set; }
        public Car(int AutoID, string nazev, int cena) { 
            this.AutoID = AutoID;
            this.nazev = nazev;
            this.cena = cena;
        }
    }
}
