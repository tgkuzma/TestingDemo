using System;
using System.Collections.Generic;
using Business.Interfaces;
using Models;
using Models.Interfaces;

namespace Business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer GetCustomerByDateOfBirth(DateTime dateOfBirth)
        {
            return _customerRepository.GetByDateOfBirth(dateOfBirth);
        }

        public void AddNewCustomer(Customer customerToAdd)
        {
            _customerRepository.Add(customerToAdd);
            _customerRepository.SaveChanges();
        }

        public void DeleteCustomer(Customer customerToDelete)
        {
            _customerRepository.Delete(customerToDelete);
            _customerRepository.SaveChanges();
        }

        public void UpdateCustomer(Customer customerToUpdate)
        {
            _customerRepository.SaveChanges();
        }
    }
}