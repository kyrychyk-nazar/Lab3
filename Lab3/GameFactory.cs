namespace Лаб2;

public class GameFactory
{
    public static BaseGame CreateStandardGame(string playerName, string opponentName, int rating, bool isWin)
    {
        return new StandardGame(playerName, opponentName, rating, isWin);
    }

    public static BaseGame CreateTrainingGame(string playerName, string opponentName)
    {
        return new TrainingGame(playerName, opponentName);
    }
}