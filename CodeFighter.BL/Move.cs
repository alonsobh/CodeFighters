namespace CodeFighter.BL
{
    internal abstract class Move
    {
        public abstract int Power { get; }
        public abstract int Energy { get; }
    }

    internal class Punch : Move
    {
        public override int Power { get; } = 10;
        public override int Energy { get; } = 5;
    }

    internal class Kick : Move
    {
        public override int Power { get; } = 20;
        public override int Energy { get; } = 8;
    }

    internal class Special : Move
    {
        public override int Power { get; } = 30;
        public override int Energy { get; } = 15;
    }

    internal class Heal : Move
    {
        public override int Power { get; } = 50;
        public override int Energy { get; } = 0;
    }

}
