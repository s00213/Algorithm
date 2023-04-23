using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_1._CSharp_Stack_05_1._Queue
{
    // 1.
    // 큐(순환배열) 구현
    // + 주석 꼭 달아줘
    public class Queue<T>
    {
        private const int DefaultCapacity = 4; // 최초 크기

        private T[] array; // 배열
        private int head;  // head 
        private int tail;  // tail 

        public Queue() // 원형배열 컨셉
        {
            array = new T[DefaultCapacity + 1]; // 1개가 더 큰 배열을 만들어줌
            head = 0; // 0부터 시작
            tail = 0; // 0부터시작
        }

        public int Count
        {
            get
            {
                if (head <= tail) // head가 앞에 있을 때
                    return tail - head; // tail - head면 반환
                else // 아닌 경우
                    return tail + (array.Length - head);
            }
        }

        private bool IsEmpty() // 비어있는 상황
        {
            return head == tail; // head와 tail이 같은 위치
        }

        private bool IsFull() // 꽉 차있는 상황
        {
            if (head > tail) // head가 tail보다 클 때
            {
                return head == tail + 1; // head가 tail +1 일 떄 꽉 차있음
            }
            else // 아닌 경우
            {
                return head == 0 && tail == array.Length - 1; // head가 0이면서 동시에 tail이 array.Length - 1만큼의 위치를 가지고 있는 경우
            }                                                 // -1을 하는 이유는 가장 끝에 있음 의미               
        }

        private void Grow()
        {
            int newCapacity = array.Length * 2; // 새로 만드는 배열의 크기는 2배 짜리
            T[] newArray = new T[newCapacity]; // 새로운 배열을 만들었음
            if (head < tail) // tail이 head보다 앞에 있을 때
            {    
                Array.Copy(array, newArray, Count); // 가지고 있는 개수만큼 복사하고
            }
            else // 아닌 경우
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }

            array = newArray;// 새로운 배열 만들어줌
            tail = Count; // tail을 Count 위치로 옮겨줘야 함
            head = 0; // head는 0을 가리키도록 함
        }

        public void Enqueue(T item) // Enqueue : 줄 맨 뒤에 데이터를 넣어줌
        {
            if (IsFull()) // 꽉차있으면                 
            {
                Grow(); // 크기를 키워주고 늘리자
            }
            array[tail] = item; // tail 자리에 item을 넣음
            MoveNext(ref tail); // tail이 끝에 있었으면 맨 앞으로 가야함 // tail이 원본이 바뀌어야 함
        }

        public T Dequeue() // Dequeue : 줄 맨 앞의 데이터를 제거함
        {
            if (IsEmpty()) // 비어있는데 
                throw new InvalidOperationException(); // 꺼내려는 것은 의도한 것이 아님

            T result = array[head]; // head에 있는 데이터를 result에 넣어주고 
            MoveNext(ref head); // head를 다음 칸으로 밀어주고
            return result; // result를 반환함
        }

        public T Peek() // Peek :  줄 맨 앞의 데이터를 읽어옴
        {
            if (IsEmpty()) // 비어있는데 
                throw new InvalidOperationException(); // 꺼내려는 것은 의도한 것이 아님

            return array[head];
        }

        private void MoveNext(ref int index)
        {
            index = (index == array.Length - 1) ? 0 : index + 1; // 만약에 index가 array.Length - 1이면 0으로 가고 아니면 index +1로 감
        }
    }
}