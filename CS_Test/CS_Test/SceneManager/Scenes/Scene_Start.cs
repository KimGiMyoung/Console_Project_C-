using System;

class Scene_Start : SceneManager
{
	// 시작 화면 그려주기
	// 커서 키 업데이트

	// 시작 화면 x좌표
	readonly int _scenePosX;

	// 커서 키 관련 변수
	readonly char _c;
	int _cPosX;
	int _cPosY;

	// 현재 화면 맞는지 변수
	bool _isScene;

	public Scene_Start()
	{
		// readonly 값 설정 및 변수들 초기화
		_scenePosX = (int)SCENE_START_POS.SCENE_START_POS_X;
		_c = '▶';

		Init();
	}

	private void Init()
	{
		// 초기화 하는 함수
		_cPosX = (int)SCENE_START_POS.CUR_POS_X;
		_cPosY = (int)SCENE_START_POS.CUR_POS_Y;
		_isScene = true;
	}

	public void Run()
	{
		Init();

		while (_isScene)
		{
			Console.Clear();
			SceneStartRender();

			var k = Console.ReadKey(true);

			Update(k);
		}

		// 게임 화면 전환
		CurrentScene(SCENE.SCENE_PLAY);
	}

	private void Update(ConsoleKeyInfo k)
	{
		// 커서 이동 관련 업데이트
		if (k.Key == ConsoleKey.DownArrow && _cPosY != (int)SCENE_START_POS.GAME_POS_Y)
		{
			_cPosY++;
		}
		else if (k.Key == ConsoleKey.UpArrow && _cPosY != (int)SCENE_START_POS.SONG_POS_Y)
		{
			_cPosY--;
		}
		else if (k.Key == ConsoleKey.LeftArrow || k.Key == ConsoleKey.RightArrow)
		{
			if (_cPosY == (int)SCENE_START_POS.SONG_POS_Y)
			{
				ChangeSong(k);
			}
			else if (_cPosY == (int)SCENE_START_POS.SPEED_POS_Y)
			{
				ChangeSpeed(k);
			}
		}
		else if(_cPosY == (int)SCENE_START_POS.GAME_POS_Y && k.Key == ConsoleKey.Enter)
		{
			_isScene = false;
		}
	}

	private void SceneStartRender()
	{
		Console.SetCursorPosition(_scenePosX, (int)SCENE_START_POS.SONG_POS_Y);
		Console.Write("노래 : ");
		Console.Write(SongKey.SongName[(int)SongKey.GameSongKey]);

		Console.SetCursorPosition(_scenePosX, (int)SCENE_START_POS.SPEED_POS_Y);
		Console.Write("속도 : ");
		Console.Write(Speed.GameSpeed);

		Console.SetCursorPosition(_scenePosX, (int)SCENE_START_POS.GAME_POS_Y);
		Console.Write("시작하기");

		Console.SetCursorPosition(_cPosX, _cPosY);
		Console.Write(_c);
	}

	private void ChangeSong(ConsoleKeyInfo key)
	{
		// 노래 체인지 함수
		if(key.Key == ConsoleKey.LeftArrow)
		{
			if(SongKey.GameSongKey > SONG_KEY.SONG_1)
			{
				SongKey.GameSongKey--;
			}
		}
		else if(key.Key == ConsoleKey.RightArrow)
		{
			if (SongKey.GameSongKey < SONG_KEY.MAX -1)
			{
				SongKey.GameSongKey++;
			}
		}
	}

	private void ChangeSpeed(ConsoleKeyInfo key)
	{
		// 스피드 체인지 함수
		if (key.Key == ConsoleKey.LeftArrow)
		{
			if (Speed.GameSpeed > SPEED.SPEEDx1)
			{
				Speed.GameSpeed--;
			}
		}
		else if (key.Key == ConsoleKey.RightArrow)
		{
			if (Speed.GameSpeed < SPEED.MAX - 1)
			{
				Speed.GameSpeed++;
			}
		}
	}
}
