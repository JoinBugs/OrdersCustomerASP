using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArdyssLife.Models;

namespace ArdyssLife.Contracts
{
    public interface IOrderDetailRepository
    {
        List<OrdersDetail> GetOrdersDetail();

        OrdersDetail GetOrderDetailById(int id);

        OrdersDetail InsertOrderDetail(OrdersDetail order);

        OrdersDetail UpdateOrderDetail(OrdersDetail order);

        OrdersDetail DeleteOrderDetail(int id);
    }
}
