using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class datavalor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 8, 21, 51, 56, 447, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Cliente",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Cliente");
        }
    }
}
