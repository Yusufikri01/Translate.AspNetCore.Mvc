using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Translate.AspNetCore.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWordAndWordLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordLevels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordLevelId",
                table: "Words",
                column: "WordLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordLevels_WordLevelId",
                table: "Words",
                column: "WordLevelId",
                principalTable: "WordLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordLevels_WordLevelId",
                table: "Words");

            migrationBuilder.DropTable(
                name: "WordLevels");

            migrationBuilder.DropIndex(
                name: "IX_Words_WordLevelId",
                table: "Words");
        }
    }
}
