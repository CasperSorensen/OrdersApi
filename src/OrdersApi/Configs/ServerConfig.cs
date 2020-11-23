using System;

namespace OrdersApi.Configs
{
  public class ServerConfig
  {
    public MongoDbConfig MongoDb { get; set; } = new MongoDbConfig();
  }
}