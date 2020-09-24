using System;
using System.Drawing;
using System.Windows.Forms;
using Ex02_Othelo_Logic;

namespace Ex02_Othelo_UI
{

    // $G$ CSS-016 (-3) Bad class name - The name of classes derived from Form should start with Form.
    public partial class GameMainForm : Form
    {
        // $G$ DSN-999 (-3) This array should be readonly.
        private PictureBox[,] m_TilesMatrix;
        // $G$ DSN-999 (-3) This kind of field should be readonly.
        private GameLogic m_GameToPlay;
        private Image redCoinImage;
        private Image yellowCoinImage;

        public GameMainForm()
        {
            GameSettingsForm settingsForm = new GameSettingsForm();
            settingsForm.ShowDialog();
            InitializeComponent();
            m_GameToPlay = new GameLogic(settingsForm.BoardSize, settingsForm.IsSecondPlayerHuman);
            generateTilesMatrix(settingsForm.BoardSize);
            redCoinImage = new Bitmap(Ex02_Othelo_UI.Properties.Resources.CoinRed);
            yellowCoinImage = new Bitmap(Ex02_Othelo_UI.Properties.Resources.CoinYellow);
            setTilesinTableLayout();
            updateTilesMatrix();
        }

        private void generateTilesMatrix(int i_TilesMatrixSize)
        {
            m_TilesMatrix = new PictureBox[i_TilesMatrixSize, i_TilesMatrixSize];

            for (int i = 0; i < i_TilesMatrixSize; i++)
            {
                for (int j = 0; j < i_TilesMatrixSize; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = string.Format("pictureBox{0}{1}", i, j);
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Size = new Size(35, 35);
                    pictureBox.BackColor = Color.LightGray;
                    pictureBox.Enabled = false;
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.MouseEnter += pictureBox_MouseEnter;
                    pictureBox.MouseLeave += pictureBox_MouseLeave;
                    pictureBox.Click += pictureBox_Click;
                    m_TilesMatrix[i, j] = pictureBox;
                }
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Ex02_Othelo_Logic.Point chosenTile = getPictureBoxCoordinates((PictureBox)sender);
            m_GameToPlay.PickTile(chosenTile);
            (sender as PictureBox).BackColor = Color.Blue;
            if (!m_GameToPlay.CurrentPlayer.HumanPlayer)
            {
                MessageBox.Show("Computer chose the tile marked in blue");
                System.Threading.Thread.Sleep(500);
            }

            switchPlayer();
            playNextTurn();
        }

        private void switchPlayer()
        {
            m_GameToPlay.SwitchCurrentPlayer();
            if (m_GameToPlay.CurrentPlayer.Equals(m_GameToPlay.FirstPlayer))
            {
                this.Text = "Othello - Red's Turn";
            }
            else
            {
                this.Text = "Othello - Yellow's Turn";
            }
        }

        private Ex02_Othelo_Logic.Point getPictureBoxCoordinates(PictureBox i_PictureBoxTile)
        {
            int gameDimension = m_TilesMatrix.GetLength(0);

            Ex02_Othelo_Logic.Point pictureBoxPoint = new Ex02_Othelo_Logic.Point();
            for (int i = 0; i < gameDimension; i++)
            {
                for (int j = 0; j < gameDimension; j++)
                {
                    if (m_TilesMatrix[i, j].Equals(i_PictureBoxTile))
                    {
                        pictureBoxPoint.XCoord = i;
                        pictureBoxPoint.YCoord = j;
                    }
                }
            }

            return pictureBoxPoint;
        }

        private void gameMainForm_Load(object sender, EventArgs e)
        {
            setFormSizeAndPosition();
            this.Text = "Othello - Red's Turn";
            playNextTurn();
        }

        private void setFormSizeAndPosition()
        {
            int gameFormWidth;
            int gameFormHeight;
            int boardDimension;
            int pictureBoxSize;
            int pictureBoxMargin;
            int tableLayoutSize;

            boardDimension = m_TilesMatrix.GetLength(0);
            pictureBoxSize = m_TilesMatrix[0, 0].Size.Height;
            pictureBoxMargin = m_TilesMatrix[0, 0].Margin.Left * 2;
            tableLayoutSize = boardDimension * (pictureBoxSize + pictureBoxMargin);
            this.TilesTableLayout.Size = new Size(tableLayoutSize, tableLayoutSize);
            gameFormWidth = tableLayoutSize + pictureBoxSize;
            gameFormHeight = this.TilesTableLayout.Height + +pictureBoxSize + pictureBoxMargin + 15;
            this.Size = new Size(gameFormWidth, gameFormHeight);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(600, 100);
        }

        private void playNextTurn()
        {
            updateTilesMatrix();
            showPlayerAvailableMoves();
            if (!m_GameToPlay.CurrentPlayer.HumanPlayer)  
            {
                Ex02_Othelo_Logic.Point computerTile = m_GameToPlay.GenerateComputerTile();
                pictureBox_Click(m_TilesMatrix[computerTile.XCoord, computerTile.YCoord], null);
            }
        }

        private void showPlayerAvailableMoves()
        {
            m_GameToPlay.buildNextMovesList();
            if (m_GameToPlay.NextMovesList.Count == 0)    
            {
                bool isGameOver = m_GameToPlay.AreNoTilesAvailable();
                if (!isGameOver)       
                {
                    MessageBox.Show("Current player doesn't have any valid moves. Turn is being skipped...");
                    switchPlayer();
                    showPlayerAvailableMoves();
                }
                else
                {
                    showGameOverDialog();
                }
            }

            foreach (NextMoves nextMove in m_GameToPlay.NextMovesList)
            {
                Ex02_Othelo_Logic.Point validTile = nextMove.NewCoinInBoard;
                m_TilesMatrix[validTile.XCoord, validTile.YCoord].BackColor = Color.LimeGreen;
                m_TilesMatrix[validTile.XCoord, validTile.YCoord].Enabled = true;
            }
        }

        private void showGameOverDialog()
        {
            DialogResult gameOverDR = MessageBox.Show(m_GameToPlay.CalculateScores(), "Othello", MessageBoxButtons.YesNo);

            switch (gameOverDR)
            {
                case DialogResult.Yes:
                    restartGame();
                    break;
                case DialogResult.No:
                    Environment.Exit(1);
                    break;
            }
        }

        private void restartGame()
        {
            m_GameToPlay.RestartGame();
            updateTilesMatrix();
            gameMainForm_Load(this, null);
        }

        private void setTilesinTableLayout()
        {
            int gameDimension = m_TilesMatrix.GetLength(0);

            this.TilesTableLayout.Controls.Clear();
            this.TilesTableLayout.ColumnCount = gameDimension;
            this.TilesTableLayout.RowCount = gameDimension;
            this.TilesTableLayout.ColumnStyles.Clear();
            this.TilesTableLayout.RowStyles.Clear();
            for (int i = 0; i < gameDimension; i++)
            {
                for (int j = 0; j < gameDimension; j++)
                {
                    this.TilesTableLayout.Controls.Add(m_TilesMatrix[i, j], j, i);
                }
            }

            TilesTableLayout.Visible = true;
        }

        private void updateTilesMatrix()
        {
            Board gameLogicBoard = m_GameToPlay.Board;

            for (int i = 0; i < gameLogicBoard.Dimension; i++)
            {
                for (int j = 0; j < gameLogicBoard.Dimension; j++)
                {
                    if (gameLogicBoard.BoardMatrix[i, j] == m_GameToPlay.FirstPlayer.PlayerCoin)
                    {
                        m_TilesMatrix[i, j].Image = redCoinImage;
                    }
                    else if (gameLogicBoard.BoardMatrix[i, j] == m_GameToPlay.SecondPlayer.PlayerCoin)
                    {
                        m_TilesMatrix[i, j].Image = yellowCoinImage;
                    }
                    else
                    {
                        m_TilesMatrix[i, j].Image = null;
                    }

                    m_TilesMatrix[i, j].BackColor = Color.LightGray;
                    m_TilesMatrix[i, j].Enabled = false;
                }
            }
        }

        private void GameMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
