using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acc.Infrastructure.EFCore.Migrations
{
    public partial class AddSeedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3062d373-692a-4719-af17-e539348cedf5", "130447bc-a90b-418d-8e2c-fbc5a710dd80" },
                    { "3062d373-692a-4719-af17-e539348cedf5", "c2fba437-1de8-440b-902d-8dda014454e0" },
                    { "383cac8c-52db-4910-9d82-436ec592b223", "c2fba437-1de8-440b-902d-8dda014454e0" },
                    { "7d873ea9-74df-417a-b56a-660d16d87a27", "c2fba437-1de8-440b-902d-8dda014454e0" },
                    { "7d873ea9-74df-417a-b56a-660d16d87a27", "ec5575d0-b739-46f1-b91b-d30e26db1491" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3062d373-692a-4719-af17-e539348cedf5", "130447bc-a90b-418d-8e2c-fbc5a710dd80" });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3062d373-692a-4719-af17-e539348cedf5", "c2fba437-1de8-440b-902d-8dda014454e0" });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "383cac8c-52db-4910-9d82-436ec592b223", "c2fba437-1de8-440b-902d-8dda014454e0" });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d873ea9-74df-417a-b56a-660d16d87a27", "c2fba437-1de8-440b-902d-8dda014454e0" });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d873ea9-74df-417a-b56a-660d16d87a27", "ec5575d0-b739-46f1-b91b-d30e26db1491" });

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
        }
    }
}
