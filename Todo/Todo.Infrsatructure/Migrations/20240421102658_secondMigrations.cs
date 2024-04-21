using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infrsatructure.Migrations
{
    /// <inheritdoc />
    public partial class secondMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_ProgrammerId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ProgrammerId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SenderId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Issues",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ProgrammerId1",
                table: "Issues",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProgrammerId1",
                table: "Issues",
                column: "ProgrammerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SenderId1",
                table: "Comments",
                column: "SenderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId1",
                table: "Comments",
                column: "SenderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_ProgrammerId1",
                table: "Issues",
                column: "ProgrammerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_ProgrammerId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ProgrammerId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SenderId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProgrammerId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Issues",
                newName: "id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProgrammerId",
                table: "Issues",
                column: "ProgrammerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SenderId",
                table: "Comments",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId",
                table: "Comments",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_ProgrammerId",
                table: "Issues",
                column: "ProgrammerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
