using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex02_Othelo_UI
{

    // CSS-016 (-3) Bad class name - The name of classes derived from Form should start with Form.
    public partial class GameSettingsForm : Form
    {
        private int m_BoardSize = 6;
        private bool m_IsSecondPlayerHuman;

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public bool IsSecondPlayerHuman
        {
            get { return m_IsSecondPlayerHuman; }
        }

        private void setBoardSizeButton_Click(object sender, EventArgs e)
        {
            if (m_BoardSize != 12)
            {
                if (m_BoardSize == 10)
                {
                    SetBoardSizeButton.Text = string.Format("Board Size: {0}x{0} (click to reset to 6x6)", m_BoardSize + 2);
                }
                else
                {
                    SetBoardSizeButton.Text = string.Format("Board Size: {0}x{0} (click to increase)", m_BoardSize + 2);
                }

                m_BoardSize += 2;
            }
            else
            {
                m_BoardSize = 6;
                SetBoardSizeButton.Text = string.Format("Board Size: {0}x{0} (click to increase)", m_BoardSize);
            }
        }

        private void computerPlayerButton_Click(object sender, EventArgs e)
        {
            m_IsSecondPlayerHuman = false;
            startGame();
        }

        private void startGame()
        {
            this.Hide();
        }

        private void humanPlayerButton_Click(object sender, EventArgs e)
        {
            m_IsSecondPlayerHuman = true;
            startGame();
        }

        private void gameSettingsForm_Load(object sender, EventArgs e)
        {
        }

        private void gameSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
