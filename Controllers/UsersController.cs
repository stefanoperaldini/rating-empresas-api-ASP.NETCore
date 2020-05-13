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
    public class UsersController : ControllerBase
    {
        private readonly RatingEmpresasContext _context;

        public UsersController(RatingEmpresasContext context)
        {
            _context = context;
        }

        // GET: v1/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // DELETE: v1/users
        [HttpDelete]
        public async Task<ActionResult<Users>> DeleteUsers()
        {
            return Ok("Delete user");
            //var users = await _context.Users.FindAsync(id);
            //if (users == null)
            //{
            //    return NotFound();
            //}

            //_context.Users.Remove(users);
            //await _context.SaveChangesAsync();

            //return users;
        }

        // PATCH: v1/users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch]
        public async Task<IActionResult> PatchUsers(Users users)
        {
            return Ok("Update user");

            //if (id != users.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(users).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UsersExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //       throw;
            //    }
            //}

            //return NoContent();
        }

        private bool UsersExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
