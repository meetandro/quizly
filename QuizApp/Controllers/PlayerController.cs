using Microsoft.AspNetCore.Mvc;
using QuizApp.Entities;
using QuizApp.Exceptions;
using QuizApp.Services;

namespace QuizApp.Controllers;

public class PlayerController(IPlayerService playerService) : Controller
{
    private readonly IPlayerService _playerService = playerService;

    [HttpGet]
    public IActionResult GetAllPlayers()
    {
        var players = _playerService.GetAllPlayers();
        return View(players);
    }

    public IActionResult AddPlayer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddPlayer(Player player)
    {
        try
        {
            _playerService.AddPlayer(player);
            return RedirectToAction();
        }
        catch (EmptyInputException ex)
        {
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
        catch (EntityAlreadyExistsException ex)
        {
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "Home", new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult DeletePlayer(int id)
    {
        _playerService.DeletePlayer(id);
        return RedirectToAction("GetAllPlayers");
    }
}