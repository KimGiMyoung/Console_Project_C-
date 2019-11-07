using System;

class Scene_Play : SceneManager
{
	// 플레이 씬 그리기
	// 플레이 씬에서 키보드 입력 업데이트
	// 게임데이터 업데이트

	GameDataManager _gameData;

	// 키 입력 관련 변수
	int _isKeyPosX;
	readonly char _isKey;
	ConsoleKeyInfo _k;

	// 현재 화면 맞는지 변수
	bool _isScene;

	// 틱관련 변수
	DateTime _old;
	long _ticks;
	readonly long _targetTicks;

	public Scene_Play()
	{
		// readonly 변수 설정 및 초기화
		_gameData = new GameDataManager();
		_isKey = '▲';
		_targetTicks = (long)Tick.GetTargetFPSTicks();

		Init();
	}

	private void Init()
	{
		// 초기화 함수
		_isKeyPosX = (int)KEY.KEY_Q;
		_old = DateTime.Now;
		_k = default(ConsoleKeyInfo);
		_isScene = true;
	}

	public void Run()
	{
		Init();
		_gameData.Init();

		while (_isScene)
		{
			long tempTicks = (DateTime.Now - _old).Ticks;
			_old = DateTime.Now;
			_ticks += tempTicks;

			if (_ticks > _targetTicks)
			{
				ScenePlayRender();
				Update();

				Console.SetCursorPosition((int)SCENE_GAME_POS.GAME_SPEED_POS_X, (int)SCENE_GAME_POS.GAME_SPEED_POS_Y);
				Console.WriteLine(Speed.GameSpeed);

				_gameData.Update(_ticks);

				_ticks = 0;

				if (_gameData.IsGameEnd())
				{
					_isScene = false;
				}
			}

		}
		
		CurrentScene(SCENE.SCENE_END);
	}

	private void ScenePlayRender()
	{
		// 게임 화면 배경 그리기
		Console.Clear();
		Console.SetCursorPosition((int)SCENE_GAME_POS.SCENE_GAME_POS_X, (int)SCENE_GAME_POS.SCENE_GAME_POS_Y);
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|  |  |  |  |  |");
		Console.WriteLine("|--------------|");
		Console.WriteLine("|ⓠ|ⓦ|ⓔ|ⓡ|ⓣ|");

		Console.SetCursorPosition(_isKeyPosX, (int)SCENE_GAME_POS.CUR_POS_Y);
		Console.WriteLine(_isKey);
	}

	private void Update()
	{
		// 키 입력 받은거 업데이트
		_k = default(ConsoleKeyInfo);
		Key.K = KEY.KEY_NONE;

		if (Console.KeyAvailable == true)
		{
			_k = Console.ReadKey(true);

			if (_k.Key == ConsoleKey.Q)
			{
				Key.K = KEY.KEY_Q;
				_isKeyPosX = (int)KEY.KEY_Q;
			}
			else if (_k.Key == ConsoleKey.W)
			{
				Key.K = KEY.KEY_W;
				_isKeyPosX = (int)KEY.KEY_W;
			}
			else if (_k.Key == ConsoleKey.E)
			{
				Key.K = KEY.KEY_E;
				_isKeyPosX = (int)KEY.KEY_E;
			}
			else if (_k.Key == ConsoleKey.R)
			{
				Key.K = KEY.KEY_R;
				_isKeyPosX = (int)KEY.KEY_R;
			}
			else if (_k.Key == ConsoleKey.T)
			{
				Key.K = KEY.KEY_T;
				_isKeyPosX = (int)KEY.KEY_T;
			}
			else if (_k.Key == ConsoleKey.Z)
			{
				_isScene = false;
			}
		}
	}
}
