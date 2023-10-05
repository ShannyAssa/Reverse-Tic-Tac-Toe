using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.GameLogic
{
    public class Game
    {
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private const int k_Player1Turn = 1;
        private const int k_Player2Turn = 2;
        private int m_CurrentTurn;
        private Cell m_LastMove;
        public Game(int i_BoardSize, ePlayerType i_PlayerType2)
        {
            m_Board = new Board(i_BoardSize);
            m_Player1 = new Player(ePlayerType.Human, eSymbol.X);
            m_Player2 = new Player(i_PlayerType2, eSymbol.O);
            m_CurrentTurn = k_Player1Turn;
            m_LastMove = null;
        }

        public eSymbol GetCellValue(int i_Row, int i_Column)
        {
            return m_Board.GetCellValue(i_Row, i_Column);
        }

        public void IncreasePlayerScore(int i_Player)
        {
            if (k_Player1Turn == i_Player)
            {
                m_Player1.IncreaseScore();
            }
            else
            {
                m_Player2.IncreaseScore();
            }
        }

        public int GetPlayerScore(eSymbol i_PlayerSymbol)
        {
            int playerScore;

            if (m_Player1.Symbol == i_PlayerSymbol)
            {
                playerScore = m_Player1.Score;
            }
            else
            {
                playerScore = m_Player2.Score;
            }

            return playerScore;
        }

        public bool IsCurrentPlayerComputer()
        {
            return (m_CurrentTurn == k_Player2Turn) && ((m_Player2.Type.Equals(ePlayerType.Computer)) || (m_Player2.Type.Equals(ePlayerType.SmartComputer)));
        }

        public void ExecuteComputerTurn()
        {
            if (m_Player2.Type.Equals(ePlayerType.Computer))
            {
                int chosenCell = m_Player2.ExecuteComputerMovement(m_Board.AvailableCellsCount);
                updateComputerMove(chosenCell);
            }
            else
            {
                executeSmartComputerTurn();
            }

        }
        private void executeSmartComputerTurn()
        {
            m_Board.SetCellAvailability();
            for (int i = 0; i < m_Board.Size; i++)
            {
                m_Board.SetPotentialSymbolSequence(i, i, eSymbol.X, eCellScore.CreateSequenceOpponent);
                m_Board.SetPotentialSymbolSequence(i, i, eSymbol.O, eCellScore.CreateSequenceComputer);
            }

            int chosenCell = m_Board.GetMaxScoreCellIndex();
            updateComputerMove(chosenCell);
        }

        private void updateComputerMove(int i_ChosenCell)
        {
            m_LastMove = m_Board.GetCellByCellNumber(i_ChosenCell);
            m_Board.SetCellValueByCellNumber(i_ChosenCell, m_Player2.Symbol);
            m_CurrentTurn = k_Player1Turn;
        }

        public void ExecuteHumanTurn(int i_Row, int i_Col)
        {
            m_LastMove = m_Board.GetCellByCoords(i_Row, i_Col);
            if (m_CurrentTurn == k_Player1Turn)
            {
                m_Board.SetCellValue(i_Row, i_Col, m_Player1.Symbol);
                m_CurrentTurn = k_Player2Turn;
            }
            else
            {
                m_Board.SetCellValue(i_Row, i_Col, m_Player2.Symbol);
                m_CurrentTurn = k_Player1Turn;
            }
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            return m_Board.IsCellEmpty(i_Row, i_Col);
        }

        public bool IsSomeoneWon()
        {
            return m_LastMove != null && m_Board.IsSymbolSequenceCreated(m_LastMove.Row, m_LastMove.Column, m_LastMove.Symbol);
        }

        public bool IsTie()
        {
            return m_Board.IsBoardFull();
        }

        public int GetWinner()
        {
            return m_CurrentTurn;
        }

        public void ReinitializeGame()
        {
            m_Board.ReinitializeBoard();
            m_CurrentTurn = k_Player1Turn;
            m_LastMove = null;
        }

        public int Turn
        {
            get
            {
                return m_CurrentTurn;
            }

            set
            {
                m_CurrentTurn = value;
            }
        }

        public int Player1Turn
        {
            get
            {
                return k_Player1Turn;
            }
        }

        public int Player2Turn
        {
            get
            {
                return k_Player2Turn;
            }
        }

        public Cell LastMove
        {
            get
            {
                return m_LastMove;
            }
        }
    }
}
