using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class Tuny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 16, 13, 9, 17, 616, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 13, 9, 17, 616, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 13, 9, 17, 616, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 16, 13, 9, 17, 616, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 16, 13, 9, 17, 616, DateTimeKind.Local).AddTicks(7269));
        }
    }
}
