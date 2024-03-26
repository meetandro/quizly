using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers;

public class QuestionController : Controller
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionController(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    [HttpGet]
    public IActionResult GetQuestions()
    {
        return View("QuestionsList", _questionRepository.GetQuestions());
    }

    [HttpPost]
    public IActionResult AddQuestion(Question question, int correctAnswerIndex)
    {
        _questionRepository.AddQuestion(question, correctAnswerIndex);
        return RedirectToAction();
    }

    public IActionResult AddQuestion()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DeleteQuestion(int id)
    {
        _questionRepository.DeleteQuestion(id);
        return RedirectToAction("GetQuestions");
    }
}