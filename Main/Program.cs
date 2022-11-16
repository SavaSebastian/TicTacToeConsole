using TicTacToeConsole.Enums;
using TicTacToeConsole.Managers;

namespace TicTacToeConsole.Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gameManager = new GameManager();

            while (true)
            {
                switch (gameManager.GameState)
                {
                    case GameStates.Setup:
                        gameManager.Setup();
                        break;

                    case GameStates.Playing:
                        gameManager.ComputePlayerMove();
                        break;

                    case GameStates.End:
                        gameManager.EndGame();
                        break;

                    default:
                        Console.WriteLine("Something went teribly wrong.");
                        break;
                }
            }

        }
    }
}