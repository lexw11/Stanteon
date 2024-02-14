using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StantreonApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipMembersCreators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreatorMember",
                columns: table => new
                {
                    CreatorsUserId = table.Column<long>(type: "bigint", nullable: false),
                    MembersUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatorMember", x => new { x.CreatorsUserId, x.MembersUserId });
                    table.ForeignKey(
                        name: "FK_CreatorMember_Creators_CreatorsUserId",
                        column: x => x.CreatorsUserId,
                        principalTable: "Creators",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_CreatorMember_Members_MembersUserId",
                        column: x => x.MembersUserId,
                        principalTable: "Members",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatorMember_MembersUserId",
                table: "CreatorMember",
                column: "MembersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatorMember");
        }
    }
}
