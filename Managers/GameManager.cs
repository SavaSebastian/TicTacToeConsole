using TicTacToeConsole.Entities;
using TicTacToeConsole.Enums;
using TicTacToeConsole.Helper;

namespace TicTacToeConsole.Managers
{
    public class GameManager
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Board Board { get; private set; }
        public GameStates GameState { get; private set; }

        public GameManager()
        {
            Player1 = new Player()
            {
                State = PlayerStates.Playing
            };

            Player2 = new Player();

            GameState = GameStates.Setup;
        }

        public void Setup()
        {
            Console.WriteLine("Welcom to the customizable TicTacToe game!");
            Console.WriteLine("Do you want to play a default game? (Y/N)");

            string answer;

            do
            {
                answer = Console.ReadLine();

                if (answer.Equals("N"))
                {
                    Console.WriteLine("Enter the length of the board you want to play on. (integer)");
                    _ = int.TryParse(Console.ReadLine(), out var size);
                    Board = new Board(size);
                }
                else if (answer.Equals("Y"))
                {
                    Board = new Board();
                }
                else
                {
                    Console.WriteLine("Enter a correct response!");
                    
                }
            } while (!answer.Equals("Y") && !answer.Equals("N"));

            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    Board.Tiles[i, j] = new Tile();
                }
            }

            GameState = GameStates.Playing;
        }

        public void ComputePlayerMove()
        {
            Console.WriteLine("Enter the desired position: (x y; each integer on a new line)");

            var isValid = false;

            while (!isValid)
            {
                if (!int.TryParse(Console.ReadLine(), out int x) || x < 0 || x >= Board.Size)
                {
                    Console.WriteLine("Try again");
                    continue;
                }

                if (!int.TryParse(Console.ReadLine(), out int y) || y < 0 || y >= Board.Size)
                {
                    Console.WriteLine("Try again");
                    continue;
                }

                if (Board.Tiles[x, y].Value != TileStates.Empty)
                {
                    Console.WriteLine("Tile already has a value, try another");
                    continue;
                }

                if (Player1.State == PlayerStates.Playing)
                {
                    Board.Tiles[x, y].Value = TileStates.X;
                }
                else
                {
                    Board.Tiles[x, y].Value = TileStates.O;
                }

                isValid = true;
            }

            if (CheckWinner.IsWinner(Board))
            {
                if (Player1.State == PlayerStates.Playing)
                {
                    Console.WriteLine("X Won!");
                }
                else
                {
                    Console.WriteLine("Y Won!");
                }
                GameState = GameStates.End;
            }
            else
            {
                if (Player1.State == PlayerStates.Playing)
                {
                    Player1.State = PlayerStates.Waiting;
                    Player2.State = PlayerStates.Playing;
                }
                else
                {
                    Player1.State = PlayerStates.Playing;
                    Player2.State = PlayerStates.Waiting;
                }
            }

            PrintBoard();
        }

        

        public void EndGame()
        {
            Console.WriteLine("Play again? (Y/N)");

            string answer;

            do
            {
                answer = Console.ReadLine();

                if (answer.Equals("Y"))
                {
                    GameState = GameStates.Setup;
                }
                else if (answer.Equals("N"))
                {
                    Console.WriteLine("Thanks for playing!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Enter a correct response!");
                    answer = Console.ReadLine();
                }
            } while (!answer.Equals("Y") && !answer.Equals("N"));

        }

        private void PrintBoard()
        {
            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    Console.Write(Board.Tiles[i, j].Value + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
