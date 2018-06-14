using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace livraria_virtual_api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET api/cart/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var mockList = new List<Cart>();
                var random = new Random();

                for (int i = 0; i < random.Next(1, 20); i++)
                {
                    var price = random.Next(99, 499);
                    mockList.Add(new Cart
                    {
                        Quantity = (i + 1),
                        Price = price,
                        TotalPrice = price * (i + 1),
                        ProductName = string.Format("Name{0}", (i + 1)),
                        ProductLink = "http://exemplo.com"
                    });
                }

                return Ok(mockList);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/cart
        [HttpPost]
        public IActionResult Post([FromBody] Cart item)
        {
            try
            {
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/cart/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
