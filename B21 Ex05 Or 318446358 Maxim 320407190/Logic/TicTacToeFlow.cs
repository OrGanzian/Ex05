using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class TicTacToeFlow
    {
        // $G$ CSS-999 (-3) this member should be readonly
        private Board m_Board;
        private PcPlayer m_PcPlayer;



        public TicTacToeFlow(int i_size)
        {
            this.m_Board = new Board(i_size);
            this.m_PcPlayer = new PcPlayer();
        }

        public Board DisplayBoard
        {
            get
            {
                return this.m_Board;
            }
        }

        public List<int> GetRandomizedIndeciesByPC()
        {
            List<List<int>> listOfFreeIndecies = this.m_Board.GetFreeIndecies();
            List<int> listOf2RandomizedIndecies = m_PcPlayer.RandFreeIndex(listOfFreeIndecies);

            return listOf2RandomizedIndecies;
        }

        public bool CheckBoardRange(int i_InputNumber)
        {
            bool rangeStatus = false;
            if (i_InputNumber >= 0 && i_InputNumber < this.m_Board.NumOfRows)
            {
                rangeStatus = true;
            }

            return rangeStatus;
        }

        public bool SetBoardValues(int i_Row, int i_Column, char i_Symbol)
        {
            return m_Board.SetValueByIndex(i_Row, i_Column, i_Symbol);
        }

        public bool BoardFull()
        {
            return this.m_Board.IsFull();
        }

        public bool CheckIfLose(char i_SymbolToCheck)
        {
            return this.m_Board.CheckIfMatch(i_SymbolToCheck);
        }

        public void InitializeBoard()
        {
            this.m_Board.InitializeBoard();
        }
    }
}
