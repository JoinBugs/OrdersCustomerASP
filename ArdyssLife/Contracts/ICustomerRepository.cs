using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArdyssLife.Models;

namespace ArdyssLife.Contracts
{
    public interface ICustomerRepository
    {
        List<Customers> GetCustomers();

        Customers GetCustomerById(int id);
    }
}
