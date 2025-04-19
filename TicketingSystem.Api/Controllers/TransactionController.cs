using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Application.Interfaces;
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IService<Transaction> _transactionService;

        public TransactionController(IService<Transaction> transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionService.GetAllAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null)
                return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transaction transaction)
        {
            if (transaction == null)
                return BadRequest();

            await _transactionService.AddAsync(transaction);
            return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Transaction transaction)
        {
            if (id != transaction.Id)
                return BadRequest();

            await _transactionService.UpdateAsync(transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _transactionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
