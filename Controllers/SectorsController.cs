using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rating_empresas_api_.NET.Models;

namespace rating_empresas_api_.NET.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly RatingEmpresasContext _context;

        public SectorsController(RatingEmpresasContext context)
        {
            _context = context;
        }

        // GET: v1/sectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sectors>>> GetSectors()
        {
            return await _context.Sectors.ToListAsync();
        }

        // GET: v1/sectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sectors>> GetSectors(string id)
        {
            var sectors = await _context.Sectors.FindAsync(id);

            if (sectors == null)
            {
                return NotFound();
            }

            return sectors;
        }

        // POST: v1/sectors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sectors>> PostSectors(Sectors sectors)
        {
            sectors.Id = Guid.NewGuid().ToString();
            _context.Sectors.Add(sectors);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SectorsExists(sectors.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSectors", new { id = sectors.Id }, sectors);
        }

        private bool SectorsExists(string sector)
        {
            return _context.Sectors.Any(e => e.Sector == sector);
        }
    }
}
