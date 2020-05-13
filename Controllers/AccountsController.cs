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
    public class AccountsController : ControllerBase
    {
        private readonly RatingEmpresasContext _context;

        public AccountsController(RatingEmpresasContext context)
        {
            _context = context;
        }

        // POST: v1/accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users users)
        {
            users.Id = Guid.NewGuid().ToString();
            _context.Users.Add(users);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersExists(users.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // PUT: /v1/accounts/activate/331e6adc-48aa-45c9-9cd1-eba74cb0b340
        [Route("activate/{userId}")]
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutActivateUser(string userId)
        {

            return Ok("Account activated");

            //if (userId != users.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(userId))
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

        // POST: /v1/accounts/login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Users>> PostLogin(Users users)
        {
            return Ok("Login");
        }

        // POST: /v1/accounts/email/activation/recovery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("email/activation/recovery")]
        [HttpPost]
        public async Task<ActionResult<Users>> PostEmailActivationRecovery(Users users)
        {
            return Ok("Accounts email activation recovery");
        }

        // POST: /v1/accounts/password/recovery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("password/recovery")]
        [HttpPost]
        public async Task<ActionResult<Users>> PostPasswordRecovery(Users users)
        {
            return Ok("Password recovery");
        }

        // POST: /v1/accounts/password/change
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("password/change")]
        [HttpPost]
        public async Task<ActionResult<Users>> PostPasswordChange(Users users)
        {
            return Ok("Password change");
        }

        // POST: /v1/accounts/logout
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("logout")]
        [HttpPost]
        public async Task<ActionResult<Users>> PostLogout()
        {
            return Ok("Logout");
        }

        private bool UsersExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
    }
}
