using System;

namespace Netpioneer.GCSC
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string lastName) 
            : base("Customer with lastName '" + lastName + "' not found.") {}
    }
}
