using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Domain.Models
{
    public class EventFeedback
    {
        public string Id { get; set; }  
        public string EventId { get; set; }  
        public string UserId { get; set; } 
        public int Rating { get; set; }  
        public string Comment { get; set; } 
        public DateTime FeedbackDate { get; set; }
    }

}
