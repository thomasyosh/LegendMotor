﻿using AutoMapper;
using LegendMotor.Api.Dtos;
using LegendMotor.Dal;
using LegendMotor.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LegendMotor.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        private readonly ILogger<StaffController> _logger;
        private readonly HttpContext _http;
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public StaffController(
                                ILogger<StaffController> logger,
                                IHttpContextAccessor httpContextAccessor,
                                DataContext ctx,
                                IMapper mapper

            )
        {
            _logger = logger;
            _http = httpContextAccessor.HttpContext;
            _ctx = ctx;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await _ctx.Staff.ToListAsync();
            return Ok(staff);
        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStaffById(string id)
        {
            var staff = await _ctx.Staff.FirstOrDefaultAsync(staff => staff.StaffId == id);
            return Ok(staff);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] StaffCreateDto staff)
        {
            var domainStaff = _mapper.Map<Staff>(staff);
            domainStaff.StaffId = Guid.NewGuid().ToString();
            _ctx.Staff.Add(domainStaff);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaffById), new { id = domainStaff.StaffId }, domainStaff);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStaff([FromBody] Staff updated, string id)
        {
            var staff = await _ctx.Staff.FirstOrDefaultAsync(staff => staff.StaffId == id);
            staff.Password = updated.Password;
            staff.Name = updated.Name;
            staff.Gemder = updated.Gemder;
            staff.Email = updated.Email;
            staff.Phone = updated.Phone;
            staff.Address = updated.Address;
            staff.AreaCode  = updated.AreaCode;
            staff.PositionCode = updated.PositionCode;
            _ctx.Staff.Update(staff);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStaff(string id)
        {
            var staff = await _ctx.Staff.FirstOrDefaultAsync(staff => staff.StaffId == id);
            _ctx.Staff.Remove(staff);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}