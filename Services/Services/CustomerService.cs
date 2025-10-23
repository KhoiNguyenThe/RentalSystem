using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService()
        {
            _customerRepo = new CustomerRepository();
        }

        public string GetCustomerName(int id)
        {
            return _customerRepo.GetCustomerNameById(id);
        }
    }
}
