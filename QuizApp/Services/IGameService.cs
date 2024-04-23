using QuizApp.Models;

namespace QuizApp.Services;

public interface IGameService
{
    public ResultModel SubmitQuiz(SubmitModel submitModel);
}