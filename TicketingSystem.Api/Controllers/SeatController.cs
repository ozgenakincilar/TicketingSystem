using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingSystem.Application.Interfaces;
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IService<Seat> _seatService;

        public SeatController(IService<Seat> seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetAll()
        {
            var seats = await _seatService.GetAllAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetById(int id)
        {
            var seat = await _seatService.GetByIdAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Seat seat)
        {
            if (seat == null)
            {
                return BadRequest("Seat cannot be null.");
            }

            await _seatService.AddAsync(seat);

            return CreatedAtAction(nameof(GetById), new { id = seat.Id }, seat);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Seat seat)
        {
            if (seat == null || id != seat.Id)
            {
                return BadRequest("Invalid seat data.");
            }

            var existingSeat = await _seatService.GetByIdAsync(id);
            if (existingSeat == null)
            {
                return NotFound();
            }

            await _seatService.UpdateAsync(seat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var seat = await _seatService.GetByIdAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            await _seatService.DeleteAsync(id);
            return NoContent();
        }
    }
}
