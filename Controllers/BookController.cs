using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace livraria_virtual_api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET api/book
        [HttpGet]
        public IActionResult Get(int? page, int? limit, string title, string author, DateTime publishDate)
        {
            try
            {
                if (!limit.HasValue) { limit = 10; }
                if (!page.HasValue) { page = 1; }

                var mockList = new List<Book>();

                for (int i = 0; i < limit; i++)
                {
                    mockList.Add(new Book
                    {
                        Isbn = string.Format("Isbn-{0}-{1}", page, i),
                        Title = string.Format("Title-{0}-{1}", page, i),
                        Author = string.Format("Author-{0}-{1}", page, i),
                        PublishDate = publishDate
                    });
                }

                return Ok(mockList);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // GET api/book/{isbn}
        [HttpGet("{isbn}")]
        public IActionResult Get(string isbn)
        {
            var result = string.Format("Livro com ISBN = {0}", isbn);
            return Ok(result);
        }

        // POST api/book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
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

        // PUT api/book/5
        [HttpPut("{isbn}")]
        public IActionResult Put(string isbn, [FromBody] Book book)
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

        // DELETE api/book/5
        [HttpDelete("{isbn}")]
        public IActionResult Delete(string isbn)
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
