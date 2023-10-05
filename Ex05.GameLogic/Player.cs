using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.GameLogic
{
    public class Player
    {
        private int m_Score;
        private readonly ePlayerType r_PlayerType;
        private readonly eSymbol r_Symbol;
        public Player(ePlayerType i_PlayerType, eSymbol i_Symbol)
        {
            m_Score = 0;
            r_PlayerType = i_PlayerType;
            r_Symbol = i_Symbol;
        }

        public void IncreaseScore()
        {
            m_Score++;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

        }

        public eSymbol Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public ePlayerType Type
        {
            get
            {
                return r_PlayerType;
            }
        }

        public int ExecuteComputerMovement(int i_AvailableCellsNumber)
        {
            return new Random().Next(i_AvailableCellsNumber);
        }
    }
}
