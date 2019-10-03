using Microsoft.AspNetCore.Mvc;
using RestCustomerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static readonly List<Customer> customerList = new List<Customer>() {
                new Customer("Alexander", "Bruun", DateTime.Now.Year),
                new Customer("Torben", "Pedersen", DateTime.Now.Year),
                new Customer("Pernille", "Bruun", DateTime.Now.Year),
                new Customer("Lizette", "Bruun", DateTime.Now.Year),
                new Customer("Ib", "Biger Pedersen", DateTime.Now.Year)
        };

        // GET: api/Customer
        [HttpGet]
        // MVC policy
        //[EnableCors("AllowAnyOrigin")]
        public IEnumerable<Customer> Get()
        {
            return customerList;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        // MVC policy
        //[EnableCors("AllowAnyOrigin")]
        public Customer Get(int id)
        {
            return customerList.Where(x => x.Id == id).First();
        }

        // POST: api/Customer
        [HttpPost]
        // MVC policy
        //[EnableCors("AllowSpecificOrigin")]
        public void Post(Customer value)
        {
            customerList.Add(value);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        // MVC policy
        // [DisableCors]
        public void Put(int id, Customer value)
        {
            int index = customerList.FindIndex(x => x.Id == id);

            customerList[index] = value;
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        //[DisableCors]
        // MVC policy
        public void Delete(int id)
        {
            customerList.Remove(customerList.Where(x => x.Id == id).First());
        }
    }
}
