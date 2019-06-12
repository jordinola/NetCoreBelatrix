using Belatrix.WebApi.Controllers;
using Belatrix.WebApi.Repository.PostgresSQL;
using Belatrix.WebApi.Tests.Builder.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Belatrix.WebApi.Tests
{
    public class CustomerControllerTest
    {
        private readonly BelatrixDbContextBuilder _builder;
        public CustomerControllerTest()
        {
            _builder = new BelatrixDbContextBuilder();
        }
        [Fact]
        public async Task CustomerController_GetCustomer_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddCustomers()
                .Build();

            var repository = new GenericRepository<Models.Customer>(db);
            var controller = new CustomerController(repository);

            var response = (await controller.GetCustomer()).Result as OkObjectResult;

            var values = response.Value as List<Models.Customer>;

            values.Count.Should().Be(10);
        }
    }
}
