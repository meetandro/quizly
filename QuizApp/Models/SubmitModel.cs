namespace QuizApp.Models;

public class SubmitModel
{
    public string PlayerUsername { get; set; }
    public List<int> SelectedAnswerIds { get; set; }
}