using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
    public partial class FormSettings : Form
    {
        private const string k_ComputerLabel = "[Computer]";
        private const string k_Player1Label = "Player1";
        private const string k_Player2Label = "Player2";
        private const string k_ComputerAsPlayer2 = "Computer";


        public FormSettings()
        {
            InitializeComponent();
            modifyNumericUpDownComponentsAccordingToBoardSize();
        }

        private void modifyNumericUpDownComponentsAccordingToBoardSize()
        {
            numericUpDownCols.Minimum = Board.MinSizeOfBoard;
            numericUpDownRows.Minimum = Board.MinSizeOfBoard;
            numericUpDownCols.Maximum = Board.MaxSizeOfBoard;
            numericUpDownRows.Maximum = Board.MaxSizeOfBoard;
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }

        public bool IsGameAgainstComputer
        {
            get
            {
                return !checkBoxPlayer2.Checked;
            }
        }

        public int BoardSize
        {
            get
            {
                return ((int)numericUpDownRows.Value);
            }
        }

        public string Player1Name
        {
            get
            {
                return textBoxPlayer1Name.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                return textBoxPlayer2Name.Text;
            }
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPlayer2.Checked)
            {
                textBoxPlayer2Name.Enabled = true;
                textBoxPlayer2Name.Text = string.Empty;
            }
            else
            {
                textBoxPlayer2Name.Enabled = false;
                textBoxPlayer2Name.Text = k_ComputerLabel;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if(textBoxPlayer1Name.Text == string.Empty)
            {
                textBoxPlayer1Name.Text = k_Player1Label;
            }

            if (textBoxPlayer2Name.Text == string.Empty)
            {
                textBoxPlayer2Name.Text = k_Player2Label;
            }
            else if(textBoxPlayer2Name.Text == k_ComputerLabel)
            {
                textBoxPlayer2Name.Text = k_ComputerAsPlayer2;
            }    

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
