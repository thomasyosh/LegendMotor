using AutoMapper;
using LegendMotor.Api.Dtos;
using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LegendMotor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealerController : Controller
    {
        private readonly ILogger<StaffController> _logger;
        private readonly HttpContext _http;
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public DealerController(ILogger<StaffController> logger, IHttpContextAccessor httpContextAccessor, DataContext ctx, IMapper mapper)
        {
            _logger = logger;
            _http = httpContextAccessor.HttpContext;
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet("GetAllDealer")]
        public async Task<IActionResult> GetAllDealer()
        {
            var dealers = await _ctx.Dealer.ToListAsync();
            return Ok(dealers);
        }

        [HttpPost("CreateDealer")]
        public async Task<IActionResult> CreateDealer([FromBody] Dealer dealer)
        {
            dealer.DealerCode = Guid.NewGuid().ToString();
            _ctx.Dealer.Add(dealer);
            await _ctx.SaveChangesAsync();

            return Ok(dealer);
        }
    }
}
