using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osobe_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailOdId = table.Column<int>(type: "int", nullable: true),
                    EmailPremaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poruke_Emails_EmailOdId",
                        column: x => x.EmailOdId,
                        principalTable: "Emails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Poruke_Emails_EmailPremaId",
                        column: x => x.EmailPremaId,
                        principalTable: "Emails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_EmailId",
                table: "Osobe",
                column: "EmailId",
                unique: true,
                filter: "[EmailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_EmailOdId",
                table: "Poruke",
                column: "EmailOdId");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_EmailPremaId",
                table: "Poruke",
                column: "EmailPremaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "Poruke");

            migrationBuilder.DropTable(
                name: "Emails");
        }
    }
}
