using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEnglish.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryType", "CreatedDate", "Name", "Rank", "SectionId" },
                values: new object[] { 1, "GrammarTips", new DateTime(2022, 3, 3, 22, 26, 56, 558, DateTimeKind.Local).AddTicks(6843), "Grammar Tips _1", (byte)0, null });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "CategoryId", "ContentType", "CreatedDate", "InstructionId", "QuestionActivityId", "Rank", "Title" },
                values: new object[] { 1, null, "Instruction", new DateTime(2022, 3, 3, 22, 26, 56, 559, DateTimeKind.Local).AddTicks(4414), null, null, (byte)0, "Present Perfect T." });

            migrationBuilder.InsertData(
                table: "Instruction",
                columns: new[] { "InstructionId", "CreatedDate", "Title" },
                values: new object[] { 1, new DateTime(2022, 3, 3, 22, 26, 56, 560, DateTimeKind.Local).AddTicks(2715), "Present Perfect T." });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "CreatedDate", "Rank", "ThemeId", "Title" },
                values: new object[] { 1, new DateTime(2022, 3, 3, 22, 26, 56, 558, DateTimeKind.Local).AddTicks(2179), (byte)0, null, "1A" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "CreatedDate", "IsActive", "Level", "Rank", "Title" },
                values: new object[] { 1, new DateTime(2022, 3, 3, 22, 26, 56, 553, DateTimeKind.Local).AddTicks(4107), (short)1, "A1", (byte)0, "Theme-1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "ContentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "InstructionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "ThemeId",
                keyValue: 1);
        }
    }
}
