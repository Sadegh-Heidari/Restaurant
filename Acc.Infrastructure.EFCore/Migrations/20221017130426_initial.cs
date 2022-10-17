using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acc.Infrastructure.EFCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PhoneConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "3062d373-692a-4719-af17-e539348cedf5", "Kitchen" },
                    { "383cac8c-52db-4910-9d82-436ec592b223", "Admin" },
                    { "7d873ea9-74df-417a-b56a-660d16d87a27", "FrontDesk" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "PhoneConfirmed", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { "130447bc-a90b-418d-8e2c-fbc5a710dd80", "Kitchen@gmail.com", "ea661MuJdwQ2K0rmZRlEz7xcXpadVVD+FQ5prf2UBAA=", false, "111111", "Kitchen" },
                    { "c2fba437-1de8-440b-902d-8dda014454e0", "Admin@gmail.com", "ea661MuJdwQ2K0rmZRlEz7xcXpadVVD+FQ5prf2UBAA=", false, "111111", "Manager" },
                    { "ec5575d0-b739-46f1-b91b-d30e26db1491", "FrontDesk@gmail.com", "ea661MuJdwQ2K0rmZRlEz7xcXpadVVD+FQ5prf2UBAA=", false, "111111", "FrontDesk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
