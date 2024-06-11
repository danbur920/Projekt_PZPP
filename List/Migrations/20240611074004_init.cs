using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace List.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "BoardId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8152), "Description 1", "List 1", new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8197) },
                    { 2, 1, new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8200), "Description 2", "List 2", new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8201) },
                    { 3, 1, new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8204), "Description 3", "List 3", new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8206) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lists");
        }
    }
}
