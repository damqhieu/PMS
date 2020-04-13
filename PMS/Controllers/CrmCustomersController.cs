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
    public class CrmCustomersController : ControllerBase
    {
        private readonly PmsContext _context;

        public CrmCustomersController(PmsContext context)
        {
            _context = context;
        }

        // GET: api/CrmCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrmCustomer>>> GetCrmCustomers()
        {
            return await _context.CrmCustomers.ToListAsync();
        }

        // GET: api/CrmCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CrmCustomer>> GetCrmCustomer(long id)
        {
            var crmCustomer = await _context.CrmCustomers.FindAsync(id);

            if (crmCustomer == null)
            {
                return NotFound();
            }

            return crmCustomer;
        }

        // PUT: api/CrmCustomers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrmCustomer(long id, CrmCustomer crmCustomer)
        {
            if (id != crmCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(crmCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrmCustomerExists(id))
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

        // POST: api/CrmCustomers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CrmCustomer>> PostCrmCustomer(CrmCustomer crmCustomer)
        {
            _context.CrmCustomers.Add(crmCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrmCustomer", new { id = crmCustomer.Id }, crmCustomer);
        }

        // DELETE: api/CrmCustomers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CrmCustomer>> DeleteCrmCustomer(long id)
        {
            var crmCustomer = await _context.CrmCustomers.FindAsync(id);
            if (crmCustomer == null)
            {
                return NotFound();
            }

            _context.CrmCustomers.Remove(crmCustomer);
            await _context.SaveChangesAsync();

            return crmCustomer;
        }

        private bool CrmCustomerExists(long id)
        {
            return _context.CrmCustomers.Any(e => e.Id == id);
        }
    }
}
