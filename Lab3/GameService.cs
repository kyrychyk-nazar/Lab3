namespace Лаб2;

public class GameService : IGameService
{
    private readonly IGameRepository gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public void CreateGame(BaseGame game)
    {
        gameRepository.CreateGame(game);
    }

    public BaseGame? GetGameById(Guid gameId)
    {
        return gameRepository.GetGameById(gameId);
    }

    public List<BaseGame> GetAllGames()
    {
        return gameRepository.GetAllGames();
    }

    public void GetStats()
    {
        Console.WriteLine("\nСтатистика iгор:");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("| Противник     | Результат  | Рейтинг | Game ID      |");
        Console.WriteLine("-------------------------------------------------");

        foreach (var game in gameRepository.GetAllGames())
        {
            string result = game.IsWin ? "Win" : "Lose";
            Console.WriteLine($"| {game.OpponentName,-12} | {result,-7} | {game.CalculateRating(),-6} | {game.GameId} |");
        }

        Console.WriteLine("-------------------------------------------------");
    }
}