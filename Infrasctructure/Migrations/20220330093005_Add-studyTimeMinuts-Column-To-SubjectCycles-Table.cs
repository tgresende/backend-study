using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrasctructure.Migrations
{
    public partial class AddstudyTimeMinutsColumnToSubjectCyclesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyTimeMinutes",
                table: "SubjectCycles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudyTimeMinutes",
                table: "SubjectCycles");
        }
    }
}
