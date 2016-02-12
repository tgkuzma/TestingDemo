using System;

namespace Models.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByDateOfBirth(DateTime dateOfBirth);
    }
}