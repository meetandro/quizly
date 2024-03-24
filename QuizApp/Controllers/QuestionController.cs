using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Controllers;

public class QuestionController : Controller
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public IActionResult GetQuestions()
    {
        return View("QuestionsList", _questionService.GetQuestions());
    }

    [HttpPost]
    public IActionResult AddQuestion(Question question, int correctAnswerIndex)
    {
        _questionService.AddQuestion(question, correctAnswerIndex);
        return RedirectToAction();
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