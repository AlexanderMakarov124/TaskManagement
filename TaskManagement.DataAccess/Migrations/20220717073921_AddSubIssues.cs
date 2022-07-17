using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataAccess.Migrations
{
    public partial class AddSubIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueId",
                table: "Issues",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Issues_IssueId",
                table: "Issues",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Issues_IssueId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssueId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Issues");
        }
    }
}
