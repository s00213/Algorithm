using System;
using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _01._List
{
    internal class List<M>
    /* List<T> 클래스
     -> 인덱스로 액세스할 수 있는 강력한 형식의 개체 목록을 나타냅니다. 목록의 검색, 정렬 및 조작에 사용할 수 있는 메서드를 제공함 */
    {
        private const int DefaultCapacity = 4;

        private M[] items;
        private int size;

        public List()
        {
            items = new M[DefaultCapacity];
            size = 0;
        }

        public int Capacity { get { return items.Length; } }
        /* List<T>.Capacity
        -> 크기를 조정하지 않고 내부 데이터 구조가 보유할 수 있는 전체 요소 수를 가져오거나 설정함 */
        public int Count { get { return size; } }
        /* List<T>.Count
        -> List<T>에 포함된 요소 수를 가져옴 */

        public M this[int index]
        /* this 키워드
        -> 클래스 또는 구조체에서 인덱서를 선언 시 사용함 */
        {
            get
            /* get 키워드
            -> 속성 값 또는 인덱서 요소를 반환하는 속성 또는 인덱서의 accessor 메서드를 정의 */
            {
                if (index < 0 || index <= size)
                throw new IndexOutOfRangeException();
                /*IndexOutOfRangeException 클래스
                 -> 잘못된 인덱스가 배열 또는 컬렉션의 멤버에 액세스하거나 버퍼의 특정 위치에서 읽거나 쓰는 데 사용되는 경우 예외가 throw됨 */
                return items[index];
            }
            set
            /* set 키워드
            -> 속성 또는 인덱서 요소에 값을 할당하는 속성 또는 인덱서의 accessor 메서드를 정의 */
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(M item)
        /* List<T>.Add(T) 메서드
        -> 개체를 List<T>의 끝 부분에 추가 */
        {
            if (size >= items.Length)
                Grow();

            items[size++] = item;
        }

        public void Grow() // Grow로 3배짜리 저장소 만들어줌
        {
            int newCapacity = items.Length * 3;
            M[] newItems = new M[newCapacity]; // newItems의 새로운 배열을 만들어줌
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems; // 이전 배열을 담고 있던 items를 새로운 더 큰 배열 newItems
        }

        public M? Find(Predicate<M> match)
        /*List<T>.Find(Predicate<T>) 메서드
         -> 지정된 조건자에 정의된 조건과 일치하는 요소를 검색하고 전체 List<T>에서 처음으로 검색한 요소를 반환함 */
        {
            if (match == null) throw new ArgumentNullException();
            /* ArgumentNullException 클래스
            -> 예외는 메서드가 호출되고 전달된 인수 중 적어도 하나가 이지만 이면 안 되는 경우 에 throw됨 */
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(M);
        }

        public int FindIndex(Predicate<M> match)
        /*FindIndexList<T>.FindIndex 메서드
         -> 지정된 조건자에 정의된 조건과 일치하는 요소를 검색하고 List<T>이나 그 일부에서 처음으로 검색한 요소의 인덱스(0부터 시작)를 반환함 */
        {
            return FindIndex(0, size, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<M> match)
        {
            if (startIndex > size)
                throw new ArgumentOutOfRangeException();
            /*/* ArgumentOutOfRangeException 클래스
            -> 인수 값이 호출된 메서드에서 정의한 값의 허용 범위를 벗어날 때 throw되는 예외 */
            if (count < 0 || startIndex > size - count)
                throw new ArgumentOutOfRangeException();
            if (match == null)
                throw new ArgumentNullException();

            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (match(items[i])) return i;
            }
            return -1;
        }

        public int IndexOf(M item)
        /*List<T>.Index Of 메서드
         -> List<T> 또는 그 일부에서 처음 나타나는 값의 0부터 시작하는 인덱스를 반환함 */
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public bool Remove(M item)
        /* List<T>.Remove(T) 메서드
        -> List<T> 에서 특정 개체의 첫 번째 항목을 제거
        -> public bool Remove (T item); 
        -> 반환형은 bool, 성공적으로 제거된 경우 item; 그렇지 않으면 false. List<T>에서 찾지 못한 false경우에도 반환 */
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        /* List<T>.RemoveAt(Int32) 메서드
        -> List<T>의 지정된 인덱스에 있는 요소를 제거 */
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            size--;
            Array.Copy(items, index + 1, items, index, size - index);
            /* Array.Copy 메서드
             -> 한 Array의 요소 범위를 다른 Array에 복사하고 필요에 따라 형식 캐스팅 및 boxing을 수행 */
        }
    }
}

 