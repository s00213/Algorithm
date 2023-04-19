﻿namespace _02._LinkedList
{
    internal class Program
    {
        /******************************************************
        * 연결리스트 (Linked List) -> 노드기반 자료 구조는 가비지컬렉터 때문에 C#에서 거의 안 씀
        * 
        * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
        -> 삽입, 삭제가 빨라서 유용함
        * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음
        * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음노드의 위치를 확인
        -> 배열 구조가 아니기 때문에 인덱스의 개념이 없음 (접근에 있어서는 비효율적임)
        ******************************************************/

        // <링크드리스트 사용>
        void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("0번 뒤데이터");
            linkedList.AddLast("1번 뒤데이터");

            // 링크드리스트 요소 삭제
            linkedList.Remove("1번 앞데이터");

            // 링크드리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

            // 링크드리스트 노드를 통한 노드 참조
            LinkedListNode<string> prevNode = findNode.Previous;
            LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 링크드리스트 노드를 통한 삭제
            linkedList.Remove(findNode);
        }

        // <LinkedList의 시간복잡도>
        // 접근		탐색		삽입		삭제 
        // O(n)		O(n)	O(1)	O(1)

        static void Main(string[] args)
        {
            // 강의 듣기!
        }
    }
}