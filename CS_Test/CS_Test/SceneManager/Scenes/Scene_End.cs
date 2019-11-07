using System;

class Scene_End : SceneManager
{
	// 시작 화면 그려주기
	// 커서 키 업데이트

	// 종료 화면 x좌표
	readonly int _scenePosX;

	// 커서 키 관련 변수
	readonly char _c;
	int _cPosX;
	int _cPosY;

	// 현재 화면 맞는지 변수
	bool _isScene;

	public Scene_End()
	{
		// readonly 값 설정 및 변수들 초기화
		_scenePosX = (int)SCENE_END_POS.SCENE_END_POS_X;
		_c = '▶';

		Init();
	}

	private void Init()
	{
		// 초기화 함수
		_cPosX = (int)SCENE_END_POS.CUR_POS_X;
		_cPosY = (int)SCENE_END_POS.CUR_POS_Y;
		_isScene = true;
	}

	public void Run()
	{
		Init();

		while (_isScene)
		{
			Console.Clear();
			SceneEndRender();

			var k = Console.ReadKey(true);

			Update(k);
		}

		// 게임 화면 전환
		if(_cPosY == (int)SCENE_END_POS.GAME_RESTART_POS_Y)
		{
			CurrentScene(SCENE.SCENE_START);
		}
	}

	private void Update(ConsoleKeyInfo k)
	{
		// 커서 이동 관련 업데이트
		if (k.Key == ConsoleKey.DownArrow && _cPosY != (int)SCENE_END_POS.GAME_END_POS_Y)
		{
			_cPosY++;
		}
		else if (k.Key == ConsoleKey.UpArrow && _cPosY != (int)SCENE_END_POS.GAME_RESTART_POS_Y)
		{
			_cPosY--;
		}
		else if (k.Key == ConsoleKey.Enter)
		{
			_isScene = false;
		}
	}

	private void SceneEndRender()
	{
		Console.SetCursorPosition(_scenePosX, (int)SCENE_END_POS.GAME_OVER_POS_Y);
		Console.Write("게임 오버");

		Console.SetCursorPosition(_scenePosX, (int)SCENE_END_POS.GAME_RESTART_POS_Y);
		Console.Write("다시 시작");

		Console.SetCursorPosition(_scenePosX, (int)SCENE_END_POS.GAME_END_POS_Y);
		Console.Write("게임 끝내기");

		Console.SetCursorPosition(_cPosX, _cPosY);
		Console.Write(_c);
	}
}
