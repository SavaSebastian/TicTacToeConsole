using TicTacToeConsole.Enums;

namespace TicTacToeConsole.Entities
{
    public class Tile
    {
        public TileStates Value { get; set; }

        public Tile()
        {
            Value = TileStates.Empty;
        }
    }
}