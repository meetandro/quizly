using QuizApp.Models;

namespace QuizApp.Services;

public interface IGameService
{
    public Player SubmitQuiz();
}