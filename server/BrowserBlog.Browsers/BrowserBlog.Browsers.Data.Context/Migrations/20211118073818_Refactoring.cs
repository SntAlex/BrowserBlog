using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrowserBlog.Browsers.Data.Context.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrowserPages_Browsers_BrowserId",
                table: "BrowserPages");

            migrationBuilder.DropTable(
                name: "Browsers");

            migrationBuilder.DropIndex(
                name: "IX_BrowserPages_BrowserId",
                table: "BrowserPages");

            migrationBuilder.DropColumn(
                name: "BrowserId",
                table: "BrowserPages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BrowserPages",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BrowserPages",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BrowserPages_Name",
                table: "BrowserPages",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BrowserPages_Name",
                table: "BrowserPages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BrowserPages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BrowserPages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<Guid>(
                name: "BrowserId",
                table: "BrowserPages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Browsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrowserPages_BrowserId",
                table: "BrowserPages",
                column: "BrowserId");

            migrationBuilder.CreateIndex(
                name: "IX_Browsers_Name",
                table: "Browsers",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BrowserPages_Browsers_BrowserId",
                table: "BrowserPages",
                column: "BrowserId",
                principalTable: "Browsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
