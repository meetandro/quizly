namespace QuizApp.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; } = "Unknown";
    public int Score { get; set; }
}