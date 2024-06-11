using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Description", "ListId", "State", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 11, 9, 40, 19, 720, DateTimeKind.Local).AddTicks(4590), "Description 1", 1, "To Do", "Task 1" },
                    { 2, new DateTime(2024, 6, 11, 9, 40, 19, 720, DateTimeKind.Local).AddTicks(4636), "Description 2", 1, "To Do", "Task 2" },
                    { 3, new DateTime(2024, 6, 11, 9, 40, 19, 720, DateTimeKind.Local).AddTicks(4639), "Description 3", 1, "To Do", "Task 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
