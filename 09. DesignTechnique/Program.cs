using System.Security.Cryptography.X509Certificates;

namespace _09._DesignTechnique
{
    internal class Program
    {
        /******************************************************
		 * 알고리즘 설계기법 (Algorithm Design Technique)
		 * 
		 * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
		 * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
		 * 문제의 성질과 조건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용
		 ******************************************************/
        // 분할정복 : 하노이탑
        
        public static void Move(int count, int start, int end)
        {
            if (count == 1) 
            {
                // 그냥 이동
                int node = stick[start].Pop();
                stick[end].Push(node);
                Console.WriteLine($"{start} 스틱에서 { end } 스틱으로 { node } 이동");
                return;
            }
            int other = 3 - start - end;

            Move(count - 1, start, other); // Move를 알면 쉬움!
            Move(1, start, end); 
            Move(count - 1, other, end);
        }

        public static Stack<int>[] stick;

        static void Main(string[] args)
        {
            // * 재귀
            //Recursion.Factorial(5);

            // * 분할정복 : 하노이 탑
            //int nodeCount = 7; // 스틱 3개   
            //stick = new Stack<int>[3];
            //for (int i = 0; i < stick.Length; i++)
            //{
            //    stick[i] = new Stack<int>();
            //}
            //for (int i = nodeCount; i > 0; i--) // 0번째 스틱에서 옆으로 옮기기
            //{
            //    stick[0].Push(i);
            //}
            //Move(nodeCount, 0, 2); // 하노이탑 돌리기


            // * 백트래킹 : N개의 퀸 (체스판의 서로 공격할 수 없는 퀸 N개 놓기)
            //Backtracking backtracking = new Backtracking();
            //bool[,] board = new bool[4, 4];
            //backtracking.Equals(board);

            // * 시분할 시스템
        }
    }
}