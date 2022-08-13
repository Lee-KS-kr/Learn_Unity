using System;

namespace CSharp
{
    internal class Program
    {
        enum Choice
        {
            Sicssors = 0,
            Rock = 1,
            Paper = 2,
        }

        // 여기에 주석을 달 수 있어요.
        public static void Main_main(string[] args)
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

            Console.WriteLine(Add(1, 2, e: 7.2));
            
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
        static void Swap(ref int a,ref int b)
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