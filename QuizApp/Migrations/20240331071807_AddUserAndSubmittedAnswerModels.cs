using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations;

/// <inheritdoc />
public partial class AddUserAndSubmittedAnswerModels : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "SubmittedAnswers",
            columns: table => new
            {
                UserId = table.Column<int>(type: "int", nullable: false),
                QuestionId = table.Column<int>(type: "int", nullable: false),
                AnswerId = table.Column<int>(type: "int", nullable: false),
                IsCorrect = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Score = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SubmittedAnswers");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
