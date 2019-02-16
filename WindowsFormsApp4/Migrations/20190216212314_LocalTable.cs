using Microsoft.EntityFrameworkCore.Migrations;

namespace WindowsFormsApp4.Migrations
{
    public partial class LocalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalTables",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalTables", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalTables");
        }
    }
}
