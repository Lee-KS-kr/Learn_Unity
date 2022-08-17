using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace CSharp
{
    public class Advanced
    {
        class MyList<T> where T : struct // T에 조건을 추가할 수 있음. 이 경우 값형식이어야 한다는 조건을 명시
        {
            // 나만의 자료구조를 만든다고 할 때
            // 여러가지 데이터 형식을 지원해줘야 함
            // 무식한 방법 : 있는대로 다 만들기
            // 하나하나 다 만들면 타입이 몇 개가 될지 예측이 안되는데 효율적이지 않고
            // 새 형식을 만들면 그것도 또 하나를 늘려야 함.
            // 굉장히 비효율적인 방식
            // 다른 옵션 1.
            // 이 모든 타입을 소화할 수 있는 오브젝트를 사용하는 방법
            // 단점 : 오브젝트는 참조 타입, 일반 변수는 값 타입
            // 박싱과 언박싱이 일어날 수 있다.(속도가 느리다)
            // 다른 옵션 2.
            // 일반화 형식. T 타입에 대해 어떤 값을 넣어줘도 작동을 한다는 뜻.
            
            private T[] arr = new T[10];

            public T GetItem(int i)
            {
                return arr[i];
            }
        }

        class YourList<T> where T : class
        {
            // 참조타입의 T를 받는 클래스
        }

        class EveryList<T> where T : new()
        {
            // 반드시 어떠한 인자도 받지 않는 기본 생성자가 있어야 한다
        }

        abstract class Dog
        {
            // 추상 클래스가 되면 new로 객채를 생성할 수 없다.
            // 추상 함수는 본문 정의를 할 수 없다

            protected int hp;
            public int Hp
            {
                get
                {
                    return hp;
                }
                protected set
                {
                    hp = value;
                }
            }

            // 자동 완성 프로퍼티
            // 이렇게 해 둘 경우 아래와 같아진다.
            // 초기화도 가능
            /*
             * private int criticalRate = 10;
             * public int GetCriticalRate() { return criticalRate; }
             * public void SetCriticalRate() { criticalRate = value; }
             */
            public int CriticalRate { get; set; } = 10;
            
            public abstract void Bark();
        }

        interface IAttackable
        {
            // 다이아몬드 상속 문제로 인해 다중 상속이 불가능하다.
            // 이런 문제를 해결하기 위해 제공되는 기능이 인터페이스
            
            void Attack();
        }

        class Corgi : Dog, IAttackable
        {
            // 추상 클래스를 상속받으면 추상 함수를 반드시 정의해야 한다
            
            public override void Bark()
            {
                Console.WriteLine("멍멍멍!");
            }

            public void Attack()
            {
                
            }
        }

        delegate int OnClicked();
        // delegate -> 함수 자체를 인자로 넘겨주는 형식
        // int를 반환하고 매개변수는 void인 형식
        // OnClicked가 delegate 형식의 이름이다.

        class Item
        {
            [Important("Very Important")]
            public string itemName;
            public ItemType itemType;
            public Rarity rarity;
        }

        enum ItemType
        {
            Weapon,
            Armor,
            Amulet,
            Ring,
        }

        enum Rarity
        {
            Normal,
            Uncommon,
            Rare,
        }

        class Important : System.Attribute
        {
            // 컴퓨터가 런타임에 체크할 수 있는 주석같은 것..
            string message;

            public Important(string message)
            {
                this.message = message;
            }
        }

        static List<Item> _items = new List<Item>();
        
        delegate bool ItemSelector(Item item);

        public static void Main(string[] args)
        {
            // IAttackable corgiDoggo = new Corgi();
            // DoAttack(corgiDoggo);

            //Corgi brownCorgi = new Corgi();
            //brownCorgi.CriticalRate = 20;

            //LectureDelegate();

            //LectureEvent();

            //LectureLambda();

            //LectureError();

            //LectureReflection();

            // LectureNullable();
        }

        static void LectureNullable()
        {
            // Null + albe
            int? number = null;
            
            // 문제점 -> null값인 변수를 참조하려고 하면 크래시가 난다
            // 참조하려는 변수가 null인지, 혹은 값을 가지고 있는지(HasValue) 체크해야 한다
            if (number != null)
            {
                int a;
                a = number.Value;
            }
            
            // 이것 때문에 생겨난 문법 -> ??
            // 참조하려는 변수가 null이 아니면 참조값을 넣고, null이면 뒤의 값을 초기값으로 넣어라.
            int b = number ?? 0;
            // int c = (number != null) ? number : 0; 와 같은 의미
        }

        static void LectureReflection()
        {
            // 리플렉션 : 엑스레이를 찍는 것이다...
            // 런타임중에 모든 정보를 뜯어 볼 수 있다.

            Item item = new Item();
            var type = item.GetType();
            var fileds = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                       BindingFlags.Static | BindingFlags.Instance);

            foreach (var VARIABLE in fileds)
            {
                string access = $"protected";
                if (VARIABLE.IsPublic)
                    access = "public";
                else if (VARIABLE.IsPrivate)
                    access = "private";

                var attribute = VARIABLE.GetCustomAttributes();
                Console.WriteLine($"{access} {VARIABLE.FieldType.Name} {VARIABLE.Name}");
            }
        }

        static void LectureError()
        {
            // 예외 처리
            try
            {
                // 0으로 나눌 때
                // 잘못된 메모리를 참조(null, 잘못된 캐스팅)
                // 오버플로우 등

                throw new TestException();

                int a = 10;
                int b = 0;
                int result = a / b;

                // 위에서 에러가 걸리면 그 아래로는 애려오지 않는다
                int c = 0;
            }
            catch (DivideByZeroException e)
            {

            }
            catch (Exception e)
            {

            }
            finally
            {
                // 이 안에서 무조건 실행되어야 하는 것이 있다면 이곳에서
            }
        }

        class TestException : Exception
        {
            // 커스텀 예외도 만들 수 있다.
        }

        delegate Return MyFunc<T, Return>(T item);

        static void LectureLambda()
        {
            // 일회용 함수를 만드는데 사용하는 문법
            _items.Add(new Item() {itemName = "고결한 성녀의 에뮬렛", itemType = ItemType.Amulet, rarity = Rarity.Uncommon});
            _items.Add(new Item() {itemName = "흔한 체인 메일", itemType = ItemType.Armor, rarity = Rarity.Normal});
            _items.Add(new Item() {itemName = "전설의 용사의 대검", itemType = ItemType.Weapon, rarity = Rarity.Rare});

            // 무명함수, 익명 함수
            // 하나하나 함수를 만들어주기는 복잡하고 귀찮아지니 따로 만들지 않고 일회용 함수를 만든다
            Item item = FindItem(delegate(Item _item) { return _item.rarity == Rarity.Rare; });
            
            // 람다식. 윗 줄을 줄인 버전... 입력값 => 반환값
            Item item2 = FindItem((Item _item) => _item.itemType == ItemType.Weapon);
            Console.WriteLine($"레어 아이템 : {item.itemType}. 무기 레어도 : {item2.rarity}");
            
            // delegate를 직접 선언하지 않아도 이미 만들어진 애들이 존재한다
            // 반환 타입이 있을 경우 Func
            // 반환 타입이 없을 경우 Action
        }

        static Item FindItem(ItemSelector selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }

            return null;
        }

        static void LectureEvent()
        {
            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest;
            // 구독 신청

            while (true)
            {
                inputManager.Update();
            }

            inputManager.InputKey -= OnInputTest;
            // 구독 취소
        }

        static void OnInputTest()
        {
            Console.WriteLine("Input Received");
        }

        static void LectureDelegate()
        {
            ButtonPressed(TestDelegate);
            
            // 델리게이트 객체를 만들면 체이닝도 가능하다
            OnClicked clicked = new OnClicked(TestDelegate);
            clicked += TestDelegate2;

            for(int i=0;i<10;i++)
                ButtonPressed(clicked);
        }

        static void ButtonPressed(OnClicked clickedFunction)
        {
            clickedFunction();
        }

        static int TestDelegate()
        {
            int result;
            Random rand = new Random();
            result = rand.Next(0, 11);
            Console.WriteLine($"Delegate 1 : {result}");
            return result;
        }
        
        static int TestDelegate2()
        {
            int result;
            Random rand = new Random();
            result = rand.Next(0, 11);
            Console.WriteLine($"Delegate 2 : {result}");
            return result;
        }

        static void DoAttack(IAttackable attackable)
        {
            attackable.Attack();
        }

        static void TestGeneric()
        {
            MyList<int> myIntList = new MyList<int>();
            YourList<string> myStringList = new YourList<string>();
            EveryList<float> myFloatList = new EveryList<float>();

            int item = myIntList.GetItem(0);
            
            Test<int, string>(3, "Hello World!");
        }

        static void Test<T, K>(T input1, K input2)
        {
            Console.WriteLine(input1);
            Console.WriteLine(input2);
        }
    }
}