using System;
using MongoDB.Driver;
using OrdersApi.Models;

namespace OrdersApi.Contexts
{
  public interface IOrdersContext
  {
    public IMongoCollection<Order> Orders { get; }
  }
}