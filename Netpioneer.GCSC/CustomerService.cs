using System;
using System.Collections.Generic;

namespace Netpioneer.GCSC
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers = new List<Customer>();

        public CustomerService() {
            Customer customer1 = new Customer("login1", "Fritz", "Müller", 20, Gender.MALE);
            Customer customer2 = new Customer("login2", "Vivian", "Auer", 40, Gender.FEMALE);
            Customer customer3 = new Customer("login3", "Susi", "Sorglos", 30, Gender.FEMALE);
            Customer customer4 = new Customer("login4", "Martin", "Auer", 18, Gender.FEMALE);
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            customers.Add(customer4);
        }

        public bool ContainsCustomer(Customer customer)
        {
            if (customers.Contains(customer) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Deletes the given <paramref name="customer"/>.
        /// </summary>
        /// <param name="customer">customer to delete</param>
        /// <returns>true if the customer has been deleted, false otherwise.</returns>
        public bool DeleteCustomer(Customer customer)
        {
            // Check if we have a customer in our list.
            // If we don't have one, we return false as
            // the customer hasn't been deleted actually.
            if (ContainsCustomer(customer))
            {
                // Remove the customer.
                // We could also directly return the result of Remove()
                customers.Remove(customer);
                // Return true to communicate the result
                return true;
            }
            // Return false if the customer could not be found
            return false;
        }

        public Customer FindCustomerByName(string loginName)
        {
            if (loginName != null && !(loginName == ""))
            {
                foreach (Customer customer in customers)
                {
                    if (customer.LoginName == loginName)
                    {
                        return customer;
                    }
                }
            }
            throw new CustomerNotFoundException(loginName);
        }

        public IList<Customer> FindMaleAdultCustomers()
        {
            IList<Customer> custFound = new List<Customer>();
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Age < 18)
                        continue;
                    else
                {
                    if (customers[i].Gender != Gender.FEMALE)
                  custFound.Add(customers[i]);
                }
            }
            return custFound;
        }

        public IList<Customer> FindMaleAdultCustomers_V2()
        {
            IList<Customer> maleAdultCustomers = new List<Customer>();
            foreach (Customer customer in customers)
            {
                if (IsMale(customer) && IsAdult(customer))
                {
                    maleAdultCustomers.Add(customer);
                }
            }
            return maleAdultCustomers;
        }

        private bool IsMale(Customer customer)
        {
            return customer.Gender == Gender.MALE;
        }

        private bool IsAdult(Customer customer)
        {
            return customer.Age >= 18;
        }

        public IList<Customer> GetAllCustomers()
        {
            return customers;
        }

        public void PrintSortedByAge()
        {
            IEnumerator<Customer> en = customers.GetEnumerator();
            List<String> list = new List<String>();
            while (en.MoveNext())
            {
                Customer customer = en.Current;
                list.Add(customer.Age + " " + customer.LoginName);
            }
            list.Sort();
            IEnumerator<String> en2 = list.GetEnumerator();
            while (en2.MoveNext())
            {
                try
                {
                    String str = en2.Current;
                    Console.WriteLine(
                            FindCustomerByName(str.Substring(str.LastIndexOf(" ") + 1)));
                }
                catch (CustomerNotFoundException e)
                {
                    Console.WriteLine("Cust not found: " + e.Message);
                }
            }
        }

        public void PrintSortedByAge_V2()
        {
            List<Customer> customersToSort = new List<Customer>(customers);
            customersToSort.Sort(new AgeComparer());

            foreach (Customer customer in customersToSort)
            {
                Console.WriteLine(customer);
            }
        }

        public void PrintSortedByLastName()
        {
            SortedSet<Customer> sortedCustomers = new SortedSet<Customer>(new LastNameComparer());
            sortedCustomers.UnionWith(customers);

            foreach (Customer customer in sortedCustomers)
            {
                Console.WriteLine(customer);
            }
        }

        public void PrintSortedByLastName_V2()
        {
            customers.Sort(new LastNameComparer());

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
