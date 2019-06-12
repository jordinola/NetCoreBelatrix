﻿using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository; 
        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            var customer = await _repository.Read();
            return Ok(customer);
        }
    }
}
