namespace Quizly.Models;

public class SubmitModel
{
    public string? PlayerUsername { get; set; }
    public List<int> SelectedAnswerIds { get; set; } = [];
}