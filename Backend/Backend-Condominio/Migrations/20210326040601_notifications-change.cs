using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Condominio.Migrations
{
    public partial class notificationschange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "nvarchar(1200)",
                maxLength: 1200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "AlreadySeen",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48aeb3ab-2f3d-4a53-9105-d16079980f3e",
                column: "ConcurrencyStamp",
                value: "212abb58-a37a-4c1e-9867-9a996c0c8cda");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9653822c-0c90-403c-a105-b7370d3bb552",
                column: "ConcurrencyStamp",
                value: "ae9156cf-d689-48d8-8fdc-1437fe4f438f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4c5362-0859-4ceb-bdfa-fb56b7aef532",
                column: "ConcurrencyStamp",
                value: "e0ed9081-ddf5-4a3a-9377-0245fa578a34");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AlreadySeen",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1200)",
                oldMaxLength: 1200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                columns: new[] { "UserId", "NotificationTypeId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48aeb3ab-2f3d-4a53-9105-d16079980f3e",
                column: "ConcurrencyStamp",
                value: "9bf53508-8a7f-428b-a9fb-c436cd6d31a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9653822c-0c90-403c-a105-b7370d3bb552",
                column: "ConcurrencyStamp",
                value: "bc117c1d-aa11-4297-bca8-9bd12b8fd476");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4c5362-0859-4ceb-bdfa-fb56b7aef532",
                column: "ConcurrencyStamp",
                value: "79e3eeeb-7734-4b6c-9dfd-b7d3a5841977");
        }
    }
}
