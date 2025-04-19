using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Application.Interfaces;
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSeatReservationController : ControllerBase
    {
        private readonly IService<UserSeatReservation> _userSeatReservationService;

        public UserSeatReservationController(IService<UserSeatReservation> userSeatReservationService)
        {
            _userSeatReservationService = userSeatReservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations = await _userSeatReservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reservation = await _userSeatReservationService.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserSeatReservation reservation)
        {
            if (reservation == null)
                return BadRequest();

            await _userSeatReservationService.AddAsync(reservation);
            return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserSeatReservation reservation)
        {
            if (id != reservation.Id)
                return BadRequest();

            await _userSeatReservationService.UpdateAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userSeatReservationService.DeleteAsync(id);
            return NoContent();
        }
    }
}

