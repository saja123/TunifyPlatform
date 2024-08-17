using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigattion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 17, 13, 44, 4, 479, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 13, 44, 4, 479, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 13, 44, 4, 479, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 17, 13, 44, 4, 479, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 17, 13, 44, 4, 479, DateTimeKind.Local).AddTicks(4019));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 16, 13, 14, 25, 854, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 13, 14, 25, 854, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 13, 14, 25, 854, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 16, 13, 14, 25, 854, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 16, 13, 14, 25, 854, DateTimeKind.Local).AddTicks(2451));
        }
    }
}
