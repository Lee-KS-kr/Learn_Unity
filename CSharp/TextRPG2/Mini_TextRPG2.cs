using System;

namespace CSharp
{
    // 객체지향 (OOP Object Oriented Programming)
    // 속성
    // 기능
    // 기사
    // 기사의 속성 : hp, attack ...
    // 기사의 기능 : Move, Attack, Die ...
    
    // 클래스 : 설계도, 붕어빵 틀
    // 객체 : 설계도를 가지고 생성해 낸 붕어빵
    // static -> 객체가 아닌 클래스에 종속적임. 각 객체들끼리 공유하는 것
    // 상속 -> 부모객체의 필드를 물려받아 자식객체가 사용할 수 있다
    // 접근 한정자 : public, protected, private
    // 클래스 형식 변환 : 자식타입 -> 부모타입 부모타입 -> 자식타입 is as
    // 다형성(여러가지 형태를 가지고 있다) : virtual, override, sealed

    public class Mini_TextRPG2
    {
        public static void Main_TextRPG2(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("~\tTEXT RPG\t~");
            while (true)
            {
                game.Process();
            }
        }
    }
}