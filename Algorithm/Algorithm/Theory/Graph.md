그래프 이론
=

### 그래프의 개념

__현실 세계의 사물이나 추상적인 개념 간의 연결 관계를 표현__   
* 정점(Vertex) : 데이터를 표현(사물, 개념 등)   
* 간선(Edge) : 정점들을 연결하는데 사용   

_그래프 예시_   
<img height="300" src="https://mblogthumb-phinf.pstatic.net/20160604_100/kbs4674_1465044559857m4vcP_PNG/BFS.png?type=w2" width="400"/> </img>   

*그래프의 종류*   
* 그래프 : 각 정점끼리의 관계를 나타낼 수 있다(ex. 소셜 네트워크 관계도)
* 가중치 그래프 : 각 정점끼리의 가중치는 활용하고 싶은 정보를 담을 수 있다(ex. 지하철 노선도)
* 방향 그래프 : 간선에 방향이 있다(ex. 일방 통행이 포함된 도로망)   
등...

### 그래프의 표현
이런 그래프를 어떻게 코드로 표현할 수 있을까?
#### 인스턴스 생성 : LinkedList의 Node처럼 인스턴스를 생성?

<pre><code>void CreateGraph()
{
    List<Vertex> v = new List<Vertex>();
    {
        new Vertex(),
        new Vertex(),
        new Vertex(),
        new Vertex(),
        new Vertex()
    };
    v[0].edges.Add(v[1]);
    v[0].edges.Add(v[2]);
    v[1].edges.Add(v[2]);
    v[2].edges.Add(v[3]);
    v[2].edges.Add(v[4]);
    v[3].edges.Add(v[4]);
} </code></pre>    

#### 리스트를 이용하기 : Vertex 인스턴스 생성 부담을 줄인다
<pre><code>List<int>[] Graph = new List<int>[5]
{
    new List<int> {1, 2, 4},
    new List<int> {0, 2}
    new List<int> {0, 1, 3, 4}
    new List<int> {2, 4}
    new List<int> {0, 2, 3}
} </pre></code>

#### 행렬(2차원 배열)을 이용하기 : 접근 속도를 높이기 위해 행렬을 사용할 수도 있다.
<pre><code>int[,] Graph = new int[5,5]
{
    {0, 1, 1, 0, 1},
    {1, 0, 1, 0, 0},
    {1, 1, 0, 1, 1},
    {0, 0, 1, 0, 1},
    {1, 0, 1, 1, 0}
} </pre></code>

