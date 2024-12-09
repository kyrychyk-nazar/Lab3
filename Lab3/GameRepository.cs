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

    public List<BaseGame> GetStats()
    {
        return context.Games;
    }
}