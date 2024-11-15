namespace Quizly.Entities;

public class Player
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public int WinCount { get; set; }
    public int HighScore { get; set; }
    public List<Round> Rounds { get; set; } = [];
}