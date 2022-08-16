using System;

namespace CSharp
{
    public class Workout_Array
    {
        public static void Main_WorkArray(string[] args)
        {
            int[] scores = new int[] {10, 30, 40, 20, 50};
            Console.WriteLine($"최고 점수 : {GetHighesScore(scores)}");
            Console.WriteLine($"평균 점수 : {GetAverageScore(scores)}");
            
                        
            Console.Write($"검색할 숫자를 입력하세요. >> ");
            int search = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine($"{search}는 {GetIndexOf(scores, search)} 번째에 있습니다.");

            Console.WriteLine("정렬 전");
            foreach (var VARIABLE in scores)
            {
                Console.Write(VARIABLE + " ");
            }
            
            Sort(scores);
            Console.WriteLine("\n정렬 후");
            foreach (var VARIABLE in scores)
            {
                Console.Write(VARIABLE + " ");
            }
        }
        
        static int GetHighesScore(int[] scores)
        {
            int result = 0;

            foreach (var value in scores)
            {
                if (result < value)
                    result = value;
            }
            
            return result;
        }

        static int GetAverageScore(int[] scores)
        {
            if (scores.Length == 0) return 0;
            
            int result = 0;

            foreach (var value in scores)
            {
                result += value;
            }

            return (result / scores.Length);
        }

        static int GetIndexOf(int[] scores,int value)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                if (value == scores[i])
                    return i;
            }
            return -1;
        }

        static void Sort(int[] scores)
        {
            int turn = 0;
            while (turn < scores.Length)
            {
                for (int i = 0; i < scores.Length - 1; i++)
                {
                    if (scores[i] < scores[i + 1])
                        (scores[i], scores[i + 1]) = (scores[i + 1], scores[i]);
                }

                turn++;
            }
        }
    }
}