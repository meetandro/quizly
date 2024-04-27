using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;
using QuizApp.Services;

namespace QuizApp.Controllers;

public class GameController(IGameService gameService, IQuestionRepository questionRepository) : Controller
{
    private readonly IGameService _gameService = gameService;
    private readonly IQuestionRepository _questionRepository = questionRepository;

    [HttpGet]
    public IActionResult StartQuiz()
    {
        return View(_questionRepository.GetQuestions());
    }

    [HttpPost]
    public IActionResult SubmitQuiz(SubmitModel submitModel)
    {
        if (string.IsNullOrEmpty(submitModel.PlayerUsername))
        {
            return RedirectToAction("Error", "Home", new { message = "Name is required." });
        }

        try
        {
            var resultModel = _gameService.SubmitQuiz(submitModel);
            return View("Result", resultModel);
        }
        catch (ArgumentNullException ex)
        {
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
    }
}