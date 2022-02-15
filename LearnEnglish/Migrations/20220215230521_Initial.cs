using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEnglish.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentDetails",
                columns: table => new
                {
                    ContentDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<short>(type: "smallint", nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentDetails", x => x.ContentDetailID);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ThemeID);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    InstructionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentDetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.InstructionID);
                    table.ForeignKey(
                        name: "FK_Instructions_ContentDetails_ContentDetailID",
                        column: x => x.ContentDetailID,
                        principalTable: "ContentDetails",
                        principalColumn: "ContentDetailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThemeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionID);
                    table.ForeignKey(
                        name: "FK_Sections_Themes_ThemeID",
                        column: x => x.ThemeID,
                        principalTable: "Themes",
                        principalColumn: "ThemeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    SectionID = table.Column<int>(type: "int", nullable: true),
                    ContentDetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentID);
                    table.ForeignKey(
                        name: "FK_Contents_ContentDetails_ContentDetailID",
                        column: x => x.ContentDetailID,
                        principalTable: "ContentDetails",
                        principalColumn: "ContentDetailID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contents_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContentDetails",
                columns: new[] { "ContentDetailID", "ContentType", "CreatedDate", "Name", "Rank" },
                values: new object[] { 1, 0, new DateTime(2022, 2, 16, 2, 5, 19, 982, DateTimeKind.Local).AddTicks(9465), "Instruction 1", (short)0 });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentID", "Category", "ContentDetailID", "CreatedDate", "Name", "Rank", "SectionID" },
                values: new object[] { 1, 0, null, new DateTime(2022, 2, 16, 2, 5, 19, 982, DateTimeKind.Local).AddTicks(7017), "Present Perfect T.", (short)0, null });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionID", "ContentDetailID", "CreatedDate", "Info", "Rank", "Title" },
                values: new object[] { 1, null, new DateTime(2022, 2, 16, 2, 5, 19, 983, DateTimeKind.Local).AddTicks(1918), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras laoreet pharetra tortor. Curabitur sed ante at urna interdum viverra in id augue. Fusce ligula est, imperdiet in ipsum at, varius volutpat quam. Cras ac arcu semper, condimentum massa eget, gravida orci. Morbi cursus leo vitae mi malesuada dignissim. Phasellus pellentesque massa lobortis ex vestibulum ultrices. Praesent posuere quis elit at euismod. Cras vel sem quis ipsum consequat lobortis. Pellentesque tristique elementum enim sit amet ultricies. Etiam in elit sed metus placerat blandit. Aenean ut faucibus enim. In at feugiat dolor. Donec eu euismod elit, quis maximus erat. Integer at ultrices tortor. Etiam aliquam odio tellus, vel ullamcorper velit tempus in. Curabitur iaculis libero sem, nec laoreet augue rutrum vitae. ", (short)0, "Present Perfect Tense Title" });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionID", "CreatedDate", "Rank", "ThemeID", "Title" },
                values: new object[] { 1, new DateTime(2022, 2, 16, 2, 5, 19, 982, DateTimeKind.Local).AddTicks(4647), (short)0, null, "1A" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeID", "CreatedDate", "IsActive", "Level", "Rank", "Title" },
                values: new object[] { 1, new DateTime(2022, 2, 16, 2, 5, 19, 979, DateTimeKind.Local).AddTicks(2316), (short)1, 0, (short)0, "Theme-1" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ContentDetailID",
                table: "Contents",
                column: "ContentDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_SectionID",
                table: "Contents",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_ContentDetailID",
                table: "Instructions",
                column: "ContentDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ThemeID",
                table: "Sections",
                column: "ThemeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "ContentDetails");

            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
