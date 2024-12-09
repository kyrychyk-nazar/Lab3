namespace Лаб2;

public class GameService : IGameService
{
    private readonly IGameRepository GameRepository;

    public GameService(IGameRepository gameRepository)
    {
        this.GameRepository = gameRepository;
    }

    public void CreateGame(BaseGame game)
    {
        GameRepository.CreateGame(game);
    }

    public BaseGame? GetGameById(Guid gameId)
    {
        return GameRepository.GetGameById(gameId);
    }

    public List<BaseGame> GetAllGames()
    {
        return GameRepository.GetAllGames();
    }

    public void GetStats()
    {
        GameRepository.GetStats();
    }
}