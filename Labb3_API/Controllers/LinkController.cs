using Labb3_API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Labb3_API.models.DTOs.LinkDTOs;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly UserInterestsDbContext _db;

        public LinkController(UserInterestsDbContext db)
        {
            _db = db;
        }

        [HttpPost("{userId}/{interestId}", Name = "AddNewLink")]
        public async Task<IActionResult> AddNewLink(int userId, int interestId, CreateAddLinkRequest addLinkRequest)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
            {
                return BadRequest("User was not found.");
            }
            var interest = await _db.Interests.FindAsync(interestId);
            if(interest == null)
            {
                return BadRequest("Interest was not found.");
            }

            var linkToAdd = new Link
            {
                Url = addLinkRequest.Url,
                UserId = userId,
                InterestId = interestId
            };
            _db.Links.Add(linkToAdd);
            await _db.SaveChangesAsync();
            return Ok(linkToAdd);
        }

        [HttpGet("{userId}", Name = "GetLinksByUserId")]
        public async Task<IActionResult> GetLinksByUserId(int userId)
        {
            var links = await _db.Links
                .Where(l => l.UserId == userId)
                .Select(l => new
                {
                    l.Id,
                    l.Url,
                    User = new
                    {
                        l.User.Id,
                        l.User.Name
                    }
                })
                .ToListAsync();

            return Ok(links);
        }

        [HttpGet("GetAllLinks")]
        public async Task<IActionResult> GetAllLinks()
        {
            var links = await _db.Links
                .Select(l => new
                {
                    l.Id,
                    l.Url,
                })
                .ToListAsync();

            return Ok(links);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            var link = await _db.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound("Link was not found.");
            }

            _db.Links.Remove(link);
            await _db.SaveChangesAsync();
            return Ok("Link deleted.");
        }
    }
}
