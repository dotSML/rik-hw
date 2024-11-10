using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class EventAttendees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeEvent");

            migrationBuilder.CreateTable(
                name: "EventAttendees",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendees", x => new { x.EventId, x.AttendeeId });
                    table.ForeignKey(
                        name: "FK_EventAttendees_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "AttendeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAttendees_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_AttendeeId",
                table: "EventAttendees",
                column: "AttendeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventAttendees");

            migrationBuilder.CreateTable(
                name: "AttendeeEvent",
                columns: table => new
                {
                    AttendeesAttendeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventsEventId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeEvent", x => new { x.AttendeesAttendeeId, x.EventsEventId });
                    table.ForeignKey(
                        name: "FK_AttendeeEvent_Attendees_AttendeesAttendeeId",
                        column: x => x.AttendeesAttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "AttendeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendeeEvent_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeEvent_EventsEventId",
                table: "AttendeeEvent",
                column: "EventsEventId");
        }
    }
}
