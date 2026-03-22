using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.API.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000009999"),
                column: "CriadoEm",
                value: new DateTime(2026, 3, 22, 18, 54, 51, 790, DateTimeKind.Utc).AddTicks(779));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000009999"),
                column: "CriadoEm",
                value: new DateTime(2026, 3, 22, 18, 49, 1, 718, DateTimeKind.Utc).AddTicks(3190));
        }
    }
}
