using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers;

public class QuestionController(IQuestionRepository questionRepository) : Controller
{
    private readonly IQuestionRepository _questionRepository = questionRepository;

    [HttpGet]
    public IActionResult GetQuestions()
    {
        return View(_questionRepository.GetQuestions());
    }

    [HttpPost]
    public IActionResult AddQuestion(Question question, int correctAnswerIndex)
    {
        if (string.IsNullOrEmpty(question.QuestionText))
        {
            return RedirectToAction("Error", "Home", new { message = "Question text is required." });
        }
        if (question.Answers.Any(a => string.IsNullOrEmpty(a.AnswerText)))
        {
            return RedirectToAction("Error", "Home", new { message = "All answers must be filled." });
        }

        question.Answers[correctAnswerIndex].IsCorrect = true;
        _questionRepository.AddQuestion(question);
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