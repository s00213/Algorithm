using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
	public class Dragon : Monster
	{
		private Random random = new Random();
		private int moveTurn = 0;

		public Dragon()
		{
			name = "드래곤";
			curHp = 100;
			maxHp = 100;
			ap = 15;
			dp = 10;

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("####################");
			sb.AppendLine("#                  #");
			sb.AppendLine("#  (엄청난 드래곤)  #");
			sb.AppendLine("#  (텍스트 이미지)  #");
			sb.AppendLine("#                  #");
			sb.AppendLine("####################");
			image = sb.ToString();
		}

		public override void MoveAction()
		{
			if (moveTurn++ < 3)
			{
				return;
			}
			moveTurn = 0;

			List<Position> path;
			if (!PathFinding(in Data.map, pos, Data.player.pos, out path))
				return;

			if (path[1].x == pos.x)
			{
				if (path[1].y == pos.y - 1)
					TryMove(Direction.Up);
				else
					TryMove(Direction.Down);
			}
			else
			{
				if (path[1].x == pos.x - 1)
					TryMove(Direction.Left);
				else
					TryMove(Direction.Right);
			}
		}

		private bool PathFinding(in bool[,] map, Position pos1, object pos2, out List<Position> path)
		{
			throw new NotImplementedException();
		}
	}
}
