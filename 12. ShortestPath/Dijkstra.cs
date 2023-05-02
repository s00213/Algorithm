using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    internal class Dijkstra
    {
        /******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 ******************************************************/
        const int INF = 99999; // 오버 플로우 방지를 위해 많이 큰 값으로 넣어줌

        public static void ShortestPath(int[,] graph, in int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size]; // 방문 여부

            distance = new int[size];
            path = new int[size];
            for (int i = 0; i < size; i++) // 가지고 있는 사이즈 만큼
            {
                distance[i] = graph[start, i]; // i번째에 대한 거리는 
                path[i] = graph[start, i] < INF ? start : -1;
            }

            for (int i = 0; i < size; i++) // 가지고 있는 정점 만큼 갱신
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++) // 있는 정점들을 모두 확인
                {
                    if (!visited[j] && // 방문하지 않았으면서
                        distance[j] < minCost) // 동시에 가장 가까운 정점
                    {
                        next = j;
                        minCost = distance[j];
                        // minCost : 가장 작은 정점의 최솟값
                    }
                }
                if (next < 0)
                    break;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신
                for (int j = 0; j < size; j++) // 전체의 정점만큼 반복을 하면서
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j]) // 만약 직접적인 거리가 
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }
    }
}