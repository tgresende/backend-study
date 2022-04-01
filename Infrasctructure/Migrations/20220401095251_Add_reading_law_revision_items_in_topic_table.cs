using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrasctructure.Migrations
{
    public partial class Add_reading_law_revision_items_in_topic_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "lawsCycle",
                table: "Topics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lawsItem",
                table: "Topics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "readingCycle",
                table: "Topics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "readingItem",
                table: "Topics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "revisionCycle",
                table: "Topics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "revisionItem",
                table: "Topics",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lawsCycle",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "lawsItem",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "readingCycle",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "readingItem",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "revisionCycle",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "revisionItem",
                table: "Topics");
        }
    }
}
