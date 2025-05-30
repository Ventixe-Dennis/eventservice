using Business.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.EventService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventService eventService) : ControllerBase
    {
        private readonly IEventService _eventService = eventService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _eventService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(string id)
        {
            var result = await _eventService.GetAsync(id);
            return result != null ? Ok(result) : NotFound(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _eventService.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetEvent), new { id = result.Result }, dto);
        }

    }
}
