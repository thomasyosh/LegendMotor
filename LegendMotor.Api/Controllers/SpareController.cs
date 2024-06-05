using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LegendMotor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpareController : Controller
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IHttpContextAccessor _http;
        private readonly DataContext _ctx;

        public SpareController(ILogger<StaffController> logger, IHttpContextAccessor http, DataContext ctx)
        {
            _logger = logger;
            _http = http;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpare()
        {
            var spare = await _ctx.Spare.ToListAsync();
            return Ok(spare);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSpareById(string id)
        {
            var spare = await _ctx.Spare.FirstOrDefaultAsync(spare => spare.SpareId == id);
            return Ok(spare);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpare([FromBody] Spare spare)
        {
            _ctx.Spare.Add(spare);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSpareById), new { id = spare.SpareId }, spare);
        }
    }
}
