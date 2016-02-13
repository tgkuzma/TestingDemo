using System;
using System.Linq;
using Models;
using Models.Interfaces;

namespace Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly TestingContext _context;

        public CustomerRepository(TestingContext context) : base(context)
        {
            _context = context;
        }

        public Customer GetByDateOfBirth(DateTime dateOfBirth)
        {
            return _context.Customers.FirstOrDefault(c => c.DateOfBirth == dateOfBirth);
        }
    }
}