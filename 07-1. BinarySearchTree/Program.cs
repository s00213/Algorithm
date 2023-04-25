﻿namespace _07_1._BinarySearchTree
{
    internal class Program
    {
        // 2. 이진탐색트리의 한계점과 극복방법 조사

        // 한계점 
        // : 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // : 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가

        // 극복방법
        // : 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
        // -> 좌회전과 우회전을 통해서 불균형 문제를 해결함
        // * 우회전 
        // : 왼쪽 자식 노드의 오른족 자식 노드를 부모 노드의 왼쪽 자식으로 연결함
        // * 좌회전
        // : 오른쪽 자식 노드의 왼쪽 자식 노드를 부모 노드의 오른쪽 자식으로 연결함
        // : C#에서 사용하는 대표적인 방식은 Red-Black Tree가 있음
        // * Red-Black Tree 는 아래 규칙을 지키면서 균형을 유지함
        // -1. 모든 노드는 빨간색 아니면 검은색이다.
        // -2. 루트 노드는 검은색이다.
        // -3. 잎 노드는 검은색이다.
        // -4. 빨간 노드의 자식들은 모두 검은색이다. 하지만 검은색 노드의 자식 이 빨간색 일 필요는 없다.
        // -5. 루트 노드에서 모든 잎 노드 사이에 있는 검은색 노드의 수는 모두 동일하다.


        // 3. 이진탐색트리의 순회방법 조사와 순회순서

        // 순회
        // : 규칙에 근거해서 이진 트리 내부를 돌아다니며 효율적이 방법으로 원하는 데이터에 접근할 수 있는 방법

        // * 전위 순회
        // : 노드, 왼쪽, 오른쪽
        // : 이진 트리를 중첩된 괄호로 표현할 수 있음
        // -> 루트부터 시작해서 방문하는 노드의 깊이가 깊어질 때마다 괄호를 한 겹씩 두를 수 있음

        // * 중위 순회
        // : 왼쪽, 노드, 오른쪽
        // -> 이진탐색트리의 순회 : 오름차순 정렬

        // * 후위 순회
        // : 왼쪽, 오른쪽, 노드











        static void Main(string[] args)
        {           
        }
    }
}