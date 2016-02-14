using System;
using System.Data.Entity;
using Models;

namespace Data
{
    internal class DataContextInitializer : DropCreateDatabaseAlways<TestingContext>
    {
        protected override void Seed(TestingContext context)
        {
            context.Customers.Add(new Customer
            {
                FirstName = "Trenton",
                LastName = "Kuzma",
                DateOfBirth = Convert.ToDateTime("12/22/1968")
            });

            context.Customers.Add(new Customer
            {
                FirstName = "Underage",
                LastName = "Customer",
                DateOfBirth = Convert.ToDateTime("02/14/2000")
            });

            context.SaveChanges();
        }
    }
}