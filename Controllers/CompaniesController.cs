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
    public class CompaniesController : ControllerBase
    {
        private readonly RatingEmpresasContext _context;

        public CompaniesController(RatingEmpresasContext context)
        {
            _context = context;
        }

        // GET: v1/companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Companies>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> GetCompanies(string id)
        {
            var companies = await _context.Companies.FindAsync(id);

            if (companies == null)
            {
                return NotFound();
            }

            return companies;
        }

        // GET: api/companies/cities/e2961ced-ef78-42c8-bb4e-f0eaf242ca23
        [Route("cities/{cityId}")]
        [HttpGet]
        public async Task<ActionResult<Companies>> GetCompaniesCity(string cityId)
        {
            return Ok("Get Companies City");

            //var companies = await _context.Companies.FindAsync(cityId);

            //if (companies == null)
            //{
            //    return NotFound();
            //}

            //return companies;
        }

        // GET: /v1/companies/cities/active
        [Route("cities/active")]
        [HttpGet]
        public async Task<ActionResult<Companies>> GetCompaniesCitiesActive(string cityId)
        {
            return Ok("Get companies cities active");

            //var companies = await _context.Companies.FindAsync(cityId);

            //if (companies == null)
            //{
            //    return NotFound();
            //}

            //return companies;
        }

        // POST: vi/companies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompanies(Companies companies)
        {
            companies.Id = Guid.NewGuid().ToString();
            companies.UserId = "ca39880d-1f68-44e1-a9ad-a7b652827e92";
            companies.CreatedAt = DateTime.Now;

            _context.Companies.Add(companies);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompaniesExists(companies.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompanies", new { id = companies.Id }, companies);
        }

        // POST: v1/companies/logo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("logo")]
        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompaniesLogo(Companies companies)
        {
            return Ok("Post logo");
        }

        // PUT: vi/companies/b495fa6d-4b63-4cce-8814-20f72aac6822
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanies(string id, Companies companies)
        {
            return Ok("Update company");
            
            if (id != companies.Id)
            {
                return BadRequest();
            }

            _context.Entry(companies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompaniesExists(id))
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

        private bool CompaniesExists(string id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
