﻿
using api.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/attendees")]
    public class AttendeeController: ControllerBase
    {
        private readonly IAttendeeService _attendeeService;
        public AttendeeController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendeeById([FromRoute] Guid id)
        {
            var attendeeDto = await _attendeeService.GetByIdAsync(id);
            return Ok(attendeeDto);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetAttendeesForEvent(Guid eventId)
        {
            var attendees = await _attendeeService.GetAttendeesForEventAsync(eventId);
            return Ok(attendees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendee(Guid eventId, [FromBody] CreateAttendeeDto dto)
        {
            var attendeeId = await _attendeeService.CreateAttendeeAsync(eventId, dto);
            return Ok(attendeeId);
        }
    }
}
