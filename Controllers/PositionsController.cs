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
    public class PositionsController : ControllerBase
    {
        private readonly RatingEmpresasContext _context;

        public PositionsController(RatingEmpresasContext context)
        {
            _context = context;
        }

        // GET: v1/positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Positions>>> GetPositions()
        {
            return await _context.Positions.ToListAsync();
        }

        // GET: v1/positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Positions>> GetPositions(string id)
        {
            var positions = await _context.Positions.FindAsync(id);

            if (positions == null)
            {
                return NotFound();
            }

            return positions;
        }

        // POST: v1/Positions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Positions>> PostPositions(Positions positions)
        {
            positions.Id = Guid.NewGuid().ToString();
            _context.Positions.Add(positions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PositionsExists(positions.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPositions", new { id = positions.Id }, positions);
        }

        // GET: /v1/positions/company/e2961ced-ef78-42c8-bb4e-f0eaf242ca23
        [Route("company/{companyId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Positions>>> GetPositionsCompany(string companyId)
        {
            return await _context.Positions.ToListAsync();
        }

        private bool PositionsExists(string Name)
        {
            return _context.Positions.Any(e => e.Name == Name);
        }
    }
}
