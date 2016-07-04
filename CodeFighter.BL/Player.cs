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
        public int Life { get; set; } = 200;


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
