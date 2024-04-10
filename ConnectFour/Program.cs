using System;

namespace ConnectFour
{
    const int Rows = 6;
    const int Cols = 7;

    private void InitializeBoard()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                board[row, col] = '-';
            }
        }
    }
    
    private void DisplayBoard()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
               Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private bool DropPiece()
    {
        
    }

    private bool WinningConditions()
    {
        // Horizontal
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col <= Cols - 4; col++)
            {
                if (board[row, col] == player &&
                    board[row, col + 1] == player &&
                    board[row, col + 2] == player &&
                    board[row, col + 3] == player &&)
                {
                    return true;
                }
            }
        }

        // Vertical
        for (int row = 0; row < Rows - 4; row++)
        {
            for (int col = 0; col <= Cols; col++)
            {
                if (board[row, col] == player &&
                    board[row + 1, col] == player &&
                    board[row + 2, col] == player &&
                    board[row + 3, col] == player &&)
                {
                    return true;
                }
            }
        }

        // Diagonally: bottom-left to top-right
        for (int row = 0; row < Rows - 4; row++)
        {
            for (int col = 0; col <= Cols - 4; col++)
            {
                if (board[row, col] == player &&
                    board[row + 1, col + 1] == player &&
                    board[row + 2, col + 2] == player &&
                    board[row + 3, col + 3] == player &&)
                {
                    return true;
                }
            }
        }

        // Diagonally: top-left to bottom-right
        for (int row = 3; row < Rows; row++)
        {
            for (int col = 0; col <= Cols - 4; col++)
            {
                if (board[row, col] == player &&
                    board[row + 1, col + 1] == player &&
                    board[row + 2, col + 2] == player &&
                    board[row + 3, col + 3] == player &&)
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
