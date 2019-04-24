using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArdyssLife.Contracts;
using ArdyssLife.Models;

namespace ArdyssLife.DAL
{
    public class CustomerRepository: ICustomerRepository
    {
        private ardysslifeEntities context;

        public CustomerRepository(ardysslifeEntities _context)
        {
            this.context = _context;
        }

        public Customers GetCustomerById(int id)
        {
            try
            {
                Customers customer = this.context.Customers.SingleOrDefault(_customer => _customer.CustomerId == id);
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Customers> GetCustomers()
        {
            try
            {
                List<Customers> customers = this.context.Customers.ToList<Customers>();
                return customers;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}