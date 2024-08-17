using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 16, 13, 6, 7, 37, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 13, 6, 7, 37, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 13, 6, 7, 37, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 16, 13, 6, 7, 37, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 16, 13, 6, 7, 37, DateTimeKind.Local).AddTicks(4259));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 9, 14, 51, 39, 599, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 14, 51, 39, 599, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 14, 51, 39, 599, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 9, 14, 51, 39, 599, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 9, 14, 51, 39, 599, DateTimeKind.Local).AddTicks(5904));
        }
    }
}
