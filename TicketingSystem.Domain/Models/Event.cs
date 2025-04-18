namespace TicketingSystem.Domain.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime EventDate { get; set; }

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
