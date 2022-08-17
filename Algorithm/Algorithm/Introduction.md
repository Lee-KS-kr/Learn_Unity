알고리즘
=

Big O 표기법
-

#__알고리즘의 효율을 측정하려면?__   

##우리가 알고리즘을 연구하는 근본적인 이유?   
기존에 사용하던 로직보다 조금 더 효율적인 코드를 구현하기 위해   
-> 새로 구현한 알고리즘이 기존에 돌아가던 알고리즘보다 더 효율적이라는 것을 객관적으로 입증할 수 있는 것이 필요하다   
-> 해당초 두 알고리즘을 어떻게 비교해야 할까?

* 말로 설명하는 것? 애매모호하다
* 프로그램을 짜서 실행 속도를 비교하는 것? 환경에 의존적이다
* 입력이 적은 구간과 많은 구간에서 성능이 확연하게 차이가 날 경우는?
* 등등등...   

대안으로 Big O 표기법을 사용하기로 한다   
   

###__Big O 표기법 1단계 : 대략적인 계산__   
수행되는 연산(산술, 비교 대입 등)의 개수를 대략적으로 판단   

    public int Add(int N)
    {
        return N + N;
    }
위 코드의 경우 대략적인 연산의 횟수는 1   
  
    public int Add2(int N)
    {
        int sum = 0;

        for(int i = 0; i < N; i++)
            sum += i;

        return sum;
    }
위 코드의 경우 대략적인 연산의 횟수는 N + 1   
###__Big O 표기법 2단계 : 대장만 남긴다__   
* 규칙 1 : 영향력이 가장 큰 대표 항목만 남기고 삭제   
* 규칙 2 : 상수 무시   


    public int Add4(int N)
    {
        int sum = 0;
            for(int i = 0; i < N; i++)
                sum += i;
        
        for(int i = 0; i < 2 * N; i++)
            for(int j = 0; j < 2 * N; j++)
                sum += 1;
        
        sum += 1234567;
        
        return sum;
    }
   
위 코드의 경우   
O(1 + N + 4 * N^2 + 1) = O(4 * N^2) = __O(N^2)__   
*O는 Order Of라고 읽는다*   
> __Big O 표기법의 의미__   
> 왜 이런식으로 생략을 하고 상수도 무시하는 걸까?   
>    
> 이 함수가 정확히 몇 개의 연산을 하느냐가 중요한 개념이 아닌,
> __데이터가 늘어남에 따라 어떤 식으로 연산량이 증가하는가__ 를 알고싶은 것.   
> N의 제곱이 워낙 빠르게 증가하는 함수이기 때문에, 그 외에는 영향이 미미하므로 생략을 하는 것.  

### Big O 표기법의 의의
* 입력 N의 크기에 따라 성능이 영향을 받는 정도를 나타냄   

<img src="https://cooervo.github.io/Algorithms-DataStructures-BigONotation/images/graphs/comparison.svg" width="400px" height="300px"></img>   
사진 출처 : [Github](https://cooervo.github.io/Algorithms-DataStructures-BigONotation/index.html)   

#### 부록 : Log 함수
2^1 = 2   
2^2 = 2 * 2 = 4   
2^3 = 2 * 2 * 2 = 8   
이런 숫자를 조금 더 일반화 하여, a^? = b가 되었다라는 식이 성립하였을 때, ? = loga(b) 이다   
