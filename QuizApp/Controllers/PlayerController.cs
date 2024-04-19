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