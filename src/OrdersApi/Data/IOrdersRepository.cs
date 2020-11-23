using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersApi.Models;

namespace OrdersApi.Data
{
  public interface IOrdersRepository
  {

    public Task<IEnumerable<Order>> GetAllOrders();

    public Task<Order> GetOrder(long id);

    public Task Create(Order Order);

    public Task<bool> Update(Order Order);

    public Task<bool> Delete(long id);

    public Task<long> GetNextId();
  }

}