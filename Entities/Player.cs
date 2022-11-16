using TicTacToeConsole.Enums;

namespace TicTacToeConsole.Entities
{
    public class Player
    {
        public PlayerStates State { get; set; }

        public Player() 
        {
            State = PlayerStates.Waiting;
        }
    }
}