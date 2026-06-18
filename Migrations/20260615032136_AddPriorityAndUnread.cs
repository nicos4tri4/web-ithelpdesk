using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPriorityAndUnread : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasUnreadUserMessage",
                table: "TicketRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "TicketRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasUnreadUserMessage",
                table: "TicketRequests");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TicketRequests");
        }
    }
}
