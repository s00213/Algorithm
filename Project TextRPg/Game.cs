using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
	public class Game
	{
		private bool running = true;

		private Scene scene;
		private MainMenuScene mainMenu;
		private MapScene mapScene;
		private InventoryScene inventoryScene;
		private BattleScene battleScene;

		public void Run()
		{
			// 초기화
			Init();

			// 게임루프
			while (running)
			{
				// 랜더링
				Render();
				// 갱신
				Update();

			}

			// 마무리
			Release();
		}

		public void GameStart()
		{
			Data.LoadLevel1();
			scene = mapScene;
		}

		public void GameOver(string text = "")
		{
			Console.Clear();

			StringBuilder sb = new StringBuilder();

			sb.AppendLine();
			sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
			sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
			sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
			sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
			sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
			sb.AppendLine();

			sb.AppendLine();
			sb.Append(text);

			Console.WriteLine(sb.ToString());

			running = false;
		}

		private void Init()
		{
			mainMenu = new MainMenuScene(this);
			mapScene = new MapScene(this);
			inventoryScene = new InventoryScene(this);
			battleScene = new BattleScene(this);

			// 시작하자마자 메인 메뉴로 시작됨
			scene = mainMenu;
		}

		private void Render()
		{
			Console.Clear();
			scene.Render();
		}

		private void Update()
		{
			scene.Update();
		}

		private void Release()
		{
			
		}
		public void Map()
		{
			scene = mapScene;
		}

		public void Battle(Monster monster)
		{
			scene = battleScene;
			battleScene.StartBattle(monster);
		}

		public void Inventory()
		{
			scene = inventoryScene;
		}
	}
}
