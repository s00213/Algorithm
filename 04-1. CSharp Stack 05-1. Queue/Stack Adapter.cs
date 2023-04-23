using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_1._CSharp_Stack_05_1._Queue
{
    // 1.
    // 스택(어댑터) 구현
    // + 주석 꼭 달아줘
    public class Stack<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array; // 배열을 저장할 멤버 변수
        private int topIndex; // 현재 스택의 가장 위 인덱스를 저장할 멤버 변수

        public Stack()
        {
            array = new T[DefaultCapacity]; // 기본 용량을 갖는 배열을 생성
            topIndex = -1; // 스택이 비어있는 상태로 초기화
        }

        public int Count { get { return topIndex + 1; } } // 현재 스택에 저장된 요소의 개수를 반환하는 속성

        public void Clear()
        {
            array = new T[DefaultCapacity]; // 스택을 초기 용량으로 다시 생성
            topIndex = -1; // 스택이 비어있는 상태로 초기화
        }

        public T Peek()
        {
            if (IsEmpty()) // 스택이 비어있으면 예외를 던짐
                throw new InvalidOperationException();

            return array[topIndex]; // 가장 위에 있는 요소를 반환
        }

        public bool TryPeek(out T result)
        {
            if (IsEmpty())
            {
                result = default(T); // 스택이 비어있으면 기본값을 저장하고 false 반환
                return false;
            }
            else
            {
                result = array[topIndex]; // 가장 위에 있는 요소를 저장하고 true 반환
                return true;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[topIndex--]; // 가장 위에 있는 요소를 반환하고 topIndex를 감소시켜서 스택에서 제거
        }

        public bool TryPop(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }
            else
            {
                result = array[topIndex--]; // 가장 위에 있는 요소를 저장하고 topIndex를 감소시켜서 스택에서 제거, true 반환
                return true;
            }
        }

        public void Push(T item)
        {
            if (IsFull()) // 스택이 가득 차있으면 용량을 늘림
            {
                Grow();
            }
            array[++topIndex] = item; // 가장 위에 새로운 요소를 추가
        }

        private void Grow()
        {
            int newCapacity = array.Length * 2; // 현재 배열의 용량을 두 배로 증가
            T[] newArray = new T[newCapacity]; // 새로운 배열 생성
            Array.Copy(array, 0, newArray, 0, Count); // 기존 배열의 내용을 새 배열로 복사
            array = newArray; // 새 배열을 기존 배열로 대체
        }

        private bool IsEmpty()
        {
            return Count == 0; // 스택이 비어있는지 여부를 반환
        }

        private bool IsFull()
        {
            return Count == array.Length; // 스택이 가득 차있는지 여부를 반환
        }
    }
}
