using Belatrix.WebApi.Repository.PostgresSQL;
using GenFu;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {
        public BelatrixDbContextBuilder AddCustomers()
        {
            AddCustomers(_context);
            return this;
        }
        private void AddCustomers(BelatrixDbContext context)
        {
            var customerList = A.ListOf<Models.Customer>(10);
            _context.AddRange(customerList);
            _context.SaveChanges();
        }
    }
}
