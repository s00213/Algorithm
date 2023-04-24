namespace _06._Heap
{
    internal class Program
    {
        /******************************************************
		 * 힙 (Heap) -> PriorityQueue(우선순위 큐)는 힙을 사용해서 자료구조를 이용함
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 * 
		 * 비선형 자료
		 * 트리기반 - 부모가 여러 자녀를 가짐
		 * 이진 트리 : 부모가 2개의 자녀를 가짐 -> 힙
		 * 완전 이진 트리 -> 배열로 관리
         * 왼쪽 자식 : index * 2 + 1
         * 오른쪽 자식 : index * 2 + 2
         * 부모 주소 : (index -1 ) / 2 -> 소수점은 버림
         ******************************************************/

		 // 헥사 트리 : 부모가 6개의 자녀를 가짐 
		 // 옥타 트리 : 부모가 8개의 자녀를 가짐
		 

        static void PriorityQueue()
        {
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

            pq.Enqueue("감자", 3);
            pq.Enqueue("양파", 5);
            pq.Enqueue("당근", 1);
            pq.Enqueue("토마토", 2);
            pq.Enqueue("마늘", 4);

            while (pq.Count > 0)
            {
                Console.WriteLine(pq.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
            }

            // acsendingPQ 오름차순
            PriorityQueue<string, int> acsendingPQ = new PriorityQueue<string, int>(); 

            acsendingPQ.Enqueue("감자", 3);
            acsendingPQ.Enqueue("양파", 5);
            acsendingPQ.Enqueue("당근", 1);
            acsendingPQ.Enqueue("토마토", 2);
            acsendingPQ.Enqueue("마늘", 4);

            while (acsendingPQ.Count > 0)
            {
                Console.WriteLine(acsendingPQ.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
            }

            // desendingPQ 내림차순
            PriorityQueue<string, int> desendingPQ 
                = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            desendingPQ.Enqueue("왼쪽", 70);
            desendingPQ.Enqueue("위쪽", 100);
            desendingPQ.Enqueue("오른쪽", 10);
            desendingPQ.Enqueue("아래쪽", 20);

            string nextDir = desendingPQ.Dequeue();
            Console.WriteLine(nextDir);
            desendingPQ.Clear();
        }

        // * 새로운 자식이 생겼을 떄는 일단 가장 뒤에 놓음
        // 힙상태가 깨졌다면,
        // 우선순위를 비교해서 승격시키고 완료된 상태를 보면 힙상태가 됨
        // 승격과정이 어렵다고 하더라도, 전체 자료를 확인하는 것이 아니고
        // 해당 데이터만 승격만 시키면 됨 -> 반절만 비교하면 됨(이분법적임)
        // 속도적인 우위가 확보됨
        // * 삭제 시, 가장 우선순위 자리를 삭제했다면,
        // 가장 아래있던 자료를 부모자리로 올림
        // 올린 자료와 자식 자료 2개를 비교 후 우선순위대로 자리를 내림
        // 계속 자리를 내리다보면 힙상태가 됨

        // 시간복잡도
        // 탐색(가장 우선순위가 높은)  추가       삭제
        // 0(1)                      0(logN)    0(logN)
        // -> 굉장히 시간이 빠름

        static void Main(string[] args)
        {
            PriorityQueue();
        }        
    }
}
