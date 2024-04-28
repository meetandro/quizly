namespace QuizApp.Entities;

public class Round
{
    public int Id { get; set; }
    public bool IsWon { get; set; }
    public int PlayerId { get; set; }
    public List<Attempt> Attempts { get; set; } = [];
}