using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Controllers;

public class GameController(IGameService gameService, IQuestionService questionService) : Controller
{
    private readonly IGameService _gameService = gameService;
    private readonly IQuestionService _questionService = questionService;

    [HttpGet]
    public IActionResult StartQuiz()
    {
        return View(_questionService.GetQuestions());
    }

    [HttpPost]
    public IActionResult SubmitQuiz(SubmitViewModel submitViewModel)
    {
        try
        {
            var resultViewModel = _gameService.SubmitQuiz(submitViewModel);
            return View("Result", resultViewModel);
        }
        catch (ArgumentNullException ex)
        {
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
    }
}