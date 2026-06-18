using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSenderNameToNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "FollowUpNotes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "FollowUpNotes");
        }
    }
}
