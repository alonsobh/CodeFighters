namespace CodeFighter.BL
{
    internal abstract class Move
    {
        public abstract int Power { get; }
        public abstract int EfectOnSelf { get; }
        public abstract int EnergyBonus { get; }
        public abstract bool RequiresFullEnergy { get; }
    }

    internal class Punch : Move
    {
        public override int Power { get; } = 10;
        public override int EfectOnSelf { get; } = 0;
        public override int EnergyBonus { get; } = 10;
        public override bool RequiresFullEnergy { get; } = false;
    }

    internal class Kick : Move
    {
        public override int Power { get; } = 20;
        public override int EfectOnSelf { get; } = 0;
        public override int EnergyBonus { get; } = 16;
        public override bool RequiresFullEnergy { get; } = false;
    }

    internal class Special : Move
    {
        public override int Power { get; } = 30;
        public override int EfectOnSelf { get; } = 0;
        public override int EnergyBonus { get; } = -70;
        public override bool RequiresFullEnergy { get; } = true;
    }

    internal class Heal : Move
    {
        public override int Power { get; } = 0;
        public override int EfectOnSelf { get; } = 50;
        public override int EnergyBonus { get; } = -100;
        public override bool RequiresFullEnergy { get; } = true;
    }
}