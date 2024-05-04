using Microsoft.AspNetCore.Mvc;
using QuizApp.Exceptions;
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
        var questions = _questionService.GetAllQuestions();
        return View("Quiz", questions);
    }

    [HttpPost]
    public IActionResult SubmitQuiz(SubmitModel submitModel)
    {
        try
        {
            var resultViewModel = _gameService.SubmitQuiz(submitModel);
            return View("Result", resultViewModel);
        }
        catch (Exception ex)
        {
            return ex switch
            {
                EmptyInputException => RedirectToAction("Error", "Home", new { message = ex.Message }),
                EntityNotFoundException => RedirectToAction("Error", "Home", new { message = ex.Message }),
                _ => RedirectToAction("Error", "Home", new { message = ex.Message })
            };
        }
    }
}