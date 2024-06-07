using AutoMapper;
using LegendMotor.Api.Dtos;
using LegendMotor.Dal;
using LegendMotor.Dal.Repository;
using LegendMotor.Domain.Abstractions.Repositories;
using LegendMotor.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace LegendMotor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BinLocationController : Controller
    {
        private readonly ILogger<StaffController> _logger;
        private readonly HttpContext _http;
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        private readonly IBinLocationRepository _binLocationRepository;

        public BinLocationController(ILogger<StaffController> logger, IHttpContextAccessor http, DataContext ctx, IMapper mapper, BinLocationRepository binLocationRepository)
        {
            _logger = logger;
            _http = http.HttpContext;
            _ctx = ctx;
            _mapper = mapper;
            _binLocationRepository = binLocationRepository;
        }

        [HttpGet("/api/GetAllBinLocation")]
        public async Task<IActionResult> GetAllBinLocation()
        {
            var binLocation = await _ctx.BinLocation.ToListAsync();
            return Ok(binLocation);
        }

        [HttpGet("/api/GetAllBinLocationSpare")]
        public async Task<IActionResult> GetAllBinLocationSpare()
        {
            var binLocationSpares = await _ctx.BinLocationSpare.ToListAsync();
            return Ok(binLocationSpares);
        }

        [HttpGet("/api/CreateBinLocationStaff")]
        public async Task<IActionResult> GetAllBinLocationStaff()
        {
            var binLocationStaff = await _ctx.BinLocationStaff.ToListAsync();
            return Ok(binLocationStaff);
        }

        [HttpPost("/api/CreateBinLocationSpare")]
        public async Task<IActionResult> CreateBinLocationSpare([FromBody] BinLocationSpare binLocationSpare)
        {
            binLocationSpare.Id = Guid.NewGuid();
            _ctx.BinLocationSpare.Add(binLocationSpare);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("/api/CreateBinLocationStaff")]
        public async Task<IActionResult> CreateBinLocationStaff([FromBody] BinLocationStaff binLocationStaff)
        {
            _ctx.BinLocationStaff.Add(binLocationStaff);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [Route("{binLocationCode}/{spareName}/{category}")]
        [HttpGet]
        public async Task<ActionResult<List<BinLocationSpareDto>>> GetStockList(string binLocationCode, string spareName, char category)
        {
                    var item = _ctx.BinLocationSpare.Join(_ctx.Spare,
                    spare => spare.SpareId,
                    spare2 => spare2.SpareId,
                    (spare, spare2) => new { BinLocationSpare = spare, Spare = spare2 })
                        .Where(p => p.BinLocationSpare.BinLocationCode.Equals(binLocationCode))
                        .Select(s => new BinLocationSpareDto
                        {
                            SpareId = s.BinLocationSpare.SpareId,
                            Name = s.Spare.Name,
                            Description = s.Spare.Description,
                            Category = s.Spare.Category,
                            Weight = s.Spare.Weight,
                            Stock = s.BinLocationSpare.Stock,
                            ROL = s.BinLocationSpare.ROL
                        }
                    ).Where(s => s.Category.Equals(category) && s.Name.Equals(spareName))
                     .ToList();
            return Ok(item);
        }

    }
}
