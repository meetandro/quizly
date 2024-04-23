using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class GameService(IPlayerRepository playerRepository, IQuestionRepository questionRepository) : IGameService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IQuestionRepository _questionRepository = questionRepository;

    public Player SubmitQuiz(SubmitModel submitModel)
    {
        var player = _playerRepository.GetPlayerByUsername(submitModel.PlayerUsername);

        var answers = _questionRepository.GetAnswersByIds(submitModel.SelectedAnswerIds);

        var round = new Round();

        round.Attempts.AddRange(answers.Select(answer => new Attempt
        {
            IsCorrect = answer.IsCorrect,
            AnswerId = answer.Id
        }));

        int correctAnswersCount = answers.Count(answer => answer.IsCorrect);

        int questionsCount = _questionRepository.GetQuestions().Count;

        int scorePercentage = questionsCount == 0 ? 0 : correctAnswersCount * 100 / questionsCount;

        if (scorePercentage >= 75)
        {
            round.IsWon = true;
            player.WinCount++;
        }

        player.HighScore = Math.Max(player.HighScore, (int)scorePercentage);

        player.Rounds.Add(round);

        player = _playerRepository.UpdatePlayer(player);

        return player;
    }
}