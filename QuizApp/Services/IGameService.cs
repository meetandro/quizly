using QuizApp.Models;

namespace QuizApp.Services;

public interface IGameService
{
    public ResultViewModel SubmitQuiz(SubmitViewModel submitViewModel);
}