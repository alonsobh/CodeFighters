﻿namespace CodeFighter.BL
{
    public class Player
    {
        public Player(string name, GameRoleList role)
        {
            Name = name;
            Role = role;
        }

        public string Name { get; private set; }
        public GameRoleList Role { get; private set; }

        public int Energy { get; set; } = 0;
        public int Life { get; set; } = 200;
        public string LifeString => string.Format("{0}/200", Life);
        public string EnergyString => string.Format("{0}/100", Life);



        internal bool CanApplyMove(Move move)
        {
            return !move.RequiresFullEnergy || Energy == 100;
        }

        public bool CanApplySpecial()
        {
            return Energy == 100;
        }

        public bool CanApplyHeal()
        {
            return Energy == 100;
        }

        //TODO:set to internal
        public void FillEnergy()
        {
            Energy = 100;
        }
        //TODO:set to internal
        public void SetLife(int value)
        {
            Life = value;
        }

    }
}
