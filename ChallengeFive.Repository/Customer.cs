using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive.Repository
{
    public enum TypeOfCustomer { Current, Past, Potential }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public TypeOfCustomer CustomerType { get; set; }

        public Customer () { }

        public Customer (string firstName, string lastName, string emailAddress, TypeOfCustomer customerType) 
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            CustomerType = customerType;
        }
    }
}
