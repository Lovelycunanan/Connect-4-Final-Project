using System;
using System.Collections.Generic;

namespace ConnectFour
{
    class Program
    {
        const int Rows = 6;
        const int Cols = 7;
        static Random random = new Random();
    
        static char[,] InitializeBoard()
        {
            char[,] board = new char[Rows, Cols];
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    board[row, col] = '-';
                }
            }
            return board;
        }
        
        static void DisplayBoard(char[,] board)
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
    
        static bool DropPiece(char[,] board, char player, Dictionary<char, string> playerNames)
        {
            Console.WriteLine($"Player {playerNames[player]}, enter the column number (1-{Cols}):");
            int col;
    
            while (!int.TryParse(Console.ReadLine(), out col) || col < 1 || col > Cols || board[0, col - 1] != '-')
            {
                Console.WriteLine($"Invalid input. Enter a valid column number (1-{Cols}):");
            }
    
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (board[row, col - 1] == '-')
                {
                    board[row, col - 1] = player;
                    return true;
                }
            }
            return false;
        }

        static bool DropPieceAI(char[,] board, char player, Dictionary<char, string> playerNames)
        {
            Console.WriteLine($"Player {playerNames[player]} is making a move...");

            int col = random.Next(1, Cols + 1);

            for (int row = Rows - 1; row >= 0; row--)
            {
                if (board[row, col -1] == '-')
                {
                    board[row, col - 1] == '-' = player;
                    return true;
                }
            }
            return false;
        }
    
        static bool WinningConditions(char[,] board, char player)
        {
            // Horizontal
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col <= Cols - 4; col++)
                {
                    if (board[row, col] == player &&
                        board[row, col + 1] == player &&
                        board[row, col + 2] == player &&
                        board[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }
    
            // Vertical
            for (int row = 0; row <= Rows - 4; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (board[row, col] == player &&
                        board[row + 1, col] == player &&
                        board[row + 2, col] == player &&
                        board[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }
    
            // Diagonally: bottom-left to top-right
            for (int row = 0; row <= Rows - 4; row++)
            {
                for (int col = 0; col <= Cols - 4; col++)
                {
                    if (board[row, col] == player &&
                        board[row + 1, col + 1] == player &&
                        board[row + 2, col + 2] == player &&
                        board[row + 3, col + 3] == player)
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
                        board[row - 1, col + 1] == player &&
                        board[row - 2, col + 2] == player &&
                        board[row - 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }
    
            return false;
        }
    
        static void Main(string[] args)
        {
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine("Choose the game mode: ");
                Console.WriteLine("1. Two Players");
                Console.WriteLine("2. Player vs AI");
                Console.Write("Enter your choice: ");
                int choice;

                while (!int.TryParse(Console.Readline(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                }

                string player1Name, player2Name;
                if (choice == 1)
                {
                    Console.WriteLine("Enter Player 1 name: ");
                    string player1Name = Console.ReadLine();
                    Console.WriteLine("Enter Player 2 name: ");
                    string player2Name = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Enter player name: ");
                    player1Name = Console.ReadLine();
                    player2Name = "AI";
                }
    
                Dictionary<char, string> playerNames = new Dictionary<char, string>()
                {
                    { 'X', player1Name },
                    { 'O', player2Name }
                };
                
                char[,] board = InitializeBoard();
                char currentPlayer = 'X';
    
                while (true)
                {
                    DisplayBoard(board);
                    if (choice == 1 || currentPlayer == 'X')
                    {
                        if (DropPiece(board, currentPlayer, playerNames))
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
                    else
                    {
                        if (DropPieceAI(board, currentPlayer, playerNames))
                        {
                            if (WinningConditions(board, currentPlayer))
                            {
                                Console.WriteLine($"Player {currentPlayer} ({playerNames[currentPlayer]}) wins!");
                                break;
                            }
                            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                        }
                    }
                }

                Console.WriteLine("Do you want to play again? (yes/no)");
                string answer = Console.ReadLine();
                playAgain = (answer.ToLower() == "yes");
            }
        }
    }
}
