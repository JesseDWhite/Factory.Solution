using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class jesse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RepairsNeeded",
                table: "Machines",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairsNeeded",
                table: "Machines");
        }
    }
}
