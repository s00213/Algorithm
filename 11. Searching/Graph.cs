﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{
    internal class Graph
    {
        /******************************************************
        * 그래프 (Graph)
        * 
        * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
        * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
        * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
        * 간선의 가중치에 따라 연결 그래프, 가중치 그래프가 있음
        ******************************************************/

        // <인접행렬 그래프>
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 [출발정점, 도착정점] 으로 표현
        // 장점 : 인접여부 접근이 빠름 
        // 단점 : 메모리 사용량이 많음 
        
        // 예시 - 양방향 연결 그래프 => 대칭성이 있음
        bool[,] matrixGraph1 = new bool[5, 5]
        { //  [0,0]  [0,1]   [0,3]  [0,4]  [0,5]
            { false, true,  true,  true,  true },
            { true, false,  true, false,  true },
            { true,  true, false, false, false },
            { true, false, false, false,  true },
            { true,  true, false,  true, false },
        };

        const int INF = int.MaxValue;
        // INF 무한
        // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현) => 대칭성이 없음
        int[,] matrixGraph2 = new int[5, 5]
        {
            {   0, 132, INF, INF,  16 },
            {  12,   0, INF, INF, INF },
            { INF,  38,   0, INF, INF },
            { INF,  12, INF,   0,  54 },
            { INF, INF, INF, INF,   0 },
        };


        // <인접 리스트 그래프>
        // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트 O(N)

        // 인접한 간선만을 리스트에 추가하여 관리 O(N)
        // 장점 : 메모리 사용량이 적음
        // 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요 

        // 예시
        List<List<int>> listGraph1;             // 연결 그래프
        List<List<(int, int)>> listGraph2;      // 가중치 그래프
        public void CreateGraph()
        {
            listGraph1 = new List<List<int>>();

            for (int i = 0; i < 5; i++)
                listGraph1.Add(new List<int>());

            listGraph1[0].Add(1);
            listGraph1[1].Add(0);
            listGraph1[1].Add(3);
            listGraph1[2].Add(0);
            listGraph1[2].Add(1);
            listGraph1[2].Add(4);
            listGraph1[3].Add(1);
            listGraph1[4].Add(3);
        }
    }
}
