using System.Data;

namespace CodeFighter.BL
{
    public class Game
    {
        public bool CanApplySpecial(bool isPlayer1)
        {
            return isPlayer1 ? EnergyPlayer1 == 100 : EnergyPlayer2 == 100;
        }
        public bool CanApplyHeal(bool isPlayer1)
        {
            return isPlayer1 ? EnergyPlayer1 == 100 : EnergyPlayer2 == 100;
        }

        //TODO:set to internal
        public void FillEnergy(bool isPlayer1)
        {
            if (isPlayer1)
                EnergyPlayer1 = 100;
            else
                EnergyPlayer2 = 100;
        }
        //TODO:set to internal
        public void SetLife(bool isPlayer1, int value)
        {
            if (isPlayer1)
                LifePlayer1 = value;
            else
                LifePlayer2 = value;
        }


        public Game(string namePlayer1, GameRoleList rolePlayer1, string namePlayer2, GameRoleList rolePlayer2)
        {
            NamePlayer1 = namePlayer1;
            NamePlayer2 = namePlayer2;
            RolePlayer1 = rolePlayer1;
            RolePlayer2 = rolePlayer2;
        }

        //Player 1
        public string NamePlayer1 { get; private set; }
        public int LifePlayer1 { get; set; } = 200;
        public int EnergyPlayer1 { get; set; }
        public GameRoleList RolePlayer1 { get; private set; }

        //Player 2
        public string NamePlayer2 { get; private set; }
        public int LifePlayer2 { get; set; } = 200;
        public int EnergyPlayer2 { get; set; }
        public GameRoleList RolePlayer2 { get; private set; }


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
            if (isPlayer1)
            {
                if (move.RequiresFullEnergy)
                {
                    if (EnergyPlayer1 == 100)
                        EnergyPlayer1 = 0;
                    else
                        throw new DataException("Energy Must Be Full");
                }
                LifePlayer1 += move.EfectOnSelf;
                LifePlayer2 -= move.Power;
                EnergyPlayer1 += move.EnergyBonus;
            }
            else
            {
                if (move.RequiresFullEnergy)
                {
                    if (EnergyPlayer2 == 100)
                        EnergyPlayer2 = 0;
                    else
                        throw new DataException("Energy Must Be Full");
                }
                LifePlayer2 += move.EfectOnSelf;
                LifePlayer1 -= move.Power;
                EnergyPlayer2 += move.EnergyBonus;
            }
            if (LifePlayer1 > 200) LifePlayer1 = 200;
            if (LifePlayer2 > 200) LifePlayer2 = 200;
            if (EnergyPlayer1 > 100) EnergyPlayer1 = 100;
            if (EnergyPlayer2 > 100) EnergyPlayer2 = 100;
        }
    }
}