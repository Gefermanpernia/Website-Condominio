using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Condominio.Migrations
{
    public partial class defaultroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9653822c-0c90-403c-a105-b7370d3bb552", "bc117c1d-aa11-4297-bca8-9bd12b8fd476", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48aeb3ab-2f3d-4a53-9105-d16079980f3e", "9bf53508-8a7f-428b-a9fb-c436cd6d31a5", "CondiminioMember", "CondiminioMember" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e4c5362-0859-4ceb-bdfa-fb56b7aef532", "79e3eeeb-7734-4b6c-9dfd-b7d3a5841977", "Resident", "Resident" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48aeb3ab-2f3d-4a53-9105-d16079980f3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9653822c-0c90-403c-a105-b7370d3bb552");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4c5362-0859-4ceb-bdfa-fb56b7aef532");
        }
    }
}
