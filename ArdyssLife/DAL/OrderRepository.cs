using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArdyssLife.Contracts;
using ArdyssLife.Models;

namespace ArdyssLife.DAL
{
    public class OrderRepository: IOrderRepository
    {
        private ardysslifeEntities context;

        public OrderRepository(ardysslifeEntities _context)
        {
            this.context = _context;
        }

        public Orders DeleteOrder(int id)
        {
            try
            {
                Orders order = this.context.Orders.SingleOrDefault(_order => _order.OrderId == id);
                this.context.Orders.Remove(order);
                this.context.SaveChanges();
                return order;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Orders GetOrderById(int id)
        {
            try
            {
                Orders order = this.context.Orders.SingleOrDefault(_order => _order.OrderId == id);
                return order;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Orders> GetOrdersByCustomer(int idCustomer)
        {
            try
            {
                List<Orders> orders = this.context.Orders.Where(_order => _order.CustomerId == idCustomer).ToList<Orders>();
                return orders;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Orders InsertOrder(Orders order)
        {
            try
            {
                Orders orderInserted = this.context.Orders.Add(order);
                this.context.SaveChanges();
                return orderInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Orders UpdateOrder(Orders order)
        {
            try
            {
                Orders orderModified = this.context.Orders.SingleOrDefault(_order => _order.OrderId == order.OrderId);
                orderModified.OrderDate = order.OrderDate;
                orderModified.Shipping = order.Shipping;
                orderModified.Subtotal = order.Subtotal;
                orderModified.Tax = order.Tax;
                orderModified.Total = order.Total;
                this.context.SaveChanges();
                return orderModified;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}