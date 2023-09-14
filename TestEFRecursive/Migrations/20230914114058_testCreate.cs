using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestEFRecursive.Migrations
{
    /// <inheritdoc />
    public partial class testCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.CheckConstraint("CK_Email", "Email LIKE '__%@__%.%'");
                });

            migrationBuilder.CreateTable(
                name: "ProfileShared",
                columns: table => new
                {
                    BasedUserId = table.Column<int>(type: "int", nullable: false),
                    SharedProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileShared", x => new { x.BasedUserId, x.SharedProfileId });
                    table.ForeignKey(
                        name: "FK_ProfileShared_Profile_BasedUserId",
                        column: x => x.BasedUserId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileShared_Profile_SharedProfileId",
                        column: x => x.SharedProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "g.adnet@email.be", "Geoffroy", "Adnet" },
                    { 2, "s.connor@skynet.com", "Sarah", "Connor" },
                    { 3, "hell.master69@lux.god", "Lucifer", "Morningstar" }
                });

            migrationBuilder.InsertData(
                table: "ProfileShared",
                columns: new[] { "BasedUserId", "SharedProfileId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Email",
                table: "Profile",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileShared_SharedProfileId",
                table: "ProfileShared",
                column: "SharedProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileShared");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
