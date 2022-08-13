using System;

namespace CSharp
{
    public class Mini_RockPaperSiccor
    {
        static void Main_RockPaperSiccor(string[] args)
        {
            // 0 가위 1 바위 2 보
            Random rand = new Random();
            int aiChoice = rand.Next(0, 3);

            Console.WriteLine("가위바위보 게임!");
            Console.WriteLine("0 ~ 2 사이의 숫자를 입력하세요");

            int humanChoice = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("당신의 선택...");
            switch (humanChoice)
            {
                case 0:
                    Console.WriteLine("가위");
                    break;
                case 1:
                    Console.WriteLine("바위");
                    break;
                case 2:
                    Console.WriteLine("보");
                    break;
            }
            
            Console.WriteLine("컴퓨터의 선택...");
            switch (aiChoice)
            {
                case 0:
                    Console.WriteLine("가위");
                    break;
                case 1:
                    Console.WriteLine("바위");
                    break;
                case 2:
                    Console.WriteLine("보");
                    break;
            }

            // 내 풀이 방식
            // if (humanChoice == aiChoice)
            // {
            //     Console.WriteLine("무승부입니다.");
            // }
            // else
            // {
            //     if (humanChoice != 2 && aiChoice != 2)
            //     {
            //         if (humanChoice > aiChoice)
            //             Console.WriteLine("사람의 승리!");
            //         else if (aiChoice > humanChoice)
            //         {
            //             Console.WriteLine("AI의 승리!");
            //         }
            //     }
            //     else
            //     {
            //         if (humanChoice == 2)
            //         {
            //             if (aiChoice == 0)
            //                 Console.WriteLine("AI의 승리!");
            //             else
            //             {
            //                 Console.WriteLine("사람의 승리!");
            //             }
            //         }
            //         else
            //         {
            //             if (humanChoice == 2)
            //                 Console.WriteLine("사람의 승리!");
            //             else
            //             {
            //                 Console.WriteLine("AI의 승리!");
            //             }
            //         }
            //     }
            // }
            
            // 강사님 풀이 방식 1
            // if (humanChoice == 0)
            // {
            //     if (aiChoice == 0)
            //     {
            //         Console.WriteLine("무승부입니다.");
            //     }
            //     else if (aiChoice == 1)
            //     {
            //         Console.WriteLine("AI의 승리!");
            //     }
            //     else
            //     {
            //         Console.WriteLine("사람의 승리!");
            //     }
            // }
            // else if (humanChoice == 1)
            // {
            //     if (aiChoice == 0)
            //     {
            //         Console.WriteLine("사람의 승리!");
            //     }
            //     else if (aiChoice == 1)
            //     {
            //         Console.WriteLine("무승부입니다.");
            //     }
            //     else
            //     {
            //         Console.WriteLine("AI의 승리!");
            //     }
            // }
            // else
            // {
            //     if (aiChoice == 0)
            //     {
            //         Console.WriteLine("AI의 승리!");
            //     }
            //     else if (aiChoice == 1)
            //     {
            //         Console.WriteLine("사람의 승리!");
            //     }
            //     else
            //     {
            //         Console.WriteLine("무승부입니다.");
            //     }
            // }
            
            // 강사님 풀이 방식 2
            // if (humanChoice == aiChoice)
            // {
            //     Console.WriteLine("무승부입니다.");
            // }
            // else if (humanChoice == 0 && aiChoice == 2)
            // {
            //     Console.WriteLine("사람의 승리!");
            // }
            // else if (humanChoice == 1 && aiChoice == 0)
            // {
            //     Console.WriteLine("사람의 승리!");
            // }
            // else if (humanChoice == 2 && aiChoice == 1)
            // {
            //     Console.WriteLine("사람의 승리!");
            // }
            // else
            // {
            //     Console.WriteLine("AI의 승리!");
            // }
        }
    }
}