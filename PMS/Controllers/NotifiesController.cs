using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.Models;

namespace PMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifiesController : ControllerBase
    {
        private readonly PmsContext _context;

        public NotifiesController(PmsContext context)
        {
            _context = context;
        }

        // GET: api/Notifies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notify>>> GetNotify()
        {
            return await _context.Notify.ToListAsync();
        }

        // GET: api/Notifies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notify>> GetNotify(long id)
        {
            var notify = await _context.Notify.FindAsync(id);

            if (notify == null)
            {
                return NotFound();
            }

            return notify;
        }

        // PUT: api/Notifies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotify(long id, Notify notify)
        {
            if (id != notify.Id)
            {
                return BadRequest();
            }

            _context.Entry(notify).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotifyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notifies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Notify>> PostNotify(Notify notify)
        {
            _context.Notify.Add(notify);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotify", new { id = notify.Id }, notify);
        }

        // DELETE: api/Notifies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notify>> DeleteNotify(long id)
        {
            var notify = await _context.Notify.FindAsync(id);
            if (notify == null)
            {
                return NotFound();
            }

            _context.Notify.Remove(notify);
            await _context.SaveChangesAsync();

            return notify;
        }

        private bool NotifyExists(long id)
        {
            return _context.Notify.Any(e => e.Id == id);
        }
    }
}
