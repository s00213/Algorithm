using System;
using System.Collections.Generic; // List<T> 클래스 사용하려면 기재해야함
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01._List
{
    internal class Program
    {

        /******************************************************
		 * 배열 (Array)
		 * 
		 * ★연속적인 메모리★상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
		 * 초기화때 정한 크기가 소멸까지 유지됨 -> 삽입, 삭제 어려움
		 * 배열의 요소는 ★인덱스★를 사용하여 직접적으로 엑세스 가능
		 ******************************************************/

        // <배열의 사용>
        void Array()
        {
            int[] intArray = new int[100];

            // 인덱스를 통한 접근
            intArray[0] = 10;
            int value = intArray[0];

            /* Array.Length
            ->모든 차원의 Array에서 요소의 총수를 가져옴
            -> public int Length { get; } */
        }

        // <배열의 시간복잡도>
        // 접근		탐색
        // O(1)		O(N)

        // int 배열 20번 째 자료 접근 : 20번 째 자료의 주소 = 배열의 주소 + int의 자료형의 크기 * 19
        // int 배열 100번 째 자료 접근 : 20번 째 자료의 주소 = 배열의 주소 + int의 자료형의 크기 * 99

        // 데이터가 n개 있을 때 탐색
        //public void FindIndex(int[] intArray, int data)
        //{
        //    for (int i = 0; i < intArray.Length; i++)
        //    {
        //        if (intArray[i] == data)
        //            return i;
        //    }
        //    return -1;
        //}

        /******************************************************
		 * 리스트(동적배열) (Dynamic Array) -> 크기가 지정되어 있지 않을 때 사용
		 * 
		 * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
		 * 배열요소의 갯수를 특정할 수 없는 경우 사용
		 ******************************************************/

        // <List의 사용>
        void List()
        {
            List<string> list = new List<string>();

            /* list.Count 
            -> List<T>에 포함된 요소 수를 가져옴
            -> public int Count { get; } */

            /* list.Capacity 
            -> 크기를 조정하지 않고 내부 데이터 구조가 보유할 수 있는 전체 요소 수를 가져오거나 설정
            -> public int Capacity { get; set; } */

            // 배열 요소 삽입
            list.Add("0번 데이터");
            list.Add("1번 데이터");
            list.Add("2번 데이터");

            // 배열 요소 삭제
            list.Remove("1번 데이터");

            // 배열 요소 접근
            list[0] = "데이터0";
            string value = list[0];

            // 배열 요소 탐색
            string? findValue = list.Find(x => x.Contains('2'));
            int findIndex = list.FindIndex(x => x.Contains('0'));
        }

        // <List의 시간복잡도>
        // 접근		탐색		삽입		삭제
        // O(1)		O(n)	O(n)	O(n)


        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");
          
            string value;
            value = list[0];
            value = list[1];
            value = list[2];
            value = list[3];
            value = list[4];

            list[0] = "5번 데이터";
            list[1] = "4번 데이터";
            list[2] = "3번 데이터";
            list[3] = "2번 데이터";
            list[4] = "1번 데이터";

            // list[7] = "a"; // -> error : 7번 데이터가 없음

            list.Remove("3번 데이터");
            list.Remove("2번 데이터");

            string? findValue = list.Find(x => x.Contains('4'));
            int findIndex = list.FindIndex(x => x.Contains('1'));
        }
    }
}