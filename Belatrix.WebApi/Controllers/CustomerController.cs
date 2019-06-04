using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Belatrix.WebApi.Repository.PostgresSQL;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.WebApi.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly GenericRepository<Customer> _repository; 
        public CustomerController(GenericRepository<Customer> repository)
        {
            _repository = repository;
        }
    }
}
