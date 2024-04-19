namespace QuizApp.Models;

public class Player
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public int WinCount { get; set; } = 0;
    public int HighScore { get; set; } = 0;
    public List<Round> Rounds { get; set; } = [];
}