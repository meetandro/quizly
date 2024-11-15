using Quizly.Entities;
using Quizly.Exceptions;
using Quizly.Repositories;

namespace Quizly.Services;

public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public List<Player> GetAllPlayers()
    {
        return _playerRepository.GetAllPlayers();
    }

    public Player AddPlayer(Player player)
    {
        if (string.IsNullOrEmpty(player.Username))
        {
            throw new EmptyInputException("Username is required.");
        }
        if (_playerRepository.GetPlayerByUsername(player.Username) is not null)
        {
            throw new EntityAlreadyExistsException($"Player '{player.Username}' already exists.");
        }

        return _playerRepository.AddPlayer(player);
    }

    public Player DeletePlayer(int id)
    {
        return _playerRepository.DeletePlayer(id);
    }
}