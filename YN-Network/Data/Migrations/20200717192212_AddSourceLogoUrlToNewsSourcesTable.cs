using Microsoft.EntityFrameworkCore.Migrations;

namespace YN_Network.Data.Migrations
{
    public partial class AddSourceLogoUrlToNewsSourcesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceLogoUrl",
                table: "NewsSources",
                type: "string",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceLogoUrl",
                table: "NewsSources");
        }
    }
}
