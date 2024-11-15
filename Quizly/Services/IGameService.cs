using Quizly.Models;

namespace Quizly.Services;

public interface IGameService
{
    ResultViewModel SubmitQuiz(SubmitModel submitModel);
}