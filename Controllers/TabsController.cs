using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabHubAPI.Contracts;
using TabHubAPI.DataAccess;
using TabHubAPI.Models;
using TabHubAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TabHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabsController : ControllerBase
    {
        private readonly ITabRepository _tabRepository;
        public TabsController(ITabRepository tabRepository)
        {
            _tabRepository = tabRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var tabs = await _tabRepository.GetAllAsync(ct);

            return Ok(tabs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var tab = await _tabRepository.GetByIdAsync(id, ct);

            return Ok(tab);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTabRequest request, CancellationToken ct)
        {
            var tab = new Tab(request.Url, request.collection, request.Description);

            await _tabRepository.CreateAsync(tab, ct);
            await _tabRepository.SaveAsync(ct);

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
