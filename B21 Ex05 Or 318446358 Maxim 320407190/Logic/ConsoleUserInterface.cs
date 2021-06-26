using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;

namespace Ex02
{
    public class ConsoleUserInterface
    {
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;
        private TicTacToeFlow m_GameFlow;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;

        public void InitializeGame()
        {
            Console.WriteLine("Welcome to Reversed TicTacToe Game :)");
            int size = getBoardSize();
            m_Player1 = new Player("First Player", 'X', ePlayerType.User);
            m_Player2 = new Player("Second Player", 'O', getOpponentType());
            m_GameFlow = new TicTacToeFlow(size);
       
            while(true)
            {
                startSingleGame();
                PrintScore(m_Player1, m_Player2);

                if(getQuitOption())
                {
                    break;
                }
            }
        }

        private void startSingleGame()
        {
            m_CurrentPlayer = m_Player1;
            printBoard(m_GameFlow.DisplayBoard);

            while (true)
            {
                if (m_CurrentPlayer.PlayerType == ePlayerType.User)
                {
                    userTurn();
                }
                else
                {
                    pcTurn();
                }

                printBoard(m_GameFlow.DisplayBoard);

                if (m_GameFlow.CheckIfLose(m_CurrentPlayer.Symbol))
                {
                    togglePlayerTurn();
                    m_CurrentPlayer.AddScore();
                    Console.WriteLine("{0} Win! :)))", m_CurrentPlayer.Name);
                    m_GameFlow.InitializeBoard();
                    break;
                }

                if (m_GameFlow.BoardFull())
                {
                    Console.WriteLine("The board is full, No one wins at this Round");
                    break;
                }

                togglePlayerTurn();
            }
        }

        private ePlayerType getOpponentType()
        {
            ePlayerType typeOfPlayer = ePlayerType.User;
            Screen.Clear();
            Console.WriteLine(string.Format("Who do you want to play against?{0}{0}Press 'ENTER' to Player vs Player mode,{0}Press 'C' to Play vs Computer", Environment.NewLine));
            string vText = Console.ReadLine();

            if (vText.ToLower() == "c")
            {
                typeOfPlayer = ePlayerType.Computer;
            }

            return typeOfPlayer;
        }

        public void PrintScore(Player first, Player sec)
        {
            string text = string.Format("{0} - {1} : {2} - {3}", first.Name, first.Score, sec.Name, sec.Score);
            Console.WriteLine(text);
        }

        private void userTurn()
        {
            Console.WriteLine("[{0}] is playing,you are [{1}]", m_CurrentPlayer.Name, m_CurrentPlayer.Symbol);
            int row = getRowPlayerTurnInput();
            int column = getColumnPlayerTurnInput();

            while (!setCoordinates(row, column, m_CurrentPlayer.Symbol))
            {
                Screen.Clear();
                printBoard(m_GameFlow.DisplayBoard);
                Console.WriteLine(string.Format("This Index is allready occupied,use another Index"));
                row = getRowPlayerTurnInput();
                column = getColumnPlayerTurnInput();
            }
        }

        private void pcTurn()
        { 
            List<int> listOf2RandomizedIndecies = m_GameFlow.GetRandomizedIndeciesByPC();
            setCoordinates(listOf2RandomizedIndecies[0], listOf2RandomizedIndecies[1], m_CurrentPlayer.Symbol);
        }

        private bool setCoordinates(int i_Row, int i_Column, char i_Symbol)
        {
            return m_GameFlow.SetBoardValues(i_Row, i_Column, i_Symbol);
        }

        private void togglePlayerTurn()
        {
            m_CurrentPlayer = getNextPlayer();
        }

        private Player getNextPlayer()
        {
            return m_CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
        }

        private int getBoardSize()
        {
            Console.WriteLine(string.Format("Please enter TicTacToe Board game dimensions: ({0}-{1}) ", k_MinBoardSize, k_MaxBoardSize));
            int size;
            bool inputFlag = int.TryParse(Console.ReadLine(), out size);

            while (!inputFlag || (size > k_MaxBoardSize || size < k_MinBoardSize))
            {
                Screen.Clear();
                Console.WriteLine(string.Format("Invalid input,Please enter board size ({0}-{1})", k_MinBoardSize, k_MaxBoardSize));
                inputFlag = int.TryParse(Console.ReadLine(), out size);
            }

            return size;
        }


        // $G$ NTT-999 (-5) Should use Environment.NewLine rather than \n.
        private void printBoard(Board i_Board)
        {
            StringBuilder matrixText = new StringBuilder();
            StringBuilder separationRow = new StringBuilder();
            Screen.Clear();

            separationRow.Append("  ");
            matrixText.AppendFormat("   ");
            for (int i = 1; i <= i_Board.NumOfCols; i++)
            {
                matrixText.AppendFormat(" {0}  ", i);
                separationRow.Append("====");
            }

            separationRow.Append("=");
            matrixText.Append("\n");
            for (int i = 0; i < i_Board.NumOfRows; i++)
            {
                matrixText.AppendFormat("{0} ", i + 1);
                for (int j = 0; j < i_Board.NumOfCols; j++)
                {
                    matrixText.AppendFormat("| {0} ", i_Board.GetValueByIndex(i, j));
                }

                matrixText.AppendFormat("| \n{0} \n", separationRow);
            }

            Console.WriteLine(matrixText);
        }

        private int getRowPlayerTurnInput()
        {
            Console.WriteLine("Please enter Row:");
            int row;
            bool inputFlag = int.TryParse(Console.ReadLine(), out row);
            row--;

            while (!inputFlag || !m_GameFlow.CheckBoardRange(row))
            {
                Screen.Clear();
                printBoard(m_GameFlow.DisplayBoard);
                Console.WriteLine(string.Format("Your input for Row is not correct,try correct index:"));
                inputFlag = int.TryParse(Console.ReadLine(), out row);
            }

            return row;
        }

        private int getColumnPlayerTurnInput()
        {
            Console.WriteLine("Please enter Column:");
            int column;
            bool inputFlag = int.TryParse(Console.ReadLine(), out column);
            column--;

            while (!inputFlag || !m_GameFlow.CheckBoardRange(column))
            {
                Screen.Clear();
                printBoard(m_GameFlow.DisplayBoard);
                Console.WriteLine(string.Format("Your input for Column is not correct,try correct index:"));
                inputFlag = int.TryParse(Console.ReadLine(), out column);
            }

            return column;
        }

        private bool getQuitOption()
        {
            bool quit = false;
            Console.WriteLine(string.Format("Do you want to exit the game? Press 'Q' / Enter for rematch {0}", Environment.NewLine));
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                quit = true;
            }

            return quit;
        }
    }
}
