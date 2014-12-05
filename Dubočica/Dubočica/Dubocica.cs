using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dubočica
{
    public class Dubocica
    {
        private Queue customersToServe;
        private Timer time;

        Random rnd = new Random();

        public void addCustomer() // svake sekunde
        {
            customersToServe.Enqueue("Kupac broj 1.");
            customersToServe.Enqueue("Kupac broj 2.");
            customersToServe.Enqueue("Kupac broj 3.");
            customersToServe.Enqueue("Kupac broj 4.");
            customersToServe.Enqueue("Kupac broj 5.");
            customersToServe.Enqueue("Kupac broj 6.");
        }

        private void checkCustomers() // pozivas svake sekunde preko Timer-a
        {
            customersToServe.Peek();
            int ukupno = customersToServe.Count;
            Console.Write(customersToServe.Peek());
            Console.Write("Jos ih je ostalo " + ukupno);
        }

        public void startServing(bool shouldStartServing) // startuje timer
        {
            
            if (shouldStartServing == true)
            {
                
                time.Start();
            }
            else
            {
                time.Stop();
            }
 
        }


        private static void pecenje(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sendvich gotov.");
            Console.ReadLine();
        }
    }
}
