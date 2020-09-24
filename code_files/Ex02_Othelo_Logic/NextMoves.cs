using System.Collections.Generic;

namespace Ex02_Othelo_Logic
{
    // $G$ DSN-999 (-3) Better use a struct here
    public class NextMoves
    {
        // $G$ DSN-999 (-3) This kind of field should be readonly.
        private Point m_NewCoinInBoard;
        private List<Point> m_CoinsToFlipList; //// = new List<Point>();

        public NextMoves(Point i_Point, List<Point> i_PointList)
        {
            m_NewCoinInBoard = i_Point;
            m_CoinsToFlipList = i_PointList;
        }

        public Point NewCoinInBoard
        {
            get { return m_NewCoinInBoard; }
        }

        public List<Point> CoinsToFlipList
        {
            get { return m_CoinsToFlipList; }
        }
    }
}
