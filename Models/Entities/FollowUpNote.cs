using System;
using System.ComponentModel.DataAnnotations;

namespace HelpdeskApp.Models.Entities
{
    public class FollowUpNote
    {
        [Key]
        public int Id { get; set; }

        public string TicketRequestId { get; set; }
        public TicketRequest TicketRequest { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        public string Note { get; set; }

        public string SenderName { get; set; } = "System";
    }
}
