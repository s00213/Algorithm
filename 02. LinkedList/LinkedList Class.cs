using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;

        public LinkedListNode(T value) // 생성자
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value) // 생성자
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value) // 생성자
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } } // 프로퍼티로 읽기 전용으로 만들어줌
        public LinkedListNode<T> Prev { get { return prev; } } // 프로퍼티
        public LinkedListNode<T> Next { get { return next; } } // 프로퍼티

        public T Item { get { return item; } set { item = value; } }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            // 예외1 : 노드가 연결리스트에 포함된 노드가 아닌 경우 
            if (node.list == this)
                throw new InvalidOperationException();
            // 예외2 : 노드가 null인 경우
            if (node == null)
                throw new ArgumentException(nameof(node));

            // 1. 새로운 노드 만들기 
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            if (node.prev !=  null)
                node.prev.next = newNode;

            // 3. 갯수 증가
            count++;
            return newNode;
        }

            public LinkedListNode<T> AddFirst(T value)
        {
            // 1. 새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            // 2. 연결 구조 바꾸기
            // 2 - 1.head 노드가 있었을 때, 새로운 노드를 head 노드로 지정
            if (head != null)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            // 2-1. head 노드가 없었을 때 == 연결리스트에 아무것도 없었을 때
            else
            {
                head = newNode;
                tail = newNode;
            }
            return newNode;

            // 3. 갯수 늘리기
            count++;
            return newNode;
        }
        /* Linked List<T>.Remove 메서드
        -> LinkedList<T> 에서 노드 또는 값의 첫 번째 항목을 제거 */ 
        public void Remove(LinkedListNode<T> node)
        {
            // 예외1 : 노드가 연결리스트에 포함된 노드가 아닌 경우 
            if (node.list == this)
                throw new InvalidOperationException();
            // 예외2 : 노드가 null인 경우
            if (node == null)
                throw new ArgumentException(nameof(node));

            // 0. 지웠을 때 head나 tail이 변경되는 경우 적용
            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;

            // 1. 연결구조 바꾸기
            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next = node.prev;

            // 2. 갯수 줄이기
            count--;
        }

        public bool Remove(T value)
        { 
            LinkedListNode<T> findNode = Find(value); // = 찾기
            if (findNode != null)
            {
                Remove(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T>? target = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (value != null)
            {
                while (target != null)
                {
                    if (comparer.Equals(target.Item, value))
                        return target;
                    else
                        target = target.next;
                }
            }
            else
            {
                while (target != null)
                {
                    if (target.Item == null)
                        return target;
                    else
                        target = target.next;
                }
            }
            return null;       
        }
        
    }
}