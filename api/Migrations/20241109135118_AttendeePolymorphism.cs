using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AttendeePolymorphism : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "IdentificationNumber",
                table: "Attendees",
                newName: "ParticipantRequests");

            migrationBuilder.AddColumn<int>(
                name: "AttendeeCount",
                table: "Attendees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttendeeType",
                table: "Attendees",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Attendees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyRegistrationCode",
                table: "Attendees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalIdCode",
                table: "Attendees",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendeeCount",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "AttendeeType",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "CompanyRegistrationCode",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "PersonalIdCode",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "ParticipantRequests",
                table: "Attendees",
                newName: "IdentificationNumber");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Attendees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
