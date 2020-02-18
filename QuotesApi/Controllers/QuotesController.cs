using System;
using System.Collections.Generic;
using System.Net.Http;
using QuotesApi.Data;
using QuotesApi.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace QuotesApi.Controllers
{
    public class QuotesController : ApiController
    {
        QuotesDbContext quotesDbContext = new QuotesDbContext();
        // GET: api/Quotes
        public /*IEnumerable<Quote>*/IHttpActionResult Get()
        {
            var quotes = quotesDbContext.Quotes;
            //return quotesDbContext.Quotes;
            return Ok(quotes);
        }

        // GET: api/Quotes/5
        public /*Quote*/IHttpActionResult Get(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if(quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        // POST: api/Quotes
        public /*void*/IHttpActionResult Post([FromBody]Quote quote)
        {
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Quotes/5
        public /*void*/IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            var  entity = quotesDbContext.Quotes.FirstOrDefault(q => q.Id == id);
            if(entity == null)
            {
                return BadRequest("No record found against this id");
            }
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            quotesDbContext.SaveChanges();
            return Ok("Record Updated Successfully....");
        }

        // DELETE: api/Quotes/5
        public /*void*/IHttpActionResult Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return BadRequest("No record found against this id");
            }
            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();
            return Ok("Quote deleted");
        }
    }
}
