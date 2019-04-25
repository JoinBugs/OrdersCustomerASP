using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArdyssLife.Models;

namespace ArdyssLife.Contracts
{
    public interface IOrderRepository
    {
        List<Orders> GetOrdersByCustomer(int idCustomer);

        Orders GetOrderById(int id);

        Orders InsertOrder(Orders order);

        Orders UpdateOrder(Orders order);

        Orders DeleteOrder(int id);
    }
}