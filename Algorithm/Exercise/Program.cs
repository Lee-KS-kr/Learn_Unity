using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }

        public int CompareTo(Knight other)
        {
            // if (ReferenceEquals(this, other)) return 0;
            // if (ReferenceEquals(null, other)) return 1;
            // return Id.CompareTo(other.Id);
            if (Id == other.Id)
                return 0;
            return Id > other.Id ? 1 : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Graph graph = new Graph();
            // graph.DFSArray(0);
            // graph.DFSList(0);
            // graph.BFSArray(0);
            // graph.Dijikstra(0);

            /*TreeNode<string> root = MakeTree();
            PrintTree(root);
            Console.WriteLine(GetHeight(root));*/

            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight() {Id = 20});
            q.Push(new Knight() {Id = 15});
            q.Push(new Knight() {Id = 37});
            q.Push(new Knight() {Id = 92});
            q.Push(new Knight() {Id = 64});
            q.Push(new Knight() {Id = 48});

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop().Id);
            }
        }

        // 트리 구현 예제
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() {Data = "R1 개발실"};
            {
                {
                    TreeNode<string> node = new TreeNode<string>() {Data = "디자인팀"};
                    node.Children.Add(new TreeNode<string>() {Data = "전투"});
                    node.Children.Add(new TreeNode<string>() {Data = "경제"});
                    node.Children.Add(new TreeNode<string>() {Data = "스토리"});
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() {Data = "프로그래밍팀"};
                    node.Children.Add(new TreeNode<string>() {Data = "서버"});
                    node.Children.Add(new TreeNode<string>() {Data = "클라이언트"});
                    node.Children.Add(new TreeNode<string>() {Data = "엔진"});
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() {Data = "아트팀"};
                    node.Children.Add(new TreeNode<string>() {Data = "배경"});
                    node.Children.Add(new TreeNode<string>() {Data = "캐릭터"});
                    root.Children.Add(node);
                }
            }

            return root;
        }

        // 트리 순회 예제
        static void PrintTree(TreeNode<string> root)
        {
            Console.WriteLine(root.Data);
            foreach (var child in root.Children)
            {
                PrintTree(child);
            }
        }

        // 트리 높이 예제
        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach (var child in root.Children)
            {
                int newHeight = GetHeight(child) + 1;
                //height = (height < newHeight) ? newHeight : height;
                height = Math.Max(height, newHeight);
            }

            return height;
        }

        // 스택 : LIFO(후입선출 Last In First Out)
        static void LectureStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(101);
            stack.Push(102);
            stack.Push(103);
            stack.Push(104);
            stack.Push(105);

            int data = stack.Count;
            data = stack.Pop();
            data = stack.Peek();
            stack.Clear();
        }

        // 큐 :  FIFO(선입선출 First In First Out)
        static void LectureQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(301);
            queue.Enqueue(302);
            queue.Enqueue(303);
            queue.Enqueue(304);
            queue.Enqueue(305);

            int data = queue.Count;
            data = queue.Dequeue();
            data = queue.Peek();
            queue.Clear();
        }
    }

    // 그래프 구현 연습
    // 그래프 순회 방법
    // DFS(Depth First Search 깊이 우선 탐색) : 들어갈 수 있으면 끝까지 가고, 되돌아오면서 가보지 않은 곳을 간다 -> 다양한 곳에 사용
    // BFS(Breadth First Search 너비 우선 탐색) : 인접한 곳을 대기열에 넣고, 대기열 제일 앞으로 이동한다. 이동한 곳에서 가지 않은 인접한 곳이 있으면 또 대기열에 넣고 이동한다. -> 최단거리(길찾기)에서 주료 사용
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            {-1, 15, -1, 35, -1, -1},
            {15, -1, 05, 10, -1, -1},
            {-1, 05, -1, -1, -1, -1},
            {35, 10, -1, -1, 05, -1},
            {-1, -1, -1, 05, -1, 05},
            {-1, -1, -1, -1, 05, -1}
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() {1, 3},
            new List<int>() {0, 2, 3},
            new List<int>() {1},
            new List<int>() {0, 1, 4},
            new List<int>() {3, 5},
            new List<int>() {4}
        };

        #region DFS 구현 예제

        bool[] isVisitied = new bool[6];

        // 1. 우선 now부터 방문하고
        // 2. now와 연결된 정점들을 하나씩 확인해서 방문하지 않은 곳으로 방문한다
        public void DFSArray(int now)
        {
            Console.WriteLine(now);
            isVisitied[now] = true;

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0) // 지금 위치와 다음 위치가 연결되어 있지 않으면 스킵
                    continue;
                if (isVisitied[next]) // 다음방에 이미 방문했었으면 스킵
                    continue;

                DFSArray(next);
            }
        }

        public void DFSList(int now)
        {
            Console.WriteLine(now);
            isVisitied[now] = true;

            foreach (var next in adj2[now])
            {
                if (isVisitied[next])
                    continue;

                DFSList(next);
            }
        }

        public void SearchAll()
        {
            isVisitied = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if (isVisitied[now] == false)
                    DFSList(now);
            }
        }

        #endregion

        #region BFS 구현 예제

        public void BFSArray(int start)
        {
            bool[] found = new bool[6];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            found[start] = true;

            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0) // 인접하지 않았으면 스킵
                        continue;
                    if (found[next]) // 이미 발견한 곳이라면 스킵
                        continue;

                    queue.Enqueue(next);
                    found[next] = true;
                }
            }
        }

        #endregion

        #region 다익스트라 구현 예제

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;
            ;

            while (true)
            {
                // 제일 좋은 후보를 찾는다(가장 가까이에 있는 후보)

                // 가장 유력한 후보의 거리와 번호를 저장한다
                int closest = Int32.MaxValue;
                int now = -1;
                for (int i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i]) continue;

                    // 아직 예약된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest) continue;

                    // 여태껏 발견한 가장 좋은 후보라는 의미니까 정보를 갱신
                    closest = distance[i];
                    now = i;
                }

                // 다음 후보가 하나도 없다 -> 종료
                if (now == -1)
                    break;

                // 제일 좋은 후보를 찾았으니까 방문한다
                visited[now] = true;

                // 방문한 정점과 인접한 정점들을 조사해서
                // 상황에 따라 발견한 최단거리를 갱신한다
                for (int next = 0; next < 6; next++)
                {
                    // 연결되지 않은 정점 스킵
                    if (adj[now, next] == -1) continue;

                    // 이미 방문한 정점은 스킵
                    if (visited[next]) continue;

                    // 새로 조사된 정점의 최단거리를 계산한다
                    int nextDist = distance[now] + adj[now, next];
                    // 만약 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면 정보를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }

        #endregion
    }

    // 트리 구현 연습
    // 트리는 그래프와는 달리 노드 위주 구현
    // 그래프는 동적인 상황(데이터 변경이 자주 일어나지 않는 상황)이므로 간선 위주의 구현을 하였으나
    // 트리의 경우 삽입, 삭제가 자주 일어나는 상정 하에 구현을 하기 때문에 노드 위주 구현을 한다.
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    // 우선순위 큐 구현 연습
    // 큐는 맞지만 우선순위가 가장 높은 값이 먼저 빠져나온다.
    class PriorityQueue<T> where T : IComparable<T>

    {
        private List<T> _heap = new List<T>();

        public void Push(T data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다
            _heap.Add(data);

            int now = _heap.Count - 1;
            //도장 깨기
            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;
                else
                    (_heap[now], _heap[next]) = (_heap[next], _heap[now]);

                // 이렇게 될까?
                // (_heap[now], _heap[next]) =
                //     (_heap[now] < _heap[next]) ? (_heap[now], _heap[next]) : (_heap[next], _heap[now]);

                now = next;
            }
        }

        public T Pop()
        {
            // 반환할 데이터를 따로 저장
            T ret = _heap[0];

            // 마지막 데이터를 루트로 이동한다
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 역으로 내려가기
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // 왼쪽 오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체한다.
                (_heap[now], _heap[next]) = (_heap[next], _heap[now]);
                // 검사 위치를 이동한다
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }
}