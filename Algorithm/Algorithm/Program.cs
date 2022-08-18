using System;

namespace Algorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;

            int lastTick = 0;
            
            while (true)
            {
                #region 프레임 관리
                // 메인 루프. 게임이 종료될 때 까지 돌아간다
                int currentTick = System.Environment.TickCount;

                // 만약에 경과한 시간이 1/30초보다 작다면
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                // 입력 : 사용자의 모든 인풋을 감지하는 단계

                // 로직 : 그 입력을 따라 게임 로직이 실행된다
                player.Update(deltaTick);

                // 렌더링 : 연산된 게임 세상을 그려준다
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}