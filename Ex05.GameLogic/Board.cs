using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.GameLogic
{
    public class Board
    {
        private Cell[,] m_Board;
        private readonly int r_Size;
        private List<Cell> m_AvailableCells;
        private const int k_MinSizeOfBoard = 3;
        private const int k_MaxSizeOfBoard = 9;
        public Board(int i_BoardSize)
        {
            r_Size = i_BoardSize;
            m_Board = new Cell[r_Size, r_Size];
            m_AvailableCells = new List<Cell>(i_BoardSize);

            for (int row = 0; row < r_Size; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    m_Board[row, col] = new Cell(row, col);
                    m_AvailableCells.Add(m_Board[row, col]);
                }
            }
        }

        public void ReinitializeBoard()
        {
            m_AvailableCells.Clear();
            for (int row = 0; row < r_Size; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    m_Board[row, col].Symbol = eSymbol.Empty;
                    m_AvailableCells.Add(m_Board[row, col]);
                }
            }
        }

        public eSymbol GetCellValue(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column].Symbol;
        }

        public void SetCellValue(int i_Row, int i_Column, eSymbol i_Symbol)
        {
            Cell selectedCell = m_Board[i_Row, i_Column];

            selectedCell.Symbol = i_Symbol;
            m_AvailableCells.Remove(selectedCell);
        }

        public Cell GetCellByCoords(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }

        public Cell GetCellByCellNumber(int i_CellNumber)
        {
            Cell selectedCell = m_AvailableCells[i_CellNumber];

            return selectedCell;
        }

        public void SetCellValueByCellNumber(int i_CellNumber, eSymbol i_Symbol)
        {
            Cell selectedCell = m_AvailableCells[i_CellNumber];

            selectedCell.Symbol = i_Symbol;
            m_AvailableCells.Remove(selectedCell);
        }

        public bool IsCellEmpty(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column].Symbol == eSymbol.Empty;
        }

        public bool IsBoardFull()
        {
            return m_AvailableCells.Count == 0;
        }

        public bool IsSymbolSequenceCreated(int i_Row, int i_Col, eSymbol i_Symbol)
        {
            bool hasRowSequence = true;
            bool hasColSequence = true;
            bool hasDiagonalSequence = true;
            bool hasSecondDiagonalSequence = true;

            for (int i = 0; i < r_Size; i++)
            {
                if (m_Board[i_Row, i].Symbol != i_Symbol)
                {
                    hasRowSequence = false;
                }

                if (m_Board[i, i_Col].Symbol != i_Symbol)
                {
                    hasColSequence = false;
                }

                if (m_Board[i, i].Symbol != i_Symbol)
                {
                    hasDiagonalSequence = false;
                }

                if (m_Board[i, r_Size - i - 1].Symbol != i_Symbol)
                {
                    hasSecondDiagonalSequence = false;
                }
            }

            return (hasRowSequence || hasColSequence || hasDiagonalSequence || hasSecondDiagonalSequence);
        }

        public void SetPotentialSymbolSequence(int i_Row, int i_Col, eSymbol i_Symbol, eCellScore i_Score)
        {
            int symbolCountInRow = 0;
            int symbolCountInCol = 0;
            int symbolCountInDiagonal = 0;
            int symbolCountInSecondDiagonal = 0;
            bool hasPotentialRowSequence = true;
            bool hasPotentialColSequence = true;
            bool hasPotentialDiagonalSequence = true;
            bool hasPotentialSecondDiagonalSequence = true;

            for (int i = 0; i < r_Size; i++)
            {
                if (m_Board[i_Row, i].Symbol == i_Symbol)
                {
                    symbolCountInRow++;
                }
                else if (m_Board[i_Row, i].Symbol != eSymbol.Empty)
                {
                    hasPotentialRowSequence = false;
                }

                if (m_Board[i, i_Col].Symbol == i_Symbol)
                {
                    symbolCountInCol++;
                }
                else if (m_Board[i, i_Col].Symbol != eSymbol.Empty)
                {
                    hasPotentialColSequence = false;
                }

                if (m_Board[i, i].Symbol == i_Symbol)
                {
                    symbolCountInDiagonal++;
                }
                else if (m_Board[i, i].Symbol != eSymbol.Empty)
                {
                    hasPotentialDiagonalSequence = false;
                }

                if (m_Board[i, r_Size - i - 1].Symbol == i_Symbol)
                {
                    symbolCountInSecondDiagonal++;
                }
                else if (m_Board[i, i].Symbol != eSymbol.Empty)
                {
                    hasPotentialSecondDiagonalSequence = false;
                }
            }

            SetCellsScore(hasPotentialRowSequence, hasPotentialColSequence, hasPotentialDiagonalSequence, hasPotentialSecondDiagonalSequence,
                symbolCountInRow, symbolCountInCol, symbolCountInDiagonal, symbolCountInSecondDiagonal, i_Row, i_Col, i_Score);
        }

        private void SetCellsScore(bool i_HasPotentialRowSequence, bool i_HasPotentialColSequence, bool i_HasPotentialDiagonalSequence,
            bool i_HasPotentialSecondDiagonalSequence, int i_SymbolCountInRow, int i_SymbolCountInCol, int i_SymbolCountInDiagonal,
            int i_SymbolCountInSecondDiagonal, int i_Row, int i_Col, eCellScore i_Score)
        {
            if (i_HasPotentialRowSequence && i_SymbolCountInRow >= r_Size / 2)
            {
                for (int i = 0; i < r_Size; i++)
                {
                    if (m_Board[i_Row, i].Symbol == eSymbol.Empty)
                    {
                        m_Board[i_Row, i].Score = i_Score;
                    }
                }
            }

            if (i_HasPotentialColSequence && i_SymbolCountInCol >= r_Size / 2)
            {
                for (int i = 0; i < r_Size; i++)
                {
                    if (m_Board[i, i_Col].Symbol == eSymbol.Empty)
                    {
                        m_Board[i, i_Col].Score = i_Score;
                    }
                }
            }

            if (i_HasPotentialDiagonalSequence && i_SymbolCountInDiagonal >= r_Size / 2)
            {
                for (int i = 0; i < r_Size; i++)
                {
                    if (m_Board[i, i].Symbol == eSymbol.Empty)
                    {
                        m_Board[i, i].Score = i_Score;
                    }
                }
            }

            if (i_HasPotentialSecondDiagonalSequence && i_SymbolCountInSecondDiagonal >= r_Size / 2)
            {
                for (int i = 0; i < r_Size; i++)
                {
                    if (m_Board[i, r_Size - i - 1].Symbol == eSymbol.Empty)
                    {
                        m_Board[i, r_Size - i - 1].Score = i_Score;
                    }
                }
            }
        }

        public void SetCellAvailability()
        {
            for (int row = 0; row < r_Size; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    if (m_Board[row, col].Symbol == eSymbol.Empty)
                    {
                        m_Board[row, col].Score = eCellScore.CellAvailable;
                    }
                    else
                    {
                        m_Board[row, col].Score = eCellScore.CellNotAvailable;
                    }
                }
            }
        }

        public int GetMaxScoreCellIndex()
        {
            eCellScore maxScore = eCellScore.CellNotAvailable;

            int maxScoreCellIndex = 0;
            for (int i = 0; i < m_AvailableCells.Count; i++)
            {
                if (m_AvailableCells[i].Score > maxScore)
                {
                    maxScore = m_AvailableCells[i].Score;
                    maxScoreCellIndex = i;
                }
            }

            return maxScoreCellIndex;
        }

        public int AvailableCellsCount
        {
            get
            {
                return m_AvailableCells.Count;
            }
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        public eCellScore GetCellCellScore(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col].Score;
        }

        public static int MinSizeOfBoard
        {
            get
            {
                return k_MinSizeOfBoard;
            }
        }

        public static int MaxSizeOfBoard
        {
            get
            {
                return k_MaxSizeOfBoard;
            }
        }
    }
}
