using Microsoft.EntityFrameworkCore.Migrations;

namespace FavouriteService.Migrations
{
    public partial class favtube : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavVideosTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    VideoTitle = table.Column<string>(nullable: true),
                    ChannelTitle = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavVideosTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavVideosTable");
        }
    }
}
