using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Program
    {
        static void Main(string[] args)
        {
            ICentrum centrum = new Centrum();
             var test = new Test(centrum);
             Console.WriteLine("TESTY:");
             Console.WriteLine(test.Test1());
             Console.WriteLine(test.Test2());
             Console.WriteLine(test.Test3());
             Console.WriteLine(test.Test4());
             Console.WriteLine(test.Test5());
             Console.WriteLine(test.Test6());
             Console.WriteLine(test.Test7());
             Console.WriteLine(test.Test8());
             Console.WriteLine(test.Test9());
             Console.WriteLine(test.testZapis());
             Console.WriteLine(test.TestOdczytu());
             //test.wypiszWszystko();
       
            Console.WriteLine();
            Console.ReadKey();
        
        }
    }
}
