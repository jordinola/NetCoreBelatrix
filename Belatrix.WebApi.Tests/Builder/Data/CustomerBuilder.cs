using Belatrix.WebApi.Repository.PostgresSQL;
using GenFu;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {
        public BelatrixDbContextBuilder AddTenCustomers()
        {
            AddCustomers(_context, 10);
            return this;
        }
        private void AddCustomers(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.Customer>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                customerList[i - 1].Id = i;
            }

            _context.AddRange(customerList);
            _context.SaveChanges();
        }
    }
}
