using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokusBanka
{
    class Program
    {
        static void Main(string[] args)
        {
            Ucet u1 = new Ucet("Pepa Novák", 10000, 0);
            Ucet u2 = new Ucet("Franta Vomáčka", 1000000, 50000);
            Ucet u3 = new Ucet("Karel Vošáhlo", 5000, 10000);

            Console.WriteLine(u1.ToString());
            Console.WriteLine(u2.ToString());
            Console.WriteLine(u3.ToString());

            Console.WriteLine("*****************************");

            u1.Vloz(50000);
            u2.Vyber(2000000);

            Console.WriteLine(u1.ToString());
            Console.WriteLine(u2.ToString());
            Console.WriteLine(u3.ToString());
            Console.ReadKey();
        }
    }
}
