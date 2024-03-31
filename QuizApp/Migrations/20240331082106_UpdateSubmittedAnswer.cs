using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubmittedAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "SubmittedAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_AnswerId",
                table: "SubmittedAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_UserId",
                table: "SubmittedAnswers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_Answers_AnswerId",
                table: "SubmittedAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_Users_UserId",
                table: "SubmittedAnswers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_Answers_AnswerId",
                table: "SubmittedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_Users_UserId",
                table: "SubmittedAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedAnswers_AnswerId",
                table: "SubmittedAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedAnswers_UserId",
                table: "SubmittedAnswers");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "SubmittedAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
