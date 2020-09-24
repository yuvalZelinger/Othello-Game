namespace Ex02_Othelo_Logic
{
    // $G$ DSN-999 (-3) Better use a struct here
    public class Player
    {
        private readonly string r_Name;
        private readonly char r_PlayerCoin;
        private readonly bool r_IsPlayerHuman;
        private int m_VictoriesNumber;

        public Player(string i_Name, char i_PlayerCoin, bool i_PlayerType)
        {
            r_Name = i_Name;
            r_PlayerCoin = i_PlayerCoin;
            r_IsPlayerHuman = i_PlayerType;
            m_VictoriesNumber = 0;
        }

        public int VictoriesNumber
        {
            get { return m_VictoriesNumber; }
            set { m_VictoriesNumber = value; }
        }

        public char PlayerCoin
        {
            get { return r_PlayerCoin; }
        }

        public string PlayerName
        {
            get { return r_Name; }
        }

        public bool HumanPlayer
        {
            get { return r_IsPlayerHuman;  }
        }
    }
}
