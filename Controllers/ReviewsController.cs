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
    public class ReviewsController : ControllerBase
    {
        private readonly RatingEmpresasContext _context;

        public ReviewsController(RatingEmpresasContext context)
        {
            _context = context;
        }

        // GET: v1/reviews/filter/all
        [Route("filter/all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviews>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // GET: v1/reviews/e2961ced-ef78-42c8-bb4e-f0eaf242ca23
        [HttpGet("{id}")]
        public async Task<ActionResult<Reviews>> GetReviews(string id)
        {
            var reviews = await _context.Reviews.FindAsync(id);

            if (reviews == null)
            {
                return NotFound();
            }

            return reviews;
        }

        // GET: v1/reviews/user/list
        [Route("user/list")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviews>>> GetReviewsUserList()
        {
            return Ok("Get Reviews User List");
        }

        // POST: vi/reviews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reviews>> PostReviews(Reviews reviews)
        {
            return Ok("Post Review");
            reviews.Id = Guid.NewGuid().ToString();
            reviews.User_Id = "ca39880d-1f68-44e1-a9ad-a7b652827e92";
            reviews.Created_At = DateTime.Now;
            _context.Reviews.Add(reviews);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReviewsExists(reviews.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReviews", new { id = reviews.Id }, reviews);
        }

        // POST: /v1/reviews/blacklist/03cfed66-964d-4093-9dc0-cf07dec241ac
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("blacklist/{idReview}")]
        [HttpPost]
        public async Task<ActionResult<Reviews>> PostBlackList(Guid idReview)
        {
            return Ok("PostBlackList");
        }

        // DELETE: v1/reviews/e2961ced-ef78-42c8-bb4e-f0eaf242ca23
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reviews>> DeleteReviews(string id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();

            return reviews;
        }

        private bool ReviewsExists(string id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
