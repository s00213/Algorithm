using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_1._Iterator
{
    internal class List<T> : IEnumerable<T> // 반복할 수 있는 자료 구조
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int size;

        public List()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return size; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (size >= items.Length)
                Grow();

            items[size++] = item;
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException();

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, size, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex > size)
                throw new ArgumentOutOfRangeException();
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

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        // List 전용 반복기 생성
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list; // 어떤 리스트를 반복하고 있는지
            private int index;
            private T current;

            internal Enumerator(List<T> list) // list에 index를 가져오게함
            {
                this.list = list;
                this.index = 0;
                this.current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current
            {
                get
                {
                    if (index < 0 || index >= list.Count)
                        throw new InvalidOperationException();
                    return Current;
                }
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (index < list.Count)
                {
                    current = list[index++]; //후위연산자 개념으로 0을 준 다음 ++로 구현
                    return true;
                }
                else
                {
                    current = default(T);
                    index = list.Count;
                    return false;
                }
            }

            public void Reset()
            {
                index = 0;
                current = default(T);
            }
        }
    }
}
