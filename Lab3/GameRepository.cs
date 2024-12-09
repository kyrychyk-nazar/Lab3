namespace Лаб2;

public class GameRepository : IGameRepository
{
    private readonly DbContext context;

    public GameRepository(DbContext context)
    {
        this.context = context;
    }

    public void CreateGame(BaseGame game)
    {
        context.Games.Add(game);
    }

    public List<BaseGame> GetAllGames()
    {
        return context.Games;
    }

    public BaseGame? GetGameById(Guid gameId)
    {
        return context.Games.Find(x => x.GameId == gameId);
    }

    public void GetStats()
    {
        Console.WriteLine("\nСтатистика iгор:");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("| Противник     | Результат  | Рейтинг | Game ID      |");
        Console.WriteLine("-------------------------------------------------");

        foreach (var game in context.Games)
        {
            string result = game.IsWin ? "Win" : "Lose";
            Console.WriteLine($"| {game.OpponentName,-12} | {result,-7} | {game.CalculateRating(),-6} | {game.GameId} |");
        }

        Console.WriteLine("-------------------------------------------------");
    }
}