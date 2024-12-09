using System;
using System.Collections.Generic;
using System.Linq;

namespace Лаб2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DbContext context = new DbContext();
            IPlayerRepository playerRepository = new PlayerRepository(context);
            IPlayerService playerService = new PlayerService(playerRepository);
            IGameRepository gameRepository = new GameRepository(context);
            IGameService gameService = new GameService(gameRepository);

            // Створення гравців
            playerService.AddPlayer("John", 100);
            playerService.AddPlayer("Pavlik", 200, isPayToWin: true);

            Console.WriteLine("\nВсi гравцi:");
            foreach (var player in playerService.GetAllPlayers())
            {
                Console.WriteLine($"Username: {player.Username} Rating:{player.CurrentRating}");
            }
            
            // Створення ігор
            var game1 = GameFactory.CreateStandardGame("John", "Pavlik", 50, true); 
            var game2 = GameFactory.CreateStandardGame("Pavlik", "John", 50, true);

            gameService.CreateGame(game1);
            gameService.CreateGame(game2);

            // Виведення статистики всіх ігор
            gameService.GetStats();

            // Виведення ігор конкретного гравця
            Console.WriteLine("\nIгри John:");
            foreach (var game in gameService.GetAllGames().Where(g => g.PlayerName == "John"))
            {
                Console.WriteLine($"Game ID: {game.GameId}, Opponent: {game.OpponentName}, Result: {(game.IsWin ? "Win" : "Lose")}");
            }
            
            // Виведення всіх ігор
            Console.WriteLine("\nВсi iгри:");
            foreach (var game in gameService.GetAllGames())
            {
                Console.WriteLine($"Game ID: {game.GameId}, Player: {game.PlayerName}, Opponent: {game.OpponentName}, Result: {(game.IsWin ? "Win" : "Lose")}");
            }
            
            playerService.RemovePlayer("John");
            Console.WriteLine("\nПісля видалення John:");
            foreach (var player in playerService.GetAllPlayers())
            {
                Console.WriteLine($"Username: {player.Username} Rating:{player.CurrentRating}");
            }
        }
    }
}
