namespace Ex02_Othelo_Logic
{
    public struct Point
    {
        private int m_X;
        private int m_Y;

        public Point(int i_X, int i_Y)
        {
            m_X = i_X;
            m_Y = i_Y;
        }

        public int XCoord
        {
            get { return m_X; }
            set { m_X = value; }
        }

        public int YCoord
        {
            get { return m_Y; }
            set { m_Y = value; }
        }
    }
}
