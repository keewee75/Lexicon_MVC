using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lexicon_MVC.Migrations
{
    public partial class AddedrolesanddefaultAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "348c7ebd-4b70-4142-9f9a-0c0779ed2f89", "5abde7a1-22a7-4465-8865-f61a7490c30a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65850dde-414c-4164-9617-25b3317eaf54", "4e24dfc8-5d5f-4418-84b1-73c72d7ad4e5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f16863c-bda8-43da-9654-535bfb8fe6f8", 0, new DateTime(2022, 9, 14, 13, 46, 44, 54, DateTimeKind.Local).AddTicks(5066), "45025c16-74e8-41ac-9e53-a4b6bc0400c3", "admin@admin.com", false, "Admin", "Jedi", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEN5RcvSSC7AjfJ3kDIWxu3J1EnRMEkahGiIAgafgZvQ4GLX3+MAomjNwlf5r1oYa7A==", null, false, "d4849a8a-06bd-40cb-b52e-2dd785e69af5", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "348c7ebd-4b70-4142-9f9a-0c0779ed2f89", "3f16863c-bda8-43da-9654-535bfb8fe6f8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65850dde-414c-4164-9617-25b3317eaf54");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "348c7ebd-4b70-4142-9f9a-0c0779ed2f89", "3f16863c-bda8-43da-9654-535bfb8fe6f8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348c7ebd-4b70-4142-9f9a-0c0779ed2f89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f16863c-bda8-43da-9654-535bfb8fe6f8");
        }
    }
}
