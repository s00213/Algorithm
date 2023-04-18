﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._List
{
    public class List1<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int size;

        public List1()
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
            if (size < items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow();
                items[size++] = item;
            }
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
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public void Grow() // Grow로 2배짜리 저장소 만들어줌
        { 
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity]; // newItems의 새로운 배열을 만들어줌
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems; // 이전 배열을 담고 있던 items를 새로운 더 큰 배열 newItems
        }
    }
}
