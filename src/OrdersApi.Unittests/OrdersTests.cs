using System;
using System.Threading.Tasks;
using Xunit;
using OrdersApi.Data;
using OrdersApi.Contexts;
using OrdersApi.Configs;
using OrdersApi.Models;

namespace OrdersApi.Unittests
{
  public class OrdersTests
  {
    private Order _testOrder;

    public OrdersTests()
    {

    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void CreateDummyOrder_NotNull()
    {
      var testorder = this._testOrder.CreateDummyOrder();
      Assert.NotNull(testorder);
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void CreateDummyOrder_ProductQuantityZero()
    {
      var testorder = this._testOrder.CreateDummyOrder();
      Assert.Equal(0, testorder.product_quantity);
    }
  }
}
