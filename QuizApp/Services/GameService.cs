using QuizApp.Entities;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class GameService(IPlayerRepository playerRepository, IQuestionRepository questionRepository) : IGameService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IQuestionRepository _questionRepository = questionRepository;

    public ResultViewModel SubmitQuiz(SubmitViewModel submitViewModel)
    {
        if (string.IsNullOrEmpty(submitViewModel.PlayerUsername))
        {
            throw new ArgumentNullException(nameof(submitViewModel), "Username is required.");
        }

        var player = _playerRepository.GetPlayerByUsername(submitViewModel.PlayerUsername) ?? throw new Exception($"Player {submitViewModel.PlayerUsername} does not exist");

        var answers = _questionRepository.GetAnswersByIds(submitViewModel.SelectedAnswerIds);

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

        player.HighScore = Math.Max(player.HighScore, scorePercentage);

        player.Rounds.Add(round);

        player = _playerRepository.UpdatePlayer(player);

        var resultModel = new ResultViewModel
        {
            PlayerUsername = player.Username,
            IsWon = round.IsWon,
            Score = scorePercentage
        };

        return resultModel;
    }
}