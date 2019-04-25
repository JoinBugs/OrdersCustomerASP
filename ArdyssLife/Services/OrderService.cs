using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArdyssLife.DAL;
using ArdyssLife.Models;

namespace ArdyssLife.Services
{
    public class OrderService
    {
        public static Orders CreateOrder(Orders order)
        {
            try
            {
                return new OrderRepository(new ardysslifeEntities()).InsertOrder(order);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static Orders UpdateOrder(Orders order)
        {
            try
            {
                return new OrderRepository(new ardysslifeEntities()).UpdateOrder(order);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static Orders DeleteOrder(int id)
        {
            try
            {
                return new OrderRepository(new ardysslifeEntities()).DeleteOrder(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Orders> GetOrdersByCustomer(int idCustomer)
        {
            try
            {
                return new OrderRepository(new ardysslifeEntities()).GetOrdersByCustomer(idCustomer);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static Orders GetOrderById(int id)
        {
            try
            {
                return null;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}