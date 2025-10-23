using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class CustomerRepository
    {
        private readonly EvsdbContext _db;

        public CustomerRepository()
        {
            _db = new EvsdbContext();
        }

        public string GetCustomerNameById(int customerId)
        {
            var customer = _db.Users.FirstOrDefault(c => c.Id == customerId);
            return customer?.FullName ?? "Unknown";
        }
    }
}
