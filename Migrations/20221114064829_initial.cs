using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAS.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WordDocuments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wordid = table.Column<int>(type: "INTEGER", nullable: false),
                    documentid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordDocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_WordDocuments_Documents_documentid",
                        column: x => x.documentid,
                        principalTable: "Documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordDocuments_Words_wordid",
                        column: x => x.wordid,
                        principalTable: "Words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordDocuments_documentid",
                table: "WordDocuments",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "IX_WordDocuments_wordid",
                table: "WordDocuments",
                column: "wordid");

            migrationBuilder.CreateIndex(
                name: "IX_WordDocuments_wordid_documentid",
                table: "WordDocuments",
                columns: new[] { "wordid", "documentid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_text",
                table: "Words",
                column: "text",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordDocuments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
