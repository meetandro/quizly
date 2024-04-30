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
        return View(questions);
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
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult DeleteQuestion(int id)
    {
        _questionService.DeleteQuestion(id);
        return RedirectToAction("GetAllQuestions");
    }
}