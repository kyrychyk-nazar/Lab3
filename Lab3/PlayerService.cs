namespace Лаб2;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository repository;

    public PlayerService(IPlayerRepository repository)
    {
        this.repository = repository;
    }

    public void AddPlayer(string username, int initialRating, bool isPayToWin = false)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Ім'я користувача не може бути порожнім.");
        }

        if (initialRating < 1)
        {
            throw new ArgumentException("Рейтинг має бути хоча б 1.");
        }

        if (repository.GetPlayerByName(username) != null)
        {
            throw new InvalidOperationException("Користувач із таким ім'ям вже існує.");
        }

        GameAccount player = isPayToWin
            ? new PayToWin(username, initialRating)
            : new StandardAcc(username, initialRating);

        repository.AddPlayer(player);
    }

    public GameAccount? GetPlayerByName(string username)
    {
        return repository.GetPlayerByName(username);
    }

    public List<GameAccount> GetAllPlayers()
    {
        return repository.GetAllPlayers();
    }

    public void RemovePlayer(string username)
    {
        var player = repository.GetPlayerByName(username);
        if (player != null)
        {
            repository.RemovePlayer(player);
            Console.WriteLine($"Гравець {username} успішно видалений.");
        }
        else
        {
            Console.WriteLine($"Гравця з іменем {username} не знайдено.");
        }
    }
}