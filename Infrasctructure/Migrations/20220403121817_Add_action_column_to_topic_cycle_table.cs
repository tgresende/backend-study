using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrasctructure.Migrations
{
    public partial class Add_action_column_to_topic_cycle_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Action",
                table: "TopicCycles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "TopicCycles");
        }
    }
}
