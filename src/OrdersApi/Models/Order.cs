using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrdersApi.Models
{
  public class Order
  {

    [BsonId]
    public ObjectId InternalId { get; set; }
    public long Id { get; set; }
    public int OrderNo { get; set; }
    public string Content { get; set; }
  }

}