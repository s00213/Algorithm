using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._BinarySearchTree
{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        // 추가
        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return;
            }
            Node current = root;
            while (current != null)
            {
                // 비교해서 더 작은 경우 왼쪽으로 감
                if (item.CompareTo(current.item) < 0)
                {
                    // 비교 노드가 왼쪽 자식이 있는 경우
                    if (current.left != null)
                    { 
                        // 왼쪽 자식과 또 비교하기 위해 current 왼쪽 자식으로 설정
                        current = current.left;
                    }
                    // 비교 노드가 왼쪽 자식이 없는 경우
                    else 
                    { 
                        // 그 자리가 지금추가가 될 자리
                        current.left = newNode;
                        newNode.parent = current;
                        return;
                    }
                    
                }
                // 비교해서 더 큰 경우 오른쪽으로 감
                else if (item.CompareTo(current.item) > 0)
                {
                    // 비교 노드가 오른쪽 자식이 있는 경우
                    if (current.right != null)
                    {
                        // 오른쪽 자식과 또 비교하기 위해 current 오른쪽 자식으로 설정
                        current = current.right;
                    }
                    // 비교 노드가 오른쪽 자식이 없는 경우
                    else 
                    { 
                        // 그 자리가 지금 추가가 될 자리
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                {
                    // 아무것도 안함
                    return;
                }
            }
        }

        // 제거 
        public bool Remove(T item) 
        { 
            Node findnode = FindNode(item);

            if (findnode == null)
            {
                return false;
            }
            else 
            { 
                ErageNode(findnode);
                return true;
            }
        }

        // 탐색
        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item);

            if (findNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }

        private Node FindNode(T item)
        { 
            if (root == null) // 이진 탐색트리가 비어있는 경우
            {
                return null;
            }

            Node current = root;
            while (current != null)
            {
                // 현재 노드의 값이 찾고자 하는 값보다 작은 경우
                if (item.CompareTo(current.item) < 0)
                {
                    // 왼쪽 자식부터 다시 찾기 시작
                    current = current.left;
                }
                // 현재 노드의 값이 찾고자 하는 값보다 큰 경우
                else if (item.CompareTo(current.item) > 0)
                { 
                    // 오른쪽 자식부터 다시 찾기 시작
                    current = current.right;
                }
                // 현재 노드의 값이 찾고자 하는 값이랑 같은 경우
                else
                {
                    // 찾음
                    return current;
                }
            }           
            // 못 찾음
            return null;
        }

        // 제거 Remove의 ErageNode
        private void ErageNode(Node node)
        {
            // 1. 자식 노드가 없는 노드일 경우
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else // if (node.IsRootNode)
                    root = null;
            }
            // 2. 자식노드가 1개인 노드일 경우
            else if (node.HasLeftChild || node.HasRightChild )
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right;

                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else // if (node.IsRootNode) -> 부모가 없는 node
                {
                    root = child;
                    child.parent = null;
                }
            }
            // 3. 자식 노드가 2개인 경우
            // 왼쪽 자식 중 가장 큰 값과 데이터 교환 후, 그 노드를 지워주는 방식으로 대체
            else // if (node.HasBothChild)
            {
                Node replaceNode = node.left;
                while (replaceNode.right != null)
                { 
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;
                ErageNode(replaceNode);

                /* 또는 
                
                Node replaceNode = node right;
                while (replaceNode.left != null)
                {
                    replaceNode = replaceNode.left;
                }
                node.item = replaceNode.item;
                ErageNode(replaceNode); 
                
                -> 둘 중에 1개 쓰면 됨*/
            }
        }

        public class Node
        {
            internal T item;
            internal Node parent;
            internal Node left;
            internal Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            // 자식이 없을 때
            public bool HasNoChild { get { return left == null && right == null;  } }
            // 왼쪽 자식만 있을 때
            public bool HasLeftChild { get { return left != null && right == null; } }
            // 오른쪽 자식만 있을 떄
            public bool HasRightChild { get { return left == null && right != null; } }
            // 양 쪽 자식이 모두 있을 때
            public bool HasBothChild { get { return left != null && right != null; } }
        }
    }
}
