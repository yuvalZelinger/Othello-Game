using System;
using System.Collections.Generic;

namespace Ex02_Othelo_Logic
{
    public class GameLogic
    {
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Board m_GameBoard;
        private Player m_CurrentPlayer;
        // $G$ DSN-999 (-3) This array should be readonly.
        private List<NextMoves> m_NextMovesList;
        private bool m_LastTurnWasSkipped;
        private int m_RoundNumber;

        public GameLogic(int i_BoardDimension, bool i_IsSecondPlayerHuman)
        {
            m_RoundNumber = 1;
            const bool v_PlayerIsHuman = true;

            r_Player1 = new Player("FirstPlayer", 'X', v_PlayerIsHuman);
            r_Player2 = new Player("SecondPlayer", 'O', i_IsSecondPlayerHuman);

            m_GameBoard = new Board(i_BoardDimension, r_Player1, r_Player2);
            m_CurrentPlayer = r_Player1;
            m_NextMovesList = new List<NextMoves>();
            m_LastTurnWasSkipped = false;
        }

        public bool AreNoTilesAvailable()
        {
            bool endGame = false;

            if (!isBoardFull())
            {
                if (m_LastTurnWasSkipped)
                {
                    endGame = true;
                }
                else
                {
                    m_LastTurnWasSkipped = true;
                }
            }
            else
            {
                endGame = true;
            }

            return endGame;
        }

        private bool isBoardFull()
        {
            bool isFull = true;

            for (int i = 0; i < m_GameBoard.Dimension; i++)
            {
                for (int j = 0; j < m_GameBoard.Dimension; j++)
                {
                    if (!m_GameBoard.BoardMatrix[i, j].Equals(FirstPlayer.PlayerCoin) && !m_GameBoard.BoardMatrix[i, j].Equals(SecondPlayer.PlayerCoin))
                    {
                        isFull = false;
                    }
                }
            }

            return isFull;
        }

        public string CalculateScores()
        {
            string scoresString;
            int player1Score = 0;
            int player2Score = 0;

            for (int i = 0; i < m_GameBoard.Dimension; i++)
            {
                for (int j = 0; j < m_GameBoard.Dimension; j++)
                {
                    if (m_GameBoard.BoardMatrix[i, j] == r_Player1.PlayerCoin)
                    {
                        player1Score++;
                    }

                    if (m_GameBoard.BoardMatrix[i, j] == r_Player2.PlayerCoin)
                    {
                        player2Score++;
                    }
                }
            }

            if (player1Score > player2Score)
            {
                r_Player1.VictoriesNumber++;
                scoresString = string.Format("Red Won! ({1}/{2})({3}/{4}) {0} Would you like another round?", Environment.NewLine, player1Score, player2Score, r_Player1.VictoriesNumber, m_RoundNumber);
            }
            else if (player1Score < player2Score)
            {
                r_Player2.VictoriesNumber++;
                scoresString = string.Format("Yellow Won! ({1}/{2})({3}/{4}) {0} Would you like another round?", Environment.NewLine, player2Score, player1Score, r_Player2.VictoriesNumber, m_RoundNumber);
            }
            else
            {
                scoresString = "It's a tie! Would you like another round?";
            }

            return scoresString;
        }

        public void RestartGame()
        {
            m_GameBoard = new Board(m_GameBoard.Dimension, r_Player1, r_Player2);
            m_CurrentPlayer = r_Player1;
            m_LastTurnWasSkipped = false;
            m_RoundNumber++;
        }

        public void buildNextMovesList()        ////change to caps
        {
            m_NextMovesList.Clear();
            foreach (Point point in getAllPlayerPoints())
            {
                findPointsToFlip(point);
            }
        }

        public void PickTile(Point i_Tile)
        {
            flipCoins(i_Tile);
            m_LastTurnWasSkipped = false;
        }

        // $G$ NTT-999 (-5) There is no need to re-instantiate the random instance every time it is used.
        public Point GenerateComputerTile()
        {
            Random random = new Random();
            return m_NextMovesList[random.Next(m_NextMovesList.Count)].NewCoinInBoard;
        }

