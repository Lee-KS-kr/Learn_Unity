using System.Runtime.InteropServices;

namespace CSharp
{
    public enum MonsterType
    {
        None = 0,
        Slime,
        Orc,
        Skeleton,
    }
    
    public class Monster : Creature
    {
        protected MonsterType type = MonsterType.None;
        
        protected Monster(MonsterType type) : base(CreatureType.Monster)
        {
            this.type = type;
        }

        public MonsterType GetMonsterType() => type;
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            SetInfo(10, 0);
        }
    }

    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            SetInfo(20, 15);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton)
        {
            SetInfo(15, 25);
        }
    }
}