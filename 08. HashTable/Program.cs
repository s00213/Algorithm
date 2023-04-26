namespace _08._HashTable
{
    internal class Program
    {
        /******************************************************
		 * 해시테이블 (HashTable)
		 * 
		 * 키 값을 해시함수로 해싱하여 해시테이블의 특정 위치로 직접 엑세스하도록 만든 방식
		 * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
		 ******************************************************/

        // * 해싱(Hashing) : 해시 테이블을 이용한 탐색
        // -> 원본데이터를 해시 함수로 테이블 내의 주소값으로 데이터를 저장함

        // <해시테이블의 시간복잡도>
        // 접근			탐색			삽입			삭제
        // X			O(1)		O(1)		O(1)

        // <해시함수의 조건>
        // 입력에 대한 해시함수의 결과가 항상 동일한 값이여야 한다.

        // <해시함수의 효율>
        // 1. 해시함수 자체가 느린 경우 의미가 없음.
        // 2. 해시함수의 결과의 밀집도가 낮아야 함.
        // 3. 해시테이블의 크기가 클수록 효율이 높다. 

        // <해시테이블 주의점 - 충돌>
        // 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
        // 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
        // 대표적인 충돌 해결방안으로 체이닝과 개방주소법이 있음

        // <충돌해결방안 - 체이닝(Chaining) -> 닫힌주소법>
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // -> 충돌이 발생하면 각 데이터를 해당 주소에 있는 링크드 리스트에 삽입하여 문제를 해결하는 기법
        // 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요 -> 노드

        // <충돌해결방안 - 개방주소법(Open Addressing)>
        // -> C#에서 사용함
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
        // 해시 충돌 시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제 시 오버헤드가 적음
        // 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음
        // 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱 과정을 진행함
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱해서 제자리로 넣어줌

        void Dictionary() // Dictionary : 대규모 저장소
        {
            Dictionary<string, Item> ditionany = new Dictionary<string, Item>();

            // 추가
            ditionany.Add("초기아이템", new Item("초보자용 검", 10));
            ditionany.Add("초기방어구", new Item("초보자용 가죽갑옷", 30));
            ditionany.Add("전직아이템", new Item("푸른결정", 1));
            ditionany.Add("슬라임조각", new Item("슬라임조각", 3));
            ditionany.Add("하얀검", new Item("실버소드", 3));

            // ditionany.Add("초기아이템", new Item("초보 나무 망치", 20)); 이게 아니라
            ditionany["초기아이템"] = new Item("초보 나무 망치", 20); // 바꿔주기

            // 탐색
            // -> 키값은 인덱서를 통해 접근
            Console.WriteLine(ditionany["초기아이템"]); 

            // 접근
            ditionany.Remove("전직아이템");

            // 확인
            if (ditionany.ContainsKey("초기아이템"))
            {
                Console.WriteLine("딕셔너리에 초기아이템이 있음");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public class Item
        {
            public string name;
            public int weight;

            public Item(string name, int weight)
            {
                this.name = name;
                this.weight = weight;
            }
        }
    }
}