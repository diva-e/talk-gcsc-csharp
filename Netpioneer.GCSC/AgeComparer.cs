using System.Collections.Generic;

namespace Netpioneer.GCSC
{
    public class AgeComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
