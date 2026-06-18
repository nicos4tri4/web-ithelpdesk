using HelpdeskApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TicketRequest> TicketRequests { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<FollowUpNote> FollowUpNotes { get; set; }
    }
}
