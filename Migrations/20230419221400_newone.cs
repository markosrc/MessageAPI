using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageAPI.Migrations
{
    /// <inheritdoc />
    public partial class newone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Emails_EmailId",
                table: "Osobe");

            migrationBuilder.DropIndex(
                name: "IX_Osobe_EmailId",
                table: "Osobe");

            migrationBuilder.AddColumn<int>(
                name: "OsobaId",
                table: "Emails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_OsobaId",
                table: "Emails",
                column: "OsobaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Osobe_OsobaId",
                table: "Emails",
                column: "OsobaId",
                principalTable: "Osobe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Osobe_OsobaId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_OsobaId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "OsobaId",
                table: "Emails");

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_EmailId",
                table: "Osobe",
                column: "EmailId",
                unique: true,
                filter: "[EmailId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Emails_EmailId",
                table: "Osobe",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id");
        }
    }
}
