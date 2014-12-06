using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dubocica
{
    public class Dubocica
    {
        private Queue customersToServe;
        private Timer time;

        public Dubocica() 
        {
            customersToServe = new Queue(5);

            // timer
            time = new Timer(1000);
            // what you need to add to timer so that it can work?
        }

        public void addCustomer() // svake sekunde, dodamo novog Customer-a
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Customer customer = new Customer();
            customersToServe.Enqueue(customer);
            /*customersToServe.Enqueue("Kupac broj 2.");
            customersToServe.Enqueue("Kupac broj 3.");
            customersToServe.Enqueue("Kupac broj 4.");
            customersToServe.Enqueue("Kupac broj 5.");
            customersToServe.Enqueue("Kupac broj 6.");*/
        }

        private void checkCustomers() // pozivas svake sekunde preko Timer-a
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //customersToServe.Peek(); // does nothing in this context
            /*int ukupno = customersToServe.Count;
            Console.Write(customersToServe.Peek());
            Console.Write("Jos ih je ostalo " + ukupno);*/

            // you need to check here all Customers in queue if their sendviches are done, and if so remove them from queue
        }

        public void startServing(bool shouldStartServing) // startuje timer
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (shouldStartServing == true)
            {
                time.Start();
            }
            else
            {
                time.Stop();
            }
        }

        private static void OnFryingEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private static void OnAddNewCustomerEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
