namespace CSharp_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1.리스트 구현 - msdn c# List 참고
            // 인덱서[], Add, Remove, find, findIndex, Count 등
            // + 주석으로 설명

            // -1.

            List<string> fruits = new List<string>();

            // 배열 요소 삽입
            fruits.Add("Apple");
            fruits.Add("Strawberry");
            fruits.Add("Banana");
            fruits.Add("Shine Muscat");
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Kiwi");

            // 배열 요소 접근
            string value;
            value = fruits[0];
            value = fruits[1];
            value = fruits[2];
            value = fruits[3];
            value = fruits[4];
            value = fruits[5];
            value = fruits[6];
            fruits[3] = "Shine Muscat";          

            // 배열 요소 삭제
            fruits.Remove("Mango");
            fruits.Remove("Kiwi");

            // 배열 요소 탐색
            string? findValue = fruits.Find(x => x.Contains('1'));
            int findIndex = fruits.FindIndex(x => x.Contains('4'));
        }


        // 2. 배열, 선형리스트 기술면접 정리

        /* 선형구조
        -> 자료를 순차적으로 나열한 형태
        -> 종류: 배열, 연결 리스트, 스택/큐

        /* 비선형 구조
        -> 하나의 자료 뒤에 다수의 자료가 올 수 있는 형태
        -> 종류: 트리, 그래프

        선형자료구조 : 배열, 동적배열, 연결리스트
              
         /* 배열 (Array)
         int[] intArray = new int[100];
         -> 연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
		 -> 초기화때 정한 크기가 소멸까지 유지됨 -> 삽입, 삭제 어려움
		 -> 열의 요소는 인덱스를 사용하여 직접적으로 엑세스 가능

         /* 동적 배열 (리스트) (Dynamic Array)
         List<string> list = new List<string>(); 
         -> 크기가 지정되어 있지 않을 때 사용
		 -> 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
		 -> 배열요소의 갯수를 특정할 수 없는 경우 사용

         /* 연결 리스트 (LinkedList)
         LinkedList<int> = new LinkedList<int>(); 
         -> 연속되지 않은 공간 사용
         -> 중간 추가 또는 삭제가 가능함
         -> n번째 공간을 바로 찾을 수 없음(임의 접근 Random Access 불가) */


        // 0. 이 외 더 필요한 구현현들 시도
        // Contains, FindLast, CopyTo, ToArray, Clear, Insert 등


    }
}
