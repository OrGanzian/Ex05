using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class Board
    {
        // $G$ CSS-999 (-3) this member should be readonly
        private char[,] m_Matrix;
        private int m_Rows;
        private int m_Cols;

        public Board(int i_size)
        {
            this.m_Matrix = new char[i_size, i_size];
            this.m_Rows = i_size;
            this.m_Cols = i_size;
            InitializeBoard();
        }

        public List<List<int>> GetFreeIndecies()
        {
            List<List<int>> listOfFreeIndecies = new List<List<int>>();

            for (int i = 0; i < this.m_Cols; i++)
            {
                for (int j = 0; j < this.m_Rows; j++)
                {
                    if (m_Matrix[i, j] == ' ')
                    {
                        listOfFreeIndecies.Add(new List<int> { i, j });
                    }
                }
            }

            return listOfFreeIndecies;
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < this.m_Rows; i++)
            {
                for (int j = 0; j < this.m_Cols; j++)
                {
                    this.m_Matrix[i, j] = ' ';
                }
            }
        }

        public int NumOfRows
        {
            get
            {
                return m_Rows;
            }
        }

        public int NumOfCols
        {
            get
            {
                return this.m_Cols;
            }
        }

        public Board GetBoard
        {
            get
            {
                return this;
            }
        }

        public char GetValueByIndex(int i_Row, int i_Col)
        {
            return this.m_Matrix[i_Row, i_Col];
        }


        // $G$ CSS-999 (-3) You should have used constants\enum here.
        public bool SetValueByIndex(int i_Row, int i_Col, char i_iValue) // value is 'X' or 'O'
        {
            bool isSuccesfulInput = false;

            if (m_Matrix[i_Row, i_Col] == ' ')
            {
                this.m_Matrix[i_Row, i_Col] = i_iValue;
                isSuccesfulInput = true;
            }
            else if (m_Matrix[i_Row, i_Col] == 'X' || m_Matrix[i_Row, i_Col] == 'O')
            {
                isSuccesfulInput = false;
            }

            return isSuccesfulInput;
        }


        // $G$ CSS-999 (-3) You should have used constants\enum here.
        public bool IsFull()
        {
            bool flag = true;

            for (int i = 0; i < this.m_Cols; i++)
            {
                for (int j = 0; j < this.m_Rows; j++)
                {
                    if (m_Matrix[i, j] != 'X' && m_Matrix[i, j] != 'O')
                    {
                        flag = false;
                        break;
                    }
                }
            }

            return flag;
        }

        public void Clear()
        {
            for (int i = 0; i < this.m_Cols; i++)
            {
                for (int j = 0; j < this.m_Rows; j++)
                {
                    this.m_Matrix[i, j] = ' ';
                }
            }
        }

        public bool IsMatchInRows(char i_SymbolToCheck)
        {
            bool match = false;
            int counterRow = 0;

            for (int i = 0; i < this.m_Rows; i++)
            {
                counterRow = 0;
                for (int j = 0; j < this.m_Cols; j++)
                {
                    if (this.m_Matrix[i, j] == i_SymbolToCheck)
                    {
                        counterRow++;
                    }

                    if (counterRow == this.m_Rows)
                    {
                        match = true;

                        break;
                    }
                }
            }

            return match;
        }

        public bool IsMAtchInColumns(char i_SymbolToCheck)
        {
            int columnsCounter = 0;
            bool match = false;

            for (int i = 0; i < this.m_Rows; i++)
            {
                columnsCounter = 0;
                for (int j = 0; j < this.m_Cols; j++)
                {
                    if (this.m_Matrix[j, i] == i_SymbolToCheck)
                    {
                        columnsCounter++;
                    }

                    if (columnsCounter == this.m_Rows)
                    {
                        match = true;
                        break;
                    }
                }
            }

            return match;
        }

        public bool IsMatchInDiagonal(char i_SymbolToCheck)
        {
            int diagonalCounter = 0;
            bool match = false;

            for (int i = 0; i < this.m_Rows; i++)
            {
                if (m_Matrix[i, i] == i_SymbolToCheck)
                {
                    diagonalCounter++;
                }
            }

            if (diagonalCounter == this.m_Rows)
            {
                match = true;
            }

            return match;
        }

        public bool IsMatchInReverseDiagonal(char i_SymbolToCheck)
        {
            int diagonalCounter = 0;
            bool match = false;
            int row = this.m_Rows;
            row--;

            for (int i = 0; i < this.m_Rows; i++)
            {
                if (m_Matrix[i, row] == i_SymbolToCheck)
                {
                    diagonalCounter++;
                }

                row--;
            }

            if (diagonalCounter == this.m_Rows)
            {
                match = true;
            }

            return match;
        }

        public bool CheckIfMatch(char i_SymbolToCheck)
        {
            bool matchStatus = false;

            if (IsMatchInRows(i_SymbolToCheck) || IsMAtchInColumns(i_SymbolToCheck) ||
                IsMatchInDiagonal(i_SymbolToCheck) || IsMatchInReverseDiagonal(i_SymbolToCheck))
            {
                matchStatus = true;
            }

            return matchStatus;
        }
    }
}
