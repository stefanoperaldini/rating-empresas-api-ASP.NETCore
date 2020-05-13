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
    public class CitiesController : ControllerBase
    {
        private readonly RatingEmpresasContext _context;

        public CitiesController(RatingEmpresasContext context)
        {
            _context = context;
        }

        // GET: v1/cities
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Cities>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cities>> GetCities(string id)
        {
            var cities = await _context.Cities.FindAsync(id);

            if (cities == null)
            {
                return NotFound();
            }

            return cities;
        }
    }
}
