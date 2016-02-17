using System;
using Models;

namespace UnitTests
{
    public class CustomerCreator
    {
        public static Customer CreateSingleCustomer(int age)
        {
            return new Customer
            {
                DateOfBirth = DateTime.Now.AddYears(-age),
                FirstName = "Twenty",
                LastName = "YearsOld",
                Id = 1
            };
        }
    }
}
