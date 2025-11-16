using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AARProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateURT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Points",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Source",
                table: "UserRequestTemplate");

            migrationBuilder.AlterColumn<Guid>(
                name: "SourceId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PointId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Points",
                table: "UserRequestTemplate",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Source",
                table: "UserRequestTemplate",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Points",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Source",
                table: "UserRequestTemplate");

            migrationBuilder.AlterColumn<Guid>(
                name: "SourceId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PointId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Points",
                table: "UserRequestTemplate",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Source",
                table: "UserRequestTemplate",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
