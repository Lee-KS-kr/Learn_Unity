using System;

namespace CSharp
{
    public class InputManager
    {
        // 구독자를 모집 후 특정 이벤트가 발생했을 때 구독자들에게 메세지를 전달하는 방식
        // 옵저버 패턴
        
        public delegate void OnInputKey();

        public event OnInputKey InputKey;
        
        public void Update()
        {
            if (!Console.KeyAvailable)
                return;
            
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A)
            {
                // 모두에게 알려준다
                InputKey();
            }
        }
    }
}