        private bool flipCoins(Point i_NewCoinOnBoard)
        {
            bool didItFlip = false;

            foreach (NextMoves nextMove in m_NextMovesList)
            {
                if (nextMove.NewCoinInBoard.Equals(i_NewCoinOnBoard))
                {
                    m_GameBoard.BoardMatrix[i_NewCoinOnBoard.XCoord, i_NewCoinOnBoard.YCoord] = CurrentPlayer.PlayerCoin;
                    foreach (Point point in nextMove.CoinsToFlipList)
                    {
                        m_GameBoard.BoardMatrix[point.XCoord, point.YCoord] = CurrentPlayer.PlayerCoin;
                    }

                    didItFlip = true;
                }
            }

            return didItFlip;
        }

        public void SwitchCurrentPlayer()
        {
            m_CurrentPlayer = m_CurrentPlayer == r_Player1 ? r_Player2 : r_Player1;
        }

        private List<Point> getAllPlayerPoints()
        {
            List<Point> allPlayerPoints = new List<Point>();
            char playerCoin = m_CurrentPlayer.PlayerCoin;

            for (int i = 0; i < m_GameBoard.Dimension; i++)
            {
                for (int j = 0; j < m_GameBoard.Dimension; j++)
                {
                    if (m_GameBoard.BoardMatrix[i, j] == playerCoin)
                    {
                        allPlayerPoints.Add(new Point(i, j));
                    }
                }
            }

            return allPlayerPoints;
        }

        private void findPointsToFlip(Point i_CheckedPoint)
        {
            coinsToFlipInOneDirection(i_CheckedPoint, 0, -1); ////UP
            coinsToFlipInOneDirection(i_CheckedPoint, 0, 1); ////DOWN
            coinsToFlipInOneDirection(i_CheckedPoint, -1, 0); ////LEFT
            coinsToFlipInOneDirection(i_CheckedPoint, 1, 0); ////RIGHT
            coinsToFlipInOneDirection(i_CheckedPoint, 1, -1); ////UP RIGHT
            coinsToFlipInOneDirection(i_CheckedPoint, -1, -1); ////UP LEFT
            coinsToFlipInOneDirection(i_CheckedPoint, 1, 1); ////DOWN RIGHT
            coinsToFlipInOneDirection(i_CheckedPoint, -1, 1); ////DOWN LEFT
        }

        private void coinsToFlipInOneDirection(Point i_CheckedPoint, int i_XNextStep, int i_YNextStep)
        {
            List<Point> flipInDirection = new List<Point>();
            Point nextPoint = new Point(i_CheckedPoint.XCoord + i_XNextStep, i_CheckedPoint.YCoord + i_YNextStep);
            bool listNotEmpty = false;

            while (isNextMovePossible(nextPoint))
            {
                flipInDirection.Add(nextPoint);
                listNotEmpty = true;
                nextPoint.XCoord += i_XNextStep;
                nextPoint.YCoord += i_YNextStep;
            }

            if ((nextPoint.XCoord >= 0 && nextPoint.XCoord < m_GameBoard.Dimension && nextPoint.YCoord >= 0 && nextPoint.YCoord < m_GameBoard.Dimension) && listNotEmpty)
            {
                if (m_GameBoard.BoardMatrix[nextPoint.XCoord, nextPoint.YCoord] != m_CurrentPlayer.PlayerCoin)
                {
                    m_NextMovesList.Add(new NextMoves(nextPoint, flipInDirection));
                }
            }
        }

        private bool isNextMovePossible(Point i_NextPoint)
        {
            char playerCoin = m_CurrentPlayer.PlayerCoin;
            char opponentCoin = m_CurrentPlayer == r_Player1 ? r_Player2.PlayerCoin : r_Player1.PlayerCoin;

            return withinBoardBorder(i_NextPoint) && m_GameBoard.BoardMatrix[i_NextPoint.XCoord, i_NextPoint.YCoord] == opponentCoin;
        }

        private bool withinBoardBorder(Point i_NextPoint)
        {
            return i_NextPoint.XCoord >= 0 && i_NextPoint.XCoord < m_GameBoard.Dimension && i_NextPoint.YCoord >= 0 && i_NextPoint.YCoord < m_GameBoard.Dimension;
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
        }

        public Board Board
        {
            get { return m_GameBoard; }
        }

        public Player FirstPlayer
        {
            get { return r_Player1; }
        }

        public Player SecondPlayer
        {
            get { return r_Player2; }
        }

        public List<NextMoves> NextMovesList
        {
            get { return m_NextMovesList; }
        }
    }
}
