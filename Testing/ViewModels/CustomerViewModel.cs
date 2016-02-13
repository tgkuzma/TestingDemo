using System;
using Models;

namespace Testing.ViewModels
{
    public class CustomerViewModel 
    {
        public CustomerViewModel(Customer customer)
        {
            CustomerId = customer.Id;
            DateOfBirth = customer.DateOfBirth.ToShortDateString();
            FirstName = customer.FirstName;
            LastName = customer.LastName;
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string DateOfBirth { get; set; }
        public bool IsUnderAge => Convert.ToDateTime(DateOfBirth) > DateTime.Now.AddYears(-18);

    }
}