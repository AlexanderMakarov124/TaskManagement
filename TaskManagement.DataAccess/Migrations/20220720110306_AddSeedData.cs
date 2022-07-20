using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataAccess.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deadline", "Description", "EstimatedHours", "Executors", "IssueId", "Name", "Status" },
                values: new object[] { 1, null, new DateTime(2022, 7, 20, 11, 3, 5, 908, DateTimeKind.Utc).AddTicks(2577), new DateTime(2022, 7, 27, 11, 3, 5, 908, DateTimeKind.Utc).AddTicks(2550), "Test description.", 100, "Executor", null, "First issue", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
