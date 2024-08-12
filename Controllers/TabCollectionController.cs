using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabHubAPI.Contracts;
using TabHubAPI.DataAccess;
using TabHubAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TabHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabCollectionsController : ControllerBase
    {
        private readonly ThDbContext _dbContext;

        public TabCollectionsController(ThDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var collections = await _dbContext.TabCollections.Include(c => c.Tabs).ToListAsync(ct);

            return Ok(collections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var collection = await _dbContext.TabCollections.Include(c => c.Tabs).SingleOrDefaultAsync(c => c.Id == id, ct);

            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTabColRequest request, CancellationToken ct)
        {
            var collection = new TabCollection(request.Name, request.Description);

            await _dbContext.TabCollections.AddAsync(collection, ct);
            await _dbContext.SaveChangesAsync(ct);

            return Ok(collection);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
