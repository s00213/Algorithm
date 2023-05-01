using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{
    public class Search
    {
        // 선형
        // <순차 탐색> // 자료가 정렬 아니여도 탐색 가능
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IEquatable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }

        // 선형
        // <이진 탐색> // 자료가 정렬 아니면 탐색 불가능
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            return BinarySearch(list, item, 0, list.Count);
        }

        public static int BinarySearch<T>(in IList<T> list, in T item, int index, int count) where T : IComparable<T>
        {
            if (index < 0)
                throw new IndexOutOfRangeException();
            if (count < 0)
                throw new ArgumentOutOfRangeException();
            if (index + count > list.Count)
                throw new ArgumentOutOfRangeException();

            int low = index;
            int high = index + count - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2; // 중간 위치
                int compare = list[middle].CompareTo(item);

                if (compare < 0)
                    low = middle + 1; // 찾고자 하는 값이 더 큰 쪽에 있음
                else if (compare > 0)
                    high = middle - 1; 
                else // 비교를 했는데 똑같음
                    return middle;
            }
            return -1;
        }

        // <깊이 우선 탐색 (Depth-First Search) DFS>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        // 백트래킹(분할정복)
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] path)
        {
            visited = new bool[graph.GetLength(0)];
            path = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false; // 하나도 안 방문한 것
                path[i] = -1; // 경로가 없음
            }

            SearchNode(graph, start, visited, path);
        }
        
        // 분할정복용 함수
        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] path)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++) // 전체 정점들을 순회하면서
            {
                if (graph[start, i] &&      // 연결되어 있는 정점이며,
                    !visited[i])            // 방문한적 없는 정점
                {
                    path[i] = start;
                    SearchNode(graph, i, visited, path);
                }
            }
        }


        // <너비 우선 탐색 (Breadth-First Search) BFS>
        // 그래프의 분기를 만났을 때 모든 분기를 하나씩 저장한 뒤,
        // 저장한 분기를 한 번씩 거치면서 탐색
        // 균등하게 한 칸씩 다 가 봄
        // Queue 구조로 탐색

        public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0) // Queue가 빌 때까지
            {
                int next = bfsQueue.Dequeue(); // 다음으로 탐색할 지점
                visited[next] = true; // 방문함

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] &&       // 연결되어 있는 정점이며,
                        !visited[i])            // 방문한적 없는 정점
                    {
                        parents[i] = next;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}