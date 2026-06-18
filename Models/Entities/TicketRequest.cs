using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpdeskApp.Models.Entities
{
    public class TicketRequest
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string QueueNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Requester Name")]
        public string RequesterName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Target Delivery")]
        public DateTime TargetDelivery { get; set; }

        public string? AttachmentName { get; set; }
        public string? AttachmentUrl { get; set; }

        public string Status { get; set; } = "Waiting";

        [Display(Name = "Assigned Resource")]
        public string? AssignedResource { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for follow-ups
        public List<FollowUpNote> FollowUpNotes { get; set; } = new List<FollowUpNote>();

        public string Priority { get; set; } = "Low";
        public bool HasUnreadUserMessage { get; set; } = false;
        
        [Display(Name = "Related URL")]
        public string? ProblemUrl { get; set; }

        [Display(Name = "Tags")]
        public string? Tags { get; set; }
    }
}
