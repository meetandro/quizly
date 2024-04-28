namespace QuizApp.Models;

public class ResultViewModel
{
    public string? PlayerUsername { get; set; }
    public bool IsWon { get; set; }
    public int QuestionsCount { get; set; }
    public int CorrectAnswersCount { get; set; }
    public int Score { get; set; }
}