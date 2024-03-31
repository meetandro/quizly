using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models;

[Keyless]
public class SubmittedAnswer
{
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int UserId { get; set; }

    [ForeignKey("AnswerId")]
    public Answer? Answer { get; set; }
    public int AnswerId { get; set; }

    public bool IsCorrect { get; set; }
}