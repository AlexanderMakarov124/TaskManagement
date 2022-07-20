using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataAccess.Migrations
{
    public partial class AddMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline", "Name" },
                values: new object[] { new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6377), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6369), "Issue with inherited estimated hours" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deadline", "Description", "EstimatedHours", "Executors", "IssueId", "Name", "Status" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6380), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6380), "Test description.", 50, "Executor", 1, "Second issue", 2 },
                    { 3, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6383), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6382), "Test description.", 50, "Executor", 1, "Third issue", 1 },
                    { 4, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6385), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6384), "Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string", 150, "Executor", null, "Issue with huge description", 1 },
                    { 10, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6396), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6396), null, 150, "Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor", null, "Issue with very very very very very very very very very very very very very very very very long name", 3 }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deadline", "Description", "EstimatedHours", "Executors", "IssueId", "Name", "Status" },
                values: new object[] { 5, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6387), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6386), null, 150, "Executor", 2, "Child issue", 1 });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deadline", "Description", "EstimatedHours", "Executors", "IssueId", "Name", "Status" },
                values: new object[] { 6, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6388), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6388), null, 150, "Executor", 5, "Child child issue", 1 });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deadline", "Description", "EstimatedHours", "Executors", "IssueId", "Name", "Status" },
                values: new object[] { 7, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6390), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6389), null, 150, "Executor", 6, "Child child child issue", 1 });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deadline", "Description", "EstimatedHours", "Executors", "IssueId", "Name", "Status" },
                values: new object[] { 8, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6392), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6391), null, 150, "Executor", 7, "Child child child issue", 1 });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deadline", "Description", "EstimatedHours", "Executors", "IssueId", "Name", "Status" },
                values: new object[] { 9, null, new DateTime(2022, 7, 20, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6394), new DateTime(2022, 7, 27, 11, 20, 20, 651, DateTimeKind.Utc).AddTicks(6393), null, 150, "Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor", 8, "Child child child issue with many executors", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline", "Name" },
                values: new object[] { new DateTime(2022, 7, 20, 11, 3, 5, 908, DateTimeKind.Utc).AddTicks(2577), new DateTime(2022, 7, 27, 11, 3, 5, 908, DateTimeKind.Utc).AddTicks(2550), "First issue" });
        }
    }
}
