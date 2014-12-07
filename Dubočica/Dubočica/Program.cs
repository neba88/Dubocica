using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubocica
{
    class Program
    {
        static void Main(string[] args)
        {
            Dubocica d1 = new Dubocica();
            d1.startServing(true); // here you tell timer to start ticking
                                   // every tick, you create new Customer and attach Sendvich to that Customer
                                   // every tick, check if some Sendvich became done, 
                                   // and the deque that Customer along with that Sendvich

            Console.ReadLine();            
        }
    }
}
