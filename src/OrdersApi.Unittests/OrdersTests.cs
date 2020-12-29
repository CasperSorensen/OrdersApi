using System;
using System.Threading.Tasks;
using Xunit;
using OrdersApi.Data;
using OrdersApi.Contexts;
using OrdersApi.Configs;

namespace OrdersApi.Unittests
{
  public class OrdersTests
  {
    private readonly IOrdersContext _context;

    public OrdersTests()
    {
      var config = new ServerConfig();

      config.MongoDb.Database = "orders_Db";
      config.MongoDb.Host = "localhost";
      config.MongoDb.User = "root";
      config.MongoDb.Password = "example";
      config.MongoDb.Port = 27017;

      this._context = new OrdersContext(config.MongoDb);
    }

    // [Fact, Trait("Priority", "1"), Trait("Category", "IntegrationTests")]
    // public async Task GetAllOrdersTest_NotNullOrEmptyList()
    // {
    //   OrdersRepository or = new OrdersRepository(_context);
    //   var result = await or.GetAllOrders();
    //   foreach (var item in result)
    //   {
    //     System.Console.WriteLine(item.customer_name);
    //   }
    //   Assert.NotEmpty(result);
    //   Assert.NotNull(result);
    // }
  }
}
