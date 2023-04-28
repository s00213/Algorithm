using System;
using System.Text; // StringBuilder를 사용하기 위해서 기재함

namespace CodingTestPractice
{
    class Program
    {
        StringBuilder sb = new StringBuilder();

        static void HanoiTower(int n, int a, int b, int c)
        {
            if (n == 1)
            {
                sb.AppendFormat("{0}{}\n", a, c);
                return;
            }

            HanoiTower(n - 1, a, c, b);
            HanoiTower(1, a, b, c);
            HanoiTower(-1, b, a, c);
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((int)Math.Pow(2, n) - 1);
            HanoiTower(n, 1, 2, 3);

            Console.Write(sb);

        }
    }
}