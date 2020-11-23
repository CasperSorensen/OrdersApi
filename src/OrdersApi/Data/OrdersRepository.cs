using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using OrdersApi.Models;
using OrdersApi.Contexts;

namespace OrdersApi.Data
{
  //TODO Order replace Orders with Ordersa
  public class OrdersRepository : IOrdersRepository
  {
    private readonly IOrdersContext _context;

    public OrdersRepository(IOrdersContext context)
    {
      this._context = context;
    }

    // api/[GET]
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
      return await _context
                    .Orders
                    .Find(_ => true)
                    .ToListAsync();
    }

    // api/where/{id}/equals/{id} /[GET]
    public Task<Order> GetOrder(long id)
    {
      FilterDefinition<Order> filter = Builders<Order>.Filter.Eq(m => m.Id, id);
      return _context
              .Orders
              .Find(filter)
              .FirstOrDefaultAsync();
    }

    // api/[POST]
    public async Task Create(Order Order)
    {
      await _context
              .Orders
              .InsertOneAsync(Order);

    }

    // api/[PUT]
    public async Task<bool> Update(Order Order)
    {
      ReplaceOneResult updateResult =
                    await _context
                            .Orders
                            .ReplaceOneAsync(filter: g => g.Id == Order.Id, replacement: Order);

      return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    // api[DELETE]
    public async Task<bool> Delete(long id)
    {
      FilterDefinition<Order> filter = Builders<Order>.Filter.Eq(m => m.Id, id);

      DeleteResult deleteResult = await _context
                                          .Orders
                                        .DeleteOneAsync(filter);

      return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<long> GetNextId()
    {
      return await _context
                    .Orders
                    .CountDocumentsAsync(new BsonDocument()) + 1;

    }

  }

}