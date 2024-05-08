using QuizApp.Entities;
using QuizApp.Exceptions;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class GameService(IPlayerRepository playerRepository, IQuestionRepository questionRepository) : IGameService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IQuestionRepository _questionRepository = questionRepository;

    public ResultViewModel SubmitQuiz(SubmitModel submitModel)
    {
        if (string.IsNullOrEmpty(submitModel.PlayerUsername))
        {
            throw new EmptyInputException("Username is required.");
        }

        var player = _playerRepository.GetPlayerByUsername(submitModel.PlayerUsername) ?? throw new EntityNotFoundException($"Player '{submitModel.PlayerUsername}' does not exist");
        var answers = _questionRepository.GetAnswersByIds(submitModel.SelectedAnswerIds);

        var round = new Round();
        round.Attempts.AddRange(answers.Select(answer => new Attempt
        {
            IsCorrect = answer.IsCorrect,
            AnswerId = answer.Id
        }));

        int questionsCount = _questionRepository.GetAllQuestions().Count;
        int correctAnswersCount = answers.Count(answer => answer.IsCorrect);

        int score = questionsCount == 0 ? 0 : correctAnswersCount * 100 / questionsCount;
        if (score >= 50)
        {
            round.IsWon = true;
            player.WinCount++;
        }

        player.HighScore = Math.Max(player.HighScore, score);
        player.Rounds.Add(round);
        player = _playerRepository.UpdatePlayer(player);

        var resultViewModel = new ResultViewModel
        {
            QuestionsCount = questionsCount,
            CorrectAnswersCount = correctAnswersCount,
            Score = score
        };
        return resultViewModel;
    }
}