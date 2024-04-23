using System;

namespace ConnectFour
{
    class Program
    {
        const int Rows = 6;
        const int Cols = 7;
    
        private static char[,] InitializeBoard()
        {
            char[,] board = new char[Rows, Cols];
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    board[row, col] = '-';
                }
            }
        }
        
        private void DisplayBoard(char[,] board)
        {
            // display board
            for (int row = 0; row < Rows; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < Cols; col++)
                {
                   Console.Write(board[row, col] + " ");
                }
                Console.WriteLine("|");
            }

            Console.WriteLine("-----------------");
            
            // display column number
            Console.WriteLine("  1 2 3 4 5 6 7");
        }
    
        private bool DropPiece(char[,] board, char player)
        {
            Console.WriteLine($"Player {player}, enter the column number (1-{Cols}):");
            int col;
    
            while (!int.TryParse(Console.Readline(), out col) || col <0 || col >= Cols || board[0, col] != '-')
            {
                Console.WriteLine("Invalid input. Enter a valid column number (0-{Cols}):");
            }
    
            for (int row = Rows -1; row >=0; row--)
            {
                if (board[row, col - 1] == '-')
                {
                    board[row, col - 1] = player;
                    return true;
                }
            }
            return false;
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
    
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Player 1 name: ");
            string player1Name = Console.ReadLine();
            Console.WriteLine("Enter Player 2 name: ");
            string player2Name = Console.ReadLine();
            
            char[,] board = InitializeBoard();
            char currentPlayer = 'X';

            while (true)
            {
                DisplayBoard(board);
                if (DropPiece(board, currentPlayer))
                {
                    if (WinningConditions(board, currentPlayer))
                    {
                        Console.WriteLine($"Player {currentPlayer} ({(currentPlayer == 'X' ? player1Name : player2Name)}) wins!");
                        break;
                    }
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
                else 
                {
                    Console.WriteLine("Column is full. Please choose another column.");
                }
            }
        }
    }
}
