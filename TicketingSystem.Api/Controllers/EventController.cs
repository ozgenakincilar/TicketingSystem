// TicketingSystem.Api/Controllers/EventController.cs
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Application.Interfaces;
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IService<Event> _eventService;

        public EventController(IService<Event> eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var eventItem = await _eventService.GetByIdAsync(id);
            if (eventItem == null)
                return NotFound();
            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event eventItem)
        {
            if (eventItem == null)
                return BadRequest();

            await _eventService.AddAsync(eventItem);
            return CreatedAtAction(nameof(Get), new { id = eventItem.Id }, eventItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Event eventItem)
        {
            if (id != eventItem.Id)
                return BadRequest();

            await _eventService.UpdateAsync(eventItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteAsync(id);
            return NoContent();
        }
    }
}
