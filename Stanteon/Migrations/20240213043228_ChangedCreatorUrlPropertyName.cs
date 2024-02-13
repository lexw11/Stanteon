using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StantreonApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCreatorUrlPropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "urlName",
                table: "Creators",
                newName: "urlHandle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "urlHandle",
                table: "Creators",
                newName: "urlName");
        }
    }
}
