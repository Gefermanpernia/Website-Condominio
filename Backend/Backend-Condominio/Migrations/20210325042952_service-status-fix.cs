using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Condominio.Migrations
{
    public partial class servicestatusfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesT_ServiceStatuses_ServiceStatusId",
                table: "ServicesT");

            migrationBuilder.DropColumn(
                name: "ServicesStatusId",
                table: "ServicesT");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesT_ServiceStatuses_ServiceStatusId",
                table: "ServicesT",
                column: "ServiceStatusId",
                principalTable: "ServiceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesT_ServiceStatuses_ServiceStatusId",
                table: "ServicesT");

            migrationBuilder.AddColumn<int>(
                name: "ServicesStatusId",
                table: "ServicesT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesT_ServiceStatuses_ServiceStatusId",
                table: "ServicesT",
                column: "ServiceStatusId",
                principalTable: "ServiceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
