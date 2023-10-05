using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.GameLogic
{
    public class Cell
    {
        private readonly Coords r_Position;
        private eSymbol m_Symbol;
        private eCellScore m_Score;
        public Cell(int i_Row, int i_Column)
        {
            r_Position.Row = i_Row;
            r_Position.Column = i_Column;
            m_Symbol = eSymbol.Empty;
            m_Score = eCellScore.CellAvailable;
        }

        public eSymbol Symbol
        {
            get
            {
                return m_Symbol;
            }

            set
            {
                m_Symbol = value;
            }
        }

        public eCellScore Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public int Row
        {
            get
            {
                return r_Position.Row;
            }
        }

        public int Column
        {
            get
            {
                return r_Position.Column;
            }
        }
    }
}
