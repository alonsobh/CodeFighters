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
            if (HasWinner())
                throw new DataException("There is already a winner");

            var attacker = isPlayer1 ? Player1 : Player2;
            var defendant = isPlayer1 ? Player2 : Player1;
            if (!attacker.CanApplyMove(move))
                throw new DataException("Energy Must Be Full");

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

        public string GetWinner()
        {
            if (!HasWinner())
                throw new DataException("There is no winner");
            return GetMessage(Player1) ?? GetMessage(Player2);
        }

        public bool CanFatalityPlayer1()
        {
            return false;
        }

        public string GetMessage(Player player)
        {
            return player.Life < 1 ? null :

                string.Format("{0}{1} wins{2}",
                player.Energy == 100 ? "FATALITY!!! " : string.Empty,
                player.Name,
                player.Life == 200 ? " Perfectly" : string.Empty);
        }

        public bool HasWinner()
        {
            return Player1.Life < 1 || Player2.Life < 1;
        }
    }
}