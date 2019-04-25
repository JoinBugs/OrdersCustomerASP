using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArdyssLife.Services;

namespace ArdyssLife.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            try
            {
                return Ok(CustomerService.GetCustomers());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString());
            }
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            try
            {
                return Ok(CustomerService.GetCustomer(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString());
            }
        }
    }
}