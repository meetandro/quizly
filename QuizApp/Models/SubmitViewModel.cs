namespace QuizApp.Models;

public class SubmitViewModel
{
    public string? PlayerUsername { get; set; }
    public List<int> SelectedAnswerIds { get; set; } = [];
}