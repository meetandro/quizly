using Microsoft.AspNetCore.Mvc;
using QuizApp.Exceptions;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Controllers;

public class QuestionController(IQuestionService questionService) : Controller
{
    private readonly IQuestionService _questionService = questionService;

    [HttpGet]
    public IActionResult GetAllQuestions()
    {
        var questions = _questionService.GetAllQuestions();
        return View("Questions", questions);
    }

    public IActionResult AddQuestion()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddQuestion(QuestionModel questionModel)
    {
        try
        {
            _questionService.AddQuestion(questionModel);
            return RedirectToAction();
        }
        catch (EmptyInputException ex)
        {
            return ViewError(ex.Message);
        }
        catch (Exception ex)
        {
            return ViewError(ex.Message);
        }
    }

    private RedirectToActionResult ViewError(string message)
    {
        return RedirectToAction("Error", "Home", new { message });
    }

    [HttpPost]
    public IActionResult DeleteQuestion(int id)
    {
        _questionService.DeleteQuestion(id);
        return RedirectToAction("GetAllQuestions");
    }
}