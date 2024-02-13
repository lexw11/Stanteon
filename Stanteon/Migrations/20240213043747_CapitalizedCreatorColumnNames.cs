using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StantreonApi.Migrations
{
    /// <inheritdoc />
    public partial class CapitalizedCreatorColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "urlHandle",
                table: "Creators",
                newName: "UrlHandle");

            migrationBuilder.RenameColumn(
                name: "pageName",
                table: "Creators",
                newName: "PageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlHandle",
                table: "Creators",
                newName: "urlHandle");

            migrationBuilder.RenameColumn(
                name: "PageName",
                table: "Creators",
                newName: "pageName");
        }
    }
}
