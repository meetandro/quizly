using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class GameService(IPlayerRepository playerRepository, IQuestionRepository questionRepository) : IGameService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IQuestionRepository _questionRepository = questionRepository;

    public Player SubmitQuiz()
    {
        throw new NotImplementedException();
    }
}