namespace Ex02_Othelo_Logic
{
   public class Board
    {
        // $G$ DSN-999 (-3) This array should be readonly.
        private int m_Dimension;
        private char[,] m_BoardMatrix;

        public Board(int i_Dimension, Player i_Player1, Player i_Player2)
        {
            m_Dimension = i_Dimension;
            m_BoardMatrix = new char[Dimension, Dimension];
            m_BoardMatrix[(m_Dimension / 2), ((m_Dimension / 2) - 1)] = i_Player1.PlayerCoin;
            m_BoardMatrix[((m_Dimension / 2) - 1), (m_Dimension / 2)] = i_Player1.PlayerCoin;
            m_BoardMatrix[((m_Dimension / 2) - 1), ((m_Dimension / 2) - 1)] = i_Player2.PlayerCoin;
            m_BoardMatrix[(m_Dimension / 2), (m_Dimension / 2)] = i_Player2.PlayerCoin;
        }

        public int Dimension
        {
            get { return m_Dimension; }
        }

        public char[,] BoardMatrix
        {
            get { return m_BoardMatrix; }
        }
    }
}