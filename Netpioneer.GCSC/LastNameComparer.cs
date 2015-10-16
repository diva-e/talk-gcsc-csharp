using System.Collections.Generic;

namespace Netpioneer.GCSC
{
    public class LastNameComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }
}
