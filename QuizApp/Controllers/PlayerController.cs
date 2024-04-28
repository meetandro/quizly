using Microsoft.AspNetCore.Mvc;
using QuizApp.Entities;
using QuizApp.Services;

namespace QuizApp.Controllers;

public class PlayerController(IPlayerService playerService) : Controller
{
    private readonly IPlayerService _playerService = playerService;

    [HttpGet]
    public IActionResult GetPlayers()
    {
        return View(_playerService.GetPlayers());
    }

    [HttpPost]
    public IActionResult AddPlayer(Player player)
    {
        try
        {
            _playerService.AddPlayer(player);
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

    public IActionResult AddPlayer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DeletePlayer(int id)
    {
        _playerService.DeletePlayer(id);
        return RedirectToAction("GetPlayers");
    }
}