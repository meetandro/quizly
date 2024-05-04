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
        return View("Players", players);
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
            return ViewError(ex.Message);
        }
        catch (EntityAlreadyExistsException ex)
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
    public IActionResult DeletePlayer(int id)
    {
        _playerService.DeletePlayer(id);
        return RedirectToAction("GetAllPlayers");
    }
}