using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AARProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCommentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comment");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentNavigationId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentNavigationId",
                table: "Comment",
                column: "CommentNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_CommentNavigationId",
                table: "Comment",
                column: "CommentNavigationId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_CommentNavigationId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommentNavigationId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentNavigationId",
                table: "Comment");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentId",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments",
                table: "Comment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
