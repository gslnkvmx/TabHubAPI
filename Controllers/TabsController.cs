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
    public class TabsController : ControllerBase
    {
        private readonly ThDbContext _dbContext;

        public TabsController(ThDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var tabs = await _dbContext.Tabs.ToListAsync(ct);

            return Ok(tabs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tab = await _dbContext.Tabs.SingleOrDefaultAsync(x => x.Id == id);

            return Ok(tab);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTabRequest request, CancellationToken ct)
        {
            var tab = new Tab(request.Url, request.collection, request.Description);

            await _dbContext.Tabs.AddAsync(tab, ct);
            await _dbContext.SaveChangesAsync(ct);

            return Ok(tab);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
