using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Condominio.Migrations
{
    public partial class invoicesprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceUserId_InvoiceActivityId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoiceUserId_InvoiceActivityId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceActivityId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "InvoiceUserId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48aeb3ab-2f3d-4a53-9105-d16079980f3e",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "1a897b82-68f4-4c0f-a8ce-92c0d4d5254b", "CONDIMINIOMEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9653822c-0c90-403c-a105-b7370d3bb552",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "48481dbd-e223-41f1-b119-837a41e56287", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4c5362-0859-4ceb-bdfa-fb56b7aef532",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "7158acc1-1c44-4615-b85b-c9637935a337", "RESIDENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceActivityId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceUserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                columns: new[] { "UserId", "ActivityId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48aeb3ab-2f3d-4a53-9105-d16079980f3e",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "212abb58-a37a-4c1e-9867-9a996c0c8cda", "CondiminioMember" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9653822c-0c90-403c-a105-b7370d3bb552",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "ae9156cf-d689-48d8-8fdc-1437fe4f438f", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4c5362-0859-4ceb-bdfa-fb56b7aef532",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "e0ed9081-ddf5-4a3a-9377-0245fa578a34", "Resident" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceUserId_InvoiceActivityId",
                table: "Payments",
                columns: new[] { "InvoiceUserId", "InvoiceActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceUserId_InvoiceActivityId",
                table: "Payments",
                columns: new[] { "InvoiceUserId", "InvoiceActivityId" },
                principalTable: "Invoices",
                principalColumns: new[] { "UserId", "ActivityId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
