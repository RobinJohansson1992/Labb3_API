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

        [HttpPost("AddNewLink")]
        public async Task<IActionResult> AddNewLink(CreateAddLinkRequest addLinkRequest)
        {
            if (addLinkRequest == null)
            {
                return BadRequest("No link was added");
            }
            var linkToAdd = new Link
            {
                Url = addLinkRequest.Url,
                UserId = addLinkRequest.UserId,
                InterestId = addLinkRequest.InterestId
            };
            _db.Links.Add(linkToAdd);
            await _db.SaveChangesAsync();
            return Ok(linkToAdd);
        }

        [HttpGet("GetAllLinks")]
        public async Task<IEnumerable<Link>> GetAllLinks()
        {
            var links = await _db.Links.ToListAsync();
            return links;
        }
    }
}
