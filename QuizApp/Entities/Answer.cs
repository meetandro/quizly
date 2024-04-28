namespace QuizApp.Entities;

public class Answer
{
    public int Id { get; set; }
    public string? AnswerText { get; set; }
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
    public List<Attempt> Attempts { get; set; } = [];
}