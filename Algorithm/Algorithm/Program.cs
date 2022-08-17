using System;

namespace Algorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';

            int lastTick = 0;
            
            while (true)
            {
                #region 프레임 관리
                // 메인 루프. 게임이 종료될 때 까지 돌아간다
                int currentTick = System.Environment.TickCount;

                // 만약에 경과한 시간이 1/30초보다 작다면
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                lastTick = currentTick;
                #endregion
                
                // 입력 : 사용자의 모든 인풋을 감지하는 단계
                // 로직 : 그 입력을 따라 게임 로직이 실행된다
                // 렌더링 : 연산된 게임 세상을 그려준다
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}