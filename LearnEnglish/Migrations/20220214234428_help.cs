using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEnglish.Migrations
{
    public partial class help : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeID", "CreatedDate", "IsActive", "Level", "Rank", "Title" },
                values: new object[] { 1, new DateTime(2022, 2, 15, 2, 44, 27, 806, DateTimeKind.Local).AddTicks(1410), (short)1, 0, (short)0, "Theme-1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "ThemeID",
                keyValue: 1);
        }
    }
}
