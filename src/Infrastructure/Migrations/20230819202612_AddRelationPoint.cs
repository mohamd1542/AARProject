using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AARProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Point_PointId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PointId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PointId",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Point",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Point_UserId",
                table: "Point",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Users",
                table: "Point",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Users",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_UserId",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Point");

            migrationBuilder.AddColumn<Guid>(
                name: "PointId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_PointId",
                table: "User",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Point_PointId",
                table: "User",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
