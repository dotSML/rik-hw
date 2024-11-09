using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/attendees")]
    public class AttendeeController
    {
        private readonly IAttendeeService _attendeeService;
        public AttendeeController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAttendeeById(Guid id)
        {
            var attendeeDto = await _attendeeService.GetByIdAsync(id);
            return attendeeDto != null ? Ok(attendeeDto) : NotFound();
        }
    }
}
