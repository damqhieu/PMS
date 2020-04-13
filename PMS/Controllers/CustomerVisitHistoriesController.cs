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
    public class CustomerVisitHistoriesController : ControllerBase
    {
        private readonly PmsContext _context;

        public CustomerVisitHistoriesController(PmsContext context)
        {
            _context = context;
        }

        // GET: api/CustomerVisitHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerVisitHistory>>> GetCustomerVisitHistory()
        {
            return await _context.CustomerVisitHistory.ToListAsync();
        }

        // GET: api/CustomerVisitHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerVisitHistory>> GetCustomerVisitHistory(long id)
        {
            var customerVisitHistory = await _context.CustomerVisitHistory.FindAsync(id);

            if (customerVisitHistory == null)
            {
                return NotFound();
            }

            return customerVisitHistory;
        }

        // PUT: api/CustomerVisitHistories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerVisitHistory(long id, CustomerVisitHistory customerVisitHistory)
        {
            if (id != customerVisitHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerVisitHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerVisitHistoryExists(id))
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

        // POST: api/CustomerVisitHistories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CustomerVisitHistory>> PostCustomerVisitHistory(CustomerVisitHistory customerVisitHistory)
        {
            _context.CustomerVisitHistory.Add(customerVisitHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerVisitHistory", new { id = customerVisitHistory.Id }, customerVisitHistory);
        }

        // DELETE: api/CustomerVisitHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerVisitHistory>> DeleteCustomerVisitHistory(long id)
        {
            var customerVisitHistory = await _context.CustomerVisitHistory.FindAsync(id);
            if (customerVisitHistory == null)
            {
                return NotFound();
            }

            _context.CustomerVisitHistory.Remove(customerVisitHistory);
            await _context.SaveChangesAsync();

            return customerVisitHistory;
        }

        private bool CustomerVisitHistoryExists(long id)
        {
            return _context.CustomerVisitHistory.Any(e => e.Id == id);
        }
    }
}
