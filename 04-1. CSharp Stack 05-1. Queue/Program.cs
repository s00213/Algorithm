namespace _04_1._CSharp_Stack_05_1._CSharp_Queue
{
    internal class Program
    {
        // 1. 스택(어댑터), 큐(순환배열) 구현
        // + 주석 꼭 달아줘

        public class AdapterStack<T>
        {
            private List<T> container;

            public AdapterStack()
            {
                container = new List<T>();
            }

            public void Push(T item)
            {
                container.Add(item);
            }

            public T Pop()
            {
                T item = container[container.Count - 1];
                container.RemoveAt(container.Count - 1);
                return item;
            }

            public T Peek()
            {
                return container[container.Count - 1];
            }
        }





        // =========================


        static void Main(string[] args)
        {
            // 2.스택
            // 괄호 검사기 ( ) ( ), ( ( ) ) | ((), )()(
            // 스택 계산기 1+3*7-6



















            // 3. 큐 
            // 속도가 빠른 플레이어부터 행동
            // 요세푸스 순열
        }
    }
}