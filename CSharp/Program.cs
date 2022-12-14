using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CSharp
{
    class Map
    {
        private int[,] tiles =
        {
            {1, 1, 1, 1, 1},
            {1, 0, 0, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 0, 0, 0, 0},
            {1, 1, 1, 0, 0}
        };

        public void Render()
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[y, x] == 1)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write("\u25cf ");
                }

                Console.WriteLine();
            }
        }
    }

    class Item
    {
        public Item(int id)
        {
            this.id = id;
        }
        public int id;
    }
    
    internal class Program
    {
        enum Choice
        {
            Sicssors = 0,
            Rock = 1,
            Paper = 2,
        }

        // 여기에 주석을 달 수 있어요.
        public static void Main_basic(string[] args)
        {
            // int input = Int32.Parse(Console.ReadLine());
            // bool isPrime = FindPrime(input);
            // Console.WriteLine(isPrime ? $"{input}은 소수입니다." : $"{input}은 소수가 아닙니다.");

            //HelloWolrd();

            // int a = 7, b = 8;
            // int result = Add(a, b);
            // Console.WriteLine($"{a} + {b} = {result}");

            // int a = 0;
            // Program.AddOne(ref a);
            // Console.WriteLine(a);
            //
            // a = AddOne2(a);
            // Console.WriteLine(a);

            // int num1 = 1;
            // int num2 = 2;
            // Swap(ref num1,ref num2);

            // int num1 = 78, num2 = 14, get, set;
            // Divide(num1, num2, out get, out set);
            // Console.WriteLine($"{num1} 나누기 {num2}의 몫은 {get}이고 나머지는 {set}이다.");

            //Console.WriteLine(Add(1, 2, e: 7.2));

            // StringUses();

            // TestArray();

            // int[] scores = new int[5] {1, 2, 3, 4, 5};
            // int[,] arr = new int[2, 3] {{1, 2, 3}, {4, 5, 6}};

            // Map map = new Map();
            // map.Render();
            //
            // int[][] arr = new int[3][];
            // arr[0] = new int[2];
            // arr[1] = new int[9];
            // arr[2] = new int[5];

            //TestList();

            TestDictionary();
        }

        static void TestDictionary()
        {
            // key를 가지고 value를 찾을 수 있는 방법
            // 두가지 값을 넣는다
            // 키를 알면 value를 굉장히 빠르게 찾을 수 있다.
            // 딕셔너리 : hashtable 기법을 사용
            // 아주 큰 박스 하나에 모든 데이터를 넣는것이 아니라, 박스 여러개를 쪼개 넣는 방식
            // 메모리적인 면에서 손해를 보나 속도면에서는 이득
            Dictionary<int, Item> dic = new Dictionary<int, Item>();

            dic[5] = new Item(5);
            dic.Remove(5);
            
            for (int i = 0; i < 10000; i++)
            {
                dic.Add(i, new Item(i));
            }

            Item item = dic[5000];
            bool found = dic.TryGetValue(7777, out item);
            
            dic.Clear();
        }

        static void TestList()
        {
            // List : 동적 배열. 사용하다가 부족하면 증가시킴 
            // 탐색이 힘들다
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            // 리스트의 끝에 새로운 데이터를 추가해줌
            
            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE);
            }
            
            // 삽입, 삭제
            list.Insert(2, 999);
            list.Remove(4);
            list.RemoveAt(0);
            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            
            list.Clear();
        }

        static void TestArray()
        {
            // 자료 구조
            // 1. 배열
            int a; // int 형식의 데이터를 하나만 가지겠다
            int[] b; // int 형식의 데이터를 여러개 가지겠다
            b = new int[5]; // 크기는 한번 정하면 바꿀 수 없으니 신중하게 선택해야 한다
            int[] c = new int[] {100, 200, 300, 400, 500};
            b[0] = 10;
            b[1] = 20;
            b[2] = 30;
            b[3] = 40;
            b[4] = 50;

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }

            foreach (int element in c)
            {
                Console.WriteLine(element);
            }
        }

        static void StringUses()
        {
            string name = "Mizue Lee";

            // 1. 찾기(조회)
            bool found = name.Contains("Mizu");
            int index = name.IndexOf('z');

            // 2. 변형
            name = name + " Lover";
            string lowerName = name.ToLower();
            string upperName = name.ToUpper();
            string newName = name.Replace("Lover", "Love");

            // 3. 분할
            string[] names = name.Split(new char[] {' '});
            string substringName = name.Substring(6);
        }

        // 디폴트 값 중 하나만 지정하여 넣는 것도 가능하다
        static double Add(int a, int b, int c = 0, float d = 1.0f, double e = 3.0)
        {
            Console.WriteLine("Add double 호출");
            return a + b + c + d + e;
        }

        // 두가지 이상의 값을 반환하고 싶을 때 유용한 out
        static void Divide(int a, int b, out int result1, out int result2)
        {
            result1 = a / b;
            result2 = a % b;
        }

        // 원본 변수의 값을 변환하고 싶을 때 유용한 ref
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void AddOne(ref int number)
        {
            number += 1;
        }

        // 오버로딩
        static int AddOne(int number)
        {
            return ++number;
        }

        /// <summary>
        /// 덧셈 함수
        /// </summary>
        static int Add(int a, int b)
        {
            return a + b;
        }

        static void HelloWolrd()
        {
            Console.WriteLine("Hello World!");
        }

        static void Memo()
        {
            int a = 100;
            int b = a;

            a += 1;
            a -= 1;
            a *= 1;
            a %= 1;
            a <<= 1;
            a >>= 1;
            a &= 1;
            a |= 1;
            a ^= 1;

            int c = (3 + 2) * 3 | 1 ^ 1;
            /*
             * 연산 우선순위
             * 1. ++ --
             * 2. * / %
             * 3. + -
             * 4. << >>
             * 5. < >
             * 6. == !=
             * 7. &
             * 8. ^
             * 9. |
             * ...
             */

            int hp = 100;
            bool isDead = (hp <= 0);

            if (isDead)
                Console.WriteLine("당신은 죽었습니다.");
            else
                Console.WriteLine("게임을 계속 합니다.");

            // 삼항연산자로 줄이기
            // Console.WriteLine(isDead ? "당신은 죽었습니다." : "게임을 계속 합니다.");

            // 0 : 가위 1 : 바위 3: 보 4: 치트키
            Choice choice = Choice.Sicssors;
            switch (choice)
            {
                case Choice.Sicssors:
                    Console.WriteLine("가위입니다.");
                    break;
                case Choice.Rock:
                    Console.WriteLine("바위입니다.");
                    break;
                case Choice.Paper:
                    Console.WriteLine("보입니다.");
                    break;
                default:
                    Console.WriteLine("치트키입니다.");
                    break;
            }
        }

        static void IsHandsome()
        {
            Console.WriteLine("거울아 거울아~");
            string answer;
            do
            {
                Console.WriteLine("강사님은 잘생겼니? (y / n)");
                answer = Console.ReadLine();
            } while (answer != "y");
        }

        // 문득 궁금해서 만들어본 소수 확인 코드
        static bool FindPrime(int input)
        {
            bool result = true;

            for (int i = 2; i < input; i++)
            {
                if ((input % i) == 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        static void ModuleWithThree()
        {
            Console.WriteLine($"3으로 나뉘는 숫자들 : ");
            for (int i = 0; i < 100; i++)
            {
                if ((i % 3) != 0)
                    continue;
                Console.WriteLine(i);
            }
        }

        static void IsPrime()
        {
            int num = 87;
            for (int i = 2; i < 100; i++)
            {
                if ((num % i) == 0)
                {
                    Console.WriteLine("소수가 아닙니다.");
                    break;
                }
            }
        }
    }
}