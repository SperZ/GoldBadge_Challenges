using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive.Repository
{
    public class EmailRepository
    {
        public readonly List<Customer> _customerDirectory = new List<Customer>();
        public readonly List<Customer> _currentCustomers = new List<Customer>();
        public readonly List<Customer> _pastCustomers = new List<Customer>();
        public readonly List<Customer> _potentialCustomers = new List<Customer>();


        public bool AddCustomerToList(Customer newCustomer)
        {
            int startingCount = _customerDirectory.Count;
            _customerDirectory.Add(newCustomer);
            if(startingCount < _customerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> SortByType(Customer content)
        {
            foreach(Customer s in _customerDirectory)
            {
                if (s.CustomerType == TypeOfCustomer.Current)
                {
                    _currentCustomers.Add(s);
                }

                else if (s.CustomerType == TypeOfCustomer.Past)
                {
                    _pastCustomers.Add(s);
                }
                else if (s.CustomerType == TypeOfCustomer.Potential)
                {
                    _potentialCustomers.Add(s);
                }

            }
            return null;

        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDirectory;

        }

        public Customer GetCustomerByEmailAddress(string address)
        {
            foreach(Customer r in _customerDirectory)
            {
                if(r.EmailAddress == address)
                {
                    return r;
                }
            }
            return null;
        }

        public bool UpdateCustomerInfo(string address, Customer newCustomer )
        {
            Customer oldCustomer = GetCustomerByEmailAddress(address);
            if(oldCustomer != null)
            {
                oldCustomer.CustomerType = newCustomer.CustomerType;
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.EmailAddress = newCustomer.EmailAddress;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCustomer(Customer s)
        {
            bool wasRemoved = _customerDirectory.Remove(s);

            return wasRemoved;
        }

        public void DisplayCustomers()
        {
            SortCustomerByName();
            Console.WriteLine("First Name             LastName                 CustomerType            EmaliAdress");
            foreach(Customer l in _customerDirectory)
            {
                Console.WriteLine($"{l.FirstName}      {l.LastName}       {l.CustomerType}          {l.EmailAddress}"  );
            }

        }

        public void SendMessage()
        {
            foreach(Customer s in _currentCustomers)
            {
                Console.WriteLine("Thank you for your wok with us. We appreciate your loyalty. Here is a coupon on us.");
            }

            foreach(Customer r in _pastCustomers)
            {
                Console.WriteLine("It's been a long time since we heard from you we want you back.");
            }

            foreach(Customer p in _potentialCustomers)
            {
                Console.WriteLine("We currently have the lowest rates on helicopter insurance.");
            }
        }

        public List<Customer> SortCustomerByName()
        {
            _customerDirectory.Sort();

            return _customerDirectory;
        }
    }
}
