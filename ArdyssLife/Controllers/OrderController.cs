using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArdyssLife.Models;
using ArdyssLife.Services;

namespace ArdyssLife.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/order/{idCustomer:int}")]
        public IHttpActionResult GetOrdersByCustomer(int idCustomer)
        {
            try
            {
                return Ok(OrderService.GetOrdersByCustomer(idCustomer));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString());
            }
        }

        [HttpPost]
        public IHttpActionResult PostOrder(Orders order)
        {
            try
            {
                return Ok(OrderService.CreateOrder(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString());
            }
        }

        [HttpPut]
        public IHttpActionResult PutOrder(Orders order)
        {
            try
            {
                return Ok(OrderService.UpdateOrder(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("api/order/{idCustomer:int}")]
        public IHttpActionResult DeleteOrder(int idCustomer)
        {
            try
            {
                return Ok(OrderService.DeleteOrder(idCustomer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString());
            }
        }
    }
}
