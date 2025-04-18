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

        // Constructor, SeatService bağımlılığını enjekte eder
        public SeatController(IService<Seat> seatService)
        {
            _seatService = seatService;
        }

        // Tüm Seat'ları almak için GET isteği
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetAll()
        {
            var seats = await _seatService.GetAllAsync();
            return Ok(seats);
        }

        // Id'ye göre bir Seat almak için GET isteği
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

        // Yeni bir Seat oluşturmak için POST isteği
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Seat seat)
        {
            if (seat == null)
            {
                return BadRequest("Seat cannot be null.");
            }

            // Seat'ı veritabanına ekleyin
            await _seatService.AddAsync(seat);

            // Eğer oluşturma başarılıysa, CreatedAtAction ile yeni kaydın URL'sini dönün
            return CreatedAtAction(nameof(GetById), new { id = seat.Id }, seat);
        }


        // Var olan bir Seat'ı güncellemek için PUT isteği
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

        // Bir Seat'ı silmek için DELETE isteği
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
