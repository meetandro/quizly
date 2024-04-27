using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers;

public class PlayerController(IPlayerRepository playerRepository) : Controller
{
    private readonly IPlayerRepository _playerRepository = playerRepository;

    [HttpGet]
    public IActionResult GetPlayers()
    {
        return View(_playerRepository.GetPlayers());
    }

    [HttpPost]
    public IActionResult AddPlayer(Player player)
    {
        if (string.IsNullOrEmpty(player.Username))
        {
            return RedirectToAction("Error", "Home", new { message = "Name is required." });
        }
        if (_playerRepository.GetPlayerByUsername(player.Username) is not null)
        {
            return RedirectToAction("Error", "Home", new { message = "Player with name already exists." });
        }

        _playerRepository.AddPlayer(player);
        return RedirectToAction();
    }

    public IActionResult AddPlayer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DeletePlayer(int id)
    {
        _playerRepository.DeletePlayer(id);
        return RedirectToAction("GetPlayers");
    }
}