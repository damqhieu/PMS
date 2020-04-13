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
    public class PreSalesController : ControllerBase
    {
        private readonly PmsContext _context;

        public PreSalesController(PmsContext context)
        {
            _context = context;
        }

        // GET: api/PreSales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreSale>>> GetPreSale()
        {
            return await _context.PreSale.ToListAsync();
        }

        // GET: api/PreSales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreSale>> GetPreSale(long id)
        {
            var preSale = await _context.PreSale.FindAsync(id);

            if (preSale == null)
            {
                return NotFound();
            }

            return preSale;
        }

        // PUT: api/PreSales/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreSale(long id, PreSale preSale)
        {
            if (id != preSale.Id)
            {
                return BadRequest();
            }

            _context.Entry(preSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreSaleExists(id))
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

        // POST: api/PreSales
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PreSale>> PostPreSale(PreSale preSale)
        {
            _context.PreSale.Add(preSale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreSale", new { id = preSale.Id }, preSale);
        }

        // DELETE: api/PreSales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreSale>> DeletePreSale(long id)
        {
            var preSale = await _context.PreSale.FindAsync(id);
            if (preSale == null)
            {
                return NotFound();
            }

            _context.PreSale.Remove(preSale);
            await _context.SaveChangesAsync();

            return preSale;
        }

        private bool PreSaleExists(long id)
        {
            return _context.PreSale.Any(e => e.Id == id);
        }
    }
}
