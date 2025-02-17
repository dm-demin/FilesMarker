using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilesMarker.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hashtags_hierarchies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hashtags_hierarchies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hashtags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    hierarchy_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hashtags", x => x.id);
                    table.ForeignKey(
                        name: "FK_hashtags_hashtags_hierarchies_hierarchy_id",
                        column: x => x.hierarchy_id,
                        principalTable: "hashtags_hierarchies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "files_hashtags",
                columns: table => new
                {
                    file_id = table.Column<Guid>(type: "uuid", nullable: false),
                    hashtag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files_hashtags", x => new { x.file_id, x.hashtag_id });
                    table.ForeignKey(
                        name: "FK_files_hashtags_files_file_id",
                        column: x => x.file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_files_hashtags_hashtags_hashtag_id",
                        column: x => x.hashtag_id,
                        principalTable: "hashtags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_files_hashtags_hashtag_id",
                table: "files_hashtags",
                column: "hashtag_id");

            migrationBuilder.CreateIndex(
                name: "IX_hashtags_hierarchy_id",
                table: "hashtags",
                column: "hierarchy_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "files_hashtags");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "hashtags");

            migrationBuilder.DropTable(
                name: "hashtags_hierarchies");
        }
    }
}
