using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.API.Migrations
{
    /// <inheritdoc />
    public partial class AjustesIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Técnico TI" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Analista Junior" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Analista Pleno" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Analista Senior" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Médico" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Recepção" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "RH" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Serviços Gerais" }
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "Clínica Geral" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "Pediatria" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "Ortopedia" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "Urologia" },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "Ginecologia" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CPF", "CargoId", "CriadoEm", "Discriminator", "Email", "Nivel", "Nome", "PrimeiroAcesso", "SenhaHash", "Tipo" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000009999"), "00000000000", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2026, 3, 22, 18, 49, 1, 718, DateTimeKind.Utc).AddTicks(3190), "Funcionario", "admin@hospital.com", 4, "Administrador TI", true, "123456", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000009999"));

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Técnico TI" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Analista Junior" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Analista Pleno" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Analista Senior" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Médico" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Recepção" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "RH" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Serviços Gerais" }
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Clínica Geral" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Pediatria" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Ortopedia" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Urologia" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Ginecologia" }
                });
        }
    }
}
