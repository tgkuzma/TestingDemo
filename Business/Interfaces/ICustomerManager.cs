using System;
using System.Collections.Generic;
using Models;

namespace Business.Interfaces
{
    public interface ICustomerManager
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByDateOfBirth(DateTime dateOfBirth);
        void AddNewCustomer(Customer customerToAdd);
        void DeleteCustomer(Customer customerToDelete);
        void UpdateCustomer(Customer customerToUpdate);
    }
}