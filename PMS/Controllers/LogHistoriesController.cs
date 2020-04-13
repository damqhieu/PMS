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
    public class LogHistoriesController : ControllerBase
    {
        private readonly PmsContext _context;

        public LogHistoriesController(PmsContext context)
        {
            _context = context;
        }

        // GET: api/LogHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogHistory>>> GetLogHistory()
        {
            return await _context.LogHistory.ToListAsync();
        }

        // GET: api/LogHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogHistory>> GetLogHistory(long id)
        {
            var logHistory = await _context.LogHistory.FindAsync(id);

            if (logHistory == null)
            {
                return NotFound();
            }

            return logHistory;
        }

        // PUT: api/LogHistories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogHistory(long id, LogHistory logHistory)
        {
            if (id != logHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(logHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogHistoryExists(id))
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

        // POST: api/LogHistories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LogHistory>> PostLogHistory(LogHistory logHistory)
        {
            _context.LogHistory.Add(logHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogHistory", new { id = logHistory.Id }, logHistory);
        }

        // DELETE: api/LogHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LogHistory>> DeleteLogHistory(long id)
        {
            var logHistory = await _context.LogHistory.FindAsync(id);
            if (logHistory == null)
            {
                return NotFound();
            }

            _context.LogHistory.Remove(logHistory);
            await _context.SaveChangesAsync();

            return logHistory;
        }

        private bool LogHistoryExists(long id)
        {
            return _context.LogHistory.Any(e => e.Id == id);
        }
    }
}
