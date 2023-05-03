using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{
	// f = g + h / 총거리
	// g = 걸린 거리
	// h = 예상거리
	// 대각선은 14, 한 칸은 10
	// 대각선 : 10 * 루트 2 삼각함수(1.4 정도)
	// 휴리스틱
	// 맨허튼 거리, 유클리드 거리
	internal class AStar
	{

		/******************************************************
		* A* 알고리즘 -> 포트폴리오에 적용
		* 
		* 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		* 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		* 1. f 값 가장 작은 정점
		* 2. 탐색한 정점 f 값
		******************************************************/

		const int CostStraight = 10;
		const int CostDiagonal = 14;

		// 4. AStar 탐색을 진행
		// 방향 탐색
		// 상
		// 하
		// 좌
		// 우 -> 똑같은 내용 반복하게 됨 -> Direction반복으로 처리
		static Point[] Direction =
		{
			new Point(  0, +1 ),			// 상
			new Point(  0, -1 ),			// 하
			new Point( -1,  0 ),			// 좌
			new Point( +1,  0 ),			// 우
			// new Point( -1, +1 ),		    // 좌상
			// new Point( -1, -1 ),		    // 좌하
			// new Point( +1, +1 ),		    // 우상
			// new Point( +1, -1 )		    // 우하
		};

		public static bool PathFinding(bool[,] tilemap, Point start, Point end, out List<Point> path)
		{
			// 초기화
			int ySize = tilemap.GetLength(0);
			int xSize = tilemap.GetLength(1);
			bool[,] visited = new bool[ySize, xSize]; // 방문 여부 2차원배열
			ASNode[,] nodes = new ASNode[ySize, xSize];
			PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

			// 0. 시작 정점을 생성하여 추가
			ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
			nodes[startNode.point.y, startNode.point.x] = startNode;
			nextPointPQ.Enqueue(startNode, startNode.f); // 우선순위 큐에 추가

			while (nextPointPQ.Count > 0)
			{
				// 1. 다음으로 탐색할 정점 꺼내기
				ASNode nextNode = nextPointPQ.Dequeue();

				// 2. 방문한 정점은 방문표시
				visited[nextNode.point.y, nextNode.point.x] = true;

				// 3. 탐색할 정점일 도착지인 경우
				// 도착했다고 판단해서 경로 반환
				if (nextNode.point.x == end.x && nextNode.point.y == end.y)
				{
					Point? pathPoint = end;
					path = new List<Point>();

					while (pathPoint != null)
					{
						Point point = pathPoint.GetValueOrDefault(); //  null이 아닌 경우엔 default를 넣어줌
						path.Add(point);
						pathPoint = nodes[point.y, point.x].parent; // 다음 정점의 위치는 해당 정점의 부모로 감
					}

					path.Reverse(); // Reverse를 통해서 반대로 해줘야지 함
					return true; // 경로를 찾은 경우
				}

				// 4. AStar 탐색을 진행
				// 방향 탐색
				// 상
				// 하
				// 좌
				// 우 -> 똑같은 내용 반복하게 됨 -> Direction으로 반복으로 처리
				for (int i = 0; i < Direction.Length; i++)
				{
					int x = nextNode.point.x + Direction[i].x;
					int y = nextNode.point.y + Direction[i].y;

					// 4-1. 탐색하면 안되는 경우
					// 맵을 벗어났을 경우
					if (x < 0 || x >= xSize || y < 0 || y >= ySize)
						continue;
					// 탐색할 수 없는 정점일 경우
					else if (tilemap[y, x] == false)
						continue;
					// 이미 방문한 정점일 경우
					else if (visited[y, x])
						continue;

					// 4-2. 탐색한 정점 만들기
					// f 값을 결정해주는 행위
					int g = nextNode.g + 10;
					int h = Heuristic(new Point(x, y), end);
					ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

					// 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
					if (nodes[y, x] == null ||      // 점수가 없거나
						nodes[y, x].f > newNode.f)  // 가중치가 더 높은 정점인 경우
					{
						nodes[y, x] = newNode;
						nextPointPQ.Enqueue(newNode, newNode.f); // 다음으로 탐색해야하는 정점
					}
				}
			}

			path = null; // 경로가 없고
			return false; // 경로를 못 찾았음
		}

		// 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
		private static int Heuristic(Point start, Point end)
		{
			int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
			int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

			// 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
			// return CostStraight * (xSize + ySize);

			// 유클리드 거리 : 대각선을 통해 이동하는 거리
			return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
		}

		private class ASNode
		{
			public Point point;     // 현재 정점
			public Point? parent;   // 이 정점을 탐색한 정점

			public int f;   // f(x) = g(x) + h(x);
			public int g;   // 현재까지의 값, 즉 지금까지 경로 가중치
			public int h;   // 휴리스틱 : 앞으로 예상되는 값, 목표까지 추정 경로 가중치

			public ASNode(Point point, Point? parent, int g, int h)
			{
				this.point = point;
				this.parent = parent;
				this.g = g;
				this.h = h;
				this.f = g + h;
			}
		}
	}

	public struct Point
	{ 
		public int x;
		public int y;

		public Point(int x, int y)
		{ 
			this.x = x; 
			this.y = y;
		}
	}
}
