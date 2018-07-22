using Microsoft.EntityFrameworkCore.Migrations;

namespace guidStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guids",
                columns: table => new
                {
                    guid = table.Column<string>(nullable: false),
                    expire = table.Column<int>(nullable: false),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guids", x => x.guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guids");
        }
    }
}
