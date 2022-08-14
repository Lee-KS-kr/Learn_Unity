using System;

namespace CSharp.Properties
{
    public class Mini_TextRPG
    {
        enum Job
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Wizard = 3,
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        enum MonsterType
        {
            None = 0,
            Slime,
            Orc,
            Skeleton,
        }

        struct MonsterStatus
        {
            public int hp;
            public int attack;
        }

        public static void Main_TextRPG1(string[] args)
        {
            while (true)
            {
                Job choice = Job.None;
                choice = TeacherSelectJob(choice);

                if (choice != Job.None)
                {
                    Player player;
                    SetStatus(choice, out player);
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"플레이어 스테이터스\n클래스 : {choice}\n체력 : {player.hp}\n공격력 : {player.attack}");

                    EnterGame(ref player);
                }
            }
        }

        static void Fight(ref Player player,ref MonsterStatus monster)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            while (true)
            {
                monster.hp -= player.attack;
                Console.WriteLine();
                Console.WriteLine($"플레이어의 공격!\n몬스터는 {player.attack}의 데미지를 입었다. 몬스터의 남은 체력 : {monster.hp}");
                if (monster.hp <= 0)
                {
                    Console.WriteLine("몬스터 사망. 승리하였습니다!");
                    break;
                }
                
                player.hp -= monster.attack;
                Console.WriteLine();
                Console.WriteLine($"몬스터의 공격!\n플레이어는 {monster.attack}의 데미지를 입었다. 플레이어의 남은 체력 : {player.hp}");
                if (player.hp <= 0)
                {
                    Console.WriteLine("사망하였습니다. 플레이어의 패배!");
                    Environment.Exit(0);
                }
            }
        }

        static void EnterField(ref Player player)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("필드에 접속하였습니다.");

            while (true)
            {
                MonsterStatus monster;
                CreateRandomMonster(out monster);
                
                Console.WriteLine();
                Console.WriteLine("어떻게 하시겠습니까?\n[1] 전투 모드로 돌입한다.\n[2] 마을로 도망친다.\n>>");
                int input = Int32.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Fight(ref player,ref monster);
                }
                else if (input == 2)
                {
                    Random rand = new Random();
                    int randomPercent = rand.Next(0, 101);
                    if (randomPercent <= 33)
                    {
                        Console.WriteLine("도망치는데 성공하였습니다.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치는데 실패했습니다.");
                        Fight(ref player,ref monster);
                    }
                }
            }
        }

        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("마을에 접속하였습니다.\n무엇을 하시겠습니까?\n[1] 필드로 가기\n[2] 로비로 돌아가기\n>>");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        EnterField(ref player);
                        break;
                    case 2:
                        return;
                }
            }
        }

        static void SetStatus(Job jobClass, out Player player)
        {
            switch (jobClass)
            {
                case Job.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case Job.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case Job.Wizard:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        static Job TeacherSelectJob(Job choice)
        {
            Console.WriteLine($"직업을 선택하세요!\n[1] 기사\n[2] 궁수\n[3] 법사\n>>");
            int input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                case 2:
                case 3:
                    choice = (Job) input;
                    break;
            }
            
            return choice;
        }

        static void CreateRandomMonster(out MonsterStatus monster)
        {
            Console.WriteLine();
            Random rand = new Random();
            int randomMonster = rand.Next(1, 4);
            switch ((MonsterType)randomMonster)
            {
                case MonsterType.Slime:
                    Console.WriteLine($"슬라임과 마주쳤다!");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case MonsterType.Orc:
                    Console.WriteLine($"오크와 마주쳤다!");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case MonsterType.Skeleton:
                    Console.WriteLine($"스켈레톤과 마주쳤다!");
                    monster.hp = 30;
                    monster.attack = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }
    }
}