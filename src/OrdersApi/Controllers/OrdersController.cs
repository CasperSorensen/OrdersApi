using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrdersApi.Models;
using OrdersApi.Data;
using Newtonsoft.Json;

namespace OrdersApi.Controllers
{
  [Controller]
  [Route("[controller]")]
  public class OrdersController : Controller
  {
    private readonly IOrdersRepository _ordersrepo;

    private readonly ILogger<OrdersController> _logger;

    // ILogger<OrdersController> logger
    public OrdersController(IOrdersRepository repo)
    {
      this._ordersrepo = repo;
      //_logger = logger;
    }

    // GET /User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> Get()
    {
      // _logger.LogInformation("Logging: OrdersController: Getting all Orders");
      IEnumerable<Order> res = null;
      try
      {
        res = await this._ordersrepo.GetAllOrders();
        foreach (var item in res)
        {
          System.Console.WriteLine(item.customer_name);
        }
        if (res == null)
        {
          throw new Exception();
        }
      }
      catch (System.Exception)
      {
        throw;
      }
      return new ObjectResult(res);
    }

    // GET /User/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> Get(long id)
    {
      var User = await this._ordersrepo.GetOrder(id);
      if (User == null)
        return new NotFoundResult();

      return new ObjectResult(User);
    }

    // POST /User
    [HttpPost]
    public async Task<ActionResult<Order>> Post([FromBody] Order order)
    {
      order.Id = await this._ordersrepo.GetNextId();

      string jsondata = JsonConvert.SerializeObject(order);
      await _ordersrepo.Create(order);
      return new OkObjectResult(order);
    }

    // PUT /User/1
    [HttpPut("{id}")]
    public async Task<ActionResult<Order>> Put(long id, [FromBody] Order order)
    {
      var OrderFromDb = await _ordersrepo.GetOrder(id);

      if (OrderFromDb == null)
        return new NotFoundResult();

      order.Id = OrderFromDb.Id;
      order.InternalId = OrderFromDb.InternalId;

      await _ordersrepo.Update(order);

      return new OkObjectResult(order);
    }

    // DELETE /Users/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
      var post = await _ordersrepo.GetOrder(id);

      if (post == null)
        return new NotFoundResult();

      await _ordersrepo.Delete(id);

      return new OkResult();
    }

  }
}
