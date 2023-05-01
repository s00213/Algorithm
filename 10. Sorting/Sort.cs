using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Sorting
{
    /* 안정 정렬
    * 중복된 값을 입력 순서와 동일하게 정렬함
    * : 중복된 값을 입력 순서와 동일하게 정렬
    * -> 기존의 다른 요소로 정렬이 된 입력값을 정렬을 할 때 기존의 정렬 형태를 유지한 상태에서 정렬을 한다는 의미와 같음*/

    /* 불안정 정렬
     * : 중복된 값을 입력 순서와 상관없이 무작위로 뒤섞인 상태에서 정렬
     * -> 불안정 정렬의 경우 중복된 값을 입력 순서와 상관없이 무작위로 뒤섞인 상태에서 정렬함*/

    internal class Sort
    {
        /******************************************************
		 * 선형 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n개를 확인하는 정렬
		 * 시간복잡도 : O(N^2)
		 ******************************************************/

        // <선택 정렬(Selection Sort)>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // * 불안정 정렬 알고리즘
        // 최선 시간복잡도 : O(n^)
        // 평균 시간복잡도 : O(n^)
        // 최악 시간복잡도 : O(n^)

        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }
                Swap(list, i, minIndex);
            }
        }

        // <삽입 정렬(Insertion Sort)>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 최선 시간복잡도 : O(n)
        // 평균 시간복잡도 : O(n^)
        // 최악 시간복잡도 : O(n^)

        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int key = list[i];
                int j;
                for (j = i - 1; j >= 0 && key < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = key;
            }
        }

        // <버블 정렬(Bubble Sort)>
        // 서로 인접한 데이터를 비교하여 정렬
        // 최선 시간복잡도 : O(n)
        // 평균 시간복잡도 : O(n^) 
        // 최악 시간복잡도 : O(n^)

        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j - 1] > list[j])
                        Swap(list, j - 1, j);
                }
            }
        }

        /******************************************************
		 * 분할 정복 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체의 1/2를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n/2개를 확인하는 정렬
		 * 시간복잡도 : O(NlogN)
		 ******************************************************/

        // <힙정렬(Heap Sort)>
        // 힙을 이용하여 우선순위가 가장 높은 요소부터 가져와 정렬
        // 불안정 정렬
        public static void HeapSort(IList<int> list)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                pq.Enqueue(list[i], list[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = pq.Dequeue();
            }
        }

        // <병합 정렬 또는 합병 정렬(Merge Sort)>
        // 데이터를 2분할하여 정렬 후 합병
        // 특징 상 큰 데이터를 2분할 시 2분할 된 데이터를 저장할 공간이 필요함
        // -> 다른 정렬과 다르게 메모리에 부담이 되는 정렬임
        // 안정 정렬
        // 최선 시간복잡도 : O(nlogn)
        // 평균 시간복잡도 : O(nlogn)
        // 최악 시간복잡도 : O(nlogn)
        // 메모리 : n

        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return;

            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            Merge(list, left, mid, right);
        }

        public static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            // 왼쪽 List가 먼저 소진 됐을 경우
            if (leftIndex > mid)    
            {
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            // 오른쪽 List가 먼저 소진 됐을 경우
            else
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }
            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left];
            }
        }

        // <퀵 정렬(Quick Sort)>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 메모리에 부담이 적은 정렬임
        // 다만, 최악의 경우(데이터 정렬이 너무 많을 경우)에 정렬 시간이 오래 걸릴 수 있음
        // -> 시간복잡도 : O(n^2)
        // 불안정 정렬
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivotIndex = start;
            int leftIndex = pivotIndex + 1;
            int rightIndex = end;

            // 엇갈릴때까지 반복
            while (leftIndex <= rightIndex) 
            {
                // pivot보다 큰 값을 만날때까지
                while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)
                    leftIndex++;
                while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)
                    rightIndex--;

                // 엇갈리지 않았다면
                if (leftIndex < rightIndex)     
                    Swap(list, leftIndex, rightIndex);
                // 엇갈렸다면
                else
                    Swap(list, pivotIndex, rightIndex);
            }

            QuickSort(list, start, rightIndex - 1);
            QuickSort(list, rightIndex + 1, end);
        }

        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
