using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArdyssLife.Contracts;
using ArdyssLife.Models;

namespace ArdyssLife.DAL
{
    public class OrderDetailRepository: IOrderDetailRepository
    {
        private ardysslifeEntities context;

        public OrderDetailRepository(ardysslifeEntities _context)
        {
            this.context = _context;
        }

        public OrdersDetail DeleteOrderDetail(int id)
        {
            try
            {
                OrdersDetail orderDetail = this.context.OrdersDetail.SingleOrDefault(_orderDetail => _orderDetail.OrderDetailId == id);
                this.context.OrdersDetail.Remove(orderDetail);
                this.context.SaveChanges();
                return orderDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrdersDetail GetOrderDetailById(int id)
        {
            try
            {
                OrdersDetail orderDetail = this.context.OrdersDetail.SingleOrDefault(_order => _order.OrderDetailId == id);
                return orderDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrdersDetail> GetOrdersDetail()
        {
            try
            {
                List<OrdersDetail> ordersDetail = this.context.OrdersDetail.ToList<OrdersDetail>();
                return ordersDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrdersDetail InsertOrderDetail(OrdersDetail orderDetail)
        {
            try
            {
                return this.context.OrdersDetail.Add(orderDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrdersDetail UpdateOrderDetail(OrdersDetail orderDetail)
        {
            try
            {
                OrdersDetail orderDetailModified = this.context.OrdersDetail
                       .SingleOrDefault(_orderDetail => _orderDetail.OrderDetailId == orderDetail.OrderDetailId);

                orderDetailModified.ItemCode = orderDetail.ItemCode;
                orderDetailModified.ItemDescription = orderDetail.ItemDescription;
                orderDetailModified.PriceEach = orderDetail.PriceEach;
                orderDetailModified.PriceTotal = orderDetail.PriceTotal;
                orderDetailModified.Quantity = orderDetail.Quantity;
                this.context.SaveChanges();

                return orderDetailModified;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}