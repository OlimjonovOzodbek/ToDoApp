using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infrsatructure.Migrations
{
    /// <inheritdoc />
    public partial class something : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_UserId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_UserId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Comments");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Issues",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Issues",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Issues",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_UserId1",
                table: "Issues",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_UserId1",
                table: "Issues",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_UserId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_UserId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Issues");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Issues",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_UserId",
                table: "Issues",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_UserId",
                table: "Issues",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
