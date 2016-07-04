namespace CodeFighter.BL
{
    public class Game
    {
        public Game(string namePlayer1, string namePlayer2)
        {
            NamePlayer1 = namePlayer1;
            NamePlayer2 = namePlayer2;
        }

        //Player 1
        public string NamePlayer1 { get; private set; }
        public int LifePLayer1 { get; set; }
        public int EnergyPlayer1 { get; set; }

        //Player 2
        public string NamePlayer2 { get; private set; }
        public int LifePLayer2 { get; set; }
        public int EnergyPlayer2 { get; set; }
    }
}