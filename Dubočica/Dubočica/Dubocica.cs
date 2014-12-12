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
        private LinkedList<int> customersToServe = new LinkedList<int>();
        private Timer time;

        public Dubocica() 
        {
           
            // timer
            time = new Timer(1000);
            time.Elapsed += time_Elapsed; // DODAO <-----
            // what you need to add to timer so that it can work?
        }

        void time_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Usao novi kupac, poceo sam da sluzim, al nema sendvicha za sad ...");
            addCustomer();
            checkCustomers();
        }

        public void addCustomer() // svake sekunde, dodamo novog Customer-a
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //LinkedList<int> customer = new LinkedList<int>();

            foreach (int number in new int[] { 1, 2, 3, 4, 5 })
            {
                customersToServe.AddFirst(number);

            }

            //Console.WriteLine("\nIterating using a foreach statement:");
            //foreach (int number in customer)
            //{
            //    Console.WriteLine(number);
            //}
            //Console.WriteLine("\nLinkedList: ");
        }

        private void checkCustomers() // pozivas svake sekunde preko Timer-a
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (customersToServe != null)
            {
                customersToServe.Remove(1);
            }
            else
                customersToServe.Count();
            
            //customersToServe.Peek(); // does nothing in this context
            /*int ukupno = customersToServe.Count;
            Console.Write(customersToServe.Peek());
            Console.Write("Jos ih je ostalo " + ukupno);*/

            // you need to check here all Customers in queue if their sendviches are done, 
            // and if so remove them from queue
        }

        public void startServing(bool shouldStartServing) // startuje timer
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (shouldStartServing == true)
            {

                time.Start();
                customersToServe.LastOrDefault();
                while (customersToServe == null)
                {
                    time.Stop();
                }
            }
            else
            {
                time.Stop();
            }

            Console.ReadLine();
        }

        //private static void OnFryingEvent(Object source, ElapsedEventArgs e)
        //{
        //    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //}

        //private static void OnAddNewCustomerEvent(Object source, ElapsedEventArgs e)
        //{
        //    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //}
    }
}
