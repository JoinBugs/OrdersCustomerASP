using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArdyssLife.Models;
using ArdyssLife.DAL;

namespace ArdyssLife.Services
{
    public class CustomerService
    {
        public static List<Customers> GetCustomers()
        {
            try
            {
                return new CustomerRepository(new ardysslifeEntities()).GetCustomers();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static Customers GetCustomer(int id)
        {
            try
            {
                return new CustomerRepository(new ardysslifeEntities()).GetCustomerById(id);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}