namespace CodeFighter.BL
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
        public int Life { get; set; } = MaxLife;
        public string LifeString => string.Format("{0}/{1}", Life, MaxLife);
        public string EnergyString => string.Format("{0}/{1}", Energy, MaxEnergy);



        internal bool CanApplyMove(Move move)
        {
            return !move.RequiresFullEnergy || Energy == MaxEnergy;
        }

        public bool CanApplySpecial()
        {
            return IsEnergyFull();
        }

        public bool IsEnergyFull()
        {
            return Energy == MaxEnergy;
        }

        public bool CanApplyHeal()
        {
            return IsEnergyFull();
        }

        public const int MaxLife = 200;
        public const int MaxEnergy = 100;

        public void ValidateLifeAndEnergy()
        {
            if (Life > MaxLife) Life = MaxLife;
            if (Energy > MaxEnergy) Energy = MaxEnergy;
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
