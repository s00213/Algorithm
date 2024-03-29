﻿using System;
using System.Diagnostics;
using System.Threading;

namespace DataStructure
{
    internal class Program
    {
        /******************************************************
		 * 트리 (Tree)
		 *
		 * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
		 * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없음
		 ******************************************************/

        /******************************************************
        * 이진탐색트리 (BinarySearchTree)
        * 
        * 이진속성과 탐색속성을 적용한 트리
        * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
        * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
        * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치 
        ******************************************************/

        // <이진탐색트리의 시간복잡도>
        // 접근			탐색	★		삽입			삭제
        // O(log n)		O(log n)	O(log n)	O(log n)
        // -> 굉장한 효율을 보여주는 자료 구조이지만,
        // -> 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능한 점 때문에 탐색 용도로만 사용함

        // ★ <이진탐색트리의 주의점> ★
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        // 이러한 현상을 막기 위해 ★자가균형기능★을 추가한 트리의 사용이 일반적
        // -> 좌회전과 우회전을 통해서 불균형 문제를 해결함
        // 대표적인 방식으로 Red-Black Tree(C#), AVL Tree 등이 있음

        // Red-Black Tree(C#)
        // -> 불균형 확인법은 물어보지는 않음
        // 모든 노드는 빨간색 아니면 검은색이다.
        // 루트 노드는 검은색이다.
        // 잎 노드는 검은색이다.
        // 빨간 노드의 자식들은 모두 검은색이다. 하지만 검은색 노드의 자식 이 빨간색 일 필요는 없다.
        // 루트 노드에서 모든 잎 노드 사이에 있는 검은색 노드의 수는 모두 동일하다.

        // <트리기반의 자료구조의 순회>
        // 1. 전위순회 : 노드, 왼쪽, 오른쪽
        // 2. 중위순회 : 왼쪽(작은 값), 노드(중간 값), 오른쪽(큰 값) <- 이진탐색트리의 순회 : 오름차순 정렬
        // 3. 후위순회 : 왼쪽, 오른쪽, 노드
        // -> 트리 기반의 구조는 부모 자식 관계가 있을 뿐 순서 정하기가 어려움
        // -> 그래서 순회를 사용함

        void Test()
        {
            // value 이진탐색트리 -> 정렬이 보장되어 있는 자료 구조
            SortedSet<int> sortedSet = new SortedSet<int>();

            // 추가
            sortedSet.Add(1);
            sortedSet.Add(2);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);

            // 탐색
            int searchValue1;
            sortedSet.TryGetValue(3, out searchValue1); // 탐색시도

            // 삭제
            sortedSet.Remove(3);

            // 탐색용 키, 실제 데이터
            SortedDictionary<string, Monster> sortedDic = new SortedDictionary<string, Monster>();

            sortedDic.Add("피카츄", new Monster() { name = "피카츄", hp = 100 });
            sortedDic.Add("파이리", new Monster() { name = "파이리", hp = 120 });
            sortedDic.Add("꼬부기", new Monster() { name = "피카츄", hp = 80 });
            sortedDic.Add("리아코", new Monster() { name = "피카츄", hp = 110 });
            sortedDic.Add("이상해씨", new Monster() { name = "피카츄", hp = 130 });

            Monster monster;
            sortedDic.TryGetValue("파이리", out monster); // 파이리 탐색 시도
            Monster indexerMonster = sortedDic["파이리"]; // 인덱서를 통한 탐색

            sortedDic.Remove("리아코");

            // 이진탐색 검색효율
            int[] array = new int[10000000];
            SortedSet<int> set = new SortedSet<int>();

            Random random = new Random();
            int rand;
            for (int i = 0; i < 1000000; i++)
            {
                rand = random.Next();
                array[i] = rand;
                set.Add(rand);
            }
            array[9999999] = -1;
            set.Add(-1);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Array.Find(array, (x) => x == -1);
            stopwatch.Stop();
            Console.WriteLine("배열 time : {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            int value;
            set.TryGetValue(-1, out value);
            stopwatch.Stop();
            Console.WriteLine("트리 time : {0}", stopwatch.ElapsedTicks);
        }

        internal class Monster
        {
            public string name;
            public int hp;
        }

        static void Main(string[] args)
        {
            DataStructure.BinarySearchTree<int> bst = new DataStructure.BinarySearchTree<int>();

            bst.Add(3);
            bst.Add(1);
            bst.Add(5);
            bst.Add(4);
            bst.Add(9);
            bst.Add(7);
            bst.Add(6);
            bst.Add(2);

            bst.Print();
        }       
    }
}