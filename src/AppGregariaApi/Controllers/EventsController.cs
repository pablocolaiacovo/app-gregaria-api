using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGregariaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppGregariaApi.Controllers
{
    [Route("v1/api/[controller]")]
    public class EventsController : Controller
    {
        readonly EventsContext _context;

        public EventsController(EventsContext context)
        {
            _context = context;
            if(!_context.Events.Any())
            {
                _context.Events.Add(new Event("new event", DateTime.Now));
                _context.SaveChanges();
            }
        }

        // GET: api/events
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            return await _context.Events.ToListAsync();
        }

        // GET api/events/5
        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            var e = await _context.Events.FindAsync(id);
            return e;
        }

        // POST api/events
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Event item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            await _context.Events.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("Get", new { id = item.Id }, item);
        }

        // PUT api/events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Event item)
        {
            if(item == null || item.Id != id)
            {
                return BadRequest();
            }

            var e = await _context.Events.FindAsync(id);
            if(e == null)
            {
                return NotFound();
            }

            e.Name = item.Name;
            e.Date = item.Date;

            _context.Events.Update(e);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        // DELETE api/events/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var e = await _context.Events.FindAsync(id);
            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
        }
    }
}
