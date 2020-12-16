using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrdersApi.Models
{
  public class Order
  {
    [BsonId]
    public ObjectId InternalId { get; set; }
    public long Id { get; set; }
    public string customer_name { get; set; }
    public string customer_address { get; set; }
    public string customer_zipcode { get; set; }
    public int product { get; set; }
    public int product_quantity { get; set; }
  }
}