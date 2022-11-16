namespace TicTacToeConsole.Entities
{
    public class Board
    {
        public int Size { set; get; }
        public Tile[,] Tiles { get; set; }
       
        public Board(int size = 3)
        {
            Size = size;
            Tiles = new Tile[size, size];
        }
    }
}
