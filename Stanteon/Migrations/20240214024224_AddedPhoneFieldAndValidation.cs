using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StantreonApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedPhoneFieldAndValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Members",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Creators",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Phone",
                table: "Members",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creators_Phone",
                table: "Creators",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_Phone",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Creators_Phone",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Creators");
        }
    }
}
