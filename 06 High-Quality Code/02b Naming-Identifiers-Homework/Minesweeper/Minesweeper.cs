namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const int GameBoardRows = 5;
        private const int GameBoardColumns = 10;
        private const int NumberOfMinesOnBoard = 15;
        private const int MaxHighScoreRecords = 5;

        private const char UnOpenSquare = '?';
        private const char MineFreeSymbol = '-';
        private const char MineSymbol = '*';

        private const string TurnCommand = "turn";
        private const string TopCommand = "top";
        private const string RestartCommand = "restart";
        private const string ExitCommand = "exit";

        private const int NumberOfMineFreeSquares = (GameBoardRows * GameBoardColumns) - NumberOfMinesOnBoard;
        private const int NumberOfRowSymbols = 1;       // (int)Math.Ceiling(Math.Log10(GameBoardRows));
        private const int NumberOfColumnSymbols = 1;    // (int)Math.Ceiling(Math.Log10(GameBoardColumns));
        private const int RowAndColCommandLenght = NumberOfRowSymbols + NumberOfColumnSymbols + 1;

        public static void Main()
        {
            string command = string.Empty;
            int openedSquares = 0;
            List<Result> highScore = new List<Result>(6);
            int row = 0;
            int column = 0;

            bool initialScreen = true;
            bool gameWon = false;
            bool gameOver = false;

            char[,] gameBoard = CreateGameBoard();
            char[,] bombs = ChooseMinesPositions();

            do
            {
                if (initialScreen)
                {
                    Console.WriteLine(" Minesweeper Game. Find the mine-free squares. \n\t Enter '{0}' command to see Highscore \n\t Enter '{1}'command to start new game \n\t Enter '{2}' command to quit the game", TopCommand, RestartCommand, ExitCommand);
                    PrintBoard(gameBoard);
                    initialScreen = false;
                }

                Console.Write("Enter Row and Column number: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= RowAndColCommandLenght)
                {
                    // modified. If board dimentions are bigger than 10, original code does't work properly
                    string[] commands = command.Split(new char[] { ' ', ',', ';', '.' }, StringSplitOptions.RemoveEmptyEntries);
                    if (int.TryParse(commands[0].ToString(), out row) &&
                        int.TryParse(commands[1].ToString(), out column) &&
                        row <= gameBoard.GetLength(0) &&
                        column <= gameBoard.GetLength(1))
                    {
                        command = TurnCommand;
                    }
                }

                switch (command)
                {
                    case TopCommand:
                        PrintHighscore(highScore);
                        break;
                    case RestartCommand:
                        gameBoard = CreateGameBoard();
                        bombs = ChooseMinesPositions();
                        PrintBoard(gameBoard);
                        gameOver = false;
                        initialScreen = false;
                        break;
                    case ExitCommand:
                        Console.WriteLine("Game Quit");
                        break;
                    case TurnCommand:
                        if (bombs[row, column] != MineSymbol)
                        {
                            if (bombs[row, column] == MineFreeSymbol)
                            {
                                OpenSquare(gameBoard, bombs, row, column);
                                openedSquares++;
                            }

                            if (openedSquares == NumberOfMineFreeSquares)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                PrintBoard(gameBoard);
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\n Unknown command \n");
                        break;
                }

                if (gameOver)
                {
                    PrintBoard(bombs);
                    Console.Write("\n\t Game Over! Your score is {0}. Enter your nickname: ", openedSquares);
                    string nickname = Console.ReadLine();
                    AddHighscore(highScore, new Result(nickname, openedSquares)); // new method
                    PrintHighscore(highScore);

                    gameBoard = CreateGameBoard();
                    bombs = ChooseMinesPositions();
                    openedSquares = 0;
                    gameOver = false;
                    initialScreen = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("\nYou win! Found {0} squares.", NumberOfMineFreeSquares);
                    PrintBoard(bombs);
                    Console.WriteLine("Enter your nickname: ");
                    string nickname = Console.ReadLine();
                    AddHighscore(highScore, new Result(nickname, openedSquares)); // new method
                    PrintHighscore(highScore);

                    gameBoard = CreateGameBoard();
                    bombs = ChooseMinesPositions();
                    openedSquares = 0;
                    gameWon = false;
                    initialScreen = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Good Bye!");
            Console.WriteLine("Press any kew to exit");
            Console.Read();
        }

        private static void AddHighscore(List<Result> highScore, Result newScoreRecord)
        {
            if (highScore.Count < MaxHighScoreRecords)
            {
                highScore.Add(newScoreRecord);
            }
            else
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    if (highScore[i].Score < newScoreRecord.Score)
                    {
                        highScore.Insert(i, newScoreRecord);
                        highScore.RemoveAt(highScore.Count - 1);
                        break;
                    }
                }
            }

            highScore.Sort((r1, r2) => r2.Name.CompareTo(r1.Name));
            highScore.Sort((r1, r2) => r2.Score.CompareTo(r1.Score));
        }

        private static void PrintHighscore(List<Result> results)
        {
            Console.WriteLine("\nHighscore:");
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} squares", i + 1, results[i].Name, results[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Highscore is empty\n");
            }
        }

        private static void OpenSquare(char[,] gameBoard, char[,] mines, int row, int column)
        {
            char numberOfMines = NumberOfNearMines(mines, row, column);
            mines[row, column] = numberOfMines;
            gameBoard[row, column] = numberOfMines;
        }

        private static void PrintBoard(char[,] gameBoard)
        {
            int rows = gameBoard.GetLength(0);
            int columns = gameBoard.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", gameBoard[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            char[,] board = new char[GameBoardRows, GameBoardColumns];
            for (int i = 0; i < GameBoardRows; i++)
            {
                for (int j = 0; j < GameBoardColumns; j++)
                {
                    board[i, j] = UnOpenSquare;
                }
            }

            return board;
        }

        private static char[,] ChooseMinesPositions()
        {
            char[,] minesBoard = new char[GameBoardRows, GameBoardColumns];

            for (int i = 0; i < GameBoardRows; i++)
            {
                for (int j = 0; j < GameBoardColumns; j++)
                {
                    minesBoard[i, j] = MineFreeSymbol;
                }
            }

            List<int> minePositions = new List<int>();
            Random random = new Random(); // Only one random generator in the project
            int numberOfSquaresOnBoard = GameBoardRows * GameBoardColumns;
            while (minePositions.Count < NumberOfMinesOnBoard)
            {
                int newPosition = random.Next(numberOfSquaresOnBoard);
                if (!minePositions.Contains(newPosition))
                {
                    minePositions.Add(newPosition);
                }
            }

            foreach (int position in minePositions)
            {
                int column = position / GameBoardColumns;
                int row = position % GameBoardColumns;
                if (row == 0 && position != 0)
                {
                    column--;
                    row = GameBoardColumns;
                }
                else
                {
                    row++;
                }

                minesBoard[column, row - 1] = MineSymbol;
            }

            return minesBoard;
        }

        private static void FillNearMinesOnBoard(char[,] gameBoard)
        {
            int rows = gameBoard.GetLength(0);
            int columns = gameBoard.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (gameBoard[i, j] != MineSymbol)
                    {
                        gameBoard[i, j] = NumberOfNearMines(gameBoard, i, j);
                    }
                }
            }
        }

        private static char NumberOfNearMines(char[,] gameBoard, int row, int column)
        {
            int counter = 0;
            int rows = gameBoard.GetLength(0);
            int columns = gameBoard.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameBoard[row - 1, column] == MineSymbol)
                {
                    counter++;
                }
            }

            if (row + 1 < rows)
            {
                if (gameBoard[row + 1, column] == MineSymbol)
                {
                    counter++;
                }
            }

            if (column - 1 >= 0)
            {
                if (gameBoard[row, column - 1] == MineSymbol)
                {
                    counter++;
                }
            }

            if (column + 1 < columns)
            {
                if (gameBoard[row, column + 1] == MineSymbol)
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (gameBoard[row - 1, column - 1] == MineSymbol)
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (gameBoard[row - 1, column + 1] == MineSymbol)
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (gameBoard[row + 1, column - 1] == MineSymbol)
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (gameBoard[row + 1, column + 1] == MineSymbol)
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}
