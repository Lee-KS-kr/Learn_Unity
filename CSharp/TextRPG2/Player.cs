namespace CSharp
{
    public enum PlayerType
    {
        None = 0,
        Knight,
        Archer,
        Wizard,
    }
    
    public class Player : Creature
    {
        protected PlayerType type = PlayerType.None;

        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            this.type = type;
        }

        public PlayerType GetPlayerType() => type;
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }

    class Wizard : Player
    {
        public Wizard() : base(PlayerType.Wizard)
        {
            SetInfo(50, 15);
        }
    }
}