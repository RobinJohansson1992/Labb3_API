using Labb3_API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly UserInterestsDbContext _db;

        public InterestController(UserInterestsDbContext db)
        {
            _db = db;
        }

        [HttpPost("AddInterest")]
        public async Task<IActionResult> AddNewInterest(Interest interestToAdd)
        {
            if(interestToAdd == null)
            {
                return BadRequest("Interest was not registered.");
            }
            _db.Interests.Add(interestToAdd);
            await _db.SaveChangesAsync();
            return Ok(interestToAdd);
        }

        [HttpGet("GetInterests")]
        public async Task<IEnumerable<Interest>> GetAllInterests()
        {
            var interests = await _db.Interests.ToListAsync();
            return interests;
        }

    }
}
