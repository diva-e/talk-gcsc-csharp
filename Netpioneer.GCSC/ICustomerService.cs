using System.Collections.Generic;

namespace Netpioneer.GCSC
{
    public interface ICustomerService
    {
        bool ContainsCustomer(Customer customer);

        bool DeleteCustomer(Customer customer);

        Customer FindCustomerByName(string loginName);

        IList<Customer> FindMaleAdultCustomers();

        IList<Customer> GetAllCustomers();

        void PrintSortedByAge();

        void PrintSortedByLastName();
    }
}