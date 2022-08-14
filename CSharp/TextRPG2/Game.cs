using System;

namespace CSharp
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Filed,
    }
    
    public class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();

        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Filed:
                    ProcessField();
                    break;
                default:
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("직업을 선택하세요.\n[1] 기사\n[2] 궁수\n[3] 법사\n>>");
            int input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case 2:
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case 3:
                    player = new Wizard();
                    mode = GameMode.Town;
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("마을에 입장했습니다. 무엇을 하시겠습니까?\n[1] 필드로 가기\n[2] 로비로 돌아가기\n>>");
            int input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    mode = GameMode.Filed;
                    break;
                case 2:
                    mode = GameMode.Lobby;
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("필드에 입장했습니다.");

            CreateRandomMonster();
            Console.WriteLine("어떻게 할까?\n[1] 싸운다\n[2] 마을로 도망친다\n>>");
            int input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    ProcessFight();
                    break;
                case 2:
                    TryEscape();
                    break;
            }
        }

        private void ProcessFight()
        {
            while (true)
            {
                Console.WriteLine("\n------------------------------------------");
                int damage = player.GetAttack();
                monster.OnDamaged(damage);
                Console.WriteLine($"플레이어의 공격!\n몬스터는 {damage}의 피해를 입었다. 남은 체력 : {monster.GetHp()}");
                if (monster.IsDead())
                {
                    Console.WriteLine("몬스터 처치. 승리했습니다!");
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamaged(damage);
                Console.WriteLine($"몬스터의 공격!\n플레이어는 {damage}의 피해를 입었다. 남은 체력 : {player.GetHp()}");
                if (player.IsDead())
                {
                    Console.WriteLine("플레이어 사망. 패배했습니다.");
                    Console.WriteLine("로비로 돌아갑니다.");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }

        private void TryEscape()
        {
            int randValue = rand.Next(1, 101);
            if (randValue <= 30)
            {
                Console.WriteLine("도망치는데 성공하였습니다. 마을로 돌아갑니다.");
                mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("도망에 실패했습니다. 몬스터에게 발각당하여 전투를 시작합니다.");
                ProcessFight();
            }
        }

        private void CreateRandomMonster()
        {
            int randValue = rand.Next(1, 4);
            switch (randValue)
            {
                case 1:
                    monster = new Slime();
                    Console.WriteLine("슬라임과 마주쳤다!");
                    break;
                case 2:
                    monster = new Orc();
                    Console.WriteLine("오크와 마주쳤다!");
                    break;
                case 3:
                    monster = new Skeleton();
                    Console.WriteLine("스켈레톤과 마주쳤다!");
                    break;
            }
        }
    }
}