using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskApp.Migrations
{
    /// <inheritdoc />
    public partial class AddQueueNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QueueNumber",
                table: "TicketRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueueNumber",
                table: "TicketRequests");
        }
    }
}
