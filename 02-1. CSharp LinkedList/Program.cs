using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _02_1._CSharp_LinkedList
{
    // 1. LinkedList 구현해보기
    // AddFirst, AddLast,
    // AddBefore, AddAfter,
    // Remove(T value), Remove(node), Find
    // + 주석 추가

    public class Program
    {
        static void Main(string[] args)
        {
            DataStructure.LinkedList<string> linkedList = new DataStructure.LinkedList<string>();

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("0번 뒤데이터");
            linkedList.AddLast("1번 뒤데이터");
            /* Linked List<T>.AddFirst 메서드
            -> LinkedList<T> 의 시작 부분에 새 노드 또는 값을 추가 */

            // 링크드리스트 요소 삭제
            linkedList.Remove("1번 앞데이터");
            /* Linked List<T>.Remove 메서드
            -> LinkedList<T> 에서 노드 또는 값의 첫 번째 항목을 제거 */

            // 링크드리스트 요소 탐색
            DataStructure.LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");
            /* LinkedListNode<T> 클래스
            -> LinkedList<T>의 노드를 나타냅니다. 이 클래스는 상속될 수 없음 */

            // 링크드리스트 노드를 통한 노드 참조
            DataStructure.LinkedListNode<string> prevNode = findNode.Prev;
            DataStructure.LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            /* LinkedList<T>.AddBefore 메서드
            -> LinkedList<T>의 기존 노드 앞에 새 노드 또는 값을 추가 */
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");
            /* LinkedList<T>.AddAfter 메서드
            -> LinkedList<T>의 기존 노드 다음에 새 노드 또는 값을 추가 */

            // 링크드리스트 노드를 통한 삭제
            linkedList.Remove(findNode);
            /* LinkedList<T>.Remove 메서드
            -> LinkedList<T>에서 맨 처음 발견되는 노드 또는 값을 제거 */
        }
    }
    // 2. LinkedList 기술면접 준비

    // . Linked List<T> class
    // : 이중 연결 리스트를 나타냄
    // 노드기반 자료 구조는 가비지컬렉터 때문에 C#에서 거의 안 씀
    // 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
    // -> 삽입, 삭제가 빨라서 유용함
    // 노드는 데이터와 이전/ 다음 노드 객체를 참조하고 있음
    // 노드가 메모리에 연속적으로 배치되지 않고 이전 / 다음노드의 위치를 확인
    // -> 배열 구조가 아니기 때문에 인덱스의 개념이 없음(접근에 있어서는 비효율적임)


    // 0. msdn C# LinkedList 참고해서
    // Contains, FindLast, RemoveFIrst, RemoveLast
}