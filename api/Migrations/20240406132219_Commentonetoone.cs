using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Commentonetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22af1f06-9b27-4c0b-84d6-83545db86ffb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26ab5b0b-8e6b-4dba-b53d-2e54f2429bdb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be1788cd-881b-4109-853d-712aa4b80cca", null, "User", "USER" },
                    { "fad1d1c6-b37a-4a09-97dd-caa668620a23", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be1788cd-881b-4109-853d-712aa4b80cca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad1d1c6-b37a-4a09-97dd-caa668620a23");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22af1f06-9b27-4c0b-84d6-83545db86ffb", null, "User", "USER" },
                    { "26ab5b0b-8e6b-4dba-b53d-2e54f2429bdb", null, "Admin", "ADMIN" }
                });
        }
    }
}
