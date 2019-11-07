using System;

class SongObject
{
	// 노래 오브젝트 클래스(음표)

	// 오브젝트 관련 변수
	bool _isPlay;		// 오브젝트 플레이 중인지 변수
	int _objectposX;	// 오브젝트 x 위치
	float _objectPosY;	// 오브젝트 y 위치
	char _objectC;		// 오브젝트 모양

	readonly float _setObjectTime;

	public SongObject()
	{
		// readonly 설정 및 초기화
		_setObjectTime = Tick.Target;

		Init();
	}

	public bool IsPlay
	{
		get
		{
			return _isPlay;
		}
		set
		{
			_isPlay = value;
		}
	}

	public int PosX
	{
		get
		{
			return _objectposX;
		}
		set
		{
			_objectposX = value;
		}
	}

	public char SetObjectC
	{
		set
		{
			_objectC = value;
		}
	}

	public void Init()
	{
		// 초기화 변수
		IsPlay = false;
		_objectPosY = 0;
	}

	public void Update(float ticks)
	{
		Move(ticks);

		if (IsPlay == true)
		{
			Render();
		}
	}

	private void Move(float ticks)
	{
		_objectPosY += (1 / _setObjectTime) * ((float)Speed.GameSpeed);

		if (_objectPosY >= 17.0f && _objectPosY < 18.0f)
		{
			// 체크 라인에 들어왔는지 확인
			KeyCheck();
		}

		if (_objectPosY >= 18.0f)
		{
			// 체크라인 지나 갔는지 확인
			CrossLine();
		}
	}

	private void Render()
	{
		Console.SetCursorPosition(_objectposX, (int)_objectPosY);
		Console.Write(_objectC);
	}

	private void CrossLine()
	{
		// 라인밖으로 나갔을때 초기화 해주는 함수.
		if (_objectC == SongKey.SongObjectC[0] || _objectC == SongKey.SongObjectC[1] || _objectC == SongKey.SongObjectC[2])
		{
			// 오브젝트가 체크되지 않고 오면 스코어 변경
			Score.Combo = 0;
			Score.Life--;
			Score.State = "bad";
		}

		Init();
	}

	private void KeyCheck()
	{
		// 체크라인에서 오브젝트라인과 키 맞는지 체크하기
		if (_objectposX == (int)Key.K)
		{
			CorrectCheck();
		}
	}

	private void CorrectCheck()
	{
		// 체크라인에서 키가 맞다면 오브젝트 체크하기 및 스코어 올려주는 함수
		Score.Combo++;
		Score.GameScore++;

		// 현재 오브젝트 체크된 오브젝트로 변환 및 오브젝트 효과 적용
		if (_objectC == SongKey.SongObjectC[0])
		{
			_objectC = SongKey.SongObjectC[3];
		}
		else if (_objectC == SongKey.SongObjectC[1])
		{
			_objectC = SongKey.SongObjectC[4];
			if(Speed.GameSpeed != SPEED.SPEEDx1)
			{
				Speed.GameSpeed--;
			}
		}
		else if (_objectC == SongKey.SongObjectC[2])
		{
			_objectC = SongKey.SongObjectC[5];
			if(Speed.GameSpeed != (SPEED.MAX - 1))
			{
				Speed.GameSpeed++;
			}
		}

		// 범위 체크로 정확도 나눠 주기
		if (_objectPosY >= 17.4f && _objectPosY < 17.6f)
		{
			Score.State = "perfect";
		}
		else
		{
			Score.State = "good";
		}
	}
}
