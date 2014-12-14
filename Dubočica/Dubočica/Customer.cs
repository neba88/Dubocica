using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubocica
{
    public class Customer
    {
        public Sendvich sendvich; // must be public because Dubocica will give him sendvich
        public int numberInLine;
        private static int customerId = 0; // static's must be explicitly initialized; let Customer worry about it's number

        // Constructor:
        public Customer()
        {
            numberInLine = customerId++; // for next Customer this will be incremented by 1
        }

        public void tickCustomer()
        {
            Debug.Assert(sendvich != null);
            sendvich.tickMakingOfSendvich();
        }

        public bool isThisCustomerServed()
        {
            Debug.Assert(sendvich != null);
            return sendvich.done;
        }
    }
}
