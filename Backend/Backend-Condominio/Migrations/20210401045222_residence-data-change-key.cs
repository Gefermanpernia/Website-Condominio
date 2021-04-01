using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Condominio.Migrations
{
    public partial class residencedatachangekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidenceDatas",
                table: "ResidenceDatas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ResidenceDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidenceDatas",
                table: "ResidenceDatas",
                columns: new[] { "Floor", "ApartmentNumber" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48aeb3ab-2f3d-4a53-9105-d16079980f3e",
                column: "ConcurrencyStamp",
                value: "6077c1a0-9488-44a1-b852-806be11229a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9653822c-0c90-403c-a105-b7370d3bb552",
                column: "ConcurrencyStamp",
                value: "efaff7d3-bfac-438d-9c9c-a9b6c31a48d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4c5362-0859-4ceb-bdfa-fb56b7aef532",
                column: "ConcurrencyStamp",
                value: "513a1b49-8ce6-48de-b3be-0a1cb385f61e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidenceDatas",
                table: "ResidenceDatas");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ResidenceDatas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidenceDatas",
                table: "ResidenceDatas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48aeb3ab-2f3d-4a53-9105-d16079980f3e",
                column: "ConcurrencyStamp",
                value: "1a897b82-68f4-4c0f-a8ce-92c0d4d5254b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9653822c-0c90-403c-a105-b7370d3bb552",
                column: "ConcurrencyStamp",
                value: "48481dbd-e223-41f1-b119-837a41e56287");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4c5362-0859-4ceb-bdfa-fb56b7aef532",
                column: "ConcurrencyStamp",
                value: "7158acc1-1c44-4615-b85b-c9637935a337");
        }
    }
}
