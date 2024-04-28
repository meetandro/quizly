using QuizApp.Entities;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public List<Player> GetPlayers()
    {
        return _playerRepository.GetPlayers();
    }

    public Player AddPlayer(Player player)
    {
        if (string.IsNullOrEmpty(player.Username))
        {
            throw new ArgumentNullException(nameof(player), "Username is required.");
        }
        if (_playerRepository.GetPlayerByUsername(player.Username) is not null)
        {
            throw new Exception("Player with name already exists.");
        }

        return _playerRepository.AddPlayer(player);
    }

    public Player DeletePlayer(int id)
    {
        return _playerRepository.DeletePlayer(id);
    }
}