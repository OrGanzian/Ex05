using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex02;

namespace Ex02
{
    public class Player
    {
        private int m_Score = 0;

        // $G$ CSS-999 (-3) this member should be readonly
        private string m_PlayerName;
        private char m_Symbol;
        private ePlayerType m_PlayerType;

        public Player(string i_PlayerName, char i_Symbol, ePlayerType i_PlayerType)
        {
            this.m_PlayerName = i_PlayerName;
            this.m_Symbol = i_Symbol;
            this.m_PlayerType = i_PlayerType;
        }

        public ePlayerType PlayerType
        {
            get
            {
                return m_PlayerType;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        public char Symbol
        {
            get
            {
                return this.m_Symbol;
            }
        }

        public string Name
        {
            get
            {
                return this.m_PlayerName;
            }
        }

        public void AddScore()
        {
            m_Score++;
        }
    }
}
