using TicTacToeConsole.Entities;
using TicTacToeConsole.Enums;

namespace TicTacToeConsole.Helper
{
    public static class CheckWinner
    {
        public static bool IsWinner(Board board)
        {

            return SearchInDepth(board) || SearchDiagonally(board) || SearchInLength(board); 
        }

        private static bool SearchInDepth(Board board)
        {
            var found = false;

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - 1; j++)
                {
                    if (board.Tiles[j, i].Value != board.Tiles[j + 1, i].Value || board.Tiles[i, j].Value == TileStates.Empty)
                    {
                        found = false;
                        break;
                    }
                    found = true;
                }

                if (found)
                {
                    return found;
                }
            }

            return false;
        }

        private static bool SearchInLength(Board board)
        {
            var found = false;

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - 1; j++)
                {
                    if (board.Tiles[i, j].Value != board.Tiles[i, j + 1].Value || board.Tiles[i, j].Value == TileStates.Empty)
                    {
                        found = false;
                        break;
                    }
                    found = true;
                }

                if (found)
                {
                    return found;
                }
            }

            return false;
        }

        private static bool SearchDiagonally(Board board)
        {
            bool found = false;

            int i, j;

            for (i = 0; i < board.Size - 1; i++)
            {
                if (board.Tiles[i, i].Value != board.Tiles[i + 1, i + 1].Value || board.Tiles[i, i].Value == TileStates.Empty)
                {
                    found = false;
                    break;
                }
                found = true;
            }

            return found;
        }
    }
}
