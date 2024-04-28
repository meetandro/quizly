using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Controllers;

public class QuestionController(IQuestionService questionService) : Controller
{
    private readonly IQuestionService _questionService = questionService;

    [HttpGet]
    public IActionResult GetQuestions()
    {
        return View(_questionService.GetQuestions());
    }

    [HttpPost]
    public IActionResult AddQuestion(QuestionViewModel questionViewModel)
    {
        try
        {
            _questionService.AddQuestion(questionViewModel);
            return RedirectToAction();
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

    public IActionResult AddQuestion()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DeleteQuestion(int id)
    {
        _questionService.DeleteQuestion(id);
        return RedirectToAction("GetQuestions");
    }
}