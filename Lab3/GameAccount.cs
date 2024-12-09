namespace Лаб2;

public abstract class GameAccount
{
    public string Username { get; set; }
    public int CurrentRating { get; set; }
    public int GameCounts { get; private set; }

    protected List<BaseGame> gamesHistory = new List<BaseGame>();

    protected GameAccount(string username, int initialRating)
    {
        if (initialRating < 1)
            throw new ArgumentException("Рейтинг має бути хоча б 1.");

        Username = username;
        CurrentRating = initialRating;
        GameCounts = 0;
    }

    public void WinGame(BaseGame game)
    {
        int rating = game.CalculateRating();
        CurrentRating += rating;
        GameCounts++;
        gamesHistory.Add(game);
        Console.WriteLine($"Win by {game.PlayerName} vs {game.OpponentName} with {rating}. Current rating: {CurrentRating}");
    }

    public abstract void LoseGame(BaseGame game);

    public void PlayTrainingGame(string opponentName)
    {
        var game = GameFactory.CreateTrainingGame(Username, opponentName);
        gamesHistory.Add(game);
        Console.WriteLine($"Training game  by {game.PlayerName} vs {game.OpponentName}. No rating change.");
    }
}