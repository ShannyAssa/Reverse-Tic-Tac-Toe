using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;
using System.Reflection;


namespace Ex05.GameUI
{
    public partial class FormGame : Form
    {
        private readonly int r_BoardSize;
        private readonly Game r_Game;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private const int k_SymbolSize = 60;
        private const int k_GameOverviewHeight = 100;
        private const int k_GameOverviewWidth = 400;
        private const int k_MarginValue = 20;
        private const int k_ComponentsSpacing = 15;
        private const string k_EndGame = "End Game";

        public FormGame(FormSettings i_FormSettings)
        {
            r_BoardSize = i_FormSettings.BoardSize;
            r_Player1Name = i_FormSettings.Player1Name;
            r_Player2Name = i_FormSettings.Player2Name;

            if (i_FormSettings.IsGameAgainstComputer)
            {
                r_Game = new Game(r_BoardSize, ePlayerType.SmartComputer);
            }
            else
            {
                r_Game = new Game(r_BoardSize, ePlayerType.Human);
            }

            // make game listen to the executed moves
            InitializeComponent();
            manuallyCompleteInitializingComponent();
        }

        private void manuallyCompleteInitializingComponent()
        {
            updateGameOverviewDetails();
            setTableLayoutPanelBoardStyle();
            setFormDetails();
        }

        private void setFormDetails()
        {
            groupBoxGameOverview.Size = new Size(k_GameOverviewWidth, k_GameOverviewHeight);
            int formWidth = Math.Max(tableLayoutPanelBoard.Width, groupBoxGameOverview.Width) + k_MarginValue * 2;
            int formHeight = tableLayoutPanelBoard.Height + groupBoxGameOverview.Height + k_MarginValue * 3 + k_ComponentsSpacing;
            this.Size = new Size(formWidth, formHeight);
            tableLayoutPanelBoard.Location = new Point((this.Width - tableLayoutPanelBoard.Width) / 2, k_MarginValue);
            groupBoxGameOverview.Location = new Point((this.Width - groupBoxGameOverview.Width) / 2, 
                tableLayoutPanelBoard.Bottom + k_ComponentsSpacing);
        }

        private void setTableLayoutPanelBoardStyle()
        {
            tableLayoutPanelBoard.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelBoard.ColumnCount = r_BoardSize;
            tableLayoutPanelBoard.RowCount = r_BoardSize;
            tableLayoutPanelBoard.Size = new Size(k_SymbolSize * r_BoardSize, k_SymbolSize * r_BoardSize);
        }

        private void updateGameOverviewDetails()
        {
            string currentPlayerTurn;

            if(r_Game.Turn == 1)
            {
                currentPlayerTurn = r_Player1Name;
            }
            else
            {
                currentPlayerTurn = r_Player2Name;
            }
            
            labelPlayerTurn.Text = string.Format(MessageContainer.GetMessageById(eUIMessages.Turns), currentPlayerTurn);
            labelPlayersScore.Text = string.Format(MessageContainer.GetMessageById(eUIMessages.GameScore), r_Player1Name, 
                r_Game.GetPlayerScore(eSymbol.X), r_Player2Name, r_Game.GetPlayerScore(eSymbol.O));
            updateGameOverviewStyle();
        }

        private void updateGameOverviewStyle()
        {
            labelPlayerTurn.Location = new Point((groupBoxGameOverview.Width - labelPlayerTurn.Width) / 2 
                + 2 * k_MarginValue, k_MarginValue);
            labelPlayersScore.Location = new Point((groupBoxGameOverview.Width - labelPlayersScore.Width) / 2 
                + 2 * k_MarginValue, k_ComponentsSpacing + labelPlayerTurn.Bottom);
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    Button buttonCell = new Button();
                    buttonCell.Size = new Size(50, 50);
                    tableLayoutPanelBoard.Controls.Add(buttonCell, col, row);
                    buttonCell.Click += new EventHandler(this.buttonCell_Click);
                }

                tableLayoutPanelBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, k_SymbolSize));
                tableLayoutPanelBoard.RowStyles.Add(new RowStyle(SizeType.Absolute, k_SymbolSize));
            }
        }

        private void buttonCell_Click(object sender, EventArgs e)
        {
            Button theButton = sender as Button;
            string gameOverMessage;

            executeMove(theButton);
            if(IsGameEnded(out gameOverMessage))
            {
                handleEndingGame(gameOverMessage);
            }
            else if(r_Game.IsCurrentPlayerComputer())
            {
                executeComputerMove();
                if (IsGameEnded(out gameOverMessage))
                {
                    handleEndingGame(gameOverMessage);
                }
            }

        }

        private void executeComputerMove()
        {
            r_Game.ExecuteComputerTurn();
            Cell lastMove = r_Game.LastMove;
            Button theClickedButton = tableLayoutPanelBoard.GetControlFromPosition(lastMove.Column, lastMove.Row) as Button;
            updateCellValueOnBoard(theClickedButton, lastMove.Row, lastMove.Column);
            updateGameOverviewDetails();
        }

        private void handleEndingGame(string i_GameOverMessage)
        {
            StringBuilder message = new StringBuilder();
            DialogResult playAgainDialog;

            message.AppendFormat("{0}{1}{2}", i_GameOverMessage, Environment.NewLine, 
                MessageContainer.GetMessageById(eUIMessages.PlayAgain));
            playAgainDialog = MessageBox.Show(message.ToString(), k_EndGame, MessageBoxButtons.OKCancel);
            if (playAgainDialog == DialogResult.Cancel)
            {
                this.Close();
            }
            else
            {
                r_Game.ReinitializeGame();
                ReinitializeUIBoard();
            }
        }

        private void ReinitializeUIBoard()
        {

            foreach (Control button in tableLayoutPanelBoard.Controls)
            {
                (button as Button).Image = null;
                (button as Button).Enabled = true;
            }
            
            updateGameOverviewDetails();
        }

        private bool IsGameEnded(out string o_GameOverMessage)
        {
            int winner;
            string winnerName;
            o_GameOverMessage = string.Empty;
            bool isGameEnded = false;

            if (r_Game.IsSomeoneWon())
            {
                isGameEnded = true;
                winner = r_Game.GetWinner();
                r_Game.IncreasePlayerScore(winner);
                if (winner == 1)
                {
                    winnerName = r_Player1Name;
                }
                else
                {
                    winnerName = r_Player2Name;
                }

                o_GameOverMessage = string.Format(MessageContainer.GetMessageById(eUIMessages.WinnerMessage), winnerName);
            }
            else if(r_Game.IsTie())
            {
                isGameEnded = true;
                o_GameOverMessage = MessageContainer.GetMessageById(eUIMessages.TieMessage);
            }

            return isGameEnded;
        }
        
        private void executeMove(Button i_TheClickedButton)
        {
            int buttonRow = tableLayoutPanelBoard.GetCellPosition(i_TheClickedButton).Row;
            int buttonCol = tableLayoutPanelBoard.GetCellPosition(i_TheClickedButton).Column;

            r_Game.ExecuteHumanTurn(buttonRow, buttonCol);
            updateCellValueOnBoard(i_TheClickedButton, buttonRow, buttonCol);
            updateGameOverviewDetails();
        }

        private void updateCellValueOnBoard(Button i_TheClickedButton, int i_Row, int i_Col)
        {
            eSymbol cellSymbol = r_Game.GetCellValue(i_Row, i_Col);

            if (cellSymbol.Equals(eSymbol.X))
            {
                i_TheClickedButton.Image = Properties.Resources.X;
            }
            else
            {
                i_TheClickedButton.Image = Properties.Resources.O;
            }

            i_TheClickedButton.BackgroundImageLayout = ImageLayout.Center;
            i_TheClickedButton.Enabled = false;
        }
    }
}
