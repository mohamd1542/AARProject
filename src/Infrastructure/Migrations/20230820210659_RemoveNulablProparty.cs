using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AARProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNulablProparty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserRPointTemplates",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_UserRequestTemplate",
                table: "UploadedFile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Points",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Source",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Template",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Users",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Roles",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users",
                table: "UserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "UserRPointTemplates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "UserRPointTemplates",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "file",
                table: "UserRequestTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "UserRequestTemplate",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TemplateId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserRequestTemplateId",
                table: "UploadedFile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "UploadedFile",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Template",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "Template",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "CoverImage",
                table: "Template",
                type: "image",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SourceName",
                table: "Source",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PointName",
                table: "Point",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserRPointTemplateId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CommentId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Comment",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments",
                table: "Comment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserRPointTemplates",
                table: "Comment",
                column: "UserRPointTemplateId",
                principalTable: "UserRPointTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_UserRequestTemplate",
                table: "UploadedFile",
                column: "UserRequestTemplateId",
                principalTable: "UserRequestTemplate",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Template",
                table: "UserRequestTemplate",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Users",
                table: "UserRequestTemplate",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Roles",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserRPointTemplates",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_UserRequestTemplate",
                table: "UploadedFile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Points",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Source",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Template",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequestTemplate_Users",
                table: "UserRequestTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Roles",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users",
                table: "UserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "UserRPointTemplates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "UserRPointTemplates",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "file",
                table: "UserRequestTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "UserRequestTemplate",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TemplateId",
                table: "UserRequestTemplate",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserRequestTemplateId",
                table: "UploadedFile",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "UploadedFile",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Template",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "Template",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<byte[]>(
                name: "CoverImage",
                table: "Template",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image");

            migrationBuilder.AlterColumn<string>(
                name: "SourceName",
                table: "Source",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PointName",
                table: "Point",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserRPointTemplateId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "CommentId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Comment",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments",
                table: "Comment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserRPointTemplates",
                table: "Comment",
                column: "UserRPointTemplateId",
                principalTable: "UserRPointTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_UserRequestTemplate",
                table: "UploadedFile",
                column: "UserRequestTemplateId",
                principalTable: "UserRequestTemplate",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Template",
                table: "UserRequestTemplate",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequestTemplate_Users",
                table: "UserRequestTemplate",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Roles",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
