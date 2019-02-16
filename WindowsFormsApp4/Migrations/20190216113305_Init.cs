using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WindowsFormsApp4.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicEntities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StringCol1 = table.Column<string>(nullable: true),
                    StringCol2 = table.Column<string>(nullable: true),
                    IntCol1 = table.Column<int>(nullable: true),
                    SyncStatus = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ProjectTableId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SyncStatus = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTables",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SyncStatus = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableSchemas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ColumnName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsComboBox = table.Column<bool>(nullable: false),
                    ComboBoxValues = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    PhysicalColumnName = table.Column<string>(nullable: true),
                    SyncStatus = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ProjectTableId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSchemas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicEntities");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectTables");

            migrationBuilder.DropTable(
                name: "TableSchemas");
        }
    }
}
