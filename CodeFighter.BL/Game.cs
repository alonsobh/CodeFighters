using System.Data;

namespace CodeFighter.BL
{
    public class Game
    {

        public Game(string namePlayer1, GameRoleList rolePlayer1, string namePlayer2, GameRoleList rolePlayer2)
        {
            Player1 = new Player(namePlayer1, rolePlayer1);
            Player2 = new Player(namePlayer2, rolePlayer2);
        }

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }


        public void Punch(bool isPlayer1)
        {
            ApplyMove(isPlayer1, new Punch());
        }

        public void Kick(bool isPlayer1)
        {
            ApplyMove(isPlayer1, new Kick());
        }

        public void Special(bool isPlayer1)
        {
            ApplyMove(isPlayer1, new Special());
        }

        public void Heal(bool isPlayer1)
        {
            ApplyMove(isPlayer1, new Heal());
        }

        private void ApplyMove(bool isPlayer1, Move move)
        {
            var attacker = isPlayer1 ? Player1 : Player2;
            var defendant = isPlayer1 ? Player2 : Player1;
            if (move.RequiresFullEnergy)
            {
                if (attacker.Energy == 100)
                    attacker.Energy = 0;
                else
                    throw new DataException("Energy Must Be Full");
            }
            attacker.Life += move.EfectOnSelf;
            defendant.Life -= move.Power;
            attacker.Energy += move.EnergyBonus;

            ValidateLifeAndEnergy(Player1);
            ValidateLifeAndEnergy(Player2);
        }

        private void ValidateLifeAndEnergy(Player player)
        {
            if (player.Life > 200) player.Life = 200;
            if (player.Energy > 100) player.Energy = 100;
        }
    }
}