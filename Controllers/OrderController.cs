using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace livraria_virtual_api.Controllers
{
    [Route("v1/public/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET api/order
        [HttpGet]
        public IActionResult Get([FromQuery]int? page, [FromQuery]int? limit)
        {
            try
            {
                if (!limit.HasValue) { limit = 10; }
                if (!page.HasValue) { page = 1; }

                var mockList = new List<Order>();
                var random = new Random();

                for (int i = 0; i < limit; i++)
                {
                    var mockCartList = new List<Cart>();
                    for (int j = 0; j < random.Next(1, 20); j++)
                    {
                        var price = random.Next(99, 499);
                        mockCartList.Add(new Cart
                        {
                            Quantity = (j + 1),
                            Price = price,
                            TotalPrice = price * (j + 1),
                            ProductName = string.Format("Name{0}", (j + 1)),
                            ProductLink = "http://exemplo.com"
                        });
                    }

                    mockList.Add(new Order
                    {
                        Id = (i + 1),
                        Date = DateTime.Now,
                        UserName = "Nome da Pessoa que fez o pedido",
                        UserAddress = "Endereço da pessoa que fez o pedido",
                        Items = mockCartList
                    });
                }

                Util.Audit(mockList, mockList, ActionType.GET);
                return Ok(mockList);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var random = new Random();
                var mockCartList = new List<Cart>();
                for (int i = 0; i < random.Next(1, 20); i++)
                {
                    var price = random.Next(99, 499);
                    mockCartList.Add(new Cart
                    {
                        Quantity = (i + 1),
                        Price = price,
                        TotalPrice = price * (i + 1),
                        ProductName = string.Format("Name{0}", (i + 1)),
                        ProductLink = "http://exemplo.com"
                    });
                }

                var orderMock = new Order
                {
                    Id = id,
                    Date = DateTime.Now,
                    UserName = "Nome da Pessoa que fez o pedido",
                    UserAddress = "Endereço da pessoa que fez o pedido",
                    Items = mockCartList
                };

                Util.Audit(orderMock, orderMock, ActionType.GET);
                return Ok(orderMock);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}/status")]
        public IActionResult GetStatus(int id)
        {
            try
            {
                var status = new Status
                {
                    OrderId = id,
                    Description = "Produto Entregue."
                };

                Util.Audit(id, id, ActionType.GET);
                return Ok(status);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/order
        [HttpPost]
        public IActionResult GenerateOrder([FromBody] Order order)
        {
            try
            {
                Util.Audit(order, order, ActionType.POST);
                return Ok("Pedido criado com sucesso.");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
