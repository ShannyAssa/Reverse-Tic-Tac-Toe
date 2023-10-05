
namespace Ex05.GameUI
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.groupBoxGameOverview = new System.Windows.Forms.GroupBox();
            this.labelPlayersScore = new System.Windows.Forms.Label();
            this.labelPlayerTurn = new System.Windows.Forms.Label();
            this.tableLayoutPanelBoard = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxGameOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGameOverview
            // 
            this.groupBoxGameOverview.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxGameOverview.Controls.Add(this.labelPlayersScore);
            this.groupBoxGameOverview.Controls.Add(this.labelPlayerTurn);
            this.groupBoxGameOverview.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGameOverview.Location = new System.Drawing.Point(12, 281);
            this.groupBoxGameOverview.Name = "groupBoxGameOverview";
            this.groupBoxGameOverview.Size = new System.Drawing.Size(438, 98);
            this.groupBoxGameOverview.TabIndex = 1;
            this.groupBoxGameOverview.TabStop = false;
            this.groupBoxGameOverview.Text = "Game Overview";
            // 
            // labelPlayersScore
            // 
            this.labelPlayersScore.AutoSize = true;
            this.labelPlayersScore.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayersScore.Location = new System.Drawing.Point(14, 68);
            this.labelPlayersScore.Name = "labelPlayersScore";
            this.labelPlayersScore.Size = new System.Drawing.Size(72, 24);
            this.labelPlayersScore.TabIndex = 1;
            this.labelPlayersScore.Text = "label2";
            // 
            // labelPlayerTurn
            // 
            this.labelPlayerTurn.AutoSize = true;
            this.labelPlayerTurn.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerTurn.Location = new System.Drawing.Point(161, 32);
            this.labelPlayerTurn.Name = "labelPlayerTurn";
            this.labelPlayerTurn.Size = new System.Drawing.Size(80, 27);
            this.labelPlayerTurn.TabIndex = 0;
            this.labelPlayerTurn.Text = "label1";
            // 
            // tableLayoutPanelBoard
            // 
            this.tableLayoutPanelBoard.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelBoard.ColumnCount = 2;
            this.tableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.Location = new System.Drawing.Point(30, 24);
            this.tableLayoutPanelBoard.Name = "tableLayoutPanelBoard";
            this.tableLayoutPanelBoard.RowCount = 2;
            this.tableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBoard.Size = new System.Drawing.Size(409, 251);
            this.tableLayoutPanelBoard.TabIndex = 2;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ex05.GameUI.Properties.Resources.Settings_Background;
            this.ClientSize = new System.Drawing.Size(462, 392);
            this.Controls.Add(this.tableLayoutPanelBoard);
            this.Controls.Add(this.groupBoxGameOverview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REVERSE Tic Tac Toe";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.groupBoxGameOverview.ResumeLayout(false);
            this.groupBoxGameOverview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxGameOverview;
        private System.Windows.Forms.Label labelPlayersScore;
        private System.Windows.Forms.Label labelPlayerTurn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBoard;
    }
}