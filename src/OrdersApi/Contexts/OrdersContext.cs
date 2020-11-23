using System;
using OrdersApi.Configs;
using OrdersApi.Models;
using MongoDB.Driver;

namespace OrdersApi.Contexts
{
  public class OrdersContext : IOrdersContext
  {
    private readonly IMongoDatabase _db;

    public OrdersContext(MongoDbConfig config)
    {
      var client = new MongoClient(config.ConnectionString);
      _db = client.GetDatabase(config.Database);
    }

    public IMongoCollection<Order> Orders => _db.GetCollection<Order>("Orders");
  }
}