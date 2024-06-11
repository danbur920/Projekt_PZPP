using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Board.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(6993), "Description 1", "Board 1", new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7054) },
                    { 2, new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7058), "Description 2", "Board 2", new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7209) },
                    { 3, new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7214), "Description 3", "Board 3", new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7217) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
