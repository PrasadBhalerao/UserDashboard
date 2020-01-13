using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    KeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.KeyID);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "KeyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "KeyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "KeyID", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer Executive" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "KeyID", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Pending" },
                    { 3, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "KeyID", "Email", "MobileNumber", "Name", "RoleId", "StatusId" },
                values: new object[,]
                {
                    { 1, "user1@abc.com", "8181811818", "User 1", 1, 1 },
                    { 4, "user4@abc.com", "8181811818", "User 4", 2, 1 },
                    { 2, "user2@abc.com", "8181811818", "User 2", 1, 2 },
                    { 5, "user5@abc.com", "8181811818", "User 5", 2, 2 },
                    { 3, "user3@abc.com", "8181811818", "User 3", 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusId",
                table: "User",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
