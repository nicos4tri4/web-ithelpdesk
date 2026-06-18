using System.ComponentModel.DataAnnotations;

namespace HelpdeskApp.Models.Entities
{
    public class TeamMember
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        public string Status { get; set; } = "Active";
    }
}
