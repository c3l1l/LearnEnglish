using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEnglish.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruction",
                columns: table => new
                {
                    InstructionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruction", x => x.InstructionId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionActivity",
                columns: table => new
                {
                    QuestionActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionType = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionActivity", x => x.QuestionActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ThemeId);
                });

            migrationBuilder.CreateTable(
                name: "InstructionDetails",
                columns: table => new
                {
                    InstructionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionDetails", x => x.InstructionDetailId);
                    table.ForeignKey(
                        name: "FK_InstructionDetails_Instruction_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "Instruction",
                        principalColumn: "InstructionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructionSounds",
                columns: table => new
                {
                    InstructionSoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructionId = table.Column<int>(type: "int", nullable: true),
                    SoundName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoundUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionSounds", x => x.InstructionSoundId);
                    table.ForeignKey(
                        name: "FK_InstructionSounds_Instruction_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "Instruction",
                        principalColumn: "InstructionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiGapFillingQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionActivityId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiGapFillingQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_MultiGapFillingQuestions_QuestionActivity_QuestionActivityId",
                        column: x => x.QuestionActivityId,
                        principalTable: "QuestionActivity",
                        principalColumn: "QuestionActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choice1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choice2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choice3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choice4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionActivityId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestions_QuestionActivity_QuestionActivityId",
                        column: x => x.QuestionActivityId,
                        principalTable: "QuestionActivity",
                        principalColumn: "QuestionActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SingleGapFillingQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionActivityId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleGapFillingQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_SingleGapFillingQuestions_QuestionActivity_QuestionActivityId",
                        column: x => x.QuestionActivityId,
                        principalTable: "QuestionActivity",
                        principalColumn: "QuestionActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrueFalseQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choice1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choice2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionActivityId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueFalseQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_TrueFalseQuestions_QuestionActivity_QuestionActivityId",
                        column: x => x.QuestionActivityId,
                        principalTable: "QuestionActivity",
                        principalColumn: "QuestionActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "ThemeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryType = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    InstructionId = table.Column<int>(type: "int", nullable: true),
                    QuestionActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Contents_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contents_Instruction_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "Instruction",
                        principalColumn: "InstructionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contents_QuestionActivity_QuestionActivityId",
                        column: x => x.QuestionActivityId,
                        principalTable: "QuestionActivity",
                        principalColumn: "QuestionActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryType", "CreatedDate", "Name", "Rank", "SectionId" },
                values: new object[] { 1, "GrammarTips", new DateTime(2022, 3, 13, 16, 57, 34, 24, DateTimeKind.Local).AddTicks(8079), "Grammar Tips _1", (byte)0, null });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "CategoryId", "ContentType", "CreatedDate", "InstructionId", "QuestionActivityId", "Rank", "Title" },
                values: new object[] { 1, null, "Instruction", new DateTime(2022, 3, 13, 16, 57, 34, 25, DateTimeKind.Local).AddTicks(2413), null, null, (byte)0, "Present Perfect T." });

            migrationBuilder.InsertData(
                table: "Instruction",
                columns: new[] { "InstructionId", "CreatedDate", "Title" },
                values: new object[] { 1, new DateTime(2022, 3, 13, 16, 57, 34, 25, DateTimeKind.Local).AddTicks(6984), "Present Perfect T." });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "CreatedDate", "Rank", "ThemeId", "Title" },
                values: new object[] { 1, new DateTime(2022, 3, 13, 16, 57, 34, 24, DateTimeKind.Local).AddTicks(3978), (byte)0, null, "1A" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "CreatedDate", "IsActive", "Level", "Rank", "Title" },
                values: new object[] { 1, new DateTime(2022, 3, 13, 16, 57, 34, 19, DateTimeKind.Local).AddTicks(9026), (short)1, 0, (byte)0, "Theme-1" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SectionId",
                table: "Categories",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CategoryId",
                table: "Contents",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_InstructionId",
                table: "Contents",
                column: "InstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_QuestionActivityId",
                table: "Contents",
                column: "QuestionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructionDetails_InstructionId",
                table: "InstructionDetails",
                column: "InstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructionSounds_InstructionId",
                table: "InstructionSounds",
                column: "InstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiGapFillingQuestions_QuestionActivityId",
                table: "MultiGapFillingQuestions",
                column: "QuestionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestions_QuestionActivityId",
                table: "MultipleChoiceQuestions",
                column: "QuestionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ThemeId",
                table: "Sections",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleGapFillingQuestions_QuestionActivityId",
                table: "SingleGapFillingQuestions",
                column: "QuestionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseQuestions_QuestionActivityId",
                table: "TrueFalseQuestions",
                column: "QuestionActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "InstructionDetails");

            migrationBuilder.DropTable(
                name: "InstructionSounds");

            migrationBuilder.DropTable(
                name: "MultiGapFillingQuestions");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "SingleGapFillingQuestions");

            migrationBuilder.DropTable(
                name: "TrueFalseQuestions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Instruction");

            migrationBuilder.DropTable(
                name: "QuestionActivity");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
