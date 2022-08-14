namespace CSharp
{
    public enum CreatureType
    {
        None = 0,
        Player,
        Monster
    }
    
    public class Creature
    {
        private CreatureType type;
                
        protected int hp = 0;
        protected int attack = 0;
        
        protected Creature(CreatureType type)
        {
            this.type = type;
        }
        
        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
        
        public int GetHp() => hp;
        public int GetAttack() => attack;

        public bool IsDead()
        {
            return hp <= 0;
        }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}