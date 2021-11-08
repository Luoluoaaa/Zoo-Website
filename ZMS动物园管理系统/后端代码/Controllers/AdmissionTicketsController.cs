using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Model;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionTicketsController : ControllerBase
    {
        private readonly ModelContext _context;

        public AdmissionTicketsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/AdmissionTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdmissionTicket>>> GetAdmissionTickets()
        {
            return await _context.AdmissionTickets.ToListAsync();
        }

        // GET: api/AdmissionTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdmissionTicket>> GetAdmissionTicket(string id)
        {
            var admissionTicket = await _context.AdmissionTickets.FindAsync(id);

            if (admissionTicket == null)
            {
                return NotFound();
            }

            return admissionTicket;
        }

        // PUT: api/AdmissionTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmissionTicket(string id, AdmissionTicket admissionTicket)
        {
            if (id != admissionTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(admissionTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissionTicketExists(id))
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

        // POST: api/AdmissionTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AdmissionTicket>> PostAdmissionTicket(AdmissionTicket admissionTicket)
        {
            _context.AdmissionTickets.Add(admissionTicket);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdmissionTicketExists(admissionTicket.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdmissionTicket", new { id = admissionTicket.Id }, admissionTicket);
        }

        // DELETE: api/AdmissionTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdmissionTicket>> DeleteAdmissionTicket(string id)
        {
            var admissionTicket = await _context.AdmissionTickets.FindAsync(id);
            if (admissionTicket == null)
            {
                return NotFound();
            }

            _context.AdmissionTickets.Remove(admissionTicket);
            await _context.SaveChangesAsync();

            return admissionTicket;
        }

        private bool AdmissionTicketExists(string id)
        {
            return _context.AdmissionTickets.Any(e => e.Id == id);
        }
    }
}
