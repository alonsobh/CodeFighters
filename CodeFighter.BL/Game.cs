namespace CodeFighter.BL
{
    public class Game
    {
        public Game(string namePlayer1, GameRoleList rolePlayer1, string namePlayer2, GameRoleList rolePlayer2)
        {
            NamePlayer1 = namePlayer1;
            NamePlayer2 = namePlayer2;
            RolePlayer1 = rolePlayer1;
            RolePlayer2 = rolePlayer2;
        }

        //Player 1
        public string NamePlayer1 { get; private set; }
        public int LifePLayer1 { get; set; } = 200;
        public int EnergyPlayer1 { get; set; }
        public GameRoleList RolePlayer1 { get; private set; }

        //Player 2
        public string NamePlayer2 { get; private set; }
        public int LifePLayer2 { get; set; } = 200;
        public int EnergyPlayer2 { get; set; }
        public GameRoleList RolePlayer2 { get; private set; }


        public void Punch(bool isPlayer1)
        {
            ApplyMove( isPlayer1, new Punch());
        }

        public void Kick(bool isPlayer1)
        {
            ApplyMove(isPlayer1, new Kick());
        }

        public void Special(bool isPlayer1)
        {
            ApplyMove(isPlayer1, new Special());
        }

        private void ApplyMove(bool isPlayer1, Move move)
        {
            if (isPlayer1)
            {
                LifePLayer2 -= move.Power;
                EnergyPlayer1 += move.Energy;
            }
            else
            {
                LifePLayer1 -= move.Power;
                EnergyPlayer2 += move.Energy;
            }
        }

    }
}