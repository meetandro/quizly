using QuizApp.Models;

namespace QuizApp.Services;

public interface IGameService
{
    ResultViewModel SubmitQuiz(SubmitModel submitModel);
}