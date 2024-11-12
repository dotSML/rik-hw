using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("61065a73-c5b2-4a2a-8889-3afcae55f6df"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("f0911619-182e-4a68-b0f1-d87b9a21d414"));

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Method = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    AttendeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.AttendeeId);
                    table.ForeignKey(
                        name: "FK_Attendee_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendee_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Method" },
                values: new object[,]
                {
                    { new Guid("97a4e915-652d-47aa-aab5-441624365509"), "Bank transfer" },
                    { new Guid("ca066759-b7d1-41af-8f95-980226cef322"), "Cash" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_EventId",
                table: "Attendee",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_PaymentMethodId",
                table: "Attendee",
                column: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("97a4e915-652d-47aa-aab5-441624365509"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("ca066759-b7d1-41af-8f95-980226cef322"));

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Method" },
                values: new object[,]
                {
                    { new Guid("61065a73-c5b2-4a2a-8889-3afcae55f6df"), "Bank transfer" },
                    { new Guid("f0911619-182e-4a68-b0f1-d87b9a21d414"), "Cash" }
                });
        }
    }
}
