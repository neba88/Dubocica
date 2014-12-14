using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dubocica
{
    public class Dubocica
    {
        private LinkedList<Customer> customersToServe = new LinkedList<Customer>(); // ovde drzimo samo Customere
        private Timer timer;

        public Dubocica() 
        {
            //Console.WriteLine("constructor");
            timer = new Timer(1000); // set timer to fire each second, not yet started

            // what you need to add to timer so that it can work?
            timer.Elapsed += OnTickEvent;
        }

        // Dubocica instance methods to call in Event familiy of methods

        public void addCustomer() // svake sekunde, dodamo novog Customer-a
        {
            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Sendvich sendvich = new Sendvich();
            Customer customer = new Customer();
            customer.sendvich = sendvich;
            customersToServe.AddLast(customer);
        }

        private void checkCustomers() // pozivas svake sekunde preko Timer-a
        {
            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Debug.Assert(customersToServe != null);

            // you need to check here all Customers in queue if their sendviches are done, 
            // and if so remove them from queue

            List<Customer> customersToRemove = new List<Customer>();

            foreach (Customer customer in customersToServe)
            {
                if (!customer.isThisCustomerServed()) 
                    continue;
                customersToRemove.Add(customer);
                Console.WriteLine("one customer was served");
            }

            if (customersToRemove.Count > 1)
            {
                foreach (Customer customer in customersToRemove)
                {
                    customersToServe.Remove(customer);
                }
            }
        }

        private void tickMakingSendviches()
        {
            // workers are making sendviches
            foreach (Customer customer in customersToServe)
            {
                customer.tickCustomer();
            }
        }

        // to start making food, call this method
        public void startServing(bool shouldStartServing) // startuje timer
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Debug.Assert(timer != null);

            if (shouldStartServing == true)
            {
                if (timer.Enabled) return;
                timer.Start();
            }
            else
            {
                if (timer.Enabled == false) return;
                timer.Stop();
            }
        }

        // method that timer is going to fire each second

        private void OnTickEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("workers making sendviches");
                
            tickMakingSendviches();
            checkCustomers();
            addCustomer();
        }
    }
}
