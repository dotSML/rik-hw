
using api.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/attendees")]
    public class AttendeeController : ControllerBase
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
            return attendeeDto != null ? Ok(attendeeDto) : NotFound();
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetAttendeesForEvent([FromRoute] Guid eventId)
        {
            var attendees = await _attendeeService.GetAttendeesForEventAsync(eventId);
            return attendees != null ? Ok(attendees) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendee([FromBody] CreateAttendeeDto dto)
        {
            try
            {
                var attendeeId = await _attendeeService.CreateAttendeeAsync(dto);
                return Ok(attendeeId);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAttendee([FromRoute] Guid id, [FromBody] UpdateAttendeeDto dto)
        {
            try
            {
                await _attendeeService.UpdateByIdAsync(id, dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendee([FromRoute] Guid id)
        {
            try
            {
                await _attendeeService.DeleteByIdAsync(id);
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
