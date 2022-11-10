using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acc.Infrastructure.EFCore.Migrations
{
    public partial class Initial : Migration
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
                    { "59ef6387-d9d6-4abc-8d9b-d6866de4ad2a", "Admin" },
                    { "8ffc6ae4-656b-4e9d-b50c-51478010667e", "FrontDesk" },
                    { "e1263198-f41f-4b0c-86e1-ee8f409b588a", "Kitchen" }
                });
           
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "PhoneConfirmed", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { "046c8ee8-8d71-43f1-9a0a-72f7b72a82a2", "Admin@gmail.com", "ea661MuJdwQ2K0rmZRlEz7xcXpadVVD+FQ5prf2UBAA=", false, "111111", "Manager" },
                    { "553770b6-d36f-44df-9756-95149a04a5dc", "FrontDesk@gmail.com", "ea661MuJdwQ2K0rmZRlEz7xcXpadVVD+FQ5prf2UBAA=", false, "111111", "FrontDesk" },
                    { "b57448c6-f5c6-4e76-9d83-3b082af08123", "Kitchen@gmail.com", "ea661MuJdwQ2K0rmZRlEz7xcXpadVVD+FQ5prf2UBAA=", false, "111111", "Kitchen" }
                });
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "59ef6387-d9d6-4abc-8d9b-d6866de4ad2a", "046c8ee8-8d71-43f1-9a0a-72f7b72a82a2" },
                    { "8ffc6ae4-656b-4e9d-b50c-51478010667e", "553770b6-d36f-44df-9756-95149a04a5dc" },
                    { "e1263198-f41f-4b0c-86e1-ee8f409b588a", "b57448c6-f5c6-4e76-9d83-3b082af08123" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
