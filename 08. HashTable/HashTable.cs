using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 똑같은지 비교할 수 있는 인터페이스 사용하여 제약조건을 걸어둠
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey> 
    {
        // DefaultCapacity 값을 최대로 지정
        private const int DefaultCapacity = 1000; 

        // 데이터를 저장할 땐 키값과 데이터 둘 다 저장하면 여러 용도로 사용가능함
        private struct Entry
        {
            public enum State { None, Using, Delected }

            public int hashCode;
            public State state;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;

        public Dictionary()
        {
            // table을 새로운 크기로 만들어좀
            table = new Entry[DefaultCapacity];
        }

        public TValue this[TKey key]
        {
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. key가 일치하는 데이터가 나올 때까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3-1. 동일한 키값을 찾았을 떄 반환하기
                    if (key.Equals(table[index].key))
                    {
                        return table[index].value;
                    }
                    // 3-2. 동일한 키값을 못 찾고 비어있느 공간을 만났을 때
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }

                    // 3-3. 다음 index로 이동
                    index = index % table.Length;                   
                }

                throw new KeyNotFoundException();
            }
            set            
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. key가 일치하는 데이터가 나올 떄까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3. 동일한 키값을 찾았을 때 덮어쓰기
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                        return ;
                    }
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }

                    index = index < table.Length - 1 ? index + 1 : 0;
                }

                throw new InvalidOperationException();
            }
        }

        // 추가
        public void Add(TKey key, TValue value)
        {
            // 1. key를 index로 해싱
            // 나눗셈 법 또는 자릿수 접기로 해싱하는데 C#은 GetHashCode로 변환
            // GetHashCode는 램덤 방지를 위해 SHA-1 방식을 사용함 
            int index = Math.Abs(key.GetHashCode() % table.Length); // 테이블 크기로 나머지 연산, 음수 나올 수 있기 때문에 절대값으로 계산

            // 2. 사용중이 아닌 index까지다음으로 이동
            while (table[index].state == Entry.State.Using)  // 그 위치가 이미 사용중이었음 -> 충돌
            {
                // 3-1. 동일한 키값을 찾았을 때 오류 
                // C# Dictionary는 중복 키를 허용하지 않음
                if (key.Equals(table[index].key))
                {
                    throw new ArgumentException();
                }

                // 3-2. 다음 index로 이동
                index = index < table.Length -1 ? index +1 : 0;              
            }

            // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 저장
            table[index].hashCode = key.GetHashCode();
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }

        // 삭제
        public bool Remove(TKey key)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. key값과 동일한데이터를 찾을 때까지 index 증가
            while (table[index].state == Entry.State.Using)
            {
                // 3-1. 동일한 키 값을 찾았을 때 지운 상태로 표시
                if (key.Equals(table[index].key))
                {
                    table[index].state = Entry.State.Delected;
                    return true;
                }
                // 3-2. 동일한 키값을 못찾고 비어있는 공간을 만났을 때
                if (table[index].state == Entry.State.None)
                {
                    break;
                }

                // 3-3. 다음으로 이동
                index = ++index % table.Length;
            }

            return false;
        }
    }
}
