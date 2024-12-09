namespace Лаб2;

public class StandardAcc : GameAccount
{
    public StandardAcc(string username, int initialRating) : base(username, initialRating) { }

    public override void LoseGame(BaseGame game)
    {
        int rating = game.CalculateRating();
        if (CurrentRating - rating < 1)
        {
            Console.WriteLine("Рейтинг не може бути менше одного, ваш рейтинг залишається поточним.");
            rating = 0;
        }
        else
        {
            CurrentRating -= rating;
        }

        gamesHistory.Add(game);
        Console.WriteLine($"Lose by {game.PlayerName} vs {game.OpponentName}. Current rating: {CurrentRating}");
    }
}