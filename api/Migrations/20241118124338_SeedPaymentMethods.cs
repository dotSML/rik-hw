using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedPaymentMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Method" },
                values: new object[,]
                {
                    { new Guid("146457be-646c-413d-87a5-becd55d8aa0f"), "CASH" },
                    { new Guid("596d811f-cc83-4fcb-ba57-9b5107cbe4d6"), "BANK_TRANSFER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("146457be-646c-413d-87a5-becd55d8aa0f"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("596d811f-cc83-4fcb-ba57-9b5107cbe4d6"));
        }
    }
}
