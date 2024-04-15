using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations;

/// <inheritdoc />
public partial class AddRoundModelUpdateAttemptAndPlayer : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SubmittedAnswers");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.CreateTable(
            name: "Players",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                WinCount = table.Column<int>(type: "int", nullable: false),
                HighScore = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Players", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Rounds",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsWon = table.Column<bool>(type: "bit", nullable: false),
                PlayerId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rounds", x => x.Id);
                table.ForeignKey(
                    name: "FK_Rounds_Players_PlayerId",
                    column: x => x.PlayerId,
                    principalTable: "Players",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Attempts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                RoundId = table.Column<int>(type: "int", nullable: false),
                AnswerId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Attempts", x => x.Id);
                table.ForeignKey(
                    name: "FK_Attempts_Answers_AnswerId",
                    column: x => x.AnswerId,
                    principalTable: "Answers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Attempts_Rounds_RoundId",
                    column: x => x.RoundId,
                    principalTable: "Rounds",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Attempts_AnswerId",
            table: "Attempts",
            column: "AnswerId");

        migrationBuilder.CreateIndex(
            name: "IX_Attempts_RoundId",
            table: "Attempts",
            column: "RoundId");

        migrationBuilder.CreateIndex(
            name: "IX_Rounds_PlayerId",
            table: "Rounds",
            column: "PlayerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Attempts");

        migrationBuilder.DropTable(
            name: "Rounds");

        migrationBuilder.DropTable(
            name: "Players");

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Score = table.Column<int>(type: "int", nullable: false),
                Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "SubmittedAnswers",
            columns: table => new
            {
                AnswerId = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<int>(type: "int", nullable: false),
                IsCorrect = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.ForeignKey(
                    name: "FK_SubmittedAnswers_Answers_AnswerId",
                    column: x => x.AnswerId,
                    principalTable: "Answers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_SubmittedAnswers_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_SubmittedAnswers_AnswerId",
            table: "SubmittedAnswers",
            column: "AnswerId");

        migrationBuilder.CreateIndex(
            name: "IX_SubmittedAnswers_UserId",
            table: "SubmittedAnswers",
            column: "UserId");
    }
}
